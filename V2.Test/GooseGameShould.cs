using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace V2.Test
{
    [TestClass]
    public class GooseGameShould
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

        [TestMethod]
        public void PrintStayInEveryTile()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES);
            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            printer.Verify(x => x.Print(It.IsAny<int>()), Times.Exactly(NUMBER_OF_TILES));
        }

        [TestMethod]
        public void PrintMoveForwardIfMultipleOf6()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES)
            .AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            printer.As<IGooseGameSpecialTilePrinter>().Verify(x => x.Print(It.Is<int>(t => t % MOVE_FORWARD_MULTIPLE == 0), It.IsAny<MoveForwardTile>()), Times.Exactly(NUMBER_OF_TILES / MOVE_FORWARD_MULTIPLE));
        }

        [TestMethod]
        public void PrintTheBridgeIfTileIs6()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES)
                .AddSpecialTile(new BridgeTile(BRIDGE_TILE, BRIDGE_DESTINATION_TILE))
                .AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            printer.As<IGooseGameSpecialTilePrinter>().Verify(x => x.Print(It.Is<int>(t => t == BRIDGE_TILE), It.IsAny<BridgeTile>()), Times.Once);
            printer.As<IGooseGameSpecialTilePrinter>().Verify(x => x.Print(It.Is<int>(t => t == BRIDGE_TILE), It.IsAny<MoveForwardTile>()), Times.Never);
        }

        [TestMethod]
        public void PrintTheHotelIfTileIs19()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES)
                .AddSpecialTile(new HotelTile(HOTEL_TILE))
                .AddSpecialTile(new BridgeTile(BRIDGE_TILE, BRIDGE_DESTINATION_TILE))
                .AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            printer.As<IGooseGameSpecialTilePrinter>().Verify(x => x.Print(It.Is<int>(t => t == HOTEL_TILE), It.IsAny<HotelTile>()), Times.Once);
        }

        [TestMethod]
        public void PrintTheWellIfTileIs31()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES)
                .AddSpecialTile(new WellTile(WELL_TILE))
                .AddSpecialTile(new HotelTile(HOTEL_TILE))
                .AddSpecialTile(new BridgeTile(BRIDGE_TILE, BRIDGE_DESTINATION_TILE))
                .AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            printer.As<IGooseGameSpecialTilePrinter>().Verify(x => x.Print(It.Is<int>(t => t == WELL_TILE), It.IsAny<WellTile>()), Times.Once);
        }

        [TestMethod]
        public void PrintTheMazeIfTileIs42()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES)
                .AddSpecialTile(new MazeTile(MAZE_TILE, MAZE_DESTINATION_TILE))
                .AddSpecialTile(new WellTile(WELL_TILE))
                .AddSpecialTile(new HotelTile(HOTEL_TILE))
                .AddSpecialTile(new BridgeTile(BRIDGE_TILE, BRIDGE_DESTINATION_TILE))
                .AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            printer.As<IGooseGameSpecialTilePrinter>().Verify(x => x.Print(It.Is<int>(t => t == MAZE_TILE), It.IsAny<MazeTile>()), Times.Once);
        }

        [TestMethod]
        public void PrintThePrisionIfTileIsBetween50And55()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES)
                .AddSpecialTile(new PrisionTile(PRISION_FROM_TILE, PRISION_TO_TILE))
                .AddSpecialTile(new MazeTile(MAZE_TILE, MAZE_DESTINATION_TILE))
                .AddSpecialTile(new WellTile(WELL_TILE))
                .AddSpecialTile(new HotelTile(HOTEL_TILE))
                .AddSpecialTile(new BridgeTile(BRIDGE_TILE, BRIDGE_DESTINATION_TILE))
                .AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            for (int i = PRISION_FROM_TILE; i <= PRISION_TO_TILE; ++i)
            {
                printer.As<IGooseGameSpecialTilePrinter>().Verify(x => x.Print(It.Is<int>(t => t == i), It.IsAny<PrisionTile>()), Times.Once);
            }
        }
    }
}
