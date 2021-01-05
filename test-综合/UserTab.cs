using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test1.Properties;

namespace test1
{
    public partial class UserTab : TabControl
    {

        public UserTab()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);//允许使用自定义的绘制方式
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);//控件忽略窗口信息WM_ERASEBKGND 以减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//使用双缓冲，首先将控件绘制到缓冲区而不是直接绘制到屏幕，减少闪烁
            SetStyle(ControlStyles.ResizeRedraw, true);//当控件大小发生变化时重新进行绘制
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);//控件接受alpha组件数小于255个的BackColor来模拟透明度
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle TabControlArea = ClientRectangle;
            Rectangle TabArea = DisplayRectangle;
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, 0, 0, Width, Height);
            g.DrawLine(new Pen(Color.FromArgb(255, 155, 194, 244), 2), 0, 0, 0, Height);
            g.DrawLine(new Pen(Color.FromArgb(255, 155, 194, 244), 2), 0, Height, Width, Height);
            g.DrawLine(new Pen(Color.FromArgb(255, 155, 194, 244), 2), Width, 0, Width, Height);
            TextureBrush TabBackground = new TextureBrush(Resources.Back);
            g.FillRectangle(TabBackground, 0, 0, Width, Resources.Back.Height);
            TabBackground.Dispose();//释放资源
            for (int i = 0; i < TabPages.Count; i++)
            {
                bool bSelected = (SelectedIndex == i);
                Rectangle recBounds = GetTabRect(i);
                RectangleF tabTextArea = (RectangleF)GetTabRect(i);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Far;
                if (bSelected)
                {
                    TextureBrush tabSelected = new TextureBrush(Resources.wallhaven_2em38y);
                    tabSelected.TranslateTransform(recBounds.Left, recBounds.Top);
                    g.FillRectangle(tabSelected, recBounds.Left, recBounds.Top, recBounds.Width, recBounds.Height);
                    tabSelected.Dispose();
                    //g.DrawImage(Resources.wallhaven_)
                    Font font = new Font(Font.FontFamily, 12, FontStyle.Bold);
                   // Brush brush=new SolidBrush(Color.)
                }

            }
        }

    }
}
