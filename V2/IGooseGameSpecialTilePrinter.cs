using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    public interface IGooseGameSpecialTilePrinter
    {
        void Print(int tileNumber, BridgeTile tile);
        void Print(int tileNumber, MoveForwardTile tile);
        void Print(int tileNumber, HotelTile tile);
        void Print(int tileNumber, WellTile tile);
        void Print(int tileNumber, MazeTile tile);
        void Print(int tileNumber, PrisionTile tile);
    }
}
