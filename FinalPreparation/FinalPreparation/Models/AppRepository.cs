namespace FinalPreparation.Models
{
    public class AppRepository
    {
        AppDbContext dbContext = new AppDbContext();
        public void AddUser(User model)
        {
            dbContext.Users.Add(model);
            dbContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            var list = dbContext.Users.ToList();
            return list;
        }

        public bool AuthenticateUser(User model)
        {
            var x = dbContext.Users.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
            if (x != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteUser(string userName)
        {
            var x = dbContext.Users.Where(x => x.UserName == userName).FirstOrDefault();
            if (x != null)
            {
                dbContext.Users.Remove(x);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
