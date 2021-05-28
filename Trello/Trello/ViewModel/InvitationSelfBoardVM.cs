using CommonServiceLocator;using GalaSoft.MvvmLight;using GalaSoft.MvvmLight.Messaging;using PropertyChanged;using System;using System.Collections.Generic;using Trello.Model;
using System.Linq;using System.Text;using System.Threading.Tasks;using Trello.Database;using Trello.Messages;

namespace Trello.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class InvitationSelfBoardVM : ViewModelBase
    {
        public readonly TrelloDB trelloDB = ServiceLocator.Current.GetInstance<TrelloDB>();
        public readonly Messenger messenger = ServiceLocator.Current.GetInstance<Messenger>();
        public Board SelectedBoard { get; set; }
        public ICollection<List> Lists { get; set; }
        public InvitationSelfBoardVM()
        {
            messenger.Register<SelectedBoard>(this, (r) =>
            {
                SelectedBoard = r.Selected_Board;
                Lists = trelloDB.Lists.Where(p=>p.Board.ID==SelectedBoard.ID).ToList();
            });
        }
    }
}
