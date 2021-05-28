using GalaSoft.MvvmLight;
using PropertyChanged;

namespace Trello.Messages
{
    [AddINotifyPropertyChangedInterface]
    public class NavigationPage
    {
        public ViewModelBase CurrentPage { get; set; }
    }
}
