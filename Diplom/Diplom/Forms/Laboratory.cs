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
    public partial class Laboratory : Form
    {
        private int _idPatient;
        private Connects connects = new Connects();

        public Laboratory()
        {
            InitializeComponent();
        }

        public void Date(int idPatient)
        {
            _idPatient = idPatient;
        }

        private void buttonAddPatient_Click(object sender, EventArgs e)
        {
            if (Text == "Лабораторные исследования")
            {
                connects.InsertToTableLaboratoryreSearch(_idPatient, textBoxTitle.Text, dateTimePicker1.Value,
                    textBoxLaboratory.Text, textBoxIncarceration.Text);
            }
            else if (Text == "УЗИ")
            {
                connects.InsertToTableUltrasonography(_idPatient, textBoxTitle.Text, dateTimePicker1.Value,
                    textBoxLaboratory.Text, textBoxIncarceration.Text);
            }
            Close();
        }
    }
}
