using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Object
{
    public abstract class IdSearch
    {
        private int _idSearch;
        private int _idDiseases;
        private int _id;
        public IdSearch(int idSearch, int idDiseases, int id)
        {
            _idSearch = idSearch;
            _idDiseases = idDiseases;
            _id = id;
        }
        public int IdSearchs
        {
            get { return _idSearch; }
            set { _idSearch = value; }
        }
        public int IdDiseases
        {
            get { return _idDiseases; }
            set { _idDiseases = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
