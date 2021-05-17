using CSBL;
using CSModels;

namespace CSUI
{
    public class UserMenu : IMenu
    {
        private IShopBL _shopBL;
        private Customer _user;
        public UserMenu(IShopBL shopBL)
        {
            _shopBL = shopBL;
        }
        public UserMenu(IShopBL shopBL, Customer user) : this(shopBL)
        {
            _user = user;
        }
        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}