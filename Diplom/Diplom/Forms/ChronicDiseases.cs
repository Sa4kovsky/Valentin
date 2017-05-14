using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom.Connect;

namespace Diplom.Forms
{
    public partial class ChronicDiseases : Form
    {
        private Connects connects = new Connects();
        private int _idPatient;

        public ChronicDiseases()
        {
            InitializeComponent();
        }

        public void Date(int idPatient)
        {
            _idPatient = idPatient;
        }

        private void buttonAddPatient_Click(object sender, EventArgs e)
        {
            if (Text == "Хронические заболевания")
            {
                connects.InsertToTableChronicDiseases(_idPatient, textBoxTitle.Text, dateTimePicker1.Value,
                    textBoxNote.Text);
            }
            else if (Text == "Прививки")
            {
                connects.InsertToTableInoculations(_idPatient, textBoxTitle.Text, dateTimePicker1.Value,
                    textBoxNote.Text);
            }
            Close();
        }

    }

}

