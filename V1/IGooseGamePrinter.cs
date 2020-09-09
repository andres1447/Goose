using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1
{
    public interface IGooseGamePrinter
    {
        void Print(int tileNumber);
        void Print(int tileNumber, ISpecialTile tile);
        void Print(int tileNumber, BridgeTile tile);
        void Print(int tileNumber, MoveForwardTile tile);
    }
}
