using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlubbsWayOfLife
{
    public partial class Form1 : Form
    {
        private uint generation = 0;
        private uint lifeTime = 0;

        public Form1()
        {
            InitializeComponent();
            playground.Click += (s, e) =>
            {
                ((Playground)s).Nuke();
                ((Playground)s).Respawn();
                ((Playground)s).Refresh();

                generation++;
                lifeTime = 0;
            };

            timer.Interval = 1;
            timer.Tick += (s, e) =>
            {
                playground.Invalidate();
                lifeTime++;
                Text = $"Generation: {generation} Lifetime: {lifeTime}";
            };
            timer.Start();
        }
    }
}
