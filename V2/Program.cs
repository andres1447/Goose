using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
{
    class Program
    {
        const int NUMBER_OF_TILES = 63;
        const int MOVE_FORWARD_MULTIPLE = 6;
        const int MOVE_FORWARD_STEPS = 2;
        const int BRIDGE_TILE = 6;
        const int BRIDGE_DESTINATION_TILE = 12;
        const int HOTEL_TILE = 19;
        const int WELL_TILE = 31;
        const int MAZE_TILE = 42;
        const int MAZE_DESTINATION_TILE = 39;
        const int PRISION_FROM_TILE = 50;
        const int PRISION_TO_TILE = 55;

        static void Main(string[] args)
        {
            var goose = new GooseGame(NUMBER_OF_TILES)
                .AddSpecialTile(new PrisionTile(PRISION_FROM_TILE, PRISION_TO_TILE))
                .AddSpecialTile(new MazeTile(MAZE_TILE, MAZE_DESTINATION_TILE))
                .AddSpecialTile(new WellTile(WELL_TILE))
                .AddSpecialTile(new HotelTile(HOTEL_TILE))
                .AddSpecialTile(new BridgeTile(BRIDGE_TILE, BRIDGE_DESTINATION_TILE))
                .AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new ConsoleGooseGamePrinter();
            goose.Print(printer);

            Console.ReadKey();
        }
    }
}
