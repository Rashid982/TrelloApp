using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Trello.Database;
using Trello.Messages;
using Trello.Validations;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class RegistrationVM : ViewModelBase, IDataErrorInfo
    {
        private readonly TrelloDB context = ServiceLocator.Current.GetInstance<TrelloDB>();
        private readonly Messenger messenger = ServiceLocator.Current.GetInstance<Messenger>();
        public bool IsBusyOrNot { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FamilyName { get; set; }
        public string Number { get; set; }
        public string UserName { get; set; }
        public RegistrValidation ValidationRules { get; set; }
        public Regex LetterValidations { get; set; }
        public Regex DigitValidations { get; set; }
        public RelayCommand<object> RegisterCmd { get; set; }
        public RelayCommand CancelCmd { get; set; }

        public string Error
        {
            get
            {
                if (ValidationRules != null)
                {
                    var results = ValidationRules.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(" ", results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = ValidationRules.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return ValidationRules != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }

        public RegistrationVM()
        {
            ValidationRules = new RegistrValidation();
            LetterValidations = new Regex("[^a-zA-Z]+$");
            DigitValidations = new Regex("[^0-9.-]+");

            RegisterCmd = new RelayCommand<object>(async (x) =>
            {
                IsBusyOrNot = true;
                await Task.Run(() =>
                {
                    var passwordBox = x as PasswordBox;
                    var Password = passwordBox.Password;
                    if (string.IsNullOrWhiteSpace(Password))
                    {
                        MessageBox.Show("Please, enter password! ");
                    }
                    else
                    {
                        context.Users.Add(new Model.User()
                        {
                            Name = Name,
                            Surname = Surname,                           
                            Number = Number,
                            UserName = UserName,
                            Password = Password
                        });

                        context.SaveChanges();
                        IsBusyOrNot = false;
                        MessageBox.Show("Registration was successfully completed !");
                        messenger.Send(new NavigationPage() { CurrentPage = ServiceLocator.Current.GetInstance<LoginVM>() });
                    }
                });

            }, (x) => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Number)
            && !LetterValidations.IsMatch(Name) && !LetterValidations.IsMatch(Surname) && !DigitValidations.IsMatch(Number) && string.IsNullOrEmpty(Error));

            CancelCmd = new RelayCommand(() => { messenger.Send(new NavigationPage() { CurrentPage = ServiceLocator.Current.GetInstance<LoginVM>() }); });
        }
    }
}
