using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Entity
    {
        public int ID { get; set; }
    }
}
