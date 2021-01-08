
namespace test1
{
    partial class Spectrum_waterfall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.comlWaterfallChartControl1 = new test1.ComlWaterfallChartControl();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(0, -3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(284, 155);
            this.zedGraphControl1.TabIndex = 1;
            // 
            // comlWaterfallChartControl1
            // 
            this.comlWaterfallChartControl1.Location = new System.Drawing.Point(326, 12);
            this.comlWaterfallChartControl1.Name = "comlWaterfallChartControl1";
            this.comlWaterfallChartControl1.Size = new System.Drawing.Size(624, 398);
            this.comlWaterfallChartControl1.TabIndex = 2;
            // 
            // Spectrum_waterfall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 568);
            this.Controls.Add(this.comlWaterfallChartControl1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Spectrum_waterfall";
            this.Text = "Spectrum_waterfall";
            this.Load += new System.EventHandler(this.Spectrum_waterfall_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ComlWaterfallChartControl comlWaterfallChartControl1;
    }
}