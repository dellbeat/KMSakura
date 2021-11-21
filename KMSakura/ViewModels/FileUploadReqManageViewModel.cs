using KMSakura.DialogBaseClass;
using KMSakuraLib;
using Mirai.CSharp.HttpApi.Models;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;

namespace KMSakura.ViewModels
{
    public class FileUploadReqManageViewModel : DialogBase
    {
        #region Params
        Bot BotA = null;

        public Array UploadImgTarget { get; set; }
        public Array FriendActionTraget { get; set; }
        public Array GroupActionTarget { get; set; }

        private string _title;

        public new string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _voicePath;

        public string VoicePath
        {
            get => _voicePath;
            set => SetProperty(ref _voicePath, value);
        }

        private UploadTarget _voiceTarget;

        public UploadTarget VoiceTarget
        {
            get => _voiceTarget;
            set => SetProperty(ref _voiceTarget, value);
        }

        private string _imgPath;

        public string ImagePath
        {
            get => _imgPath;
            set => SetProperty(ref _imgPath, value);
        }

        private UploadTarget _imgTarget;

        public UploadTarget ImageTarget
        {
            get => _imgTarget;
            set => SetProperty(ref _imgTarget, value);
        }

        private string _filePath;

        public string FilePath
        {
            get => _filePath;
            set => SetProperty(ref _filePath, value);
        }

        private long _file_GroupNumber;

        public long FileGroupNumber
        {
            get => _file_GroupNumber;
            set => SetProperty(ref _file_GroupNumber, value);
        }

        private string _fileId;

        public string FileId
        {
            get => _fileId;
            set => SetProperty(ref _fileId, value);
        }

        private long _fileList_GroupNumber;

        public long FileListGroupNumber
        {
            get => _fileList_GroupNumber;
            set => SetProperty(ref _fileList_GroupNumber, value);
        }

        private string _fileList_Id;

        public string FileListId
        {
            get => _fileList_Id;
            set => SetProperty(ref _fileList_Id, value);
        }

        private bool _fileList_fetch;

        public bool FileListFetch
        {
            get => _fileList_fetch;
            set => SetProperty(ref _fileList_fetch, value);
        }

        private int _fileList_size;
        public int FileListSize
        {
            get => _fileList_size;
            set => SetProperty(ref _fileList_size, value);
        }

        private int _fileList_offset;

        public int FileListOffset
        {
            get => _fileList_offset;
            set => SetProperty(ref _fileList_offset, value);
        }

        private int _fileInfo_GroupNumber;

        public int FileInfoGroupNumber
        {
            get => _fileInfo_GroupNumber;
            set => SetProperty(ref _fileInfo_GroupNumber, value);
        }

        private string _fileInfo_Id;

        public string FileInfoId
        {
            get => _fileInfo_Id;
            set => SetProperty(ref _fileInfo_Id, value);
        }

        private bool _fileInfo_Fetch;

        public bool FileInfoFetch
        {
            get => _fileInfo_Fetch;
            set => SetProperty(ref _fileInfo_Fetch, value);
        }

        private long _create_GroupNumber;

        public long CreateGroupNumber
        {
            get => _create_GroupNumber;
            set => SetProperty(ref _create_GroupNumber, value);
        }

        private string _create_Id;

        public string CreateId
        {
            get => _create_Id;
            set => SetProperty(ref _create_Id, value);
        }

        private bool _create_Fetch;

        public bool CreateFetch
        {
            get => _create_Fetch;
            set => SetProperty(ref _create_Fetch, value);
        }

        private string _create_DirectoryName;

        public string CreateDirectoryName
        {
            get => _create_DirectoryName;
            set => SetProperty(ref _create_DirectoryName, value);
        }

        private long _delete_GroupNumber;

        public long DeleteGroupNumber
        {
            get => _delete_GroupNumber;
            set => SetProperty(ref _delete_GroupNumber, value);
        }

        private string _delete_FileId;

        public string DeleteFileId
        {
            get => _delete_FileId;
            set => SetProperty(ref _delete_FileId, value);
        }

        private long _move_GroupNumber;

        public long MoveGroupNumber
        {
            get => _move_GroupNumber;
            set => SetProperty(ref _move_GroupNumber, value);
        }

        private string _move_SrcId;

        public string MoveSrcId
        {
            get => _move_SrcId;
            set => SetProperty(ref _move_SrcId, value);
        }

        private string _move_DstId;

        public string MoveDstId
        {
            get => _move_DstId;
            set => SetProperty(ref _move_DstId, value);
        }

        private long _rename_GroupNumber;

        public long RenameGroupNumber
        {
            get => _rename_GroupNumber;
            set => SetProperty(ref _rename_GroupNumber, value);
        }

        private string _rename_FileId;

        public string RenameFileId
        {
            get => _rename_FileId;
            set => SetProperty(ref _rename_FileId, value);
        }

