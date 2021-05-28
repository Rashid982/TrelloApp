using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Trello.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Board : Entity
    {
        public string Title { get; set; }
        [NotMapped]
        public virtual Color Color { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        public virtual Workspace Workspace { get; set; }
    }
}
