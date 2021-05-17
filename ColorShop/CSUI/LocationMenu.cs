using CSBL;
using CSModels;

namespace CSUI
{
    public class LocationMenu : IMenu
    {
        private IShopBL _shopBL;
        private Customer _user;
        public LocationMenu(IShopBL shopBL)
        {
            _shopBL = shopBL;
        }
        public LocationMenu(IShopBL shopBL, Customer user) : this(shopBL)
        {
            _user = user;
        }
        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}