        private string _rename_FileName;

        public string RenameFileName
        {
            get => _rename_FileName;
            set => SetProperty(ref _rename_FileName, value);
        }

        private long _eventId;

        public long EventId
        {
            get => _eventId;
            set => SetProperty(ref _eventId, value);
        }

        private long _fromQQ;

        public long FromQQ
        {
            get => _fromQQ;
            set => SetProperty(ref _fromQQ, value);
        }

        private long _fromGroup;

        public long FromGroup
        {
            get => _fromGroup;
            set => SetProperty(ref _fromGroup, value);
        }

        private GroupApplyActions _groupAction;

        public GroupApplyActions GroupAction
        {
            get => _groupAction;
            set => SetProperty(ref _groupAction, value);
        }

        private FriendApplyAction _friendAction;

        public FriendApplyAction FriendAction
        {
            get => _friendAction;
            set => SetProperty(ref _friendAction, value);
        }

        private string _denyMessage;

        public string DenyMessage
        {
            get => _denyMessage;
            set => SetProperty(ref _denyMessage, value);
        }

        private ObservableCollection<object> _dataCol;

        public ObservableCollection<object> DataCol
        {
            get => _dataCol;
            set => SetProperty(ref _dataCol, value);
        }
        #endregion

        #region Commands
        public DelegateCommand UploadFileCommand { get; set; }
        public DelegateCommand UploadImgViaPathCommand { get; set; }
        public DelegateCommand UploadImgViaStreamCommand { get; set; }
        public DelegateCommand UploadVioceViaPathCommand { get; set; }
        public DelegateCommand UploadVioceViaStreamCommand { get; set; }
        public DelegateCommand GetFileListCommand { get; set; }
        public DelegateCommand GetFileInfoCommand { get; set; }
        public DelegateCommand CreateDirectoryCommand { get; set; }
        public DelegateCommand DeleteFileCommand { get; set; }
        public DelegateCommand MoveFileCommand { get; set; }
        public DelegateCommand RenameCommand { get; set; }
        public DelegateCommand ApplyGroupInviteCommand { get; set; }
        public DelegateCommand ApplyJoinGroupCommand { get; set; }
        public DelegateCommand ApplyNewFriendCommand { get; set; }
        #endregion

        public FileUploadReqManageViewModel()
        {
            Title = "群文件/多媒体";
            InitCommand();
            DataCol = new ObservableCollection<object>();
        }

        private void InitCommand()
        {
            UploadFileCommand = new DelegateCommand(UploadFile);
            UploadImgViaPathCommand = new DelegateCommand(UploadImgViaPath);
            UploadImgViaStreamCommand = new DelegateCommand(UploadImgViaStream);
            UploadVioceViaPathCommand = new DelegateCommand(UploadVioceViaPath);
            UploadVioceViaStreamCommand = new DelegateCommand(UploadVioceViaStream);
            GetFileListCommand = new DelegateCommand(GetFileList);
            GetFileInfoCommand = new DelegateCommand(GetFileInfo);
            CreateDirectoryCommand = new DelegateCommand(CreateDirectory);
            DeleteFileCommand = new DelegateCommand(DeleteFile);
            MoveFileCommand = new DelegateCommand(MoveFile);
            RenameCommand = new DelegateCommand(RenameFile);
            ApplyGroupInviteCommand = new DelegateCommand(ApplyGroupInvite);
            ApplyJoinGroupCommand = new DelegateCommand(ApplyJoinGroup);
            ApplyNewFriendCommand = new DelegateCommand(ApplyNewFriend);
            UploadImgTarget = Enum.GetValues(typeof(UploadTarget));
            GroupActionTarget = Enum.GetValues(typeof(GroupApplyActions));
            FriendActionTraget = Enum.GetValues(typeof(FriendApplyAction));
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            BotA = parameters.GetValue<Bot>("bot");
        }

        #region CommandFunctions
        public async void UploadFile()
        {
            if (string.IsNullOrEmpty(FilePath) || FileGroupNumber == 0)
            {
                return;
            }
            //GroupFileInfo info = await BotA.UploadFile(FileId, FileGroupNumber, FilePath) as GroupFileInfo;

            GroupFileInfo info = await BotA.UploadFile(FileGroupNumber, FileId, Path.GetFileName(FilePath), new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read)) as GroupFileInfo;

            FileId = null;
            FilePath = null;

