namespace drive.DTO.Respones.Auth {
    internal class LoginResponse {
        public string token { get; set; }
        public Guid id { get; set; }
        public string phone { get; set; }
    }
}
