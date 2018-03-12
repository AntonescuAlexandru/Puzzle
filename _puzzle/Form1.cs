using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _puzzle
{
    public partial class Form1 : Form
    {
        int clicks = 0;
        Point EmptyPoint;
        Image ToBeResize = null;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.BackgroundImage = ToBeResize;
            EmptyPoint.X = 0;
            EmptyPoint.Y = 0;
            button1.Click += MoveButton;
            button2.Click += MoveButton;
            button3.Click += MoveButton;
            button4.Click += MoveButton;
            button5.Click += MoveButton;
            button6.Click += MoveButton;
            button7.Click += MoveButton;
            button8.Click += MoveButton;
            button9.Click += MoveButton;
            button10.Click += MoveButton;
            button11.Click += MoveButton;
            button12.Click += MoveButton;
            button13.Click += MoveButton;
            button14.Click += MoveButton;
            button15.Click += MoveButton;
            label1.Text = "Idle";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            restart.Enabled = false;
            
      
        }

        private void MoveButton(object sender, EventArgs e)
        {
            int x = EmptyPoint.X - ((Button)sender).Location.X;
            int px = x < 0 ? -x : x;

            int y = EmptyPoint.Y - ((Button)sender).Location.Y;
            int py = y < 0 ? -y : y;

            if (((Button)sender).Location.Y.Equals(EmptyPoint.Y) && px.Equals(((Button)sender).Size.Width)) //Butonul se va deplasa pe orizontala
            {

                ((Button)sender).Location = new Point(((Button)sender).Location.X + x, ((Button)sender).Location.Y);
                EmptyPoint.X -= x;
                clicks++;
            }
            if (((Button)sender).Location.X.Equals(EmptyPoint.X) && py.Equals(((Button)sender).Size.Height))//Butonul se va deplasa pe verticala
            {
                ((Button)sender).Location = new Point(((Button)sender).Location.X, ((Button)sender).Location.Y + y);
                EmptyPoint.Y -= y;
                clicks++;  
            }
            label1.Text = "Clicks : " + clicks;
        
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG,JPG)|*.jpeg;*.bmp;*.png;*.jpg";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToBeResize = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = Resize(ToBeResize);
                AddImagesToButtons(ReturnCroppedList(Resize(ToBeResize), 70, 70));
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                restart.Enabled = true;
                restart.Enabled = true;
            }
        }


        private Bitmap Resize (Image img) {
            int w = 280;
            int h = 280;

            Bitmap bitmap = new Bitmap(w, h);
            Graphics graphic = Graphics.FromImage((Image)bitmap);
            //graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(img, 0, 0, w, h);
            return bitmap;    
        }

        public ArrayList ReturnCroppedList(Bitmap ToBeCropped, int x, int y) {

            ArrayList pictures = new ArrayList();
            int dreapta = 0;
            int jos = 0;


            for (int k = 0; k < 15; k++)
            {
                Bitmap piece = new Bitmap(x, y);

                for (int i = 0; i < x; i++)
                    for (int j = 0; j < y; j++)
                        piece.SetPixel(i, j, ToBeCropped.GetPixel(i + dreapta, j + jos));

                pictures.Add(piece);
                dreapta += 70;

                if (dreapta == 280) { dreapta = 0; jos += 70; }
                if (jos == 280) { break; }

            }
            return pictures;
        }
        private void AddImagesToButtons(ArrayList pictures) {
            int count = 0;
            int[] c = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            Amesteca(c);
            foreach (Button b in btn_group.Controls)
            {
                if (count < c.Length)
                {
                    b.Image = (Image)pictures[c[count]];
                    count++;
                }
            }
        }
        private void Amesteca(int[] array)
        {
            Random r = new Random();

            int start = r.Next(1, array.Length);
            for (int i = 0; i < array.Length; i++)
                for (int j = start; j > 0; j--)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
         //   return array;
            
        }

        private void restart_Click(object sender, EventArgs e)
        {
            AddImagesToButtons(ReturnCroppedList(Resize(ToBeResize), 70, 70));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
   

        /*private void MoveButton(Button button)
        {
            int x = EmptyPoint.X - button.Location.X;
            int px = x < 0 ? -x : x;

            int y = EmptyPoint.Y - button.Location.Y;
            int py = y < 0 ? -y : y;

            if (button.Location.Y.Equals(EmptyPoint.Y) && px.Equals(button.Size.Width))
            {

                button.Location = new Point(button.Location.X + x, button.Location.Y);
                EmptyPoint.X -= x;


            }
            if (button.Location.X.Equals(EmptyPoint.X) && py.Equals(button.Size.Width))
            {
                button.Location = new Point(button.Location.X, button.Location.Y + y);
                EmptyPoint.Y -= y;
            }
        }*/
    }
}
