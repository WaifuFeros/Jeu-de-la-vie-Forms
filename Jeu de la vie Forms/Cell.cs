using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public bool NextState { get; set; }

        public Cell(bool state)
        {
            IsAlive = state;
            NextState = state;
        }

        public void ComeAlive()
        {
            NextState = true;
        }

        public void PassAway()
        {
            NextState = false;
        }

        public void Update()
        {
            IsAlive = NextState;
        }
    }
}
