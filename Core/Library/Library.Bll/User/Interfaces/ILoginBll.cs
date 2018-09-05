using Library.Domain.DTO.User.Login;

namespace Library.Bll.User.Interfaces
{
    public interface ILoginBll
    {
        LoginResponseDTO Authenticate(string login, string password);
    }
}
