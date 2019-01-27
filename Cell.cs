using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlubbsWayOfLife
{
    public class Cell
    {
        public Point Location => new Point(Rectangle.X, Rectangle.Y);

        public Size Size => Rectangle.Size;

        public Color Color { get; set; }

        public Rectangle Rectangle { get; set; }

        public Cell(Point location, Size size, Color color)
        {
            Rectangle = new Rectangle(location, size);
            Color = color;
        }

        public Cell(int x, int y, int width, int height, Color color)
        {
            Rectangle = new Rectangle(x, y, width, height);
            Color = color;
        }

        public bool Intersects(Cell cell)
        {
            return Rectangle.IntersectsWith(cell.Rectangle);
        }

        public void Moove()
        {
            Rectangle = new Rectangle(Rectangle.X + Playground.Random.Next(-1, 2), Rectangle.Y + Playground.Random.Next(-1, 2), Rectangle.Width, Rectangle.Height);
        }

        public void Draw(Graphics graphics)
        {
            using (var brush = new SolidBrush(Color))
                graphics.FillRectangle(brush, Rectangle);
        }
    }
}
