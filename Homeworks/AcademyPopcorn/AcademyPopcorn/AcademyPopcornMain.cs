using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            for (int row = 0; row < WorldRows; row++)
            {
                for (int col = 0; col < WorldCols; col++)
                {
                    if (row == 0)
                    {
                        IndestructibleBlock ceilBlock = new IndestructibleBlock(new MatrixCoords(row, col));
                        engine.AddObject(ceilBlock);
                    }
                    else if (col == 0 || col == WorldCols - 1)
                    {
                        IndestructibleBlock sideBlock = new IndestructibleBlock(new MatrixCoords(row, col));
                        engine.AddObject(sideBlock);
                    }
                }
            }

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //engine.AddObject(theBall);

            GiftBlock giftBlock = new GiftBlock(new MatrixCoords(4, 7));

            engine.AddObject(giftBlock);

            MeteoriteBall meteoBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(meteoBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            UnstoppableBall superBall = new UnstoppableBall(new MatrixCoords(11, 5), new MatrixCoords(-1, 1));

            engine.AddObject(superBall);

            UnpassableBlock superBlock = new UnpassableBlock(new MatrixCoords(7, 8));

            engine.AddObject(superBlock);

            ExplodingBlock explodeBlock = new ExplodingBlock(new MatrixCoords(4, 30), 3);

            engine.AddObject(explodeBlock);
        }

        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Engine gameEngine = new Engine(renderer, keyboard,500);
            EngineShootingRacket gameEngineShootingRacket = new EngineShootingRacket(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngineShootingRacket.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngineShootingRacket.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngineShootingRacket.ShootPlayerRacket();
            };

            Initialize(gameEngineShootingRacket);

            //

            gameEngineShootingRacket.Run();
        }
    }
}
