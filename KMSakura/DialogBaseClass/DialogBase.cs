using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakura.DialogBaseClass
{
    public class DialogBase : BindableBase, IDialogAware
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;
        public virtual void OnDialogClosed() { }

        public virtual void OnDialogOpened(IDialogParameters parameters) { }

        public void DialogClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
    }
}
