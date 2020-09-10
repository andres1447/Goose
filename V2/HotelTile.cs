using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    public class HotelTile : ISpecialTile
    {
        int _tile;

        public HotelTile(int tile)
        {
            _tile = tile;
        }

        public bool Apply(int tile)
        {
            return _tile == tile;
        }

        public void Print(int tile, IGooseGameSpecialTilePrinter printer)
        {
            printer.Print(tile, this);
        }
    }
}
