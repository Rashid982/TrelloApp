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
using Trello.Database;
using Trello.Messages;
using Trello.Model;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MoveCardVM : ViewModelBase
    {
        public readonly TrelloDB trelloDB = ServiceLocator.Current.GetInstance<TrelloDB>();
        public readonly Messenger messenger = ServiceLocator.Current.GetInstance<Messenger>();
        public RelayCommand AddListCommand { get; set; }
        public ICollection<List> Lists { get; set; }
        public Board SelectedBoard { get; set; }
        public List SelectedList { get; set; }
        public Card SelectedCard { get; set; }
        public MoveCardVM()
        {
            messenger.Register<SelectedBoard>(this, (x) =>
            {
                SelectedBoard = x.Selected_Board;
                Lists = trelloDB.Lists.Where(z => z.Board.Title == SelectedBoard.Title).ToList();
            });

            messenger.Register<SelectedCardMsg>(this, (z) =>
            {
                SelectedCard = z.Selected_Card;
            });

            AddListCommand = new RelayCommand(() =>
            {
                try
                {
                    trelloDB.Cards.Remove(SelectedCard);
                    trelloDB.SaveChanges();

                    var a = trelloDB.Cards.Add(SelectedCard);
                    a.List = SelectedList;
                    trelloDB.SaveChanges();
                    MessageBox.Show("The card added successfully !");
                }
                catch (Exception){ MessageBox.Show("Select a card!"); }
                
            }, () => SelectedList != null);
        }
    }
}
