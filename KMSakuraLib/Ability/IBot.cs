using KMSakuraLib.Models;
using System.Threading;
using System.Threading.Tasks;
using Mirai.CSharp.Models;
using Mirai.CSharp.Models.ChatMessages;
using Mirai.CSharp.Builders;
using System.IO;
using System;
using Mirai.CSharp.HttpApi.Models.EventArgs;

namespace KMSakuraLib
{
    public interface IBot
    {
        /// <summary>
        /// 当前BOT绑定的QQ号
        /// </summary>
        long QQNumber { get; }

        IMessageChainBuilder GetBuilder();

        #region 登录登出方法
        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="config">配置文件</param>
        /// <returns></returns>
        Task<string> InitBot(BotConnectConfig config);

        /// <summary>
        /// 机器人断连
        /// </summary>
        /// <returns></returns>
        bool DisConnect();
        #endregion

        #region 获取账号消息
        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IFriendInfo[]> GetFriendList(CancellationToken token = default);

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IGroupInfo[]> GetGroupList(CancellationToken token = default);

        /// <summary>
        /// 获取指定群的群员列表
        /// </summary>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IGroupMemberInfo[]> GetGroupMemberList(long groupNumber, CancellationToken token = default);

        /// <summary>
        /// 获取BOT的资料
        /// </summary>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IBotProfile> GetBotProfile(CancellationToken token = default);

        /// <summary>
        /// 获取指定好友的资料
        /// </summary>
        /// <param name="qqNumber">指定好友的QQ号</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IFriendProfile> GetFriendProfile(long qqNumber, CancellationToken token = default);

        /// <summary>
        /// 获取指定群内特定群员的资料
        /// </summary>
        /// <param name="groupNumber">指定群的号码</param>
        /// <param name="qqNumber">指定群员的QQ号</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IGroupMemberProfile> GetGroupMemberProfile(long groupNumber, long qqNumber, CancellationToken token = default);
        #endregion

        #region 消息发送与撤回
        /// <summary>
        /// 向好友发送消息(自造消息链数组)
        /// </summary>
        /// <param name="qqNumber">好友QQ号</param>
        /// <param name="chain">消息链</param>
        /// <param name="quoteMsgId">引用的消息ID，可为 <see langword="null"/>，代表不需要引用消息</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>用于标识本条消息的 Id</returns>
        Task<int> SendFriendMessage(long qqNumber, IChatMessage[] chain, int? quoteMsgId, CancellationToken token = default);

        /// <summary>
        /// 向好友发送消息（通过<see langword="IMessageChainBuilder"/>创建消息链）
        /// </summary>
        /// <param name="qqNumber">好友QQ号</param>
        /// <param name="builder">包含消息的<see cref="IMessageChainBuilder"/></param>
        /// <param name="quoteMsgId">引用的消息ID，可为 <see langword="null"/>，代表不需要引用消息</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>用于标识本条消息的 Id</returns>
        Task<int> SendFriendMessage(long qqNumber, IMessageChainBuilder builder, int? quoteMsgId, CancellationToken token = default);

        /// <summary>
        /// 向群聊发送消息(自造消息链数组)
        /// </summary>
        /// <param name="groupNumber">QQ群号</param>
        /// <param name="chain">消息链</param>
        /// <param name="quoteMsgId">引用的消息ID，可为 <see langword="null"/>，代表不需要引用消息</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>用于标识本条消息的 Id</returns>
        Task<int> SendGroupMessage(long groupNumber, IChatMessage[] chain, int? quoteMsgId, CancellationToken token = default);

        /// <summary>
        /// 向群聊发送消息（通过<see langword="IMessageChainBuilder"/>创建消息链）
        /// </summary>
        /// <param name="groupNumber">QQ群号</param>
        /// <param name="builder">包含消息的<see cref="IMessageChainBuilder"/></param>
        /// <param name="quoteMsgId">引用的消息ID，可为 <see langword="null"/>，代表不需要引用消息</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>用于标识本条消息的 Id</returns>
        Task<int> SendGroupMessage(long groupNumber, IMessageChainBuilder builder, int? quoteMsgId, CancellationToken token = default);

