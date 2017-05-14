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
using Diplom.Object;
using Word = Microsoft.Office.Interop.Word;

namespace Diplom.Forms
{
    public partial class CardPatients : Form
    {
        private Connects connects = new Connects();
        Forms.ChronicDiseases chronicDiseases = new Forms.ChronicDiseases();
        Forms.Symptoms symptoms = new Forms.Symptoms();
        Laboratory laboratory = new Laboratory();

        private int _idDiseases;
        private int _idUltrasonography;
        private int _idLaboratory;
        private int _idSymptoms;
        private int _idChronicDiseases;
        private int _idInoculations;
        private int _idPatient;
        private string _photo;
        private string _namePatient;
        private DateTime _birthday;
        private string _address;
        private string _phone;
        private string _email;
        private string _work;
        private int[] _idlaboratoryreSearches;
        private int[] _idSymptomsMas;
        private int[] _idUltrasonographyMas;

        public CardPatients()
        {
            InitializeComponent();
            InitTable();
        }

        private void CardPatients_Activated(object sender, EventArgs e)
        {
            connects.ChronicDiseaseses.Clear();
            connects.ShowFieldsChronicDiseases(_idPatient);
            OutputTable(connects.ChronicDiseaseses);
            connects.Inoculationses.Clear();
            connects.ShowFieldsInoculations(_idPatient);
            OutputTableInoculations(connects.Inoculationses);
            connects.Symptomses.Clear();
            connects.ShowFieldsSymptoms(_idPatient);
            OutputTableSymptoms(connects.Symptomses);
            connects.LaboratoryreSearches.Clear();
            connects.ShowFieldsLaboratoryreSearch(_idPatient);
            OutputTableLaboratory(connects.LaboratoryreSearches);
            connects.Ultrasonographyes.Clear();
            connects.ShowFieldsUltrasonography(_idPatient);
            OutputTableUltrasonography(connects.Ultrasonographyes);
            connects.Diseaseses.Clear();
            connects.ShowFieldsDiseases(_idPatient);
            OutputTableDiseaseses(connects.Diseaseses);
        }

        public void Data(int idPatient, string photo, string namePatient, DateTime birthday,
            string address, string phone, string email, string work)
        {
            _idPatient = idPatient;

            _photo = photo;
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(photo, System.IO.FileMode.Open);
                System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                fs.Close();
                pictureBox1.Image = img;

                textBoxName.Text = namePatient;
                dateBirthday.Value = birthday;
                textBoxAddress.Text = address;
                maskedTextBoxPhone.Text = phone;
                textBoxEmail.Text = email;
                textBoxWork.Text = work;
            }
            catch (Exception e)
            {
                MessageBox.Show("Выберите пациента");
            }
        }

