using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trello.Database;
using Trello.Messages;
using Trello.Model;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class HomeVM : ViewModelBase
    {
        private readonly TrelloDB trelloDB = ServiceLocator.Current.GetInstance<TrelloDB>();
        
        public RelayCommand AddWorkSpCmd { get; set; }
        public Messenger Messenger { get; set; }
        public RelayCommand<object> ChangeWKNameCommand { get; set; }
        public RelayCommand<object> BoardCmd { get; set; }
        public RelayCommand<object> DeleteCmd { get; set; }
        public RelayCommand<object> NotificationCommand { get; set; }
        public ViewModelBase CurrentPage { get; set; }
        public List<Workspace> Workspaces { get; set; }       
        public User CurrentUser { get; set; }

        public HomeVM()
        {
            
            Messenger= ServiceLocator.Current.GetInstance<Messenger>();

            Messenger.Register<WorkSpacesList>(this, (x) =>
            {
                Workspaces = x.Workspaces;
            });

            Messenger.Register<CurrentUser>(this, (x) =>
            {
                CurrentUser = x.Current_User;
                Workspaces = trelloDB.Workspaces.Where(s => s.User.ID == CurrentUser.ID).ToList();
            });


            AddWorkSpCmd = new RelayCommand(() =>
            {
                Messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<WorkspaceVM>() });
                Messenger.Send(new CurrentUser() { Current_User = CurrentUser });
            });

            BoardCmd = new RelayCommand<object>((x) =>
            {
                var boardsForWorkSpace = x as Workspace;                
                CurrentPage = SimpleIoc.Default.GetInstance<BoardsTableVM>();
                Messenger.Send(new WorkspaceOfBoard() { Workspace = boardsForWorkSpace });
            });

            DeleteCmd = new RelayCommand<object>((x) =>
            {
                try
                {
                    var boardsForWorkSpace = x as Workspace;
                    trelloDB.Workspaces.Remove(boardsForWorkSpace);
                    trelloDB.SaveChanges();
                    Workspaces = trelloDB.Workspaces.Where(s => s.User.ID == CurrentUser.ID).ToList();
                }
                catch (Exception) { }                
            });

            NotificationCommand = new RelayCommand<object>((r) =>
            {
                Messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<InvitationBoardVM>() });
            });

            ChangeWKNameCommand = new RelayCommand<object>((r) =>
            {
                var workspace = r as Workspace;
                var findWksp = trelloDB.Workspaces.FirstOrDefault(s => s.ID == workspace.ID);
                findWksp.Name = workspace.Name;
                trelloDB.SaveChanges();
                MessageBox.Show("The Workspace name was changed !");
            });
        }
    }
}
