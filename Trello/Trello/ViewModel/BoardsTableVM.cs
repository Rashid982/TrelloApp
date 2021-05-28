using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class BoardsTableVM : ViewModelBase
    {
        public readonly TrelloDB trelloDB = ServiceLocator.Current.GetInstance<TrelloDB>();
        private Board selectedBoard;

        public Board SelectedBoard 
        {
            get => selectedBoard;
            set 
            {
                selectedBoard = value;                
                Messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<SelfBoardVM>() });
                Messenger.Send(new SelectedBoard() { Selected_Board = SelectedBoard });
            }  
        }
        public bool IsBusyOrNot { get; set; }
        public Messenger Messenger { get; set; }
        public Workspace WorkspaceOfBoard { get; set; }
        public ICollection<Board> Boards { get; set; }
        public RelayCommand CreateCmd { get; set; }
        public RelayCommand<object> DeleteBoardCmd { get; set; }
        public RelayCommand<object> SaveBoardNameCommand { get; set; }
        public RelayCommand<object> InviteCmd { get; set; }
        public ViewModelBase CurrentPage { get; set; }
        public BoardsTableVM()
        {
            Messenger = ServiceLocator.Current.GetInstance<Messenger>();

            Messenger.Register<NewBoards>(this, (y) =>
            {
                Boards = y.Boards as List<Board>;
            });

            Messenger.Register<WorkspaceOfBoard>(this, (x) =>
            {
                try
                {
                    WorkspaceOfBoard = x.Workspace;
                    Boards = trelloDB.Boards.Where(z => z.Workspace.Name == WorkspaceOfBoard.Name).ToList();
                }
                catch (Exception) { }                
            });

            CreateCmd = new RelayCommand(() =>
            {
                Messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<CreatingboardVM>() });
                Messenger.Send(new WorkspaceOfBoard() { Workspace = WorkspaceOfBoard });
            });

            DeleteBoardCmd = new RelayCommand<object>((x) =>
            {
                try
                {                   
                    var board = x as Board; 
                    trelloDB.Boards.Remove(board);
                    trelloDB.SaveChanges();                    
                    Boards = trelloDB.Boards.Where(z => z.Workspace.Name == WorkspaceOfBoard.Name).ToList();
                    MessageBox.Show("The board was deleted !");
                }
                catch (Exception) { MessageBox.Show("This board has already been deleted !"); }                
            });

            SaveBoardNameCommand = new RelayCommand<object>((x) =>
            {
                var board = x as Board;
                var findBoard = trelloDB.Boards.FirstOrDefault(z => z.ID == board.ID);
                findBoard.Title = board.Title;
                trelloDB.SaveChanges();
                MessageBox.Show("The name of board was changed !");
            });

            InviteCmd = new RelayCommand<object>((r) =>
            {
                Messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<InviteVM>() });
                Messenger.Send(new SelectedBoard() { Selected_Board = SelectedBoard });                
            },(r)=>SelectedBoard!=null);
        }
    }
}