        public void InitTable() //Инициализация таблицы 
        {
            dgvChronicDiseases.ColumnCount = 5;
            dgvChronicDiseases.Columns[0].Width = 50;
            dgvChronicDiseases.Columns[1].Width = 50;
            dgvChronicDiseases.Columns[3].Width = 400;
            dgvChronicDiseases.Columns[2].Width = 100;
            dgvChronicDiseases.Columns[4].Width = 600;

            dgvChronicDiseases.Columns[0].Name = "№";
            dgvChronicDiseases.Columns[0].Visible = false;
            dgvChronicDiseases.Columns[1].Name = "ФИО";
            dgvChronicDiseases.Columns[1].Visible = false;
            dgvChronicDiseases.Columns[3].Name = "Название болезни";
            dgvChronicDiseases.Columns[2].Name = "Дата";
            dgvChronicDiseases.Columns[4].Name = "Примечание";

            dgvInoculations.ColumnCount = 5;
            dgvInoculations.Columns[0].Width = 50;
            dgvInoculations.Columns[1].Width = 50;
            dgvInoculations.Columns[3].Width = 400;
            dgvInoculations.Columns[2].Width = 100;
            dgvInoculations.Columns[4].Width = 600;

            dgvInoculations.Columns[0].Name = "№";
            dgvInoculations.Columns[0].Visible = false;
            dgvInoculations.Columns[1].Name = "ФИО";
            dgvInoculations.Columns[1].Visible = false;
            dgvInoculations.Columns[3].Name = "Название болезни";
            dgvInoculations.Columns[2].Name = "Дата";
            dgvInoculations.Columns[4].Name = "Примечание";

            dgvSymptoms.ColumnCount = 4;
            dgvSymptoms.Columns[0].Width = 50;
            dgvSymptoms.Columns[1].Width = 50;
            dgvSymptoms.Columns[3].Width = 400;
            dgvSymptoms.Columns[2].Width = 100;

            dgvSymptoms.Columns[0].Name = "№";
            dgvSymptoms.Columns[0].Visible = false;
            dgvSymptoms.Columns[1].Name = "ФИО";
            dgvSymptoms.Columns[1].Visible = false;
            dgvSymptoms.Columns[3].Name = "Название";
            dgvSymptoms.Columns[2].Name = "Дата";

            dgvLaboratory.ColumnCount = 6;
            dgvLaboratory.Columns[0].Width = 50;
            dgvLaboratory.Columns[1].Width = 50;
            dgvLaboratory.Columns[3].Width = 100;
            dgvLaboratory.Columns[2].Width = 100;
            dgvLaboratory.Columns[4].Width = 300;
            dgvLaboratory.Columns[5].Width = 300;

            dgvLaboratory.Columns[0].Name = "№";
            dgvLaboratory.Columns[0].Visible = false;
            dgvLaboratory.Columns[1].Name = "ФИО";
            dgvLaboratory.Columns[1].Visible = false;
            dgvLaboratory.Columns[3].Name = "Название";
            dgvLaboratory.Columns[2].Name = "Дата";
            dgvLaboratory.Columns[5].Name = "Итоги исследования";
            dgvLaboratory.Columns[4].Name = "Заключение";

            dgvUltrasonography.ColumnCount = 6;
            dgvUltrasonography.Columns[0].Width = 50;
            dgvUltrasonography.Columns[1].Width = 50;
            dgvUltrasonography.Columns[3].Width = 100;
            dgvUltrasonography.Columns[2].Width = 100;
            dgvUltrasonography.Columns[4].Width = 300;
            dgvUltrasonography.Columns[5].Width = 300;

            dgvUltrasonography.Columns[0].Name = "№";
            dgvUltrasonography.Columns[0].Visible = false;
            dgvUltrasonography.Columns[1].Name = "ФИО";
            dgvUltrasonography.Columns[1].Visible = false;
            dgvUltrasonography.Columns[3].Name = "Название";
            dgvUltrasonography.Columns[2].Name = "Дата";
            dgvUltrasonography.Columns[5].Name = "Итоги исследования";
            dgvUltrasonography.Columns[4].Name = "Заключение";

            dgvDiseases.ColumnCount = 5;
            dgvDiseases.Columns[0].Width = 50;
            dgvDiseases.Columns[1].Width = 50;
            dgvDiseases.Columns[3].Width = 200;
            dgvDiseases.Columns[2].Width = 100;
            dgvDiseases.Columns[4].Width = 300;

            dgvDiseases.Columns[0].Name = "№";
            dgvDiseases.Columns[0].Visible = false;
            dgvDiseases.Columns[1].Name = "ФИО";
            dgvDiseases.Columns[1].Visible = false;
            dgvDiseases.Columns[3].Name = "Диагноз";
            dgvDiseases.Columns[2].Name = "Дата";
            dgvDiseases.Columns[4].Name = "Лечение";
        }

