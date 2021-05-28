using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Model
{
    [AddINotifyPropertyChangedInterface]
    public class List : Entity
    {
        public string Title { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual Board Board { get; set; }
    }
}
