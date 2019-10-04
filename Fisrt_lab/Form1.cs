using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fisrt_lab
{
    public partial class Form1 : Form
    {
        Bitmap image;
        private List<Bitmap> ListBm;
        private int[,] kernel = null;
        public Form1()
        {
            InitializeComponent();
            image = new Bitmap(300, 300);
            ListBm = new List<Bitmap>();
            ListBm.Add(new Bitmap(image));
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files| *.png; *.jpg; *.bmp| All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
            }
            pictureBox1.Image = image;
            pictureBox1.Refresh();
            ListBm.Add(new Bitmap(image));
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InverseFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if(backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                ListBm.Add(new Bitmap(image));
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();

        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void brightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sharpnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog.OpenFile();
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ListBm.Count != 2)
            {
                ListBm.RemoveAt(ListBm.Count - 1);
                image = ListBm[ListBm.Count - 1];
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
                
        }

        private void grayWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorld();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void autolevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new AutolevelsFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TransferFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void waveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new WaveFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void boundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BoundFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void maxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MaxFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void glowingBoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlowingBoundsFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void dilatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new DilationFilter(kernel);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ErosionFilter(kernel);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new OpeningFilter(kernel);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ClosingFilter(kernel);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlackHatFilter(kernel);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void changeKernelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            kernel = form2.kernel;
        }

        private void gaussianDevidedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussDevidedFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
