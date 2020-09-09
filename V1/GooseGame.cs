using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1
{
    public class GooseGame
    {
        int _tiles;
        List<ISpecialTile> _specialTiles = new List<ISpecialTile>();

        public GooseGame(int tiles)
        {
            _tiles = tiles;
        }

        public GooseGame AddSpecialTile(ISpecialTile tile)
        {
            _specialTiles.Add(tile);
            return this;
        }

        public void Print(IGooseGamePrinter printer)
        {
            for (int i = 1; i <= _tiles; ++i)
            {
                PrintTile(i, printer);
            }
        }

        private void PrintTile(int tile, IGooseGamePrinter printer)
        {
            var specialTile = _specialTiles.FirstOrDefault(x => x.Apply(tile));
            if (specialTile != null)
            {
                specialTile.Print(tile, printer);
            }
            else
            {
                printer.Print(tile);
            }
        }
    }
}
