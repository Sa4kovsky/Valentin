using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public class Ultrasonography : Laboratory
    {
        public Ultrasonography(int idChronicDiseases, int idPatient, string title, DateTime date, string note, string incarceration) 
            : base(idChronicDiseases, idPatient, title, date, note, incarceration)
        {
        }
    }
}
