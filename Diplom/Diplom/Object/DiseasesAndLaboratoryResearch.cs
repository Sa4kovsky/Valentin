using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public class DiseasesAndLaboratoryResearch : IdSearch
    {
        public DiseasesAndLaboratoryResearch(int idSearch, int idDiseases, int id) : base(idSearch, idDiseases, id)
        {
        }
    }
}