            string jsonStr = JsonConvert.SerializeObject(info);
            if (MessageBox.Show(jsonStr, "上传文件信息", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Clipboard.SetText(jsonStr);
                });
            }

        }

        private async void UploadImgViaPath()
        {
            if (string.IsNullOrEmpty(ImagePath))
            {
                return;
            }
            ImageMessage message = await BotA.UploadPicture(ImageTarget, ImagePath) as ImageMessage;
            ImagePath = null;

            string jsonStr = JsonConvert.SerializeObject(message);
            if (MessageBox.Show(jsonStr, "上传图片信息", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Clipboard.SetText(jsonStr);
                });
            }
        }

        private async void UploadImgViaStream()
        {
            if (string.IsNullOrEmpty(ImagePath))
            {
                return;
            }

            using (Stream stream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                ImageMessage message = await BotA.UploadPicture(ImageTarget, stream) as ImageMessage;
                string jsonStr = JsonConvert.SerializeObject(message);
                if (MessageBox.Show(jsonStr, "上传图片信息", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Clipboard.SetText(jsonStr);
                    });
                }
            }

            ImagePath = null;
        }

        private async void UploadVioceViaPath()
        {
            if (string.IsNullOrEmpty(VoicePath))
            {
                return;
            }
            VoiceMessage message = await BotA.UploadVoice(VoiceTarget, VoicePath) as VoiceMessage;
            VoicePath = null;

            string jsonStr = JsonConvert.SerializeObject(message);
            if (MessageBox.Show(jsonStr, "上传语音信息", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Clipboard.SetText(jsonStr);
                });
            }
        }

        private async void UploadVioceViaStream()
        {
            if (string.IsNullOrEmpty(VoicePath))
            {
                return;
            }

            using (Stream stream = new FileStream(VoicePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                VoiceMessage message = await BotA.UploadVoice(VoiceTarget, stream) as VoiceMessage;
                VoicePath = null;
                string jsonStr = JsonConvert.SerializeObject(message);
                if (MessageBox.Show(jsonStr, "上传语音信息", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Clipboard.SetText(jsonStr);
                    });
                }
            }
        }

        private async void GetFileList()
        {
            if (FileListGroupNumber == 0 || FileListSize == 0)
            {
                return;
            }

            GroupFileInfo[] fileInfos = await BotA.GetFilelist(FileListGroupNumber, FileListId, FileListOffset, FileListSize, FileListFetch) as GroupFileInfo[];

            DataCol.Clear();
            DataCol.AddRange(fileInfos);

            FileListGroupNumber = 0;
            FileListSize = 0;
        }

        private async void GetFileInfo()
        {
            if (FileInfoGroupNumber == 0)
            {
                return;
            }

            GroupFileInfo info = await BotA.GetFileInfo(FileInfoGroupNumber, FileInfoId, FileInfoFetch) as GroupFileInfo;

            MessageBox.Show(JsonConvert.SerializeObject(info));
        }

        private async void CreateDirectory()
        {
            if (CreateGroupNumber == 0 || CreateDirectoryName == "")
            {
                return;
            }

            await BotA.CreateDirectory(CreateGroupNumber, CreateId, CreateDirectoryName);
        }

        private async void DeleteFile()
        {
            if (DeleteGroupNumber == 0 || string.IsNullOrEmpty(DeleteFileId))
            {
                return;
            }

            await BotA.DeleteFile(DeleteGroupNumber, DeleteFileId);
        }

        private async void MoveFile()
        {
            if (MoveGroupNumber == 0 || string.IsNullOrEmpty(MoveSrcId))
            {
                return;
            }

            await BotA.MoveFile(MoveGroupNumber, MoveSrcId, MoveDstId);

            MoveSrcId = null;
        }

        private async void RenameFile()
        {
            if (RenameGroupNumber == 0 || string.IsNullOrEmpty(RenameFileId) || string.IsNullOrEmpty(RenameFileName))
            {
                return;
            }

            await BotA.RenameFile(RenameGroupNumber, RenameFileId, RenameFileName);
        }

        private async void ApplyGroupInvite()
        {
            if (EventId == 0 || FromQQ == 0 || FromGroup == 0)
            {
                return;
            }

            BotInvitedJoinGroupEventArgs args = new BotInvitedJoinGroupEventArgs()
            {
                EventId = EventId,
                FromQQ = FromQQ,
                FromGroup = FromGroup
            };

            await BotA.HandleBotInvitedJoinGroup(args, GroupAction, DenyMessage);
        }

        private async void ApplyJoinGroup()
        {
            if (EventId == 0 || FromQQ == 0 || FromGroup == 0)
            {
                return;
            }

            GroupApplyEventArgs args = new GroupApplyEventArgs()
            {
                EventId = EventId,
                FromQQ = FromQQ,
                FromGroup = FromGroup
            };

            await BotA.HandleGroupApply(args, GroupAction, DenyMessage);
        }

        private async void ApplyNewFriend()
        {
            if (EventId == 0 || FromQQ == 0 )
            {
                return;
            }

            GroupApplyEventArgs args = new GroupApplyEventArgs()
            {
                EventId = EventId,
                FromQQ = FromQQ,
            };

            if (FromGroup != 0)
            {
                args.FromGroup = FromGroup;
            }

            await BotA.HandleNewFriendApply(args, FriendAction, DenyMessage);
        }
        #endregion
    }
}
