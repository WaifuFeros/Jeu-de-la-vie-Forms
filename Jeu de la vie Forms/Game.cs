using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jeu_de_la_vie_Forms
{
    public class Game
    {
        public Grid grid;

        private List<Coords> AliveCellsCord;
        private int n;
        private int iter;

        public Game(int nbCells, int nbIterations)
        {
            n = nbCells;
            iter = nbIterations;
            grid = new Grid(n, new List<Coords>() { new Coords(1, 0), new Coords(1, 1), new Coords(1, 2) });
        }

        public void RunGameConsole()
        {
            grid.DisplayGrid();

            for (int i = 0; i < Form1.generation; i++)
            {
                grid.UpdateGrid();
                grid.DisplayGrid();

                Thread.Sleep(1000);
            }
        }
    }
}
