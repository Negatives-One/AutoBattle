using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;

namespace AutoBattle
{
    public class Grid
    {
        public List<GridTile> GridTiles = new List<GridTile>();
        public Vector2 GridSize;
        public Grid(Vector2 size)
        {
            GridSize = size;
            Console.WriteLine("The battle field has been created\n");
            for (int i = 0; i < GridSize.X; i++)
            {
                for (int j = 0; j < GridSize.Y; j++)
                {
                    GridTile newBox = new GridTile(new Vector2(j, i), false, (int)GridSize.X * i + j);
                    GridTiles.Add(newBox);
                    Console.Write($"{newBox.index}\n");
                }
            }
        }

        // prints the matrix that indicates the tiles of the battlefield
        public void DrawBattlefield(Vector2 size)
        {
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    GridTile currentgrid = new GridTile();
                    if (currentgrid.ocupied)
                    {
                        //if()
                        Console.Write("[X]\t");
                    }
                    else
                    {
                        Console.Write($"[ ]\t");
                    }
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }

    }
}
