using Mirai.CSharp.HttpApi.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Messages
{
    public class CustomFlashImageMessage : FlashImageMessage
    {
        public override string ToString()
        {
            return $"[mirai:flashimage:{ImageId},{Url}]";
        }
    }
}
