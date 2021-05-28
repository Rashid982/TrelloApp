using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDrop
{
    public class DragDropEventArgs : EventArgs
    {
        public Object DataContext;
        public DragDropEventArgs() { }
        public DragDropEventArgs(Object dataContext)
        {
            DataContext = dataContext;
        }
    }
}
