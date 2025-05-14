namespace FoodTekEF.DTOs.SignUp_DTO
{
    public class SignUp
    {
     
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name  { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly? Birthdate { get; set; }

    }           

}
