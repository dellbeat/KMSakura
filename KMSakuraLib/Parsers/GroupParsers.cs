using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KMSakuraLib.BotParser
{
    public abstract class Parser
    {

    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupAnonymousChatChangedEventArgs, GroupAnonymousChatChangedEventArgs>))]
    public class GroupAnonymousChatChangedParser : Parser, IMiraiHttpMessageHandler<IGroupAnonymousChatChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupAnonymousChatChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }


    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupConfessTalkChangedEventArgs, GroupConfessTalkChangedEventArgs>))]
    public class GroupConfessTalkChangedParser : Parser, IMiraiHttpMessageHandler<IGroupConfessTalkChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupConfessTalkChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupEntranceAnnouncementChangedEventArgs, GroupEntranceAnnouncementChangedEventArgs>))]
    public class GroupEntranceAnnouncementChangedParser : Parser, IMiraiHttpMessageHandler<IGroupEntranceAnnouncementChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupEntranceAnnouncementChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberCardChangedEventArgs, GroupMemberCardChangedEventArgs>))]
    public class GroupMemberCardChangedParser : Parser, IMiraiHttpMessageHandler<IGroupMemberCardChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberCardChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }


    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberInviteChangedEventArgs, GroupMemberInviteChangedEventArgs>))]
    public class GroupMemberInviteChangedParser : Parser, IMiraiHttpMessageHandler<IGroupMemberInviteChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberInviteChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }


    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberJoinedEventArgs, GroupMemberJoinedEventArgs>))]
    public class GroupMemberJoinedParser : Parser, IMiraiHttpMessageHandler<IGroupMemberJoinedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberJoinedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberKickedEventArgs, GroupMemberKickedEventArgs>))]
    public class GroupMemberKickedParser : Parser, IMiraiHttpMessageHandler<IGroupMemberKickedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberKickedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }


    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberPermissionChangedEventArgs, GroupMemberPermissionChangedEventArgs>))]
    public class GroupMemberPermissionChangedParser : Parser, IMiraiHttpMessageHandler<IGroupMemberPermissionChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberPermissionChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberPositiveLeaveEventArgs, GroupMemberPositiveLeaveEventArgs>))]
    public class GroupMemberPositiveLeaveParser : Parser, IMiraiHttpMessageHandler<IGroupMemberPositiveLeaveEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberPositiveLeaveEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberSpecialTitleChangedEventArgs, GroupMemberSpecialTitleChangedEventArgs>))]
    public class GroupMemberSpecialTitleChangedParser : Parser, IMiraiHttpMessageHandler<IGroupMemberSpecialTitleChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberSpecialTitleChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMuteAllChangedEventArgs, GroupMuteAllChangedEventArgs>))]
    public class GroupMuteAllChangedParser : Parser, IMiraiHttpMessageHandler<IGroupMuteAllChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMuteAllChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupNameChangedEventArgs, GroupNameChangedEventArgs>))]
    public class GroupNameChangedParser : Parser, IMiraiHttpMessageHandler<IGroupNameChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupNameChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupApplyEventArgs, GroupApplyEventArgs>))]
    public class GroupApplyParser : Parser, IMiraiHttpMessageHandler<IGroupApplyEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupApplyEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    public class GroupMemberHonorParser : Parser, IMiraiHttpMessageHandler<IGroupMemberHonorChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberHonorChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberMutedEventArgs, GroupMemberMutedEventArgs>))]
    public class GroupMemberMutedParser : Parser, IMiraiHttpMessageHandler<IGroupMemberMutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberMutedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMemberUnmutedEventArgs, GroupMemberUnmutedEventArgs>))]
    public class GroupMemberUnmutedParser : Parser, IMiraiHttpMessageHandler<IGroupMemberUnmutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMemberUnmutedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageRevokedEventArgs, GroupMessageRevokedEventArgs>))]
    public class GroupMessageRevokedParser : Parser, IMiraiHttpMessageHandler<IGroupMessageRevokedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMessageRevokedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageEventArgs, GroupMessageEventArgs>))]
    public class GroupMessageParser : Parser, IMiraiHttpMessageHandler<IGroupMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, Mirai.CSharp.HttpApi.Models.EventArgs.IGroupMessageEventArgs message)
        {
            return Task.FromResult(false);
        }
    }
}

