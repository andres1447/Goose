﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1
{
    public interface ISpecialTile
    {
        bool Apply(int tile);
        void Print(int tile, IGooseGamePrinter printer);
    }
}
