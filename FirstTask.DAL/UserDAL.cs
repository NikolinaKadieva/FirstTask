namespace FirstTask.DAL
{
    using FirstTask.DAL.Data;
    using FirstTask.DAL.Entities;
    using Microsoft.EntityFrameworkCore;

    public class UserDAL
    {
        UserDbContext context = new UserDbContext();

        public List<User> Get()
        {
            return context.Users.ToList();
        }

        public async Task<User> GetById(int id)
        {
            var user = await context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Create(User user)
        {
             await context.Users.AddAsync(user);
             await context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(int id, User user)
        {
            if (id != user.Id)
            {
                return null;
            }

            context.Entry(user).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return user;
        }


        public async Task<User> Delete(int id)
        {
            var userToDelete = await context.Users.FindAsync(id);
            if (userToDelete == null) return null;
            context.Users.Remove(userToDelete);
            await context.SaveChangesAsync();

            return userToDelete;
        }

    }
}