        /// <summary>
        /// 向群内群员发送临时会话消息(自造消息链数组)
        /// </summary>
        /// <param name="qqNumber">私聊对象的QQ号</param>
        /// <param name="groupNumber">私聊对象所在QQ群群号</param>
        /// <param name="chain">消息链</param>
        /// <param name="quoteMsgId">引用的消息ID，可为 <see langword="null"/>，代表不需要引用消息</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>用于标识本条消息的 Id</returns>
        Task<int> SendTempMessage(long qqNumber, long groupNumber, IChatMessage[] chain, int? quoteMsgId, CancellationToken token = default);

        /// <summary>
        /// 向群内群员发送临时会话消息（通过<see langword="IMessageChainBuilder"/>创建消息链）
        /// </summary>
        /// <param name="qqNumber">私聊对象的QQ号</param>
        /// <param name="groupNumber">私聊对象所在QQ群群号</param>
        /// <param name="chain">消息链</param>
        /// <param name="quoteMsgId">引用的消息ID，可为 <see langword="null"/>，代表不需要引用消息</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>用于标识本条消息的 Id</returns>
        Task<int> SendTempMessage(long qqNumber, long groupNumber, IMessageChainBuilder builder, int? quoteMsgId, CancellationToken token = default);

        /// <summary>
        /// 发送戳一戳消息
        /// </summary>
        /// <param name="target">要戳的对象</param>
        /// <param name="qqNumber">要戳的QQ号 (可以是Bot自己)</param>
        /// <param name="groupNumber">要戳的对象所在的群号 (戳 <see cref="NudgeTarget.Friend"/> / <see cref="NudgeTarget.Stranger"/> 时可以为 <see langword="null"/>)</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task SendNudge(NudgeTarget target, long qqNumber, long? groupNumber = null, CancellationToken token = default);

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="messageId">需要撤回的消息ID</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task RevokeMessage(int messageId, CancellationToken token = default);

        #endregion

        #region 文件操作
        /// <summary>
        /// 异步获取给定群内的文件列表
        /// </summary>
        /// <param name="groupNumber">群号</param>
        /// <param name="id">文件夹Id, 为 <see cref="string.Empty"/> 或 <see langword="null"/> 时将获取根目录</param>
        /// <param name="fetchDownloadInfo">是否获取下载链接,按照官方建议无必要不获取</param>
        /// <param name="offset">分页偏移</param>
        /// <param name="size">分页大小</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/>, 其值为文件列表</returns>
        Task<IGroupFileInfo[]> GetFilelist(long groupNumber, string id, int offset, int size, bool fetchDownloadInfo = false, CancellationToken token = default);

        /// <summary>
        /// 异步获取给定文件信息
        /// <param name="groupNumber">群号</param>
        /// <param name="id">文件夹Id, 为 <see cref="string.Empty"/> 或 <see langword="null"/> 时将获取根目录</param>
        /// <param name="fetchDownloadInfo">是否获取下载链接</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// </summary>
        /// <returns>表示此异步操作的 <see cref="Task"/>, 其值为文件信息</returns>
        Task<IGroupFileInfo> GetFileInfo(long groupNumber, string? id, bool fetchDownloadInfo, CancellationToken token = default);

        /// <summary>
        /// 异步创建文件夹
        /// </summary>
        /// <param name="groupNumber">群号</param>
        /// <param name="id">父目录id。为 <see cref="string.Empty"/> 或 <see langword="null"/> 时将从根目录创建文件夹</param>
        /// <param name="directoryName">文件夹名</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task CreateDirectory(long groupNumber, string? id, string directoryName, CancellationToken token = default);

        /// <summary>
        /// 异步删除给定文件
        /// </summary>
        /// <param name="groupNumber">群号</param>
        /// <param name="id">文件Id</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task DeleteFile(long groupNumber, string id, CancellationToken token = default);

        /// <summary>
        /// 异步移动给定文件至给定目录
        /// </summary>
        /// <param name="groupNumber">群号</param>
        /// <param name="srcId">源文件Id</param>
        /// <param name="dstId">目标文件夹Id。为 <see langword="null"/> 时将移动至根目录</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        /// <returns></returns>
        Task MoveFile(long groupNumber, string srcId, string? dstId, CancellationToken token = default);

