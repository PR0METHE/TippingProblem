using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
namespace yzbahsis
{
    
    public partial class Form1 : Form
    {

        float bahsis=0;
        Fuzzy bsyemek=new Fuzzy();
        Fuzzy bshizmet=new Fuzzy();
        float ptyemek, pthizmet;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (yemekpt.Text != "")
            {
                bsyemek.setpt(float.Parse(yemekpt.Text));
                ptyemek = float.Parse(yemekpt.Text);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void servispt_TextChanged(object sender, EventArgs e)
        {
            if (servispt.Text != "")
            {
                bshizmet.setpt(float.Parse(servispt.Text));
                pthizmet = float.Parse(servispt.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void plotView1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((bshizmet != null) && (bsyemek != null))
            {
                if ((ptyemek < 2.5) || (pthizmet < 2.5))
                        bahsis = 0;
               else
               { 
                    bahsis=(float)(0.5*(bshizmet.yuzdeBahsis() + bsyemek.yuzdeBahsis()));
                    
               }
               textBox1.Text = bahsis.ToString();
            }
           
            PlotModel model = new PlotModel();
            var myModel = new PlotModel { Title = "Example 1" };

            int py1;
            if (ptyemek < 5)
                py1 = 100 - (int)(10 * ptyemek);
            else
                py1 = 0;
             var p1 = new LineSeries();
             p1.Points.Add(new DataPoint(0, 0));
             p1.Points.Add(new DataPoint(0, py1));
             p1.Points.Add(new DataPoint((int)(py1)*5,py1));
            p1.Points.Add(new DataPoint(500, 0));



            this.plotView1.Model = model;
            model.Series.Add(p1);
            int py2 ;
            var p2 = new LineSeries();
            int x1, x2;

            if(ptyemek==10)
            {
                p2.Points.Add(new DataPoint(500, 0));
                p2.Points.Add(new DataPoint(1000, 200));
                p2.Points.Add(new DataPoint(1000, 0));

            }

            if (ptyemek <= 5)
            {
                py2 = (int)(0.2 * 100 * ptyemek);
                x1 =5 * py2;
                p2.Points.Add(new DataPoint(0, 0));
                p2.Points.Add(new DataPoint(x1, py2));
                p2.Points.Add(new DataPoint(1000-x1, py2));
                p2.Points.Add(new DataPoint(1000, 0));

            }

            else
            {
                
                py2 = 200 - (int)(0.2 * ptyemek * 100);
                x2 = (200 - py2)*5;
                p2.Points.Add(new DataPoint(0, 0));
                p2.Points.Add(new DataPoint(1000-x2, py2));
                p2.Points.Add(new DataPoint(x2, py2));
                p2.Points.Add(new DataPoint(1000, 0));
            }
            

            model.Series.Add(p2);
            int py3;
            if (ptyemek > 5)
                py3 =100- (int)(10*ptyemek);
            else
                py3 = 0;
            var p3 = new LineSeries();
            
            p3.Points.Add(new DataPoint(500, 0));
            p3.Points.Add(new DataPoint(500+5*py3, py3));
            p3.Points.Add(new DataPoint(1000 , py3));
            p3.Points.Add(new DataPoint(1000, 0));
            model.Series.Add(p3);

            PlotModel model1 = new PlotModel();
            int y1;
            if (pthizmet < 5)
                y1 = 100 - (int)(10 * pthizmet);
            else
                y1 = 0;
            var xh1 = new LineSeries();
            xh1.Points.Add(new DataPoint(0, 0));
            xh1.Points.Add(new DataPoint(0, y1));
            xh1.Points.Add(new DataPoint(y1* 5, y1));
            xh1.Points.Add(new DataPoint(500, 0));

            this.plotView2.Model = model1;
            model1.Series.Add(xh1);
            int y2;
            var xh2 = new LineSeries();
            int xd1, xd2;

            if (pthizmet == 10)
            {
                xh2.Points.Add(new DataPoint(500, 0));
                xh2.Points.Add(new DataPoint(1000, 200));
                xh2.Points.Add(new DataPoint(1000, 0));

            }

            if (pthizmet <= 5)
            {
                y2 = (int)(0.2 * 100 * pthizmet);
                xd1 = 5 * y2;
                xh2.Points.Add(new DataPoint(0, 0));
                xh2.Points.Add(new DataPoint(xd1, y2));
                xh2.Points.Add(new DataPoint(1000 - xd1, y2));
                xh2.Points.Add(new DataPoint(1000, 0));

            }

            else
            {
                y2 = 200 - (int)(0.2 * pthizmet * 100);
                xd2 = (200 - y2) * 5;
                xh2.Points.Add(new DataPoint(0, 0));
                xh2.Points.Add(new DataPoint(1000 - xd2, y2));
                xh2.Points.Add(new DataPoint(xd2, y2));
                xh2.Points.Add(new DataPoint(1000, 0));
            }

            model1.Series.Add(xh2);
            int y3;
            if (pthizmet > 5)
                y3 = 100 - (int)(10 * pthizmet);
            else
                y3 = 0;
            var xh3 = new LineSeries();

            xh3.Points.Add(new DataPoint(500, 0));
            xh3.Points.Add(new DataPoint(500 + 5 * y3, y3));
            xh3.Points.Add(new DataPoint(1000, y3));
            xh3.Points.Add(new DataPoint(1000, 0));
            model1.Series.Add(xh3);
        }
    }
}
