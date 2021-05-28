using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
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
    public class InviteVM : ViewModelBase
    {
        public readonly TrelloDB trelloDB = ServiceLocator.Current.GetInstance<TrelloDB>();
        public readonly Messenger messenger = ServiceLocator.Current.GetInstance<Messenger>();
        public ICollection<User> Users { get; set; }
        public User SelectedUser { get; set; }
        public Board SelectedBoard { get; set; }
        public RelayCommand<object> SendInvitationCommand { get; set; }
        public InviteVM()
        {
            Users = trelloDB.Users.ToList();
            messenger.Register<SelectedBoard>(this, (r) =>
            {
                SelectedBoard = r.Selected_Board;
            });

            SendInvitationCommand = new RelayCommand<object>((r) =>
            {
                int port = 5001;
                Task.Run(() =>
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                    TcpClient client = new TcpClient();
                    client.Connect(endPoint);
                    var board = trelloDB.Boards.FirstOrDefault(s => s.ID == SelectedBoard.ID);
                    var jsonMessages = JsonConvert.SerializeObject(board, Formatting.Indented,
                        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                    using (var writer = new StreamWriter(client.GetStream()))
                    {
                        writer.WriteLine(jsonMessages);
                        writer.Flush();
                    }
                });
                MessageBox.Show("The invitation sent !");                
            }, (r)=>SelectedUser!=null);
        }
    }
}
