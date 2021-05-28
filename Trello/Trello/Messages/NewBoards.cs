﻿using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Model;

namespace Trello.Messages
{
    [AddINotifyPropertyChangedInterface]
    public class NewBoards
    {
        public ICollection<Board> Boards { get; set; }
    }
}
