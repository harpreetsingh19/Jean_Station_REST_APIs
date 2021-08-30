using Models;
using MongoDB.Driver;

namespace Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;

        public AuthRepository(DataContext _context)
        {
            context = _context;
        }
        public bool CreateUser(User user)
        {
            context.Users.InsertOne(user);
            return true;
        }
        public bool AddActiveUser(Activeuser user)
        {
            context.Activeusers.InsertOne(user);
            return true;
        }
        public Activeuser LastUser()
        {
            return context.Activeusers.Find(u => true).FirstOrDefault();
        }

        public bool IsUserExists(string userId)
        {
            var filter = context.Users.Find(u => u.UserId == userId).FirstOrDefault();
            if (filter != null)
            {
                return true;
            }
            return false;
        }

        public bool LoginUser(User user)
        {
            var filter = context.Users.Find(u => u.UserId == user.UserId && u.Password == user.Password).FirstOrDefault();
            if (filter != null)
            {
                return true;
            }
            else
                return false;
        }
        public void DeleteActiveUser(int id)
        {
            context.Activeusers.DeleteOne(a => a.Activationid == id);
        }
    }
}
