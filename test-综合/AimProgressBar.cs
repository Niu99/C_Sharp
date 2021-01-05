using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class AimProgressBar : ProgressBar
    {
        public AimProgressBar()
        {
            //InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rectangle = e.ClipRectangle;
            rectangle.Width = (int)(rectangle.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            }
            rectangle.Height = rectangle.Height - 4;
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(47, 220, 232)), 2, 2, rectangle.Width, rectangle.Height);
        }
    }
}
