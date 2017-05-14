using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public abstract class ChronicAndInoculations
    {
        private int _idChronicDiseases;
        private int _idPatient;
        private string _title;
        private DateTime _date;
        private string _note;

        public ChronicAndInoculations(int idChronicDiseases, int idPatient, string title, DateTime date, string note)
        {
            _idChronicDiseases = idChronicDiseases;
            _idPatient = idPatient;
            _title = title;
            _date = date;
            _note = note;
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
    }
}
