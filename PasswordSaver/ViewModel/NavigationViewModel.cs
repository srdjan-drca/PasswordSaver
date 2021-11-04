using PasswordSaver.Event;
using Prism.Commands;
using Prism.Events;

namespace PasswordSaver.ViewModel
{
    public class NavigationViewModel : ObservableViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public NavigationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            ShowAddCredentialsViewCommand = new DelegateCommand(ShowAddCredentialsView);
            ShowCredentialListViewCommand = new DelegateCommand(ShowListCredentialsView);
        }

        public DelegateCommand ShowAddCredentialsViewCommand { get; private set; }
        public DelegateCommand ShowCredentialListViewCommand { get; private set; }

        private void ShowAddCredentialsView()
        {
            _eventAggregator.GetEvent<OpenPageEvent>().Publish(PageId.AddCredentials);
        }

        private void ShowListCredentialsView()
        {
            _eventAggregator.GetEvent<OpenPageEvent>().Publish(PageId.ListCredentials);
        }
    }
}
