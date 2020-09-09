using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1
{
    public class BridgeTile : ISpecialTile
    {
        int _tile;
        public int DestinationTile { get; protected set; }

        public BridgeTile(int tile, int destinationTile)
        {
            _tile = tile;
            DestinationTile = destinationTile;
        }

        public bool Apply(int tile)
        {
            return _tile == tile;
        }

        public void Print(int tileNumber, IGooseGamePrinter printer)
        {
            printer.Print(tileNumber, this);
        }
    }
}
