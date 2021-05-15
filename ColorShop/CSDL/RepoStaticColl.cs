using System.Collections.Generic;
using CSModels;

namespace CSDL
{
    public class RepoStaticColl
    // : IRepository
    {
        public List<Product> GetAllColors()
        {
            return CSStaticColl.Colors;
        }
    }
}