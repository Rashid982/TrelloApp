using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trello.Database;
using Trello.Messages;
using Trello.Model;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class WorkspaceVM : ViewModelBase
    {
        private readonly TrelloDB context = ServiceLocator.Current.GetInstance<TrelloDB>();
        private readonly Messenger messenger = ServiceLocator.Current.GetInstance<Messenger>();
        public string WorkSpaceName { get; set; }
        public W_Type SelectedWorkSpaceType { get; set; }
        public string Description { get; set; }
        public User CurrentUser { get; set; }
        public RelayCommand ContinueCmd { get; set; }
        public WorkspaceVM()
        {
            
            messenger.Register<CurrentUser>(this, (x) =>
            {
                CurrentUser = x.Current_User;
            });

            ContinueCmd = new RelayCommand(() =>
            {
                try
                {
                    context.Workspaces.Add(new Workspace()
                    {
                        Name = WorkSpaceName,
                        Type = SelectedWorkSpaceType,
                        Description = Description,
                        User = CurrentUser
                    });
                    context.SaveChanges();
                }
                catch (Exception) {  }
                messenger.Send(new WorkSpacesList() { Workspaces = context.Workspaces.Where(s => s.User.ID == CurrentUser.ID).ToList() });
                MessageBox.Show("The Workspace was created ! ");
            });
        }
    }
}
