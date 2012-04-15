using System;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.MvvmLight.Test.Command
{
    public class TemporaryClass
    {
        private RelayCommand _command;
        private RelayCommand<string> _commandGeneric;

        public string Content
        {
            get;
            private set;
        }

        private string ContentPrivate
        {
            get;
            set;
        }

        internal string ContentInternal
        {
            get;
            private set;
        }

        public bool CheckEnabled()
        {
            return string.IsNullOrEmpty(Content);
        }

        private bool CheckEnabledPrivate()
        {
            return string.IsNullOrEmpty(ContentPrivate);
        }

        internal bool CheckEnabledInternal()
        {
            return string.IsNullOrEmpty(ContentInternal);
        }

        private bool CheckEnabledPrivate(string p)
        {
            return string.IsNullOrEmpty(ContentPrivate);
        }

        internal bool CheckEnabledInternal(string p)
        {
            return string.IsNullOrEmpty(ContentInternal);
        }

        public bool CheckEnabled(string p)
        {
            return string.IsNullOrEmpty(Content);
        }

       public void SetContent(string newContent)
        {
            Content = newContent;
        }

        private void SetContentPrivate(string newContent)
        {
            ContentPrivate = newContent;
        }

        internal void SetContentInternal(string newContent)
        {
            ContentInternal = newContent;
        }

        public void SetContent()
        {
            Content = DateTime.Now.ToString();
        }

        private void SetContentPrivate()
        {
            ContentPrivate = DateTime.Now.ToString();
        }

        internal void SetContentInternal()
        {
            ContentInternal = DateTime.Now.ToString();
        }

        public void CreateCommandPrivate()
        {
            _command = new RelayCommand(SetContentPrivate);
        }

        public void CreateCommandInternal()
        {
            _command = new RelayCommand(SetContentInternal);
        }

        public void CreateCommandCanExecutePrivate()
        {
            _command = new RelayCommand(
                SetContentPrivate,
                CheckEnabledPrivate);
        }

        public void CreateCommandCanExecuteInternal()
        {
            _command = new RelayCommand(
                SetContentInternal,
                CheckEnabledInternal);
        }

        public void CreateCommandGenericPrivate()
        {
            _commandGeneric = new RelayCommand<string>(SetContentPrivate);
        }

        public void CreateCommandGenericInternal()
        {
            _commandGeneric = new RelayCommand<string>(SetContentInternal);
        }

        public void CreateCommandGenericCanExecutePrivate()
        {
            _commandGeneric = new RelayCommand<string>(
                SetContentPrivate,
                CheckEnabledPrivate);
        }

        public void CreateCommandGenericCanExecuteInternal()
        {
            _commandGeneric = new RelayCommand<string>(
                SetContentInternal,
                CheckEnabledInternal);
        }
    }
}