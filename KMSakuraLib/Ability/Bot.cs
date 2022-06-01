using KMSakuraLib.BotHandlers;
using KMSakuraLib.BotParser;
using KMSakuraLib.Models;
using KMSakuraLib.Session;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mirai.CSharp.Builders;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.HttpApi.Builder;
using Mirai.CSharp.HttpApi.Invoking;
using Mirai.CSharp.HttpApi.Options;
using Mirai.CSharp.HttpApi.Session;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMSakuraLib.Ability;
using Mirai.CSharp.Models;
using System.Threading;
using Mirai.CSharp.Models.ChatMessages;
using System.IO;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using KMSakuraLib.Buliders;
using Mirai.CSharp.HttpApi.Handlers;

namespace KMSakuraLib
{
    public class Bot : IBot
    {
        private static Dictionary<long, IServiceScope> _scopeDic;

        private static IServiceProvider _serviceProvider;

        public static Dictionary<long, Bot> BotsDic;

        private BotConnectConfig _config;

        public Bot()
        {
            if (!Common.InitStatu)
            {
                Common.CommonInit();
                BotsDic = new Dictionary<long, Bot>();
            }
        }

        /// <summary>
        /// 当前BOT绑定的QQ号
        /// </summary>
        public long QQNumber
        {
            get => _config.QQNumber;
        }

        /// <summary>
        /// 会话对象
        /// </summary>
        private MiraiScopedHttpSession _session;

