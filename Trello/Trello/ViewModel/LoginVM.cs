using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
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
using System.Windows.Controls;
using Trello.Database;
using Trello.Messages;
using Trello.Model;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LoginVM : ViewModelBase
    {
        private readonly TrelloDB context = ServiceLocator.Current.GetInstance<TrelloDB>();
        public bool IsBusyOrNot { get; set; }
        public Messenger Messenger { get; set; }
        public string UserName { get; set; } = "Rashid12";
        public RelayCommand<object> SignInCmd { get; set; }
        public RelayCommand RegistrationCmd { get; set; }       

        public LoginVM()
        {
            Messenger = ServiceLocator.Current.GetInstance<Messenger>();
            SignInCmd = new RelayCommand<object>(async (x) =>
            {
                var passwordBox = x as PasswordBox;
                var Password = passwordBox.Password;
                if (string.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show("Enter password ! ");
                }
                else
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            IsBusyOrNot = true;

                            var userNameDB = context.Users.FirstOrDefault(z => z.UserName == UserName);
                            var passwordDB = userNameDB.Password;
                            if (UserName == userNameDB.UserName && Password == passwordDB)
                            {
                                Messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<HomeVM>() });
                                Messenger.Send(new CurrentUser() { Current_User = userNameDB });
                                
                                IsBusyOrNot = false;
                            }
                            else
                            {
                                IsBusyOrNot = false;
                                MessageBox.Show("Username or password is incorrect !");
                            }
                        }
                        catch (Exception)
                        {
                            IsBusyOrNot = false;
                            MessageBox.Show("Username or password is incorrect !");
                        }
                    });
                }
            });

            RegistrationCmd = new RelayCommand(() =>
            {
                Messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<RegistrationVM>(Guid.NewGuid().ToString()) });
            });                        
        }
    }
}
