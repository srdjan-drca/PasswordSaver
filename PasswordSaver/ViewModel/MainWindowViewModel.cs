using PasswordSaver.Event;
using PasswordSaver.Services.CredentialsManager;
using PasswordSaver.ViewModel.Base;
using Prism.Events;
using System.Collections.Generic;

namespace PasswordSaver.ViewModel
{
    public class MainWindowViewModel : ObservableViewModel
    {
        private IEventAggregator _eventAggregator;
        private Dictionary<PageId, PageViewModel> _pageViewModels;

        public MainWindowViewModel(IEventAggregator eventAggregator, NavigationViewModel navigationViewModel)
        {
            var credentialsManager = new JsonCredentialsManager();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenPageEvent>().Subscribe(OnOpenPageEvent);
            _pageViewModels = new Dictionary<PageId, PageViewModel>
            {
                { PageId.AddCredentials, new AddCredentialsViewModel(credentialsManager) },
                { PageId.ListCredentials, new ListCredentialsViewModel(credentialsManager) }
            };

            NavigationViewModel = navigationViewModel;
            SelectedPageViewModel = _pageViewModels[PageId.AddCredentials];
        }

        public NavigationViewModel NavigationViewModel { get; private set; }

        private PageViewModel _selectedPageViewModel;
        public PageViewModel SelectedPageViewModel
        {
            get
            {
                return _selectedPageViewModel;
            }

            private set
            {
                if (_selectedPageViewModel != value)
                {
                    _selectedPageViewModel = value;
                    RaisePropertyChanged(nameof(SelectedPageViewModel));
                }
            }
        }

        private void OnOpenPageEvent(PageId pageId)
        {
            SelectedPageViewModel = _pageViewModels[pageId];
        }
    }
}