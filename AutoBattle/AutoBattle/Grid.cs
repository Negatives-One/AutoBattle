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

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="size">Game battlefield size</param>
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

        /// <summary>
        /// prints the matrix that indicates the tiles of the battlefield
        /// </summary>
        /// <param name="size">Size of the battlefield that will be drawn</param>
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

        public List<GridTile> GetFreeTiles()
        {
            List<GridTile> freeTiles = new List<GridTile>();

            foreach (GridTile g in GridTiles)
            {
                if (!g.ocupied)
                {
                    freeTiles.Add(g);
                }
            }
            return freeTiles;
        }

        public void UpdateTile(GridTile tile)
        {
            for (int i = 0; i < GridTiles.Count; i++)
            {
                if (GridTiles[i].index == tile.index)
                {
                    GridTiles[i] = tile;
                }
            }
        }
    }
}
