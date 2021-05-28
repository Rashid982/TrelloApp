using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Trello.Model;

namespace Trello.Database
{
    [AddINotifyPropertyChangedInterface]
    public class TrelloDB : DbContext
    {
        public TrelloDB() : base("TrelloDB") { }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
       
    }
}
