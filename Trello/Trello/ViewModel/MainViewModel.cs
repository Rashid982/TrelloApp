using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PropertyChanged;
using Trello.Messages;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : ViewModelBase
    {
        private readonly Messenger messenger = ServiceLocator.Current.GetInstance<Messenger>();
        public ViewModelBase CurrentPage { get; set; }
        public MainViewModel()
        {
            CurrentPage = ServiceLocator.Current.GetInstance<LoginVM>();            
            messenger.Register<NavigationPage>(this, (x) => { CurrentPage = x.CurrentPage; });
        }
    }
}