using FoodTekEF.DTOs.Login_DTOs;
using FoodTekEF.DTOs.SignUp_DTO;

namespace FoodTekEF.Interface
{
    public interface  Authentication
    {
        Task<string> SignUp(SignUp input);
        Task<string> Login(LoginRequest input);
        Task<string> sendOTP();

    }
}
