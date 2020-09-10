using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    public class MoveForwardTile : ISpecialTile
    {
        int _tileMultiple;

        public int MoveTiles { get; protected set; }

        public MoveForwardTile(int tileMultiple, int moveTiles)
        {
            _tileMultiple = tileMultiple;
            MoveTiles = moveTiles;
        }

        public bool Apply(int tile)
        {
            return tile % _tileMultiple == 0;
        }

        public void Print(int tileNumber, IGooseGameSpecialTilePrinter printer)
        {
            printer.Print(tileNumber, this);
        }
    }
}
