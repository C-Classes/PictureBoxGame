using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBoxGame
{
    public partial class Form1 : Form
    {
        Graphics gr;

        PictureBox pb1 = new PictureBox();
        PictureBox pb2 = new PictureBox();
        PictureBox pb3 = new PictureBox();
        PictureBox pb4 = new PictureBox();

        Color activeColor;

        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<Color> colors = new List<Color>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gr = this.CreateGraphics();

            timerDraw.Start();

            colors.Add(Color.Red);
            colors.Add(Color.Blue);
            colors.Add(Color.Green);
            colors.Add(Color.Yellow);

            for (int i_pb = 0; i_pb < 4; i_pb++)
            {
                PictureBox pb = new PictureBox();

                pb.Name = "pb" + i_pb.ToString();
                pb.Location = new Point(100, 100 * i_pb);
                
                pb.BackColor = colors[i_pb];

                pb.Width = 100;
                pb.Height = 100;
                pb.Click += new EventHandler(pb_Click);//tema
                pb.MouseEnter += new EventHandler(pictureBoxEnter);
                pb.MouseLeave += new EventHandler(pictureBoxLeave);

                pictureBoxes.Add(pb);
            }

            for (int i_pb = 0; i_pb < 4; i_pb++)
                this.Controls.Add(pictureBoxes[i_pb]);
        }

        private void pictureBoxLeave(object sender, EventArgs e)
        {
            label1.Text = "We left some picturebox";
        }

        private void pictureBoxEnter(object sender, EventArgs e)
        {
            label1.Text = "We entered some picturebox";
        }


        private void pb_Click(object sender, EventArgs e)//tema EventArgs, sender
        {
            var pictureBox = (PictureBox)sender; //get active picturebox
            
            int activePB = pictureBox.Name[2] - '0'; //tema ASCII; get the last char of picturebox name

            activeColor = pictureBoxes[activePB].BackColor; //set activeColor variable to the color of the clicked pb
            pictureBox1.BackColor = pictureBoxes[activePB].BackColor; //set pb1 color to active's pb color
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_BackColorChanged(object sender, EventArgs e)
        {
            MessageBox.Show("The background color was changed to: " + pictureBox1.BackColor.ToString());
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            Pen drawPen = new Pen(activeColor, 1);
            if(Control.MouseButtons == MouseButtons.Left) //draw when left-click is pressed
                gr.DrawRectangle(drawPen, MousePosition.X, MousePosition.Y - 23, 1, 1);
        }
    }
}
