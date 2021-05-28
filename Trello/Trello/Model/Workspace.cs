using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Model
{
    public enum W_Type
    {
        Engineering_IT,
        Small_Business,
        Sales_CRM,
        Education,
        Marketing,
        HR,
        Operations,
        Other
    }

    [AddINotifyPropertyChangedInterface]    
    public class Workspace : Entity
    {
        public string Name { get; set; }
        public W_Type Type { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
    }
}
