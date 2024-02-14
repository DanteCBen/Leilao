using Leilao.API.Entities;

namespace Leilao.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
