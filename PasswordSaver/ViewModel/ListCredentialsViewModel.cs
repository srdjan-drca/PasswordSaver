using MaterialDesignThemes.Wpf;
using PasswordSaver.Model;
using PasswordSaver.Services.CredentialsManager;
using PasswordSaver.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace PasswordSaver.ViewModel
{
    public class ListCredentialsViewModel : PageViewModel
    {
        public ListCredentialsViewModel(ICredentialsManager<RawCredentials> credentialsManager)
        {
            Credentials = new ObservableCollection<Credentials>();
            foreach (RawCredentials rawCredentials in credentialsManager.GetCredentialList())
            {
                Credentials.Add(new Credentials(rawCredentials.Site, rawCredentials.UserName, rawCredentials.Password));
            }
        }

        public ObservableCollection<Credentials> Credentials { get; set; }
    }
}
