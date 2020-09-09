using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1
{
    public class ConsoleGooseGamePrinter : IGooseGamePrinter
    {
        public void Print(int tile)
        {
            Console.WriteLine($"Stay in tile {tile}");
        }

        public void Print(int tileNumber, ISpecialTile tile)
        {
            tile.Print(tileNumber, this);
        }

        public void Print(int tileNumber, BridgeTile tile)
        {
            Console.WriteLine($"The Bridge: Go to space {tile.DestinationTile}");
        }

        public void Print(int tileNumber, MoveForwardTile tile)
        {
            Console.WriteLine($"Move two spaces forward");
        }
    }
}
