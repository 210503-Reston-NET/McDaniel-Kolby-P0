using System.Collections.Generic;
using CSModels;
using CSDL;

namespace CSBL
{
    public class ColorBL : IColorBL
    {
        private IRepository _repo;
        public ColorBL(IRepository repo)
        {
            _repo = repo;
        }
        public List<Product> GetAllColors()
        {
            return _repo.GetAllColors();
        }
    }
}