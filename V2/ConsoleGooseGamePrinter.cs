using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
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

        public void Print(int tileNumber, HotelTile tile)
        {
            Console.WriteLine($"The Hotel: Stay for (miss) one turn");
        }

        public void Print(int tileNumber, WellTile tile)
        {
            Console.WriteLine($"The Well: Wait until someone comes to pull you out - they then take your place");
        }

        public void Print(int tileNumber, MazeTile tile)
        {
            Console.WriteLine($"The Maze: Go back to space {tile.DestinationTile}");
        }

        public void Print(int tileNumber, PrisionTile tile)
        {
            Console.WriteLine($"The Prision: Wait until someone comes to release you - they then take your place");
        }
    }
}
