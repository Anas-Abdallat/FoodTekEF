using FoodTekEF.DTOs;
using FoodTekEF.DTOs.Login_DTOs;
using FoodTekEF.DTOs.SignUp_DTO;

namespace FoodTekEF.Interface
{
    public interface IAuthentication
    {
        Task<string> SignUp(SignUp input);
        Task<string> Login(LoginRequest input);
        Task <bool> Restpassword(Restpassword input);
        Task<string> SendOTP(string Email);

    }
}
