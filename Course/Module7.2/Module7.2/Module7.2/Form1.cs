using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module7._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.lblTime.Text = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            picImage.Image = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                // #1 sync
                // picImage.Load(openFileDialog1.FileName);
                // #2 async
                //picImage.WaitOnLoad = false;
                //picImage.LoadAsync(openFileDialog1.FileName);
                // #3
                lblNote.Text = "Wating until image loading";
                backgroundWorker1.RunWorkerAsync(openFileDialog1.FileName);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Value = 0;
            picImage.Load(e.Argument.ToString());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblNote.Text = "Select image";
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
    }
}
