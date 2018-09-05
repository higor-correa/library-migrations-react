using System;

namespace Library.Domain.DTO.User.Login.Token
{
    public class TokenResponseDTO
    {
        public DateTime Expires { get; set; }
        public string Token { get; set; }
    }
}
