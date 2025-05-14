using FoodTekEF.Context;
using FoodTekEF.DTOs;
using FoodTekEF.DTOs.Login_DTOs;
using FoodTekEF.DTOs.SignUp_DTO;
using FoodTekEF.Entities;
using FoodTekEF.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodTekEF.Service
{
    public class AuthServise : IAuthentication
    {
        private readonly FoodTekDbContext _context;
        public AuthServise(FoodTekDbContext context)
        {
            _context = context;
        }
        public Task<string> Login(LoginRequest input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Restpassword(Restpassword input)
        {
            throw new NotImplementedException();
        }

        public Task<string> SendOTP(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<string> SignUp(SignUp input)
        {
            User user = new User();
            user.Fullname = input.Name;
            user.Email = input.Email;
            user.Password = input.Password;
            user.PhoneNumber = input.PhoneNumber;
            user.Birthdate = input.Birthdate;
            user.JoinDate = DateTime.Now;
            user.IsActive = true;
            user.CreatedBy = ("system");
            user.CreatedAt = DateTime.Now;
            user.UpdatedBy = ("system");
            user.UpdatedAt = DateTime.Now;
            user.Role =4 ;
            _context.Users.Add(user);
            _context.SaveChanges();
            return Task.FromResult("User Created Successfully");



        }
    }


}
