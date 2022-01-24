using Mirai.CSharp.HttpApi.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Messages
{
    public class CustomImageMessage: ImageMessage
    {
        public override string ToString()
        {
            return $"[mirai:image:{ImageId},{Url}]";
        }
    }
}
