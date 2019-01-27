using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlubbsWayOfLife
{
    public class Playground : UserControl
    {
        public new bool Enabled { get; set; }

        private readonly List<Cell> cells = new List<Cell>();

        public static readonly Random Random = new Random();

        public Playground()
        {
            DoubleBuffered = true;

            Respawn();
        }

        public void Respawn()
        {
            for (int i = 0; i < 10; i++)
                SpawnCell(50, 50, Color.Black);
        }

        public void Nuke()
        {
            cells.Clear();
        }

        private void SpawnCell(int width, int height, Color color)
        {
            Cell cell;
            int retriesLeft = 5;

            do
            {
                var x = Random.Next(0, Math.Max(Size.Width - width, 0));
                var y = Random.Next(0, Math.Max(Size.Height - height, 0));
                cell = new Cell(x, y, width, height, color);

            }
            while (cells.Any(c => c.Intersects(cell)) && retriesLeft-- > 0);

            if (retriesLeft > 0)
                cells.Add(cell);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.CornflowerBlue);

            foreach (var cell in cells)
            {
                cell.Moove();
                cell.Draw(e.Graphics);
            }

            base.OnPaint(e);
        }
    }
}
