using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public class Diseases
    {
        private int _idDiseases;
        private int _idPatient;
        private DateTime _date;
        private string _diagnosis;
        private string _treatment;

        public  Diseases( int idDiseases, int idPatient, DateTime date, string diagnosis, string treatment)
        {
            _idDiseases = idDiseases;
            _idPatient = idPatient;
            _date = date;
            _diagnosis = diagnosis;
            _treatment = treatment;
        }


        public int IdDiseases
        {
            get { return _idDiseases; }
            set { _idDiseases = value; }
        }

        public int IdPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        public string Treatment
        {
            get { return _treatment; }
            set { _treatment = value; }
        }
    }
}
