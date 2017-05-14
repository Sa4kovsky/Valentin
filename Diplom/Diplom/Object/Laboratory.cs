using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public abstract class Laboratory
    {
        private int _idChronicDiseases;
        private int _idPatient;
        private string _title;
        private DateTime _date;
        private string _note;
        private string _incarceration;

        public String ToString(String fmt)
        {
             if (String.IsNullOrEmpty(fmt))
                 fmt = "IdChronicDiseases";

            switch (fmt)
            {
                case "IdChronicDiseases":
                    return String.Format("{0}", IdChronicDiseases);
                case "Title":
                    return String.Format("{0}", Title);
                case "Date":
                    return String.Format("{0}", Date);
                case "Note":
                    return String.Format("{0}", Note);
                case "Incarceration":
                    return String.Format("{0}", Incarceration);
                default:
                    return ToString();
            }
        }

        // return "ID: " + IdChronicDiseases + IdPatient + Title + Date + Note + Incarceration;



        public Laboratory(int idChronicDiseases, int idPatient, string title, DateTime date, string note,
            string incarceration)
        {
            _idChronicDiseases = idChronicDiseases;
            _idPatient = idPatient;
            _title = title;
            _date = date;
            _note = note;
            _incarceration = incarceration;
        }


        public int IdChronicDiseases
        {
            get { return _idChronicDiseases; }
            set { _idChronicDiseases = value; }
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

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public string Incarceration
        {
            get { return _incarceration; }
            set { _incarceration = value; }
        }
    }
}

