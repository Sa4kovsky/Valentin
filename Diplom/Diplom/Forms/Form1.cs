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
using Diplom.Forms;
using Patient = Diplom.Object.Patient;

namespace Diplom
{
    public partial class Form1 : Form
    {
        private Connects connects = new Connects();
        Forms.Patient patient = new Forms.Patient();
        CardPatients cardPatients = new CardPatients();

        private int _idPatient;
        private string _photo;
        private string _namePatient;
        private DateTime _birthday;
        private string _address;
        private string _phone;
        private string _email;
        private string _work;
        public Form1()
        {
            InitializeComponent();
            Connect();
            InitTable();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            connects.Patients.Clear();
            connects.ShowFieldsPatients();
            OutputTable(connects.Patients);
        }
        private void Connect()
        {
            try
            {
                File.Exists(@"connect.txt");
                connects.ConnectsSQL(@"connect.txt");
            }
            catch (Exception e)
            {
                MessageBox.Show("Проверьте файл: Diplom\\Diplom\\bin\\Debug\\connect.txt ");
            }
        }

        public void InitTable() //Инициализация таблицы 
        {
            dgvPatients.ColumnCount = 8;
            dgvPatients.Columns[0].Width = 50;
            dgvPatients.Columns[1].Width = 50;
            dgvPatients.Columns[2].Width = 300;
            dgvPatients.Columns[3].Width = 100;
            dgvPatients.Columns[4].Width = 300;
            dgvPatients.Columns[5].Width = 100;
            dgvPatients.Columns[6].Width = 200;
            dgvPatients.Columns[7].Width = 237;


            dgvPatients.Columns[0].Name = "№";
            dgvPatients.Columns[0].Visible = false;
            dgvPatients.Columns[1].Name = "Фото";
            dgvPatients.Columns[1].Visible = false;
            dgvPatients.Columns[2].Name = "ФИО";
            dgvPatients.Columns[3].Name = "День рождения";
            dgvPatients.Columns[4].Name = "Адрес";
            dgvPatients.Columns[5].Name = "Телефон";
            dgvPatients.Columns[6].Name = "Почта";
            dgvPatients.Columns[7].Name = "Место работы";
        }

        public void OutputTable(List<Patient> viewContracts) //запись в таблицу
        {
            dgvPatients.RowCount = viewContracts.Count;
            for (int i = 0; i < viewContracts.Count; i++)
            {
                dgvPatients[0, i].Value = viewContracts[i].IdPatient;
                dgvPatients[1, i].Value = viewContracts[i].Photo;
                dgvPatients[2, i].Value = viewContracts[i].NamePatient;
                dgvPatients[3, i].Value = viewContracts[i].Birthday.ToShortDateString();
                dgvPatients[4, i].Value = viewContracts[i].Address;
                dgvPatients[5, i].Value = viewContracts[i].Phone;
                dgvPatients[6, i].Value = viewContracts[i].Email;
                dgvPatients[7, i].Value = viewContracts[i].Work;
            }
            dgvPatients.Sort(dgvPatients.Columns["ФИО"], ListSortDirection.Ascending);
            dgvPatients.ClearSelection();
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //при двайном нажати на выбраную страку открывается форма CardPatients
        {
            foreach (DataGridViewRow row in dgvPatients.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    _idPatient = Convert.ToInt32(row.Cells[0].Value.ToString());
                   if (row.Cells[1].Value != null)
                    _photo = row.Cells[1].Value.ToString();
                   if (row.Cells[2].Value != null)
                    _namePatient = row.Cells[2].Value.ToString();
                   if (row.Cells[3].Value != null)
                    _birthday = Convert.ToDateTime(row.Cells[3].Value.ToString());
                   if (row.Cells[4].Value != null)
                    _address = row.Cells[4].Value.ToString();
                   if (row.Cells[5].Value != null)
                    _phone = row.Cells[5].Value.ToString();
                   if (row.Cells[6].Value != null)
                    _email = row.Cells[6].Value.ToString();
                   if (row.Cells[7].Value != null)
                    _work = row.Cells[7].Value.ToString();
            }
            cardPatients.Data(_idPatient, _photo, _namePatient, _birthday, _address, _phone, _email, _work);
            cardPatients.ShowDialog();
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPatients.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    _idPatient = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            connects.Patients.Clear();
            connects.SearchPatients(textBoxSearch.Text.ToLower());
            OutputTable(connects.Patients);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            patient.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            connects.DeletePatient(_idPatient);
        }
    }
}
