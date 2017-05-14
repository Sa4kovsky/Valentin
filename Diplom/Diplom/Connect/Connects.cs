using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom.Object;
using Npgsql;
using NpgsqlTypes;

namespace Diplom.Connect
{
    class Connects
    {
        public List<Patient> Patients = new List<Patient>();
        public  List<Object.ChronicDiseases> ChronicDiseaseses = new List<Object.ChronicDiseases>();
        public List<Object.Inoculations> Inoculationses = new List<Object.Inoculations>();
        public List<Object.Symptoms> Symptomses = new List<Object.Symptoms>();
        public List<LaboratoryreSearch> LaboratoryreSearches = new List<Object.LaboratoryreSearch>();
        public List<Object.Ultrasonography> Ultrasonographyes = new List<Object.Ultrasonography>();
        public List<Object.Diseases> Diseaseses = new List<Object.Diseases>();
        public List<Object.DiseasesAndLaboratoryResearch> DiseasesAndLaboratoryResearchs = new List<Object.DiseasesAndLaboratoryResearch>();
        public List<Object.DiseasesAndSymptoms> DiseasesAndSymptomses = new List<Object.DiseasesAndSymptoms>();
        public List<Object.DiseasesAndUltrasonography> DiseasesAndUltrasonographies = new List<Object.DiseasesAndUltrasonography>();

        public static string connStr;

        public void ConnectsSQL(string connectingPath)
        {
            System.IO.StreamReader file =
                new System.IO.StreamReader(connectingPath);
            connStr = file.ReadLine();
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
        }

