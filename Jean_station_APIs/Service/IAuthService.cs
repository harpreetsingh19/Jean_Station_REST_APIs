using Models;

namespace Service
{
    public interface IAuthService
    {
        bool AddActiveUser(Activeuser activeuser);
        void DeleteActiveUser(int id);
        Activeuser LastUser();
        bool LoginUser(User user);
        bool RegisterUser(User user);
    }
}