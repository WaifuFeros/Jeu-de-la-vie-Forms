using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeu_de_la_vie_Forms.Controls
{
    public class MainPanel : PictureBox
    {
        public MainPanel(int n)
        {
            Name = "pnl_main";
            BackColor = Color.Black;
            Anchor = AnchorStyles.None;
            Size = new Size(n * 5, n * 5);
            Dock = DockStyle.None;
        }
    }


}