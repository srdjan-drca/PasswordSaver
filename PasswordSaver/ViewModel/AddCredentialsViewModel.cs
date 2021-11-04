using MaterialDesignThemes.Wpf;
using PasswordSaver.Services.CredentialsManager;
using PasswordSaver.ViewModel.Base;
using Prism.Commands;
using System;
using System.Windows.Threading;

namespace PasswordSaver.ViewModel
{
    public class AddCredentialsViewModel : PageViewModel
    {
        private ICredentialsManager<RawCredentials> _credentialsManager;

        public AddCredentialsViewModel(ICredentialsManager<RawCredentials> credentialsManager)
        {
            _credentialsManager = credentialsManager;
            SaveCredentialsCommand = new DelegateCommand(SaveCredentials);
            StatusMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(3), Dispatcher.CurrentDispatcher);
        }

        public string Site { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public SnackbarMessageQueue StatusMessageQueue { get; set; }
        public DelegateCommand SaveCredentialsCommand { get; private set; }

        private void SaveCredentials()
        {
            if(string.IsNullOrWhiteSpace(Site) && string.IsNullOrWhiteSpace(UserName) && string.IsNullOrWhiteSpace(Password))
            {
                StatusMessageQueue.Enqueue("At least one field is necessary!", "", actionHandler: null, promote: true);
                return;
            }

            try
            {
                var rawCredentials = new RawCredentials(Site, UserName, Password);

                _credentialsManager.SaveCredentials(rawCredentials);

                StatusMessageQueue.Enqueue("Credentials saved sucessfully", "", actionHandler: null, promote: true);
            }
            catch(Exception exception)
            {
                StatusMessageQueue.Enqueue(exception.Message, "", actionHandler: null, promote: true);
            }
        }
    }
}
