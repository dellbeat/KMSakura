using KMSakuraLib.Components.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Components.Attributes
{
    /// <summary>
    /// 组件供外部使用的方法
    /// </summary>
    public class COMMethodAttribute : Attribute
    {
        /// <summary>
        /// 方法类型
        /// </summary>
        public MessageTypeEnum MethodType { get;private set; }

        public COMMethodAttribute(MessageTypeEnum messageType)
        {
            MethodType = messageType;
        }
    }
}
