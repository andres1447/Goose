using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    public class MazeTile : ISpecialTile
    {
        int _tile;
        public int DestinationTile { get; protected set; }

        public MazeTile(int tile, int destinationTile)
        {
            _tile = tile;
            DestinationTile = destinationTile;
        }

        public bool Apply(int tile)
        {
            return _tile == tile;
        }

        public void Print(int tileNumber, IGooseGameSpecialTilePrinter printer)
        {
            printer.Print(tileNumber, this);
        }
    }
}
