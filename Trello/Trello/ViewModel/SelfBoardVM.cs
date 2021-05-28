using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Trello.Database;
using Trello.Messages;
using Trello.Model;
using Trello.View;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class SelfBoardVM : ViewModelBase
    {
        public readonly TrelloDB trelloDB = ServiceLocator.Current.GetInstance<TrelloDB>();
        public readonly Messenger messenger = ServiceLocator.Current.GetInstance<Messenger>();
        private DateTime selectedDate = DateTime.Now;

        public string ListTitle { get; set; }
        public string CardTitle { get; set; }
        public ICollection<List> Lists { get; set; }
        public ICollection<Card> Cards { get; set; }
        public Board SelectedBoard { get; set; }
        public RelayCommand<object> AddAnotherCardCmd { get; set; }
        public RelayCommand AddListCmd { get; set; }
        public RelayCommand<object> MoveCardCmd { get; set; }
        public RelayCommand<object> DelCardCommand { get; set; }
        public RelayCommand<object> DelListCommand { get; set; }
        public RelayCommand<object> SaveListNameCommand { get; set; }
        public RelayCommand<object> SaveCardNameCommand { get; set; }
        public Card SelectedCard { get; set; }
        public DateTime SelectedDate
        {
            get => selectedDate;
            set 
            {
                selectedDate = value;
                if (selectedDate.Date > DateTime.Now)
                {
                    DeadLineColor = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    DeadLineColor = System.Windows.Media.Brushes.Red;
                }
            } 
        }
        public Brush DeadLineColor { get; set; }
        public SelfBoardVM()
        {            
            messenger.Register<SelectedBoard>(this, (x) =>
            {
                try
                {
                    SelectedBoard = x.Selected_Board;
                    Lists = trelloDB.Lists.Where(z => z.Board.Title == SelectedBoard.Title).ToList();
                }
                catch (Exception) { }
            });

            AddListCmd = new RelayCommand(() =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(ListTitle))
                    { }
                    else
                    {
                        trelloDB.Lists.Add(new List()
                        {
                            Title = ListTitle,
                            Board = SelectedBoard
                        });
                        trelloDB.SaveChanges();
                        Lists = trelloDB.Lists.Where(z => z.Board.Title == SelectedBoard.Title).ToList();
                        ListTitle = string.Empty;
                    }                    
                }
                catch (Exception) { MessageBox.Show("Select board !"); }

            });

            AddAnotherCardCmd = new RelayCommand<object>((x) =>
            {
                var selectedList = x as List;

                if (string.IsNullOrWhiteSpace(CardTitle))
                {
                    //MessageBox.Show("Enter a title for this card !");
                }
                else
                {
                    trelloDB.Cards.Add(new Card()
                    {
                        Title = CardTitle,
                        List = selectedList,
                        DeadLine = SelectedDate                       
                    });
                    trelloDB.SaveChanges();
                    CardTitle = string.Empty;
                    Lists = trelloDB.Lists.Where(z => z.Board.Title == SelectedBoard.Title).ToList();
                }
            });

            MoveCardCmd = new RelayCommand<object>((x) =>
            {
                messenger.Send(new NavigationPage() { CurrentPage = SimpleIoc.Default.GetInstanceWithoutCaching<MoveCardVM>() });
                messenger.Send(new SelectedCardMsg() { Selected_Card = SelectedCard });
                messenger.Send(new SelectedBoard() { Selected_Board = SelectedBoard });
            });

            DelCardCommand = new RelayCommand<object>((x) =>
            {
                try
                {
                    var card = x as Card;
                    trelloDB.Cards.Remove(card);
                    trelloDB.SaveChanges();
                    Lists = trelloDB.Lists.Where(z => z.Board.Title == SelectedBoard.Title).ToList();
                    MessageBox.Show("The card was deleted !");
                }
                catch (Exception) { MessageBox.Show("This card has already been deleted !"); };
            });

            DelListCommand = new RelayCommand<object>((x) =>
            {
                try
                {
                    var list = x as List;
                    trelloDB.Lists.Remove(list);
                    trelloDB.SaveChanges();
                    Lists = trelloDB.Lists.Where(z => z.Board.Title == SelectedBoard.Title).ToList();
                    MessageBox.Show("The list was deleted !");
                }
                catch (Exception) { MessageBox.Show("This list has already been deleted !"); }
            });

            SaveListNameCommand = new RelayCommand<object>((x) =>
            {
                var list = x as List;
                var findList = trelloDB.Lists.FirstOrDefault(p => p.ID == list.ID);
                findList.Title = list.Title;
                trelloDB.SaveChanges();
                Lists = trelloDB.Lists.Where(z => z.Board.Title == SelectedBoard.Title).ToList();
                MessageBox.Show("The list of title was changed !");
            });

            SaveCardNameCommand = new RelayCommand<object>((x) =>
            {
                var card = x as Card;
                var findcard = trelloDB.Cards.FirstOrDefault(s => s.ID == card.ID);
                findcard.Title = card.Title;
                trelloDB.SaveChanges();
                Lists = trelloDB.Lists.Where(z => z.Board.Title == SelectedBoard.Title).ToList();
                MessageBox.Show("The card of title was changed !");
            });
        }
    }
}
