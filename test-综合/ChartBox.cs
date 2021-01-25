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

namespace test1
{
    public partial class ChartBox : UserControl
    {
        public ChartBox()
        {
            InitializeComponent();
        }
        // 自定义属性
        // ----------------------------------
        private bool showChart = true;          // 控制是否显示直方图
        [Description("修改此值，可控制是否显示直方图"), Category("自定义属性")]
        public bool ShowChart                  // 控件的自定义属性值  
        {
            get
            {
                return showChart;
            }
            set
            {
                showChart = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private bool showLine = true;          // 控制是否显示折线图
        [Description("修改此值，可控制是否显示折线图"), Category("自定义属性")]
        public bool ShowLine                  // 控件的自定义属性值  
        {
            get
            {
                return showLine;
            }
            set
            {
                showLine = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private bool showDash = true;          // 控制是否显示折线图
        [Description("修改此值，可控制是否内部虚线网格"), Category("自定义属性")]
        public bool ShowDash                  // 控件的自定义属性值  
        {
            get
            {
                return showDash;
            }
            set
            {
                showDash = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private float[] values = new float[] { 1, 2, 5, 4, 1, 3, 8, 15, 6, 4, 8 };  // 存储颜色值的内部变量  
        [Description("修改此值，可修改概率直方图的概率值"), Category("自定义属性")]
        public float[] Values                  // 控件的自定义属性值  
        {
            get
            {
                return values;
            }
            set
            {
                values = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private Color colorBorder = Color.FromArgb(0, 192, 192);  // 存储颜色值的内部变量  
        [Description("修改此值，可修改外边框的颜色"), Category("自定义属性")]
        public Color ColorBorder                  // 控件的自定义属性值  
        {
            get
            {
                return colorBorder;
            }
            set
            {
                colorBorder = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private Color colorBorderDot = Color.Silver;  // 存储颜色值的内部变量  
        [Description("修改此值，可修改内部虚线的颜色"), Category("自定义属性")]
        public Color ColorBorderDot                  // 控件的自定义属性值  
        {
            get
            {
                return colorBorderDot;
            }
            set
            {
                colorBorderDot = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private Color colorNumber = Color.FromArgb(192, 0, 0);  // 存储颜色值的内部变量  
        [Description("修改此值，可修改刻度值颜色"), Category("自定义属性")]
        public Color ColorNumber                  // 控件的自定义属性值  
        {
            get
            {
                return colorNumber;
            }
            set
            {
                colorNumber = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private Font drawFont = new Font("Arial", 8);
        [Description("刻度值的绘制字体"), Category("自定义属性")]
        public Font DrawFont                  // 控件的自定义属性值  
        {
            get
            {
                return drawFont;
            }
            set
            {
                drawFont = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private Color colorChart = Color.FromArgb(128, 128, 255);  // 存储颜色值的内部变量  
        [Description("修改此值，可修改直方图颜色"), Category("自定义属性")]
        public Color ColorChart                  // 控件的自定义属性值  
        {
            get
            {
                return colorChart;
            }
            set
            {
                colorChart = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        private Color colorLine = Color.FromArgb(192, 0, 192);  // 存储颜色值的内部变量  
        [Description("修改此值，可修改折线图颜色"), Category("自定义属性")]
        public Color ColorLine                  // 控件的自定义属性值  
        {
            get
            {
                return colorLine;
            }
            set
            {
                colorLine = value;

                // 此处修改，为自定义属性变动时，执行的操作  
                this.Invalidate();  // 此处当颜色值属性变动时，使用新的颜色，使自定义控件重绘  
            }
        }

        // 自定义事件
        // ----------------------------------
        //public delegate void select_Handle(object sender, EventArgs e, string orther);  // 自定义事件的参数类型  
        //[Description("当点击控件时发生，调用选中当前控件逻辑"), Category("自定义事件")]
        //public event select_Handle This_Selected;                                       // 自定义事件名,  

        //在当前控件的某个默认事件中调用自定义事件，此处使用默认的Click事件时，调用自定义的选中事件This_Selected
        //private void SplitLineHorizontal_Click(object sender, EventArgs e)
        //{
        //    DrawColor = Color.Red;      // 定义选中控件时，显示为红色  
        //    if (This_Selected != null) This_Selected(this, new EventArgs(), "其它参数");//调用自定义事件  
        //}  

        /// <summary>
        /// 自定义图标控件
        /// </summary>

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //不进行背景的绘制  
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT  
                return cp;
            }
        }

        /// <summary>
        /// 直方图绘制
        /// </summary>
        private void ChartBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //float[] P = new float[] { 5, 4, 3, 2, 1, 9, 8, 7, 6, 5 };
            drawChart(g, Width, Height, Values);
        }



        /// <summary>
        /// 获取num整数部分的位数
        /// </summary>
        private int getNumLen(float num)
        {
            int len = 1;

            int n = (int)num;
            while (n > 10)
            {
                n /= 10;
                len++;
            }

            return len;
        }

        /// <summary>
        /// 在picBox上绘制概率直方图
        /// </summary>
        private void drawChart(Graphics g, float Width, float Height, float[] P)
        {
            float maxX = 1, maxY = 1;
            if (P != null || P.Length != 0)
            {
                maxX = P.Length;
                foreach (float p in P)
                {
                    if (maxY < p) maxY = p;
                }
            }

            drawChart(g, Width, Height, maxX, maxY, P);
        }

        private float _X = 34, _Y = 20, _B = 8;
        /// <summary>
        /// 在picBox上绘制概率直方图
        /// </summary>
        private void drawChart(Graphics g, float Width, float Height, float maxX, float maxY, float[] P)
        {
            int YL = getNumLen(maxY);
            _X = (float)(YL * 34 / 6) + _B;

            int XL = getNumLen(maxX);
            _Y = (float)(XL * 34 / 6) + _B;

            Pen pen = new Pen(Color.Black, 1);

            float X = (Width - _X - _B) / (maxX + 3);                   // 根据行最大值，自行计算水平间距值
            float Y = (Height - _Y - _B) / (maxY + 3);                  // 垂直间距值

            float DrawW = X * (maxX + 1), DrawH = Y * (maxY + 1);       // 绘制的最大宽度、高度

            DrawBorder(g, ColorBorder, ColorBorderDot, X, Y, DrawW, DrawH, ShowDash);   // 绘制边框刻度
            DrawNumber(g, DrawFont, ColorNumber, X, Y, DrawW, DrawH);           // 绘制刻度值

            //float[] P = new float[] { 5, 4, 3, 2, 1, 9, 8, 7, 6, 5 };
            if (showChart) Drawchart(g, ColorChart, X, Y, DrawW, DrawH, P);     // 绘制柱状图
            if (showLine) DrawchartLine(g, ColorLine, X, Y, DrawW, DrawH, P);   // 绘制折线图
        }

        /// <summary>
        /// 绘制概率直方图
        /// </summary>
        public void Drawchart(Graphics g, Color color, float X, float Y, float DrawW, float DrawH, float[] P)
        {
            Pen pen = new Pen(color, 1);

            float offX = X * 0.42f;
            int i = 0;

            // 在水平轴上方的柱状图
            float ix = X, iy = Y + DrawH;
            while (ix <= DrawW + X)
            {
                ix += X;
                if (i < P.Length)
                {
                    float Height = P[i] * Y;
                    //g.DrawRectangle(pen, ix - offX, iy - Height, 2 * offX, Height);

                    SolidBrush blueBrush = new SolidBrush(color);
                    g.FillRectangle(blueBrush, _X + ix - offX, iy - Height - 1, 2 * offX, Height);
                }
                i++;
            }
        }

        /// <summary>
        /// 绘制折线图
        /// </summary>
        public void DrawchartLine(Graphics g, Color color, float X, float Y, float DrawW, float DrawH, float[] P)
        {
            float x0 = -1, y0 = -1, x1 = -1, y1 = -1;

            Pen pen = new Pen(color, 1);

            float offX = X * 0.42f;
            int i = 0;

            // 在水平轴上方的柱状图
            float ix = X, iy = Y + DrawH;
            while (ix <= DrawW + X)
            {
                ix += X;
                if (i < P.Length)
                {
                    float Height = P[i] * Y;

                    x1 = _X + ix;
                    y1 = iy - Height - 1;

                    if (x0 != -1 && y0 != -1) g.DrawLine(pen, x0, y0, x1, y1);

                    x0 = x1;
                    y0 = y1;
                }
                i++;
            }
        }

        /// <summary>
        /// 绘制边框刻度线
        /// </summary>
        public void DrawBorder(Graphics g, Color color, Color colorDot, float X, float Y, float DrawW, float DrawH, bool showDot = true)
        {
            Pen pen = new Pen(color, 1);

            Pen pen2 = new Pen(colorDot, 1);
            pen2.DashStyle = DashStyle.Dot;

            // 绘制矩形外框
            g.DrawRectangle(pen, X + _X, Y, DrawW, DrawH);

            float unitX = (int)Math.Ceiling(16 / X);
            float unitY = (int)Math.Ceiling(16 / Y);

            // 绘制水平方向的刻度线
            float ix = X, iy = Y + DrawH;
            while (ix <= DrawW + X)
            {
                g.DrawLine(pen, ix + _X, iy, ix + _X, iy + 2);
                if (showDot) g.DrawLine(pen2, ix + _X, iy, ix + _X, iy - DrawH); // 绘制内部虚线

                ix += X * unitX;
            }

            // 绘制垂直方向的刻度线
            ix = X; iy = Y + DrawH;
            while (iy >= unitY)
            {
                g.DrawLine(pen, ix - 2 + _X, iy, ix + _X, iy);
                if (showDot) g.DrawLine(pen2, ix + _X, iy, ix + _X + DrawW, iy);// 绘制内部虚线
                iy -= Y * unitY;
            }
        }

        /// <summary>
        /// 绘制边框刻度线
        /// </summary>
        public void DrawNumber(Graphics g, Font font, Color color, float X, float Y, float DrawW, float DrawH)
        {
            float unitX = (int)Math.Ceiling(16 / X);
            float unitY = (int)Math.Ceiling(16 / Y);

            //float Size = X / 6;
            //if (Size < 8) Size = 8;

            float i = 0;

            // 绘制水平方向的刻度值
            float ix = X, iy = Y + DrawH;
            while (ix <= DrawW + X)
            {
                DrawString(g, font, color, _X + ix, iy + _B / 2, i + "", 90f, StringAlignment.Center, StringAlignment.Near);
                i += unitX;

                ix += X * unitX;
            }

            float j = 0;

            // 绘制垂直方向的刻度值
            ix = X; iy = Y + DrawH;
            while (iy >= unitY)
            {
                //float ix = ix + XX;
                //if(ix < 0) ix = 0;

                if (j > 0) DrawString(g, font, color, ix, iy, j + "", 360f, StringAlignment.Center, StringAlignment.Near);
                j += unitY;

                iy -= Y * unitY;
            }
        }
 
        /// <summary>
        ///在坐标x，y处绘制字符串str，绘制尺寸size
        /// </summary>
        //public void DrawString(Graphics g, Color color, float x, float y, string str, float angle = 0, StringAlignment H = StringAlignment.Center, StringAlignment L = StringAlignment.Center)
        //{
        //    //Font drawFont = new Font("Arial", size);
        //    SolidBrush drawBrush = new SolidBrush(color);
 
        //    //if (angle == 0) g.DrawString(str, drawFont, drawBrush, x, y);         //绘制对应的字符串
        //    //else 
        //    DrawString(g, str, DrawFont, drawBrush, new PointF(x, y), angle, H, L);
        //}
 
 
        /// <summary>  
        /// 绘制根据点旋转文本，一般旋转点给定位文本包围盒中心点  
        /// </summary>  
        /// <param name="s">文本</param>  
        /// <param name="font">字体</param>  
        /// <param name="brush">填充</param>  
        /// <param name="point">旋转点</param>  
        /// <param name="format">布局方式</param>  
        /// <param name="angle">角度</param>  
        public void DrawString(Graphics g, Font font, Color color, float x, float y, string s, float angle, StringAlignment H = StringAlignment.Center, StringAlignment L = StringAlignment.Center)
        {
            PointF point = new PointF(x, y);
            SolidBrush brush = new SolidBrush(color);

            // 绘制围绕点旋转的文本  
            StringFormat format = new StringFormat();
            format.Alignment = L;
            format.LineAlignment = H;

            // Save the matrix  
            Matrix mtxSave = g.Transform;

            Matrix mtxRotate = g.Transform;
            mtxRotate.RotateAt(angle, point);
            g.Transform = mtxRotate;

            g.DrawString(s, font, brush, point, format);

            // Reset the matrix  
            g.Transform = mtxSave;
        }

    }
}
