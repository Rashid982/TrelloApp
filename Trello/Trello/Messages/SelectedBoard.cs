using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Model;

namespace Trello.Messages
{
    [AddINotifyPropertyChangedInterface]
    public class SelectedBoard
    {
        public Board Selected_Board { get; set; }
    }
}
