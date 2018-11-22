using Petshop.Core.Entities;

namespace Petshop.Core.ApplicationService
{
    public interface IUserService
    {
        User GetWhereUsername(string username);

        bool CheckCorrectPassword(User user, LoginInput model);

        string GenerateToken(User user);

        User Create(User t);
    }
}