using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2k_2021_02_11.Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            //System.Drawing.Graphics g = mainPanel.CreateGraphics();
            Pen pen = new Pen(Color.Red, 5);
            g.DrawRectangle(pen, 10, 10, 300, 200);
            //Brush brush = new SolidBrush(Color.Blue);
            Rectangle r = new Rectangle(10, 10, 300, 200);
            Brush brush = new LinearGradientBrush(r,
                Color.Red,
                Color.Blue,
                45);
            g.FillEllipse(brush, 10, 400, 300, 200);
        }

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            mainPanel.Invalidate();
        }

        private Point lastPos = new Point(0, 0);
        private bool pressed = false;
        private Color c;

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPos.X = e.X;
            lastPos.Y = e.Y;
            pressed = true;
            if (e.Button == MouseButtons.Left)
            {
                c = Color.Green;
            } else if (e.Button == MouseButtons.Right)
            {
                c = Color.Aqua;
            }
        }

        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            pressed = false;
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (pressed)
            {
                System.Drawing.Graphics g = mainPanel.CreateGraphics();
                Pen p = new Pen(c, 25);
                p.StartCap = p.EndCap = LineCap.Round;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawLine(p, lastPos, e.Location);
                lastPos = e.Location;
            }
        }
    }
}
