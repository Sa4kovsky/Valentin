using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public class Symptoms
    {
        private int _idSymptoms;
        private int _idPatient;
        private string _title;
        private DateTime _date;

        public String ToString(String fmt)
        {
            if (String.IsNullOrEmpty(fmt))
                fmt = "Title";

            switch (fmt)
            {
                case "Title":
                    return String.Format("{0}", Title);
                case "Date":
                    return String.Format("{0}", Date);
                default:
                    return ToString();
            }
        }


        public Symptoms(int idSymptoms, int idPatient, string title, DateTime date)
        {
            _idSymptoms = idSymptoms;
            _idPatient = idPatient;
            _title = title;
            _date = date;
        }

        public int IdSymptoms
        {
            get { return _idSymptoms; }
            set { _idSymptoms = value; }
        }

        public int IdPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
