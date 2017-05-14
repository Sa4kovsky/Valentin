using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public class LaboratoryreSearch : Laboratory
    {
        public LaboratoryreSearch(int idChronicDiseases, int idPatient, string title, DateTime date, string note,
            string incarceration) : base(idChronicDiseases, idPatient, title, date, note, incarceration)
        {
        }
    }
}