        /// <summary>
        /// 异步更名给定文件
        /// </summary>
        /// <param name="groupNumber">群号</param>
        /// <param name="id">文件Id</param>
        /// <param name="renameTo">目标名称</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task RenameFile(long groupNumber, string id, string renameTo, CancellationToken token = default);

        #endregion

        #region 账号处理
        /// <summary>
        /// 异步删除指定好友
        /// </summary>
        /// <param name="qqNumber">需要删除好友的QQ号</param>
        /// <param name="token">供取消该异步方法的 <see cref="CancellationToken"/>，可不传递该参数</param>
        /// <returns></returns>
        Task DeleteFriend(long qqNumber, CancellationToken token = default);
        #endregion

        #region 群管理
        /// <summary>
        /// 异步禁言给定用户
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="PermissionDeniedException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="memberId">将要被禁言的QQ号</param>
        /// <param name="groupNumber">该用户所在群号</param>
        /// <param name="muteTime">禁言时长，单位分钟。必须介于[1, 43200]分钟</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task Mute(long memberId, long groupNumber, int muteTime, CancellationToken token = default);

        /// <summary>
        /// 异步解禁给定用户
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="PermissionDeniedException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="memberId">将要解除禁言的QQ号</param>
        /// <param name="groupNumber">该用户所在群号</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task Unmute(long memberId, long groupNumber, CancellationToken token = default);

        /// <summary>
        /// 异步将给定用户踢出给定的群
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="PermissionDeniedException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="memberId">将要被踢出的QQ号</param>
        /// <param name="groupNumber">该用户所在群号</param>
        /// <param name="msg">附加消息</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task KickMember(long memberId, long groupNumber, string msg = "", CancellationToken token = default);

        /// <summary>
        /// 异步使当前机器人退出给定的群
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="groupNumber">将要退出的群号</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task LeaveGroup(long groupNumber, CancellationToken token = default);

        /// <summary>
        /// 异步开启全体禁言
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="PermissionDeniedException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="groupNumber">将要进行全体禁言的群号</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task MuteAll(long groupNumber, CancellationToken token = default);

        /// <summary>
        /// 异步关闭全体禁言
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="PermissionDeniedException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="groupNumber">将要关闭全体禁言的群号</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task UnmuteAll(long groupNumber, CancellationToken token = default);

        /// <summary>
        /// 异步设置群精华消息
        /// </summary>
        /// <param name="id">消息Id</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task SetEssenceMessage(int id, CancellationToken token = default);

        /// <summary>
        /// 异步获取群信息
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="groupNumber">要获取信息的群号</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/>, 其值为群信息数组</returns>
        Task<IGroupConfig> GetGroupConfig(long groupNumber, CancellationToken token = default);

        /// <summary>
        /// 异步修改群信息
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="PermissionDeniedException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="groupNumber">要进行修改的群号</param>
        /// <param name="config">群信息。其中不进行修改的值请置为 <see langword="null"/></param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        [Obsolete("目前无法正常使用，后续有空再处理")]
        Task ChangeGroupConfig(long groupNumber, IGroupConfig config, CancellationToken token = default);

        /// <summary>
        /// 异步获取给定群员的信息
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="memberId">要获取信息的QQ号</param>
        /// <param name="groupNumber">该用户所在群号</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        Task<IGroupMemberInfo> GetGroupMemberInfo(long memberId, long groupNumber, CancellationToken token = default);

        /// <summary>
        /// 异步修改给定群员的信息
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="PermissionDeniedException"/>
        /// <exception cref="TargetNotFoundException"/>
        /// <param name="memberId">将要修改信息的QQ号</param>
        /// <param name="groupNumber">该用户所在群号</param>
        /// <param name="info">用户信息。其中不进行修改的值请置为 <see langword="null"/></param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/></returns>
        [Obsolete("目前无法正常使用，后续有空再处理")]
        Task ChangeGroupMemberInfo(long memberId, long groupNumber, IGroupMemberCardInfo info, CancellationToken token = default);

