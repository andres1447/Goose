using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    public interface ISpecialTile
    {
        bool Apply(int tile);
        void Print(int tile, IGooseGameSpecialTilePrinter printer);
    }
}
