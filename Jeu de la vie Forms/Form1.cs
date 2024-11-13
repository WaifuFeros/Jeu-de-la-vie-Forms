using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jeu_de_la_vie_Forms.Controls;

namespace Jeu_de_la_vie_Forms
{
    public partial class Form1 : Form
    {
        private Game game;
        private PictureBox pictureBox1; // Add this line to declare pictureBox1
        private LabelForSomeReason label; // Add this line to declare label
        private int n;

        public static int generation; // Déclaration de l'attribut generation

        public Form1(int n = 40)
        {
            InitializeComponent();
            pictureBox1 = new PictureBox(); // Initialize pictureBox1
            label = new LabelForSomeReason(); // Initialize label
            game = new Game(n, 100); // Initialize game
            generation = 0; // Initialiser generation à 0

            BackColor = Color.Black; // Set background color to black
            // Initialize Timer
            Timer timer = new Timer();
            timer.Interval = 200; // Set interval to 200ms
            timer.Tick += new EventHandler(UpdateGrid); // Assign UpdateGrid method
            timer.Start(); // Start the timer

            // Set PictureBox properties
            pictureBox1.Size = new Size(200, 200); // Example size
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // Set Label properties
            label.Text = "Label";
            label.AutoSize = true;

            // Center PictureBox and Label
            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.Width) / 2, (this.ClientSize.Height - pictureBox1.Height) / 2);
            label.Location = new Point((this.ClientSize.Width - label.Width) / 2, pictureBox1.Bottom + 10);

            // Add controls to the form
            this.Controls.Add(pictureBox1);
            this.Controls.Add(label);

            // Handle form resize event to keep controls centered
            this.Resize += new EventHandler(Form1_Resize);
            this.n = n;

            // Add Paint event handler
            pictureBox1.Paint += new PaintEventHandler(pctBox_main_Paint);
        }
        private void pctBox_main_Paint(object sender, PaintEventArgs e)
        {
            // Définir une brush blanche
            Brush whiteBrush = Brushes.White;

            // Boucler sur l’ensemble de la grille
            for (int i = 0; i < game.grid.TabCells.GetLength(0); i++)
            {
                for (int j = 0; j < game.grid.TabCells.GetLength(1); j++)
                {
                    // Si la cellule à cet emplacement est vivante :
                    if (game.grid.TabCells[i, j].IsAlive)
                    {
                        // Dessiner un rectangle plein à partir de la brush blanche de 5 par 5 pixels
                        e.Graphics.FillRectangle(whiteBrush, i * 5, j * 5, 5, 5);
                    }
                }
            }
        }

        private void UpdateGrid(object sender, EventArgs e)
        {
            // Logic to update the grid
            game.grid.UpdateGrid();
            pictureBox1.Invalidate(); // Refresh the PictureBox to trigger Paint event
            generation++; // Incrémenter generation de 1
            label.Text = $"Génération: {generation}"; // Mettre à jour le label avec la valeur de generation

            // Mise à jour de la fenêtre graphique
            pictureBox1.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.Width) / 2, (this.ClientSize.Height - pictureBox1.Height) / 2);
            label.Location = new Point((this.ClientSize.Width - label.Width) / 2, pictureBox1.Bottom + 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Définir la taille de la fenêtre
            this.Size = new Size(800, 600); // Exemple de taille

            // Définir le titre de la fenêtre
            this.Text = "Jeu de la Vie"; // Exemple de titre
        }

        public void MyTimerTick(object sender, EventArgs e)
        {

        }


    }
}