        /// <summary>
        /// 设置群管理员
        /// </summary>
        /// <param name="memberId">需要设置的群成员QQ号</param>
        /// <param name="groupNumber">所在群号</param>
        /// <param name="assign">是否设置为管理员</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task SetGroupAdmin(long memberId, long groupNumber, bool assign, CancellationToken token = default);

        #endregion

        #region 申请请求操作

        /// <summary>
        /// 异步处理Bot受邀加群请求
        /// </summary>
        /// <param name="args">Bot受邀入群事件中的参数, 即 <see cref="IBotInvitedJoinGroupEventArgs"/></param>
        /// <inheritdoc cref="HandleNewFriendApplyAsync(IApplyResponseArgs, FriendApplyAction, string?, CancellationToken)"/>
        Task HandleBotInvitedJoinGroup(IApplyResponseArgs args, GroupApplyActions action, string? message = null, CancellationToken token = default);

        /// <summary>
        /// 异步处理加群请求
        /// </summary>
        /// <param name="args">收到用户入群申请事件中的参数, 即 <see cref="IGroupApplyEventArgs"/></param>
        /// <inheritdoc cref="HandleNewFriendApplyAsync(IApplyResponseArgs, FriendApplyAction, string?, CancellationToken)"/>
        Task HandleGroupApply(IApplyResponseArgs args, GroupApplyActions action, string? message = null, CancellationToken token = default);

        /// <summary>
        /// 异步处理添加好友请求
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <param name="args">收到添加好友申请事件中的参数, 即<see cref="INewFriendApplyEventArgs"/></param>
        /// <param name="action">处理方式</param>
        /// <param name="message">附加信息</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        Task HandleNewFriendApply(IApplyResponseArgs args, FriendApplyAction action, string? message = null, CancellationToken token = default);

        #endregion

        #region 多媒体内容上传
        /// <summary>
        /// 通过路径上传图片并获得信息对象
        /// </summary>
        /// <param name="type">上传类型，图片信息不能跨类型使用</param>
        /// <param name="imagePath">图片路径</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IImageMessage> UploadPicture(UploadTarget type, string imagePath, CancellationToken token = default);

        /// <summary>
        /// 通过流上传图片并获得信息对象
        /// </summary>
        /// <param name="type">上传类型，图片信息不能跨类型使用</param>
        /// <param name="image">图片<see cref="Stream"/>流</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IImageMessage> UploadPicture(UploadTarget type, Stream image, CancellationToken token = default);

        /// <summary>
        /// 通过路径上传语音并获得信息对象
        /// </summary>
        /// <param name="type">上传类型，语音信息不能跨类型使用</param>
        /// <param name="voicePath">语音文件路径</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IVoiceMessage> UploadVoice(UploadTarget type, string voicePath, CancellationToken token = default);

        /// <summary>
        /// 通过流上传语音并获得信息对象
        /// </summary>
        /// <param name="type">上传类型，语音信息不能跨类型使用</param>
        /// <param name="voice">语音<see cref="Stream"/>流</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IVoiceMessage> UploadVoice(UploadTarget type, Stream voice, CancellationToken token = default);

        /// <summary>
        /// 通过路径上传群文件并获取上传的文件信息
        /// </summary>
        /// <param name="id">目标文件夹Id。为 <see langword="null"/> 时将上传到根目录</param>
        /// <param name="fileStream">文件流</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/>, 其值为上传后的文件信息</returns>
        Task<IGroupFileInfo> UploadFile(long groupNumber, string? id, string fileName, Stream fileStream, CancellationToken token = default);

        /// <summary>
        /// 通过路径上传群文件并获取上传的文件信息
        /// </summary>
        /// <param name="id">目标文件夹Id。为 <see langword="null"/> 时将上传到根目录</param>
        /// <param name="path">文件路径</param>
        /// <param name="token">用于取消此异步操作的 <see cref="CancellationToken"/></param>
        /// <returns>表示此异步操作的 <see cref="Task"/>, 其值为上传后的文件信息</returns>
        /// <exception cref="System.IO.IOException">文件读取过程中出现的异常</exception>
        Task<IGroupFileInfo> UploadFile(string id, long groupNumber, string path, CancellationToken token = default);

        #endregion
    }
}
