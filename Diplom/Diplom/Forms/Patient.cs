using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom.Connect;

namespace Diplom.Forms
{
    public partial class Patient : Form
    {
        private string photo;
        Connects connects = new Connects();
        public Patient()
        {
            InitializeComponent();
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Image files (*.PNG)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open);
                System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                fs.Close();
                pictureBox1.Image = img;
                img.Save("Photo\\" + Path.GetFileName(openFileDialog1.FileName), System.Drawing.Imaging.ImageFormat.Png);
                photo = "Photo\\" + Path.GetFileName(openFileDialog1.FileName);
            }

        }

        private void buttonAddPatient_Click(object sender, EventArgs e)
        {
            connects.InsertToTablePatients(photo, textBoxName.Text, dateBirthday.Value, textBoxAddress.Text, maskedTextBoxPhone.Text, textBoxEmail.Text, textBoxWork.Text);
            textBoxName.Text = "";
            dateBirthday.Value = DateTime.Now;
            textBoxAddress.Text = "";
            maskedTextBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxWork.Text = "";
            Close();
        }


    }
}
