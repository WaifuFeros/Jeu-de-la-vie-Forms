using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie
{
    public class Grid
    {
        public int N {  get; set; }

        public Cell[,] TabCells;

        private const string GRID_HORIZONTAL_EDGE_TILING = "---+";
        private const string GRID_VERTICAL_EDGE_SEPARATOR = " | ";
        private const string ALIVE_CELL = "X";
        private const string DEAD_CELL = " ";

        private string _gridHorizontalEdge;

        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            N = nbCells;
            TabCells = new Cell[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    bool isAlive = AliveCellsCoords.Contains(new Coords(i, j));
                    TabCells[i, j] = new Cell(isAlive);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("+");
            for (int i = 0; i < N; i++)
                sb.Append(GRID_HORIZONTAL_EDGE_TILING);

            _gridHorizontalEdge = sb.ToString();
        }

        public int GetNbAliveNeighboor(int i, int j)
        {
            var coords = GetCoordsNeighboors(i, j);

            int aliveCount = 0;
            foreach (var coord in coords)
            {
                if (TabCells[coord.X, coord.Y].IsAlive)
                    aliveCount++;
            }

            Console.Write($"{aliveCount} | ");

            return aliveCount;
        }

        public List<Coords> GetCoordsNeighboors(int i, int j)
        {
            var coords = new List<Coords>();

            for (int ix = i - 1; ix < i + 2; ix++)
            {
                for (int iy = j - 1; iy < j + 2; iy++)
                {
                    if (ix == i && iy == j)
                        continue;

                    if (ix >= 0 && ix < N && iy >= 0 && iy < N)
                        coords.Add(new Coords(ix, iy));
                }
            }

            return coords;
        }

        public List<Coords> GetCoordsCellsAlive()
        {
            var coords = new List<Coords>();

            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    if (TabCells[x, y].IsAlive)
                        coords.Add(new Coords(x, y));
                }
            }

            return coords;
        }

        public void DisplayGrid()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_gridHorizontalEdge);
            for (int x = 0; x < N; x++)
            {
                sb.Append("| ");

                for(int y = 0; y < N; y++)
                {
                    sb.Append(TabCells[x, y].IsAlive ? ALIVE_CELL : DEAD_CELL);
                    sb.Append(GRID_VERTICAL_EDGE_SEPARATOR);
                }
                sb.AppendLine();

                sb.AppendLine(_gridHorizontalEdge);
            }

            Console.WriteLine(sb.ToString());
        }

        public void UpdateGrid()
        {
            // Change next state
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    var currentCell = TabCells[x, y];
                    int aliveNeighboors = GetNbAliveNeighboor(x, y);
                    
                    if (!currentCell.IsAlive && aliveNeighboors == 3)
                        currentCell.ComeAlive();
                    else if (!(currentCell.IsAlive && (aliveNeighboors == 2 || aliveNeighboors == 3)))
                        currentCell.PassAway();
                }
            }

            // Update state
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    TabCells[x, y].Update();
                }
            }
        }
    }
}
