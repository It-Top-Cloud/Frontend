using System.ComponentModel.DataAnnotations;

namespace drive.DTO.Requests.Auth {
    internal class RegisterRequest {
        public string fname { get; set; }
        public string? sname { get; set; }
        public string? lname { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }
}
