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
    public partial class Symptoms : Form
    {
        private Connects connects = new Connects();
        private int _idPatient;

        public Symptoms()
        {
            InitializeComponent();
        }

        public void Date(int idPatient)
        {
            _idPatient = idPatient;
        }

        private void buttonAddSymptoms_Click(object sender, EventArgs e)
        {
            connects.InsertToTableSymptoms(_idPatient, textBoxNote.Text, dateTimePicker1.Value);
            Close();
        }


    }
}
