using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarnsleyFern
{
    public partial class CfrmBarnsleyFern : Form
    {
        static Random ProbabilitySelector;
        static double X = 0, Y = 0;
        static Graphics draw;
        public CfrmBarnsleyFern()
        {
            InitializeComponent();
            draw = pnlDraw.CreateGraphics();
            ProbabilitySelector = new Random((int)DateTime.Now.Ticks);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            SolidBrush solid = new SolidBrush(Color.LawnGreen);

            for (int i = 0; i < 100000; i++)
            {
                int Select = ProbabilitySelector.Next(100);
                double tempX = X;

                if (Select <1)
                {
                    X = 0;
                    Y = 0.16 * Y;
                }
                else if (Select < 86)
                {
                    X = 0.85 * X + 0.04 * Y;
                    Y = -0.04 * tempX + 0.85 * Y + 1.6;
                }
                else if (Select < 93)
                {
                    X = 0.2 * X - 0.26 * Y;
                    Y = 0.23 * tempX + 0.22 * Y + 1.6;
                }
                else
                {
                    X = -0.15 * X + 0.28 * Y;
                    Y = 0.226 * tempX + 0.24 * Y + 0.44;
                }
                draw.FillEllipse(solid,(int)(300 + 50 * X),(int)(43 * Y),3,3);

            }
        }
    }
}
