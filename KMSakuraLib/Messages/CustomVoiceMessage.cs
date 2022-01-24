using Mirai.CSharp.HttpApi.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Messages
{
    public class CustomVoiceMessage: VoiceMessage
    {
        public override string ToString()
        {
            return $"[mirai:voice:{VoiceId},{Url}]";
        }
    }
}
