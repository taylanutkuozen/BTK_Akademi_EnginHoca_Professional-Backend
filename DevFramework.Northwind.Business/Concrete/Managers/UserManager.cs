using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDAL _userDal;
        public UserManager(IUserDAL userDAL)
        {
            _userDal = userDAL;
        }
        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName && u.Password==password);
        }
        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}