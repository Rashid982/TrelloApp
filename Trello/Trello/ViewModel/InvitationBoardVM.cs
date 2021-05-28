using GalaSoft.MvvmLight;
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
using System.Windows.Threading;
using Trello.Messages;
using Trello.Model;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class InvitationBoardVM : ViewModelBase
    {
        private Board selectedBoard;
        public ICollection<Board> Boards { get; set; }
        public Messenger Messenger { get; set; }
        public Board SelectedBoard
        {
            get => selectedBoard;
            set
            {
                selectedBoard = value;
                Messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<InvitationSelfBoardVM>() });
                Messenger.Send(new SelectedBoard() { Selected_Board = SelectedBoard });
            }
        }
        public InvitationBoardVM()
        {
            Messenger = SimpleIoc.Default.GetInstance<Messenger>();
            Boards = new ObservableCollection<Board>();
            int port = 5002;
            Task.Run(() =>
            {
                TcpListener server = new TcpListener(IPAddress.Any, port);

                while (true)
                {
                    server.Start();
                    TcpClient s_client = server.AcceptTcpClient();

                    using (var reader = new StreamReader(s_client.GetStream()))
                    {
                        var board = reader.ReadToEnd();

                        var jsonMessage = JsonConvert.DeserializeObject<Board>(board);

                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                        {
                            Boards.Add(jsonMessage);
                        }));
                        MessageBox.Show("Invitation was accepted !");
                    }
                    server.Stop();
                }
            });
        }
    }
}
