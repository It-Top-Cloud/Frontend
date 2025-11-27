using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using drive.DTO.Requests.Auth;
using drive.DTO.Respones.Auth;
using drive.Services.BaseAPI;

namespace drive.Services.Auth {
    internal class AuthService : IAuthService {
        private readonly IApiService api;
        private LoginRequest? loginRequest;

        public AuthService(IApiService api) {
            this.api = api; 
        }

        public async Task<LoginResponse> LoginAsync(string phone = "", string password = "") {
            if (!string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(password)) {
                loginRequest = new LoginRequest {
                    phone = phone,
                    password = password
                };
            }

            var response = await api.HttpAsync<LoginRequest, LoginResponse>(HttpMethod.Post, "api/v1/auth/login", loginRequest);
            api.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.token);

            return response!;
        }

        public async Task<LoginResponse> RegisterAsync(string phone, string password, string fname, string? sname = "", string? lname = "") {
            RegisterRequest request = new RegisterRequest {
                phone = phone,
                password = password,
                fname = fname,
                sname = sname,
                lname = lname
            };
            
            var response = await api.HttpAsync<RegisterRequest, LoginResponse>(HttpMethod.Post, "api/v1/auth/register", request);
            api.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.token);

            return response!;
        }
    }
}
