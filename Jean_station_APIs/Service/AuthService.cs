using Exceptions;
using Models;
using Repository;

namespace Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;

        public AuthService(IAuthRepository repo)
        {
            _repo = repo;
        }
        public bool LoginUser(User user)
        {
            bool _user = _repo.LoginUser(user);
            if (_user)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RegisterUser(User user)
        {
            var id = _repo.IsUserExists(user.UserId);
            if (!id)
            {
                _repo.CreateUser(user);
                return true;
            }
            else
            {
                throw new UserAlreadyExistsException($"This userId {user.UserId} already in use");
            }
        }
        public bool AddActiveUser(Activeuser activeuser)
        {
            return _repo.AddActiveUser(activeuser);
        }
        public Activeuser LastUser()
        {
            return _repo.LastUser();
        }
        public void DeleteActiveUser(int id)
        {
            _repo.DeleteActiveUser(id);
        }
    }
}
