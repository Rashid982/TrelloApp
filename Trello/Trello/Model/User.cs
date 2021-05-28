using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Model
{
    [AddINotifyPropertyChangedInterface]
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }        
        public string Number { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Workspace> Workspaces { get; set; }
    }
}
