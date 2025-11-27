using drive.DTO.Respones.Auth;

namespace drive.Services.Auth {
    internal interface IAuthService {
        Task<LoginResponse> LoginAsync(string phone = "", string password = "");
        Task<LoginResponse> RegisterAsync(string phone, string password, string fname, string? sname = "", string? lname = "");
    }
}
