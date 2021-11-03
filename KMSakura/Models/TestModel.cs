using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakura.Models
{
    /// <summary>
    /// 测试专用模型类
    /// </summary>
    public class TestModel : BindableBase
    {
        private string _className;

        public string ClassName
        {
            get { return _className; }
            set => SetProperty(ref _className, value);
        }

        public override bool Equals(object obj)
        {
            if(obj== null)
            {
                return false;
            }

            TestModel model = obj as TestModel;

            return model.ClassName == ClassName;
        }
    }
}
