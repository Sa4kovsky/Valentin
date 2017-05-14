using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public class Patient
    {
        private int _idPatient;
        private string _photo;
        private string _namePatient;
        private DateTime _birthday;
        private string _address;
        private string _phone;
        private string _email;
        private string _work;

        public Patient(int idPatient, string photo, string namePatient, DateTime birthday,
            string address, string phone, string email, string work)
        {
            _idPatient = idPatient;
            _photo = photo;
            _namePatient = namePatient;
            _birthday = birthday;
            _address = address;
            _phone = phone;
            _email = email;
            _work = work;
        }


        public int IdPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }


        public string NamePatient
        {
            get { return _namePatient; }
            set { _namePatient = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }


        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }


        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Work
        {
            get { return _work; }
            set { _work = value; }
        }


    }
}
