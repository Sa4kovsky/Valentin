using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public class Inoculations : ChronicAndInoculations
    {
        public Inoculations(int idChronicDiseases, int idPatient, string title, DateTime date, string note)
            : base(idChronicDiseases, idPatient, title, date, note)
        {
        }
    }
}
