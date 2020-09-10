using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    public interface IGooseGamePrinter : IGooseGameSpecialTilePrinter
    {
        void Print(int tileNumber);
        void Print(int tileNumber, ISpecialTile tile);
    }
}
