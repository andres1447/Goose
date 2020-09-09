using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace V1.Test
{
    [TestClass]
    public class GooseGameShould
    {
        const int NUMBER_OF_TILES = 63;
        const int MOVE_FORWARD_MULTIPLE = 6;
        const int MOVE_FORWARD_STEPS = 2;
        const int BRIDGE_TILE = 6;
        const int BRIDGE_DESTINATION_TILE = 12;

        [TestMethod]
        public void PrintStayInEveryTile()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES);
            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            for (int i = 1; i <= NUMBER_OF_TILES; ++i)
            {
                printer.Verify(x => x.Print(It.Is<int>(t => t == i)), Times.Once);
            }
        }

        [TestMethod]
        public void PrintMoveForwardIfMultipleOfSix()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES);
            goose.AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            printer.Verify(x => x.Print(It.Is<int>(t => t % MOVE_FORWARD_MULTIPLE == 0), It.IsAny<MoveForwardTile>()), Times.Exactly(NUMBER_OF_TILES / MOVE_FORWARD_MULTIPLE));
        }

        [TestMethod]
        public void PrintBridgeIfTileIsSix()
        {
            // Given
            var goose = new GooseGame(NUMBER_OF_TILES);
            goose.AddSpecialTile(new BridgeTile(BRIDGE_TILE, BRIDGE_DESTINATION_TILE));
            goose.AddSpecialTile(new MoveForwardTile(MOVE_FORWARD_MULTIPLE, MOVE_FORWARD_STEPS));

            var printer = new Mock<IGooseGamePrinter>();

            // When
            goose.Print(printer.Object);

            // Then
            printer.Verify(x => x.Print(It.Is<int>(t => t == BRIDGE_TILE), It.IsAny<BridgeTile>()), Times.Once);
            printer.Verify(x => x.Print(It.Is<int>(t => t == BRIDGE_TILE), It.IsAny<MoveForwardTile>()), Times.Never);
        }
    }
}
