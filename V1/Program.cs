using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1
{
    class Program
    {
        const int NUMBER_OF_TILES = 63;
        const int MOVE_FORWARD_MULTIPLE = 6;
        const int MOVE_FORWARD_STEPS = 2;
        const int BRIDGE_TILE = 6;
        const int BRIDGE_DESTINATION_TILE = 12;

        static void Main(string[] args)
        {
            var rules = new GooseGame(NUMBER_OF_TILES)
                .AddSpecialTile(new BridgeTile(BRIDGE_TILE, BRIDGE_DESTINATION_TILE))
                .AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new ConsoleGooseGamePrinter();
            rules.Print(printer);

            Console.ReadKey();
        }
    }
}
