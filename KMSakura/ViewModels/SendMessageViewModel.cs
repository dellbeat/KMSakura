using KMSakura.DialogBaseClass;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using KMSakuraLib;
using System.Collections.ObjectModel;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using System.IO;
using System.Windows;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace KMSakura.ViewModels
{
    public class SendMessageViewModel : DialogBase
    {
        Bot BotA = null;

        public SendMessageViewModel()
        {
            Title = "信息发送";
            InitCommand();
            ChatMessageCol = new ObservableCollection<IChatMessage>();
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            BotA = parameters.GetValue<Bot>("bot");
        }

        private int _lastSendMsgId;

        public int LastSendMsgId
        {
            get => _lastSendMsgId;
            set => SetProperty(ref _lastSendMsgId, value);
        }

        private long _targetQQNumber;

        public long TargetQQNumber
        {
            get => _targetQQNumber;
            set => SetProperty(ref _targetQQNumber, value);
        }

        private long _subjectNumber;

        public long SubjectNumber
        {
            get => _subjectNumber;
            set => SetProperty(ref _subjectNumber, value);
        }

        private string _textMessage;

        public string TextMessage
        {
            get => _textMessage;
            set => SetProperty(ref _textMessage, value);
        }

        private long _atQQNumber;

        public long AtQQNumber
        {
            get => _atQQNumber;
            set => SetProperty(ref _atQQNumber, value);
        }

        private string _imageUrl;

        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }

        private string _abstractImgPath;

        public string AbstractImgPath
        {
            get => _abstractImgPath;
            set => SetProperty(ref _abstractImgPath, value);
        }

        private string _imageId;

        public string ImageId
        {
            get => _imageId;
            set => SetProperty(ref _imageId, value);
        }

        private string _voiceId;

        public string VoiceId
        {
            get => _voiceId;
            set => SetProperty(ref _voiceId, value);
        }

        private string _voiceUrl;

        public string VoiceUrl
        {
            get => _voiceUrl;
            set => SetProperty(ref _voiceUrl, value);
        }

        private string _voicePath;

        public string VoicePath
        {
            get => _voicePath;
            set => SetProperty(ref _voicePath, value);
        }

        private int _faceId;
        public int FaceId
        {
            get => _faceId;
            set => SetProperty(ref _faceId, value);
        }

        private string _faceCode;

        public string FaceCode
        {
            get => _faceCode;
            set => SetProperty(ref _faceCode, value);
        }

        private ObservableCollection<IChatMessage> _chatMessageCol;

        public ObservableCollection<IChatMessage> ChatMessageCol
        {
            get => _chatMessageCol;
            set => SetProperty(ref _chatMessageCol, value);
        }

        public DelegateCommand AddPlainMessageCommand { get; set; }
        public DelegateCommand AddAtMessageCommand { get; set; }
        public DelegateCommand AddAtAllMessageCommand { get; set; }
        public DelegateCommand AddPictureMessageCommand { get; set; }
        public DelegateCommand AddFaceMessageCommand { get; set; }
        public DelegateCommand ClearMessageCommand { get; set; }
        public DelegateCommand SendFriendFlashImgMessageCommand { get; set; }
        public DelegateCommand SendGroupFlashImgMessageCommand { get; set; }
        public DelegateCommand SendFriendVoiceMessageCommand { get; set; }
        public DelegateCommand SendGroupVoiceMessageCommand { get; set; }
        public DelegateCommand SendFriendMessageCommand { get; set; }
        public DelegateCommand SendGroupMessageCommand { get; set; }
        public DelegateCommand SendTempMessageCommand { get; set; }

        public void InitCommand()
        {
            AddPlainMessageCommand = new DelegateCommand(AddPlainMessage);
            AddAtMessageCommand = new DelegateCommand(AddAtMessage);
            AddAtAllMessageCommand = new DelegateCommand(AddAtAllMessage);
            AddPictureMessageCommand = new DelegateCommand(AddPictureMessage);
            AddFaceMessageCommand = new DelegateCommand(AddFaceMessage);
            ClearMessageCommand = new DelegateCommand(ClearMessage);
            SendFriendFlashImgMessageCommand = new DelegateCommand(SendFriendFlashImgMessage);
            SendGroupFlashImgMessageCommand = new DelegateCommand(SendGroupFlashImgMessage);
            SendFriendVoiceMessageCommand = new DelegateCommand(SendFriendVoiceMessage);
            SendGroupVoiceMessageCommand = new DelegateCommand(SendGroupVoiceMessage);
            SendFriendMessageCommand = new DelegateCommand(SendFriendMessage);
            SendGroupMessageCommand = new DelegateCommand(SendGroupMessage);
            SendTempMessageCommand = new DelegateCommand(SendTempMessage);
        }

        private void AddPlainMessage()
        {
            if (TextMessage == "")
            {
                return;
            }
            IChatMessage message = new PlainMessage(TextMessage);
            TextMessage = "";
            ChatMessageCol.Add(message);
        }

        public void AddAtMessage()
        {
            if (AtQQNumber == 0)
            {
                return;
            }
            IChatMessage message = new AtMessage(AtQQNumber);
            AtQQNumber = 0;
            ChatMessageCol.Add(message);
        }

        public void AddAtAllMessage()
        {
            IChatMessage message = new AtAllMessage();
            ChatMessageCol.Add(message);
        }

        public void AddPictureMessage()
        {
            if (string.IsNullOrEmpty(ImageUrl) && string.IsNullOrEmpty(ImageId) && !File.Exists(AbstractImgPath))
            {
                return;
            }
            IChatMessage message = new ImageMessage(ImageId, ImageUrl, AbstractImgPath);
            ImageUrl = "";
            ImageId = "";
            AbstractImgPath = "";
            ChatMessageCol.Add(message);
        }

        public void AddFaceMessage()
        {
            if (string.IsNullOrEmpty(FaceCode) && FaceId == 0)
            {
                return;
            }

            IChatMessage message = new FaceMessage(FaceId, FaceCode);
            FaceCode = "";
            FaceId = 0;
            ChatMessageCol.Add(message);
        }

        private void ClearMessage()
        {
            ChatMessageCol.Clear();
        }

        public async void SendFriendFlashImgMessage()
        {
            if (string.IsNullOrEmpty(ImageUrl) && string.IsNullOrEmpty(ImageId) && !File.Exists(AbstractImgPath))
            {
                return;
            }
            IChatMessage message = new FlashImageMessage(ImageId, ImageUrl, AbstractImgPath);
            ImageUrl = "";
            ImageId = "";
            AbstractImgPath = "";

            List<IChatMessage> chatMessages = new List<IChatMessage>();
            chatMessages.Add(message);

            LastSendMsgId = await BotA.SendFriendMessage(TargetQQNumber, chatMessages.ToArray(), null);

            MessageBox.Show(LastSendMsgId.ToString());
        }

        public async void SendGroupFlashImgMessage()
        {
            if (string.IsNullOrEmpty(ImageUrl) && string.IsNullOrEmpty(ImageId) && !File.Exists(AbstractImgPath))
            {
                return;
            }
            IChatMessage message = new FlashImageMessage(ImageId, ImageUrl, AbstractImgPath);
            ImageUrl = "";
            ImageId = "";
            AbstractImgPath = "";

            List<IChatMessage> chatMessages = new List<IChatMessage>();
            chatMessages.Add(message);

            LastSendMsgId = await BotA.SendGroupMessage(TargetQQNumber, chatMessages.ToArray(), null);

            MessageBox.Show(LastSendMsgId.ToString());
        }

        /// <summary>
        /// 好友消息仅支持silk格式语音
        /// </summary>
        public async void SendFriendVoiceMessage()
        {
            if (string.IsNullOrEmpty(VoiceId) && string.IsNullOrEmpty(VoiceUrl) && !File.Exists(VoicePath))
            {
                return;
            }

            if (TargetQQNumber == 0)
            {
                return;
            }

            IChatMessage message = new VoiceMessage(VoiceId, VoiceUrl, VoicePath);
            VoiceId = "";
            VoiceUrl = "";
            VoicePath = "";

            List<IChatMessage> chatMessages = new List<IChatMessage>();
            chatMessages.Add(message);

            LastSendMsgId = await BotA.SendFriendMessage(TargetQQNumber, chatMessages.ToArray(), null);

            MessageBox.Show(LastSendMsgId.ToString());
        }

        public async void SendGroupVoiceMessage()
        {
            if (string.IsNullOrEmpty(VoiceId ) && string.IsNullOrEmpty(VoiceUrl) && !File.Exists(VoicePath))
            {
                return;
            }

            if (TargetQQNumber == 0)
            {
                return;
            }

            IChatMessage message = new VoiceMessage(VoiceId, VoiceUrl, VoicePath);
            VoiceId = "";
            VoiceUrl = "";
            VoicePath = "";

            List<IChatMessage> chatMessages = new List<IChatMessage>();
            chatMessages.Add(message);

            LastSendMsgId = await BotA.SendGroupMessage(TargetQQNumber, chatMessages.ToArray(), null);

            MessageBox.Show(LastSendMsgId.ToString());
        }

        public async void SendFriendMessage()
        {
            if (ChatMessageCol.Count == 0)
            {
                return;
            }

            List<IChatMessage> chatMessages = new List<IChatMessage>();
            chatMessages.AddRange(ChatMessageCol);

            LastSendMsgId = await BotA.SendFriendMessage(TargetQQNumber, chatMessages.ToArray(), null);

            MessageBox.Show(LastSendMsgId.ToString());
        }

        public async void SendGroupMessage()
        {
            if (ChatMessageCol.Count == 0)
            {
                return;
            }

            List<IChatMessage> chatMessages = new List<IChatMessage>();
            chatMessages.AddRange(ChatMessageCol);

            LastSendMsgId = await BotA.SendGroupMessage(TargetQQNumber, chatMessages.ToArray(), null);

            MessageBox.Show(LastSendMsgId.ToString());
        }

        public async void SendTempMessage()
        {
            if (ChatMessageCol.Count == 0)
            {
                return;
            }

            List<IChatMessage> chatMessages = new List<IChatMessage>();
            chatMessages.AddRange(ChatMessageCol);

            LastSendMsgId = await BotA.SendTempMessage(TargetQQNumber, SubjectNumber, chatMessages.ToArray(), null);

            MessageBox.Show(LastSendMsgId.ToString());
        }
    }
}
