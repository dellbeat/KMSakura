using KMSakuraLib.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Mirai.CSharp.HttpApi.Builder;
using Mirai.CSharp.HttpApi.Invoking;
using Mirai.CSharp.HttpApi.JsonServices;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Utility;
using Mirai.CSharp.HttpApi.Utility.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Buliders
{
    public class MiraiHttpFrameworkCustomBuilder: MiraiHttpFrameworkBuilder
    {
        public MiraiHttpFrameworkCustomBuilder(IServiceCollection services) : base(services)
        {

        }

        public override MiraiHttpFrameworkBuilder AddDefaultParsers()
        {
            TryAddService(typeof(IMiraiHttpMessageJsonOptionsFactory), typeof(MiraiHttpMessageJsonOptionsFactory), ServiceLifetime.Singleton, out _); // 解析消息链所必须的服务
            TryAddService(typeof(IMiraiHttpMessageJsonOptions<>), typeof(MiraiHttpMessageJsonOptions<>), ServiceLifetime.Singleton, out _); // 同上
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IAppMessage, AppMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IAtAllMessage, AtAllMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IAtMessage, AtMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IFaceMessage, FaceMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IFlashImageMessage, CustomFlashImageMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IImageMessage, CustomImageMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IJsonMessage, JsonMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IPlainMessage, PlainMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IPokeMessage, PokeMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IQuoteMessage, QuoteMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<ISourceMessage, SourceMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IVoiceMessage, CustomVoiceMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IXmlMessage, XmlMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IForwardMessage, ForwardMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<IDiceMessage, DiceMessage>>().
            AddChatParser<DefaultMappableMiraiHttpChatMessageParser<ISharedMusicMessage, SharedMusicMessage>>().
            AddChatParser<UnknownChatMessageParser>();
            return this;
        }
    }

    public static class CustomMiraiHttpFrameworkBuilderExtensions
    {
        public static MiraiHttpFrameworkCustomBuilder AddDefaultServices(this MiraiHttpFrameworkCustomBuilder builder)
        {
            builder.Services.TryAddSingleton<ChatMessageJsonConverter>();
            builder.Services.TryAddSingleton<ISilkLameCoder, SilkLameCoder>();
            builder.AddInvoker<MiraiHttpMessageHandlerInvoker>();
            builder.AddDefaultParsers();
            builder.AddDefaultChatParsers();
            return builder;
        }
    }
}
