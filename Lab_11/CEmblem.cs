using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_11
{
    class CEmblem
    {
        const int DefaultRadius = 50;

        private Graphics graphics;
        private int _radius;

        public int X { get; set; }
        public int Y { get; set; }
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value >= 200 ? 200 : value;
                _radius = value <= 5 ? 5 : value;
            }
        }

        public CEmblem(Graphics graphics, int X, int Y)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = DefaultRadius;
        }

        public CEmblem(Graphics graphics, int X, int Y, int Radius)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
        }

        private void Draw(Pen pen)
        {
            Rectangle circl = new Rectangle(X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            graphics.DrawEllipse(pen, circl);
            Rectangle cube = new Rectangle(X - (Radius), Y - (Radius) + Radius * 2, Radius * 2, Radius * 2);
            graphics.DrawRectangle(pen, cube);
            double r = (Radius);
            Point p1 = new Point(X - (int)(r * Math.Cos(Math.PI / 6)), Y - 2 + (int)(r * Math.PI / 3) - Radius * 2);
            Point p2 = new Point(X - (int)(r * Math.Cos(Math.PI / 2)), Y - (int)(r * Math.PI / 6) - Radius * 2);
            Point p3 = new Point(X + (int)(r * Math.Cos(Math.PI / 6)), Y - 2 + (int)(r * Math.PI / 3) - Radius * 2);
            Point[] triangle = { p1, p2, p3 };
            graphics.DrawPolygon(pen, triangle);
        }

        public void Show()
        {
            Draw(Pens.Red);
        }

        public void Hide()
        {
            Draw(Pens.White);
        }

        public void Expand()
        {
            Hide();
            Radius++;
            Show();
        }

        public void Expand(int dR)
        {
            Hide();
            Radius += dR;
            Show();
        }

        public void Collapse()
        {
            Hide();
            Radius--;
            Show();
        }
        public void Collapse(int dR)
        {
            Hide();
            Radius -= dR;
            Show();
        }

        public void Move(int dX, int dY)
        {
            Hide();
            X = X + dX;
            Y = Y + dY;
            Show();
        }
    }
}