        public void OutputTableDiseaseses(List<Object.Diseases> diseaseses) //запись в таблицу
        {
            dgvDiseases.RowCount = diseaseses.Count;
            for (int i = 0; i < diseaseses.Count; i++)
            {
                dgvDiseases[0, i].Value = diseaseses[i].IdDiseases;
                dgvDiseases[1, i].Value = diseaseses[i].IdPatient;
                dgvDiseases[3, i].Value = diseaseses[i].Diagnosis;
                dgvDiseases[2, i].Value = diseaseses[i].Date.ToShortDateString();
                dgvDiseases[4, i].Value = diseaseses[i].Treatment;
            }
            dgvDiseases.Sort(dgvDiseases.Columns["Дата"], ListSortDirection.Ascending);
            dgvDiseases.ClearSelection();
        }

        public void OutputTable(List<Object.ChronicDiseases> chronicDiseases) //запись в таблицу
        {
            dgvChronicDiseases.RowCount = chronicDiseases.Count;
            for (int i = 0; i < chronicDiseases.Count; i++)
            {
                dgvChronicDiseases[0, i].Value = chronicDiseases[i].IdChronicDiseases;
                dgvChronicDiseases[1, i].Value = chronicDiseases[i].IdPatient;
                dgvChronicDiseases[3, i].Value = chronicDiseases[i].Title;
                dgvChronicDiseases[2, i].Value = chronicDiseases[i].Date.ToShortDateString();
                dgvChronicDiseases[4, i].Value = chronicDiseases[i].Note;
            }
            dgvChronicDiseases.Sort(dgvChronicDiseases.Columns["Дата"], ListSortDirection.Ascending);
            dgvChronicDiseases.ClearSelection();
        }

        public void OutputTableInoculations(List<Object.Inoculations> inoculations)
        {
            dgvInoculations.RowCount = inoculations.Count;
            for (int i = 0; i < inoculations.Count; i++)
            {
                dgvInoculations[0, i].Value = inoculations[i].IdChronicDiseases;
                dgvInoculations[1, i].Value = inoculations[i].IdPatient;
                dgvInoculations[3, i].Value = inoculations[i].Title;
                dgvInoculations[2, i].Value = inoculations[i].Date.ToShortDateString();
                dgvInoculations[4, i].Value = inoculations[i].Note;
            }
            dgvInoculations.Sort(dgvInoculations.Columns["Дата"], ListSortDirection.Ascending);
            dgvInoculations.ClearSelection();
        }

        public void OutputTableSymptoms(List<Object.Symptoms> symptomses)
        {
            dgvSymptoms.RowCount = symptomses.Count;
            for (int i = 0; i < symptomses.Count; i++)
            {
                dgvSymptoms[0, i].Value = symptomses[i].IdSymptoms;
                dgvSymptoms[1, i].Value = symptomses[i].IdPatient;
                dgvSymptoms[3, i].Value = symptomses[i].Title;
                dgvSymptoms[2, i].Value = symptomses[i].Date.ToShortDateString();
            }
            dgvSymptoms.Sort(dgvSymptoms.Columns["Дата"], ListSortDirection.Ascending);
            dgvSymptoms.ClearSelection();
        }

        public void OutputTableUltrasonography(List<Object.Ultrasonography> ultrasonographies)
        {
            dgvUltrasonography.RowCount = ultrasonographies.Count;
            for (int i = 0; i < ultrasonographies.Count; i++)
            {
                dgvUltrasonography[0, i].Value = ultrasonographies[i].IdChronicDiseases;
                dgvUltrasonography[1, i].Value = ultrasonographies[i].IdPatient;
                dgvUltrasonography[3, i].Value = ultrasonographies[i].Title;
                dgvUltrasonography[2, i].Value = ultrasonographies[i].Date.ToShortDateString();
                dgvUltrasonography[5, i].Value = ultrasonographies[i].Note;
                dgvUltrasonography[4, i].Value = ultrasonographies[i].Incarceration;
            }
            dgvUltrasonography.Sort(dgvUltrasonography.Columns["Дата"], ListSortDirection.Ascending);
            dgvUltrasonography.ClearSelection();
        }

