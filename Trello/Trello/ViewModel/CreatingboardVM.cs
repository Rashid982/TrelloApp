using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Trello.Database;
using Trello.Messages;
using Trello.Model;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class CreatingboardVM : ViewModelBase
    {
        private readonly TrelloDB trelloDB = ServiceLocator.Current.GetInstance<TrelloDB>();

        public Color SelectedColor { get; set; }
        public Messenger Messenger { get; set; }
        public RelayCommand CreateCmd { get; set; }
        public Workspace WorkspaceOfBoard { get; set; }
        public bool IsBusyOrNot { get; set; }
        public string BoardTitle { get; set; }
        public CreatingboardVM()
        {
            SelectedColor = Color.FromRgb(0,0,255);

            Messenger = ServiceLocator.Current.GetInstance<Messenger>();
            Messenger.Register<WorkspaceOfBoard>(this, (x) => 
            {
                WorkspaceOfBoard = x.Workspace; 
            });

            CreateCmd = new RelayCommand(async() =>
            {
                try
                {
                    IsBusyOrNot = true;
                    trelloDB.Boards.Add(new Model.Board()
                    {
                        Title = BoardTitle,
                        Workspace = trelloDB.Workspaces.FirstOrDefault(x => x.Name == WorkspaceOfBoard.Name),
                        Color = SelectedColor
                    });
                    await trelloDB.SaveChangesAsync();
                    IsBusyOrNot = false;
                    BoardTitle = string.Empty;
                    MessageBox.Show("The board was created !");
                    Messenger.Send(new NewBoards { Boards = trelloDB.Boards.Where(d => d.Workspace.Name == WorkspaceOfBoard.Name).ToList() });
                }
                catch (Exception){ }                
            },()=>!string.IsNullOrWhiteSpace(BoardTitle));            
        }
    }
}
