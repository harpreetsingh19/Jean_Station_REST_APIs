using Models;

namespace Repository
{
    public interface IAuthRepository
    {
        bool AddActiveUser(Activeuser user);
        bool CreateUser(User user);
        void DeleteActiveUser(int id);
        bool IsUserExists(string userId);
        Activeuser LastUser();
        bool LoginUser(User user);
    }
}