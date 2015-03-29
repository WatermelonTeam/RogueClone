﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueClone
{
    public interface IDurable
    {
        int MaxDurability
        {
            get;
            set;
        }

        int CurrentDurability
        {
            get;
            set;
        }
    }
}