        public void OutputTableLaboratory(List<Object.LaboratoryreSearch> laboratories)
        {
            dgvLaboratory.RowCount = laboratories.Count;
            for (int i = 0; i < laboratories.Count; i++)
            {
                dgvLaboratory[0, i].Value = laboratories[i].IdChronicDiseases;
                dgvLaboratory[1, i].Value = laboratories[i].IdPatient;
                dgvLaboratory[3, i].Value = laboratories[i].Title;
                dgvLaboratory[2, i].Value = laboratories[i].Date.ToShortDateString();
                dgvLaboratory[5, i].Value = laboratories[i].Note;
                dgvLaboratory[4, i].Value = laboratories[i].Incarceration;
            }
            dgvLaboratory.Sort(dgvLaboratory.Columns["Дата"], ListSortDirection.Ascending);
            dgvLaboratory.ClearSelection();
        }

        private void dgvChronicDiseases_CellClick(object sender, DataGridViewCellEventArgs e)
            //запись выделеной страки в переменные
        {
            foreach (DataGridViewRow row in dgvChronicDiseases.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    _idChronicDiseases = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
        }

        private void dgvInoculations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvInoculations.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    _idInoculations = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
        }

        private void dgvSymptoms_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSymptoms.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    _idSymptoms = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
        }

        private void dgvLaboratory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvLaboratory.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    _idLaboratory = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
        }

        private void dgvUltrasonography_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvUltrasonography.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    _idUltrasonography = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
        }


        private void buttonAddPhoto_Click(object sender, EventArgs e) // загрузка фото
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter =
                "Image files (*.BMP, *.JPG, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open);
                System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                fs.Close();
                pictureBox1.Image = img;
                img.Save("Photo\\" + Path.GetFileName(openFileDialog1.FileName), System.Drawing.Imaging.ImageFormat.Png);
                _photo = "Photo\\" + Path.GetFileName(openFileDialog1.FileName);
            }
        }

        private void buttonAddPatient_Click(object sender, EventArgs e) //редактировать пациента
        {
            connects.UpdateFromTablePatients(_idPatient, _photo, textBoxName.Text, dateBirthday.Value,
                textBoxAddress.Text, maskedTextBoxPhone.Text, textBoxEmail.Text, textBoxWork.Text);
        }

        private void buttonAddChronicDiseases_Click(object sender, EventArgs e)
            //при нажатии открывается форма для добавления хронических заболеваний
        {
            chronicDiseases.Date(_idPatient);
            chronicDiseases.Text = "Хронические заболевания";
            chronicDiseases.ShowDialog();
        }

        private void buttonDeleteChronicDiseases_Click(object sender, EventArgs e) // удаление хронических заболеваний
        {
            connects.DeleteFromTableChronicDiseases(_idChronicDiseases);
            CardPatients_Activated(sender, e);
        }

        private void buttonAddInoculations_Click(object sender, EventArgs e)
            //при нажатии открывается форма для добавления прививок
        {
            chronicDiseases.Date(_idPatient);
            chronicDiseases.Text = "Прививки";
            chronicDiseases.ShowDialog();
        }

        private void buttonDeleteInoculations_Click(object sender, EventArgs e) // удаление прививки
        {
            connects.DeleteFromTableInoculations(_idInoculations);
            CardPatients_Activated(sender, e);
        }

        private void buttonAddSymptoms_Click(object sender, EventArgs e)
            //при нажатии открывается форма для добавления симтомов
        {
            symptoms.Date(_idPatient);
            symptoms.ShowDialog();
        }

        private void buttonDeleteSymptoms_Click(object sender, EventArgs e) // удаление симтомов
        {
            connects.DeleteFromTableSymptoms(_idSymptoms);
            CardPatients_Activated(sender, e);
        }

        private void buttonAddLaboratory_Click(object sender, EventArgs e) //добавить лаб. исследование
        {
            laboratory.Date(_idPatient);
            laboratory.Text = "Лабораторные исследования";
            laboratory.ShowDialog();
        }

        private void buttonDeleteLaboratory_Click(object sender, EventArgs e) // лаб. исследование удалить
        {
            connects.DeleteFromTableLaboratoryreSearch(_idLaboratory);
            CardPatients_Activated(sender, e);
        }

        private void buttonAddUltrasonography_Click(object sender, EventArgs e) //добавить узи
        {
            laboratory.Date(_idPatient);
            laboratory.Text = "УЗИ";
            laboratory.ShowDialog();
        }

        private void buttonDeleteUltrasonography_Click(object sender, EventArgs e) //удалить узи
        {
            connects.DeleteFromTableUltrasonography(_idUltrasonography);
            CardPatients_Activated(sender, e);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            connects.Symptomses.Clear();
            connects.Ultrasonographyes.Clear();
            connects.LaboratoryreSearches.Clear();
            connects.Search(dateTimePicker1.Value, dateTimePicker2.Value, _idPatient);
            AddControls(connects.Symptomses, connects.LaboratoryreSearches, connects.Ultrasonographyes);
        }

        void AddControls(List<Object.Symptoms> symptomses, List<Object.LaboratoryreSearch> laboratoryreSearches,
            List<Object.Ultrasonography> ultrasonographies)
        {
            panelAdd.Controls.Clear();
            _idlaboratoryreSearches = new int[laboratoryreSearches.Count];
            _idSymptomsMas = new int[symptomses.Count];
            _idUltrasonographyMas = new int[ultrasonographies.Count];
            int j = 0;
            for (int i = 0; i < symptomses.Count; i++)
            {
                _idSymptomsMas[i] = symptomses[i].IdSymptoms;

                Label lbl = new Label();
                lbl.Text = "Симптомы";
                lbl.Name = "lblSymptomses" + i;
                lbl.Location = new Point(0, 0 + j);
                panelAdd.Controls.Add(lbl);
                TextBox tBox = new TextBox();
                tBox.Name = "textBoxSymptomses" + i;
                tBox.Text = symptomses[i].Title;
                tBox.Multiline = true;
                tBox.Width = 845;
                tBox.Height = 151;
                tBox.Location = new Point(0, 23 + j);
                panelAdd.Controls.Add(tBox);
                j += 183;
            }
            for (int i = 0; i < laboratoryreSearches.Count; i++)
            {
                _idlaboratoryreSearches[i] = laboratoryreSearches[i].IdChronicDiseases;
                
                Label lbl = new Label();
                lbl.Text = "Анализ";
                lbl.Name = "lblLaboratoryreSearchesTitle" + i;
                lbl.Location = new Point(0, 0 + j);
                panelAdd.Controls.Add(lbl);

                TextBox tBox = new TextBox();
                tBox.Name = "textBoxLaboratoryreSearchesTitle" + i;
                tBox.Text = laboratoryreSearches[i].Title
                            + Environment.NewLine + Environment.NewLine
                            + "Итоги лабораторных исследований:"
                            + Environment.NewLine + Environment.NewLine
                            + laboratoryreSearches[i].Note
                            + Environment.NewLine + Environment.NewLine
                            + "Заключение:"
                            + Environment.NewLine + Environment.NewLine
                            + laboratoryreSearches[i].Incarceration;
                tBox.Multiline = true;
                tBox.Width = 845;
                tBox.Height = 151;
                tBox.Location = new Point(0, 23 + j);
                panelAdd.Controls.Add(tBox);
                j += 183;
            }
            for (int i = 0; i < ultrasonographies.Count; i++)
            {
                _idUltrasonographyMas[i] = ultrasonographies[i].IdChronicDiseases;

                Label lbl = new Label();
                lbl.Text = "УЗИ";
                lbl.Location = new Point(0, 0 + j);
                panelAdd.Controls.Add(lbl);

                TextBox tBox = new TextBox();
                tBox.Name = "textBoxUltrasonographyTitle" + i;
                tBox.Text = ultrasonographies[i].Title
                            + Environment.NewLine + Environment.NewLine
                            + "Итоги лабораторных исследований:"
                            + Environment.NewLine + Environment.NewLine
                            + ultrasonographies[i].Note
                            + Environment.NewLine + Environment.NewLine
                            + "Заключение:"
                            + Environment.NewLine + Environment.NewLine
                            + ultrasonographies[i].Incarceration;
                tBox.Multiline = true;
                tBox.Width = 845;
                tBox.Height = 151;
                tBox.Location = new Point(0, 23 + j);
                panelAdd.Controls.Add(tBox);
                j += 183;
            }
            Label lbl1 = new Label();
            lbl1.Text = "Диагноз";
            lbl1.Name = "lblDiagnosis";
            lbl1.Location = new Point(0, 0 + j);
            panelAdd.Controls.Add(lbl1);
            TextBox tBox1 = new TextBox();
            tBox1.Name = "textBoxDiagnosis";
            tBox1.Multiline = true;
            tBox1.Width = 845;
            tBox1.Height = 151;
            tBox1.Location = new Point(0, 23 + j);
            panelAdd.Controls.Add(tBox1);
            j += 183;

            Label lbl2 = new Label();
            lbl2.Text = "Лечение";
            lbl2.Name = "lblTreatment";
            lbl2.Location = new Point(0, 0 + j);
            panelAdd.Controls.Add(lbl2);
            TextBox tBox2 = new TextBox();
            tBox2.Name = "textBoxTreatment";
            tBox2.Multiline = true;
            tBox2.Width = 845;
            tBox2.Height = 151;
            tBox2.Location = new Point(0, 23 + j);
            panelAdd.Controls.Add(tBox2);

            Button btn = new Button();
            btn.Name = "Add";
            btn.Text = "Добавить болезнь";
            btn.Width = 129;
            btn.Height = 43;
            btn.Location = new Point(717, 180 + j);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Click += buttonAdd_Click;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = Color.FromArgb(0, 147, 147);
            btn.ForeColor = Color.FromArgb(240, 240, 240);
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 147, 147);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 126, 127);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 147, 147);
            panelAdd.Controls.Add(btn);

            Button btnConvert = new Button();
            btnConvert.Name = "Word";
            btnConvert.Text = "Экспорт в Word";
            btnConvert.Width = 129;
            btnConvert.Height = 43;
            btnConvert.Location = new Point(580, 180 + j);
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Click += buttonConvert_Click;
            btnConvert.FlatAppearance.BorderSize = 1;
            btnConvert.BackColor = Color.FromArgb(0, 147, 147);
            btnConvert.ForeColor = Color.FromArgb(240, 240, 240);
            btnConvert.FlatAppearance.BorderColor = Color.FromArgb(0, 147, 147);
            btnConvert.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 126, 127);
            btnConvert.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 147, 147);
            panelAdd.Controls.Add(btnConvert);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            connects.InsertToTableDiseases(_idPatient, dateTimePicker2.Value, panelAdd.Controls["textBoxDiagnosis"].Text, panelAdd.Controls["textBoxTreatment"].Text, ref _idDiseases);
            for (int i = 0; i < _idlaboratoryreSearches.Length; i++)
            {
                connects.InsertDiseasesAndLaboratoryresearch(_idDiseases, _idlaboratoryreSearches[i]);
            }
            for (int i = 0; i < _idSymptomsMas.Length; i++)
            {
                connects.InsertDiseasesandsymptoms(_idDiseases, _idSymptomsMas[i]);
            }
            for (int i = 0; i < _idUltrasonographyMas.Length; i++)
            {
                connects.InsertDiseasesandultrasonography(_idDiseases, _idUltrasonographyMas[i]);
            }
            CardPatients_Activated(sender, e);
        }

        private void dgvDiseases_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDiseases.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    _idDiseases = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
            connects.DiseasesAndLaboratoryResearchs.Clear();
            connects.DiseasesAndSymptomses.Clear();
            connects.DiseasesAndUltrasonographies.Clear();
            connects.ShowFieldsDiseasesAndLaboratoryreSearch(_idDiseases);
            Output(connects.DiseasesAndSymptomses, connects.DiseasesAndLaboratoryResearchs, connects.DiseasesAndUltrasonographies);
        }

        public void Output(List<DiseasesAndSymptoms> symptomses,  List<DiseasesAndLaboratoryResearch> diseases,
            List<DiseasesAndUltrasonography> ultrasonographies) //запись в таблицу
        {
            connects.Symptomses.Clear();
            connects.ShowFieldsSymptoms(_idPatient);
            OutputTableSymptoms(connects.Symptomses);
            connects.LaboratoryreSearches.Clear();
            connects.ShowFieldsLaboratoryreSearch(_idPatient);
            OutputTableLaboratory(connects.LaboratoryreSearches);
            connects.Ultrasonographyes.Clear();
            connects.ShowFieldsUltrasonography(_idPatient);
            OutputTableUltrasonography(connects.Ultrasonographyes);
    
            panelAdd.Controls.Clear();
            int j = 0;
            for (int i = 0; i < symptomses.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = "Симптомы";
                lbl.Name = "lblSymptomses" + i;
                lbl.Location = new Point(0, 0 + j);
                panelAdd.Controls.Add(lbl);
                TextBox tBox = new TextBox();
                tBox.Name = "textBoxSymptomses" + i;
                tBox.Text = connects.Symptomses.Find(x => x.IdSymptoms == symptomses[i].Id)
                    .ToString("Title");
                tBox.Multiline = true;
                tBox.Width = 845;
                tBox.Height = 151;
                tBox.Location = new Point(0, 23 + j);
                panelAdd.Controls.Add(tBox);
                j += 183;
            }
            for (int i = 0; i < diseases.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = "Анализ";
                lbl.Name = "lblLaboratoryreSearchesTitle" + i;
                lbl.Location = new Point(0, 0 + j);
                panelAdd.Controls.Add(lbl);

                TextBox tBox = new TextBox();
                tBox.Name = "textBoxLaboratoryreSearchesTitle" + i;
                tBox.Text = connects.LaboratoryreSearches.Find(x => x.IdChronicDiseases == diseases[i].Id)
                                .ToString("Title")
                            + Environment.NewLine + Environment.NewLine
                            + "Итоги лабораторных исследований:"
                            + Environment.NewLine + Environment.NewLine
                            +
                            connects.LaboratoryreSearches.Find(x => x.IdChronicDiseases == diseases[i].Id)
                                .ToString("Note")
                            + Environment.NewLine + Environment.NewLine
                            + "Заключение:"
                            + Environment.NewLine + Environment.NewLine
                            +
                            connects.LaboratoryreSearches.Find(x => x.IdChronicDiseases == diseases[i].Id)
                                .ToString("Incarceration");
                tBox.Multiline = true;
                tBox.Width = 845;
                tBox.Height = 151;
                tBox.Location = new Point(0, 23 + j);
                panelAdd.Controls.Add(tBox);
                j += 183;          
            }

            for (int i = 0; i < ultrasonographies.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = "УЗИ";
                lbl.Location = new Point(0, 0 + j);
                panelAdd.Controls.Add(lbl);

                TextBox tBox = new TextBox();
                tBox.Name = "textBoxUltrasonographyTitle" + i;
                tBox.Text = connects.Ultrasonographyes.Find(x => x.IdChronicDiseases == ultrasonographies[i].Id)
                                .ToString("Title")
                            + Environment.NewLine + Environment.NewLine
                            + "Итоги лабораторных исследований:"
                            + Environment.NewLine + Environment.NewLine
                            + connects.Ultrasonographyes.Find(x => x.IdChronicDiseases == ultrasonographies[i].Id)
                                .ToString("Note")
                            + Environment.NewLine + Environment.NewLine
                            + "Заключение:"
                            + Environment.NewLine + Environment.NewLine
                            + connects.Ultrasonographyes.Find(x => x.IdChronicDiseases == ultrasonographies[i].Id)
                                .ToString("Incarceration");
                tBox.Multiline = true;
                tBox.Width = 845;
                tBox.Height = 151;
                tBox.Location = new Point(0, 23 + j);
                panelAdd.Controls.Add(tBox);
                j += 183;
            }

            foreach (DataGridViewRow row in dgvDiseases.SelectedRows)
            {
                if (row.Cells[3].Value != null)
                {
                    Label lbl1 = new Label();
                    lbl1.Text = "Диагноз";
                    lbl1.Name = "lblDiagnosis";
                    lbl1.Location = new Point(0, 0 + j);
                    panelAdd.Controls.Add(lbl1);
                    TextBox tBox1 = new TextBox();
                    tBox1.Name = "textBoxDiagnosis";
                    tBox1.Text = row.Cells[3].Value.ToString();
                    tBox1.Multiline = true;
                    tBox1.Width = 845;
                    tBox1.Height = 151;
                    tBox1.Location = new Point(0, 23 + j);
                    panelAdd.Controls.Add(tBox1);
                    j += 183;
                }
                if (row.Cells[4].Value != null)
                {
                    Label lbl2 = new Label();
                    lbl2.Text = "Лечение";
                    lbl2.Name = "lblTreatment";
                    lbl2.Location = new Point(0, 0 + j);
                    panelAdd.Controls.Add(lbl2);
                    TextBox tBox2 = new TextBox();
                    tBox2.Name = "textBoxTreatment";
                    tBox2.Text = row.Cells[4].Value.ToString();
                    tBox2.Multiline = true;
                    tBox2.Width = 845;
                    tBox2.Height = 151;
                    tBox2.Location = new Point(0, 23 + j);
                    panelAdd.Controls.Add(tBox2);
                }
            }

            Button btn = new Button();
            btn.Name = "Delete";
            btn.Text = "Удалить";
            btn.Width = 129;
            btn.Height = 43;
            btn.Location = new Point(717, 180 + j);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Click += buttonDelete_Click;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = Color.FromArgb(0, 147, 147);
            btn.ForeColor = Color.FromArgb(240, 240, 240);
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 147, 147);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 126, 127);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 147, 147);
            panelAdd.Controls.Add(btn);

            Button btnConvert = new Button();
            btnConvert.Name = "Word";
            btnConvert.Text = "Экспорт в Word";
            btnConvert.Width = 129;
            btnConvert.Height = 43;
            btnConvert.Location = new Point(580, 180 + j);
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Click += buttonConvert_Click;
            btnConvert.FlatAppearance.BorderSize = 1;
            btnConvert.BackColor = Color.FromArgb(0, 147, 147);
            btnConvert.ForeColor = Color.FromArgb(240, 240, 240);
            btnConvert.FlatAppearance.BorderColor = Color.FromArgb(0, 147, 147);
            btnConvert.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 126, 127);
            btnConvert.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 147, 147);
            panelAdd.Controls.Add(btnConvert);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            connects.DeleteToTableDiseases(_idDiseases);
            CardPatients_Activated(sender, e);
        }

        private Word._Application _oWord; // создаем новый экземпляр ворда
        private Word.Paragraph _wordparagraph;

        private Word._Document GetDoc(string path)
        {
            Word._Document oDoc = _oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            _oWord = new Word.Application();
            _oWord.Visible = true;
            Word._Document oDoc = GetDoc(@"e:\Заказ\ValentinDiplom\Diplom\Diplom\bin\Debug\Лечение.docx");
        }

        private void SetTemplate(Word._Document oDoc)
        {
            oDoc.Bookmarks["Лечение"].Range.Text = panelAdd.Controls["textBoxTreatment"].Text;
            oDoc.Bookmarks["Дата"].Range.Text = DateTime.Now.ToShortDateString();
        }
    }
}
