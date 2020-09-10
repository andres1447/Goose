using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    public class PrisionTile : ISpecialTile
    {
        int _fromTile;
        int _toTile;

        public PrisionTile(int fromTile, int toTile)
        {
            _fromTile = fromTile;
            _toTile = toTile;
        }

        public bool Apply(int tile)
        {
            return _fromTile <= tile && tile <= _toTile;
        }

        public void Print(int tile, IGooseGameSpecialTilePrinter printer)
        {
            printer.Print(tile, this);
        }
    }
}
