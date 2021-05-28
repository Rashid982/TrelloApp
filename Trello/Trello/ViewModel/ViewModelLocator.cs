using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Trello.Database;

namespace Trello.ViewModel
{
    public class ViewModelLocator
    {        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeVM>();
            SimpleIoc.Default.Register<LoginVM>();
            SimpleIoc.Default.Register<RegistrationVM>();
            SimpleIoc.Default.Register<BoardsTableVM>();
            SimpleIoc.Default.Register<WorkspaceVM>();
            SimpleIoc.Default.Register<CreatingboardVM>();
            SimpleIoc.Default.Register<SelfBoardVM>();
            SimpleIoc.Default.Register<MoveCardVM>();
            SimpleIoc.Default.Register<InviteVM>();
            SimpleIoc.Default.Register<InvitationBoardVM>();
            SimpleIoc.Default.Register<InvitationSelfBoardVM>();
            SimpleIoc.Default.Register<TrelloDB>();
            SimpleIoc.Default.Register<Messenger>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}