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
        public List<List<GridTile>> GridTiles = new List<List<GridTile>>();
        public Vector2 GridSize;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="size">Game battlefield size</param>
        public Grid(Vector2 size)
        {
            GridSize = size;
            Console.WriteLine("The battlefield has been created\n");
            for (int i = 0; i < GridSize.Y; i++)
            {
                GridTiles.Add(new List<GridTile>());
                for (int j = 0; j < GridSize.X; j++)
                {
                    GridTile newBox = new GridTile(new Vector2(i, j), null, (int)GridSize.X * i + j);
                    GridTiles[i].Add(newBox);
                }
            }
        }

        /// <summary>
        /// prints the matrix that indicates the tiles of the battlefield
        /// </summary>
        /// <param name="size">Size of the battlefield that will be drawn</param>
        public void DrawBattlefield()
        {
            for (int i = 0; i < (int)GridSize.X; i++)
            {
                for (int j = 0; j < (int)GridSize.Y; j++)
                {
                    GridTile currentgrid = GridTiles[j][i];
                    if (currentgrid.ocupiedBy != null)
                    {
                        if (currentgrid.ocupiedBy.IsEnemy)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        Console.Write("[" + currentgrid.ocupiedBy.Sprite + "]\t");
                        Console.BackgroundColor = ConsoleColor.Black;

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

            foreach (List<GridTile> i in GridTiles)
            {
                foreach (GridTile j in i)
                {
                    if (j.ocupiedBy == null)
                    {
                        freeTiles.Add(j);
                    }
                }
            }
            return freeTiles;
        }

        public void UpdateTile(GridTile tile)
        {
            for (int i = 0; i < GridTiles.Count; i++)
            {
                for (int j = 0; j < GridTiles[i].Count; j++)
                {
                    if (GridTiles[i][j].index == tile.index)
                    {
                        GridTiles[i][j] = tile;
                        return;
                    }
                }
            }
        }

        public Character ClosestCharacter(GridTile gridTile)
        {
            float distance = float.PositiveInfinity;
            Character character = null;
            for (int i = 0; i < GridTiles.Count; i++)
            {
                for (int j = 0; j < GridTiles[i].Count; j++)
                {
                    if (GridTiles[i][j].IsOcupied() && GridTiles[i][j].index != gridTile.index)
                    {
                        float d = Vector2.Distance(gridTile.position, GridTiles[i][j].position);
                        if (d < distance)
                        {
                            distance = d;
                            character = GridTiles[i][j].ocupiedBy;
                        }
                    }
                }
            }
            return character;
        }
    }
}
