using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public  class ChronicDiseases: ChronicAndInoculations
    {
        public ChronicDiseases(int idChronicDiseases, int idPatient, string title, DateTime date, string note)
            : base(idChronicDiseases, idPatient, title, date, note)
        {
        }
    }
}
