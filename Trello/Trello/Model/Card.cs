using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Trello.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Card : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List List { get; set; }
        public virtual DateTime DeadLine { get; set; }           
    }
}
