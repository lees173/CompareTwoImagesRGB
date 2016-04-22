using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
           
            InitializeComponent();
        }

        public void SetDataSource(int[] r1,int[] r2,double n1, double n2)
        {
           // this.chart1.setd
          //  string[] seriesArray = { "Image 1", "Image 2" };

            
         //   chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
        //    chart1.BorderlineColor = System.Drawing.Color.FromArgb(26, 60, 100);
        //    chart1.BorderlineWidth = 3;
       //     chart1.BackColor = Color.NavajoWhite;

            chart1.ChartAreas.Add("chtArea");
            chart1.ChartAreas[0].AxisX.Title = "Count";
            chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
            chart1.ChartAreas[0].AxisY.Title = "Count";
            chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
            chart1.ChartAreas[0].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chart1.ChartAreas[0].BorderWidth = 2;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;

            chart2.Legends[0].LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Table;
            chart2.Legends[0].TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            chart2.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;

            // this.chart1.Legends.Add("Count");
            chart2.Titles.Add(this.Text);

            chart2.ChartAreas.Add("chtArea1");
            chart2.ChartAreas[0].AxisX.Title = "Count";
            chart2.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
            chart2.ChartAreas[0].AxisY.Title = "Count";
            chart2.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
            chart2.ChartAreas[0].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chart2.ChartAreas[0].BorderWidth = 2;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 255;



            chart1.Legends[0].LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Table;
            chart1.Legends[0].TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;

           // this.chart1.Legends.Add("Count");
            chart1.Titles.Add(this.Text);

            chart1.Series.Add(this.Text + "1");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[0].Color = Color.Red;

          //  this.chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";
            chart1.Series[0].BorderWidth = 1;
            chart1.Series[0].BorderColor = Color.Black;
          
            

            
           chart2.Series.Add(this.Text + "2");
           chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[0].Color = Color.Blue;

           // this.chart1.Series[0].IsValueShownAsLabel = true;
            chart2.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";
            chart2.Series[0].BorderWidth = 1;
            chart2.Series[0].BorderColor = Color.Black;
            
            
            for(int i=0;i<r1.Length;i++){
                chart1.Series[0].Points.AddXY(i, r1[i]);
                chart2.Series[0].Points.AddXY(i, r2[i]);
            }



            double total1 = 0;
            double total2 = 0;

            for (int i = 0; i < 256; i++)
            {
                total1 = total1 + r1[i]*i;
                total2 = total2 + r2[i]*i;

            }


            
            double mean1 = total1 / n1;
            double mean2 = total2 / n2;


            label1.Text = label1.Text + " " + Convert.ToString(mean1);
            label2.Text = label2.Text +" "+ Convert.ToString(mean2);

            double variance1 = 0; 
            double variance2 = 0;


            for (int i = 0; i < 256; i++)
            {
                variance1 = variance1 + Math.Pow(i - mean1, 2) * r1[i];
                variance2 = variance2 + Math.Pow(i - mean2, 2) * r2[i];

            }
            variance1 = variance1 / n1;
            variance2 = variance2 / n2;

            label3.Text = label3.Text + " " + Convert.ToString(variance1);
            label4.Text = label4.Text + " " + Convert.ToString(variance2);


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