        #region 登录登出方法
        /// <summary>
        /// 创建一个机器人实例
        /// </summary>
        /// <param name="config">连接配置</param>
        public async Task<string> InitBot(BotConnectConfig config)
        {
            if (_serviceProvider == null)//初始化
            {
                IServiceCollection servicesCol = new ServiceCollection();//最初的framework
                Handler[] handlers = CreateAllInstancesOf<Handler>();

                var builder = servicesCol.AddMiraiBaseFramework();
                //var builder = new MiraiHttpFrameworkCustomBuilder(servicesCol);

                foreach (IMiraiMessageHandler typeInstance in handlers)//将所有handler通过Bulider接入framework
                {
                    builder.AddHandler(typeInstance);
                }

                Type[] parserArray = GetAllClass<Parser>();

                var httpBuilder = new MiraiHttpFrameworkCustomBuilder(servicesCol).AddDefaultServices();//通过重写相关方法达到自定义输出格式的目的

                foreach (Type handler in parserArray)
                {
                    httpBuilder.ResolveParser(handler, null);
                }

                _serviceProvider = httpBuilder.
                                    AddInvoker<MiraiHttpMessageHandlerInvoker>().
                                    AddClient<MiraiScopedHttpSession>().Services.
                                    AddLogging().
                                    BuildServiceProvider();

                _scopeDic = new Dictionary<long, IServiceScope>();
            }

            if (_scopeDic.ContainsKey(config.QQNumber))
            {
                return "已有连接实例";
            }

            IServiceScope scope = _serviceProvider.CreateScope();//创建新的作用域
            IServiceProvider provider = scope.ServiceProvider;
            MiraiHttpSessionOptions options = provider.GetRequiredService<IOptionsSnapshot<MiraiHttpSessionOptions>>().Value;//配置当前作用域的连接配置
            options.AuthKey = config.AuthKey;
            options.Host = config.IPAddress;
            options.Port = config.Port;
            IMiraiHttpSession session = provider.GetRequiredService<IMiraiHttpSession>();//获取session

            try
            {
                await session.ConnectAsync(config.QQNumber);
                _scopeDic.Add(config.QQNumber, scope);
                BotsDic.Add(config.QQNumber, this);
                _session = session as MiraiScopedHttpSession;
                Common.RecordLogger.InfoMsg(Common.BotLogName, config.QQNumber.ToString(), $"BOT{config.QQNumber}登录初始化完成");
                if(!Common.BotDic.TryAdd(config.QQNumber, this))//添加实体对象
                {
                    Common.BotDic[config.QQNumber] = this;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "连接成功";
        }

        /// <summary>
        /// 机器人断连方法
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">无此号码时或者断连中出现的异常</exception>
        public bool DisConnect()
        {
            if (!_scopeDic.ContainsKey(QQNumber))
            {
                throw new Exception($"无号码为{QQNumber}的会话");
            }

            try
            {
                IServiceScope scope = _scopeDic[QQNumber];
                IMiraiHttpSession session = scope.ServiceProvider.GetRequiredService<IMiraiHttpSession>();//获取会话

                BotsDic.Remove(QQNumber);
                session.Dispose();//释放会话
                _scopeDic.Remove(QQNumber);//移除关联
                Common.BotDic.TryRemove(QQNumber, out _);//删除已有实体对象
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
        #endregion

        public IMessageChainBuilder GetBuilder()
        {
            if(_session == null)
            {
                return null;
            }
            return _session.GetMessageChainBuilder();
        }

        #region 获取账号消息
        public Task<IFriendInfo[]> GetFriendList(CancellationToken token = default)
        {
            return _session.GetFriendListAsync(token);
        }

        public Task<IGroupInfo[]> GetGroupList(CancellationToken token = default)
        {
            return _session.GetGroupListAsync(token);
        }

        public Task<IGroupMemberInfo[]> GetGroupMemberList(long groupNumber, CancellationToken token = default)
        {
            return _session.GetGroupMemberListAsync(groupNumber, token);
        }

        public Task<IBotProfile> GetBotProfile(CancellationToken token = default)
        {
            return _session.GetBotProfileAsync(token);
        }

        public Task<IFriendProfile> GetFriendProfile(long qqNumber, CancellationToken token = default)
        {
            return _session.GetFriendProfileAsync(qqNumber, token);
        }

        public Task<IGroupMemberProfile> GetGroupMemberProfile(long groupNumber, long qqNumber, CancellationToken token = default)
        {
            return _session.GetGroupMemberProfileAsync(groupNumber, qqNumber, token);
        }
        #endregion

        #region 消息发送与撤回
        public Task<int> SendFriendMessage(long qqNumber, IChatMessage[] chain, int? quoteMsgId, CancellationToken token = default)
        {
            return _session.SendFriendMessageAsync(qqNumber, chain, quoteMsgId, token);
        }

        public Task<int> SendFriendMessage(long qqNumber, IMessageChainBuilder builder, int? quoteMsgId, CancellationToken token = default)
        {
            return _session.SendFriendMessageAsync(qqNumber, builder, quoteMsgId, token);
        }

        public Task<int> SendGroupMessage(long groupNumber, IChatMessage[] chain, int? quoteMsgId, CancellationToken token = default)
        {
            return _session.SendGroupMessageAsync(groupNumber, chain, quoteMsgId, token);
        }

        public Task<int> SendGroupMessage(long groupNumber, IMessageChainBuilder builder, int? quoteMsgId, CancellationToken token = default)
        {
            return _session.SendGroupMessageAsync(groupNumber, builder, quoteMsgId, token);
        }

        public Task<int> SendTempMessage(long qqNumber, long groupNumber, IChatMessage[] chain, int? quoteMsgId, CancellationToken token = default)
        {
            return _session.SendTempMessageAsync(qqNumber, groupNumber, chain, quoteMsgId, token);
        }

        public Task<int> SendTempMessage(long qqNumber, long groupNumber, IMessageChainBuilder builder, int? quoteMsgId, CancellationToken token = default)
        {
            return _session.SendTempMessageAsync(qqNumber, groupNumber, builder, quoteMsgId, token);
        }

        public Task SendNudge(NudgeTarget target, long qqNumber, long? groupNumber = null, CancellationToken token = default)
        {
            return _session.NudgeAsync(target, qqNumber, groupNumber, token);
        }

        public Task RevokeMessage(int messageId, CancellationToken token = default)
        {
            return _session.RevokeMessageAsync(messageId, token);
        }
        #endregion

        #region 文件操作
        public Task<IGroupFileInfo[]> GetFilelist(long groupNumber, string id, int offset, int size, bool fetchDownloadInfo = false, CancellationToken token = default)
        {
            return _session.GetFilelistAsync(groupNumber, id, fetchDownloadInfo, offset, size, token);
        }

        public Task<IGroupFileInfo> GetFileInfo(long groupNumber, string id, bool fetchDownloadInfo, CancellationToken token = default)
        {
            return _session.GetFileInfoAsync(groupNumber, id, fetchDownloadInfo, token);
        }

        public Task CreateDirectory(long groupNumber, string id, string directoryName, CancellationToken token = default)
        {
            return _session.CreateDirectoryAsync(groupNumber, id, directoryName, token);
        }

        public Task DeleteFile(long groupNumber, string id, CancellationToken token = default)
        {
            return _session.DeleteFileAsync(groupNumber, id, token);
        }

        public Task MoveFile(long groupNumber, string srcId, string dstId, CancellationToken token = default)
        {
            return _session.MoveFileAsync(groupNumber, srcId, dstId, token);
        }

        public Task RenameFile(long groupNumber, string id, string renameTo, CancellationToken token = default)
        {
            return _session.RenameFileAsync(groupNumber, id, renameTo, token);
        }

        #endregion

        #region 账号管理
        public Task DeleteFriend(long qqNumber, CancellationToken token = default)
        {
            return _session.DeleteFriendAsync(qqNumber, token);
        }
        #endregion

        #region 群管理
        public Task Mute(long memberId, long groupNumber, int muteTime, CancellationToken token = default)
        {
            TimeSpan muteTimeSpan = new DateTime(1970, 1, 1, 0, 0, 0).AddMinutes(Convert.ToDouble(muteTime)) - new DateTime(1970, 1, 1, 0, 0, 0);
            return _session.MuteAsync(memberId, groupNumber, muteTimeSpan, token);
        }

        public Task Unmute(long memberId, long groupNumber, CancellationToken token = default)
        {
            return _session.UnmuteAsync(memberId, groupNumber, token);
        }

        public Task KickMember(long memberId, long groupNumber, string msg = "", CancellationToken token = default)
        {
            return _session.KickMemberAsync(memberId, groupNumber, msg, token);
        }

        public Task LeaveGroup(long groupNumber, CancellationToken token = default)
        {
            return _session.LeaveGroupAsync(groupNumber, token);
        }

        public Task UnmuteAll(long groupNumber, CancellationToken token = default)
        {
            return _session.UnmuteAllAsync(groupNumber, token);
        }

        public Task MuteAll(long groupNumber, CancellationToken token = default)
        {
            return _session.MuteAllAsync(groupNumber, token);
        }

        public Task SetEssenceMessage(int id, CancellationToken token = default)
        {
            return _session.SetEssenceMessageAsync(id, token);
        }

        public Task<IGroupConfig> GetGroupConfig(long groupNumber, CancellationToken token = default)
        {
            return _session.GetGroupConfigAsync(groupNumber, token);
        }

        public Task ChangeGroupConfig(long groupNumber, IGroupConfig config, CancellationToken token = default)
        {
            return _session.ChangeGroupConfigAsync(groupNumber, config, token);
        }

        public Task<IGroupMemberInfo> GetGroupMemberInfo(long memberId, long groupNumber, CancellationToken token = default)
        {
            return _session.GetGroupMemberInfoAsync(memberId, groupNumber, token);
        }

        public Task ChangeGroupMemberInfo(long memberId, long groupNumber, IGroupMemberCardInfo info, CancellationToken token = default)
        {
            return _session.ChangeGroupMemberInfoAsync(memberId, groupNumber, info, token);
        }

        public Task SetGroupAdmin(long memberId, long groupNumber, bool assign, CancellationToken token = default)
        {
            return _session.SetGroupAdminAsync(memberId, groupNumber, assign, token);
        }
        #endregion

        #region 申请请求操作
        public Task HandleBotInvitedJoinGroup(IApplyResponseArgs args, GroupApplyActions action, string message = null, CancellationToken token = default)
        {
            return _session.HandleBotInvitedJoinGroupAsync(args, action, message, token);
        }

        public Task HandleGroupApply(IApplyResponseArgs args, GroupApplyActions action, string message = null, CancellationToken token = default)
        {
            return _session.HandleGroupApplyAsync(args, action, message, token);
        }

        public Task HandleNewFriendApply(IApplyResponseArgs args, FriendApplyAction action, string message = null, CancellationToken token = default)
        {
            return _session.HandleNewFriendApplyAsync(args, action, message, token);
        }
        #endregion

        #region 多媒体内容上传
        public Task<IImageMessage> UploadPicture(UploadTarget type, string imagePath, CancellationToken token = default)
        {
            return _session.UploadPictureAsync(type, imagePath, token);
        }

        public Task<IImageMessage> UploadPicture(UploadTarget type, Stream image, CancellationToken token = default)
        {
            return _session.UploadPictureAsync(type, image, token);
        }

        public Task<IVoiceMessage> UploadVoice(UploadTarget type, string voicePath, CancellationToken token = default)
        {
            return _session.UploadVoiceAsync(type, voicePath, token);
        }

        public Task<IVoiceMessage> UploadVoice(UploadTarget type, Stream voice, CancellationToken token = default)
        {
            return _session.UploadVoiceAsync(type, voice, token);
        }

        public Task<IGroupFileInfo> UploadFile(string id, long groupNumber, string path, CancellationToken token = default)
        {
            return _session.UploadFileAsync(groupNumber, id, path, token);
        }

        public Task<IGroupFileInfo> UploadFile(long groupNumber, string? id, string fileName, Stream fileStream, CancellationToken token = default)
        {
            return _session.UploadFileAsync(groupNumber, id, fileName, fileStream, token);
        }

        #endregion

        /// <summary>
        /// 获取所有继承接口的类的实例
        /// </summary>
        /// <param name="parentType">接口类</param>
        /// <returns></returns>
        private static T[] CreateAllInstancesOf<T>()
        {
            return typeof(T).Assembly.GetTypes() //获取当前类库下所有类型
                .Where(t => typeof(T).IsAssignableFrom(t)) //获取间接或直接继承t的所有类型
                .Where(t => !t.IsAbstract && t.IsClass).Select(t => (T)Activator.CreateInstance(t)).ToArray(); //获取非抽象类 排除接口继承
        }

        /// <summary>
        /// 获取所有继承接口的类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static Type[] GetAllClass<T>()
        {
            return typeof(T).Assembly.GetTypes() //获取当前类库下所有类型
                    .Where(t => typeof(T).IsAssignableFrom(t)) //获取间接或直接继承t的所有类型
                    .Where(t => !t.IsAbstract && t.IsClass).ToArray(); //获取非抽象类 排除接口继承
        }
    }
}