        public void ShowFieldsPatients()
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From patient", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patients.Add(new Patient(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                            Convert.ToDateTime(reader[3]), reader[4].ToString(),
                            reader[5].ToString(), reader[6].ToString(), reader[7].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void SearchPatients(string name)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (
                NpgsqlCommand cmd =
                    new NpgsqlCommand("SELECT * FROM patient WHERE lower(namepatient) SIMILAR TO '%" + name + "%'",
                        conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patients.Add(new Patient(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                            Convert.ToDateTime(reader[3]), reader[4].ToString(),
                            reader[5].ToString(), reader[6].ToString(), reader[7].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTablePatients(string photo, string namepatient, DateTime birthday, string address,
            string phone, string email, string work)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into patient" +
                                                         "(photo, namepatient, birthday, address, phone, email, work) Values (@photo, @namepatient, @birthday, @address, @phone, @email, @work)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@photo";
                //задаем значение параметра
                param.Value = photo;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@namepatient";
                //задаем значение параметра
                param.Value = namepatient;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@birthday";
                //задаем значение параметра
                param.Value = birthday;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Date;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@address";
                //задаем значение параметра
                param.Value = address;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@phone";
                //задаем значение параметра
                param.Value = phone;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@email";
                //задаем значение параметра
                param.Value = email;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@work";
                //задаем значение параметра
                param.Value = work;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void UpdateFromTablePatients(int idpatient, string photo, string namepatient, DateTime birthday,
            string address, string phone, string email, string work)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update patient" +
                                                         " Set (photo, namepatient, birthday, address, phone, email, work) = (@photo, @namepatient, @birthday, @address, @phone, @email, @work)" +
                                                         " where idpatient = @idpatient", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@photo";
                //задаем значение параметра
                param.Value = photo;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@namepatient";
                //задаем значение параметра
                param.Value = namepatient;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@birthday";
                //задаем значение параметра
                param.Value = birthday;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Date;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@address";
                //задаем значение параметра
                param.Value = address;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@phone";
                //задаем значение параметра
                param.Value = phone;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@email";
                //задаем значение параметра
                param.Value = email;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@work";
                //задаем значение параметра
                param.Value = work;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idpatient";
                param.Value = idpatient;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на изменение записи(ей)");
                }
            }
            conns.Close();
        }

        public void DeletePatient(int idpatient)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From patient" +
                 " where idpatient = @idpatient", conns))
            
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idpatient";
                param.Value = idpatient;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
        }

        public void ShowFieldsChronicDiseases(int idpatient)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From chronicdiseases WHERE idpatient ="+ idpatient +"", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChronicDiseaseses.Add(new Object.ChronicDiseases(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3]), reader[4].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableChronicDiseases(int idpatient, string title, DateTime date, string note)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into chronicdiseases" +
                                                         "(idpatient, title, date, note) Values (@idpatient, @title, @date, @note)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idpatient";
                param.Value = idpatient;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@title";
                param.Value = title;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Date;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@note";
                param.Value = note;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void DeleteFromTableChronicDiseases(int idchronicdiseases)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From chronicdiseases" +
                 " where idchronicdiseases = @idchronicdiseases", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idchronicdiseases";
                //задаем значение параметра
                param.Value = idchronicdiseases;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, удаление банка невозможно, так какк это приведет к удалению данного банка у всех заказчиков");
                }
            }
            conns.Close();
        }

        public void ShowFieldsInoculations(int idpatient)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From inoculations WHERE idpatient ="+ idpatient +"", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inoculationses.Add(new Object.Inoculations(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3]), reader[4].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableInoculations(int idpatient, string title, DateTime date, string note)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into inoculations" +
                                                         "(idpatient, title, date, note) Values (@idpatient, @title, @date, @note)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idpatient";
                param.Value = idpatient;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@title";
                param.Value = title;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Date;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@note";
                param.Value = note;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void DeleteFromTableInoculations(int idinoculations)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From inoculations" +
                 " where idinoculations = @idinoculations", conns))
            { 
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idinoculations";
                param.Value = idinoculations;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, удаление банка невозможно, так какк это приведет к удалению данного банка у всех заказчиков");
                }
            }
            conns.Close();
        }

        public void ShowFieldsSymptoms(int idpatient)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From symptoms WHERE idpatient =" + idpatient + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Symptomses.Add(new Object.Symptoms(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3])));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableSymptoms(int idpatient, string title, DateTime date)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into symptoms" +
                                                         "(idpatient, title, date) Values (@idpatient, @title, @date)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idpatient";
                param.Value = idpatient;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@title";
                param.Value = title;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Date;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void DeleteFromTableSymptoms(int idsymptoms)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From symptoms" +
                 " where idsymptoms = @idsymptoms", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idsymptoms";
                param.Value = idsymptoms;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, удаление банка невозможно, так какк это приведет к удалению данного банка у всех заказчиков");
                }
            }
            conns.Close();
        }

        public void ShowFieldsLaboratoryreSearch(int idpatient)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From laboratoryresearch WHERE idpatient =" + idpatient + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LaboratoryreSearches.Add(new Object.LaboratoryreSearch(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3]), reader[4].ToString(), reader[5].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableLaboratoryreSearch(int idpatient, string title, DateTime date, string data, string conclusion)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into laboratoryresearch" +
                                                         "(idpatient, title, date, data, conclusion) Values (@idpatient, @title, @date, @data, @conclusion)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idpatient";
                param.Value = idpatient;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@title";
                param.Value = title;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Date;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@data";
                param.Value = data;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@conclusion";
                param.Value = conclusion;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void DeleteFromTableLaboratoryreSearch(int idlaboratoryresearch)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From laboratoryresearch" +
                 " where idlaboratoryresearch = @idlaboratoryresearch", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idlaboratoryresearch";
                param.Value = idlaboratoryresearch;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, удаление банка невозможно, так какк это приведет к удалению данного банка у всех заказчиков");
                }
            }
            conns.Close();
        }

        public void ShowFieldsUltrasonography(int idpatient)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From ultrasonography WHERE idpatient =" + idpatient + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ultrasonographyes.Add(new Object.Ultrasonography(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3]), reader[4].ToString(), reader[5].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableUltrasonography(int idpatient, string title, DateTime date, string data, string conclusion)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into ultrasonography" +
                                                         "(idpatient, title, date, data, conclusion) Values (@idpatient, @title, @date, @data, @conclusion)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idpatient";
                param.Value = idpatient;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@title";
                param.Value = title;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Date;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@data";
                param.Value = data;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@conclusion";
                param.Value = conclusion;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void DeleteFromTableUltrasonography(int idultrasonography)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From ultrasonography" +
                 " where idultrasonography = @idultrasonography", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idultrasonography";
                param.Value = idultrasonography;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, удаление банка невозможно, так какк это приведет к удалению данного банка у всех заказчиков");
                }
            }
            conns.Close();
        }

        public void ShowFieldsDiseases(int idpatient)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From diseases WHERE idpatient =" + idpatient + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Diseaseses.Add(new Object.Diseases(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToDateTime(reader[2]), reader[3].ToString(), reader[4].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableDiseases(int idpatient, DateTime date, string diagnosis, string treatment, ref int id)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into diseases" +
                                                         "(idpatient,  date, diagnosis, treatment) Values (@idpatient, @date, @diagnosis, @treatment) RETURNING iddiseases",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idpatient";
                param.Value = idpatient;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Date;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@diagnosis";
                param.Value = diagnosis;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@treatment";
                param.Value = treatment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt32(reader[0]);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }

            }
            conns.Close();
        }

        public void DeleteToTableDiseases(int id)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From  diseases" +
                                                         " where iddiseases = @iddiseases",conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@iddiseases";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }

            }
            conns.Close();
        }

        public void Search(DateTime date, DateTime date1, int idpatient)
        {
          string  date2 = date.ToString("yyyy-MM-dd");
          string date3 = date1.ToString("yyyy-MM-dd");

            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From symptoms WHERE symptoms.date BETWEEN '%" + date2 + "%' and '%" + date3 + "%' and idpatient =" + idpatient + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Symptomses.Add(new Object.Symptoms(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3])));
                    }
                }
            }
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From laboratoryresearch WHERE laboratoryresearch.date BETWEEN '%" + date2 + "%' and '%" + date3 + "%' and idpatient =" + idpatient + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LaboratoryreSearches.Add(new Object.LaboratoryreSearch(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3]), reader[4].ToString(), reader[5].ToString()));
                    }
                }
            }
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From ultrasonography WHERE ultrasonography.date  BETWEEN '%" + date2 + "%' and '%" + date3 + "%' and idpatient =" + idpatient + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ultrasonographyes.Add(new Object.Ultrasonography(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3]), reader[4].ToString(), reader[5].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertDiseasesAndLaboratoryresearch(int iddiseases, int idlaboratoryresearch)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into diseasesandlaboratoryresearch" +
                                                         "(iddiseases, idlaboratoryresearch) Values (@iddiseases, @idlaboratoryresearch)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@iddiseases";
                param.Value = iddiseases;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idlaboratoryresearch";
                param.Value = idlaboratoryresearch;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void InsertDiseasesandsymptoms(int iddiseases, int idsymptoms)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into diseasesandsymptoms" +
                                                         "(iddiseases, idsymptoms) Values (@iddiseases, @idsymptoms)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@iddiseases";
                param.Value = iddiseases;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idsymptoms";
                param.Value = idsymptoms;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void InsertDiseasesandultrasonography(int iddiseases, int idultrasonography)
        {
            var conns = new NpgsqlConnection(Connects.connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into diseasesandultrasonography" +
                                                         "(iddiseases, idultrasonography) Values (@iddiseases, @idultrasonography)",
                conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@iddiseases";
                param.Value = iddiseases;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idultrasonography";
                param.Value = idultrasonography;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(@"Ошибка, при выполнении запроса на добавление записи");
                }
            }
            conns.Close();
        }

        public void ShowFieldsDiseasesAndLaboratoryreSearch(int iddiseases)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From diseasesandlaboratoryresearch WHERE iddiseases =" + iddiseases + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DiseasesAndLaboratoryResearchs.Add(new DiseasesAndLaboratoryResearch(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
                    }
                }
            }
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From diseasesandsymptoms WHERE iddiseases =" + iddiseases + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DiseasesAndSymptomses.Add(new DiseasesAndSymptoms(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
                    }
                }
            }
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From diseasesandultrasonography WHERE iddiseases =" + iddiseases + "", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DiseasesAndUltrasonographies.Add(new DiseasesAndUltrasonography(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
                    }
                }
            }
            conns.Close();
        }
    }
}
