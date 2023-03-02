using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class UserModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Missing name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Missing id")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Missing username")]
        public string Username { get; set; } = null!;

        public DateTime? Birth { get; set; }

        [Range(1, 2, ErrorMessage = "sex must be 1(male) or 2(female)")]
        [Required(ErrorMessage = "Missing username")]
        public byte Gender { get; set; }

        [Required(ErrorMessage = "Missing email")]
        public string Email { get; set; } = null!;

        [Range(3, 30, ErrorMessage = "username must be between 3 to 30")]
        [Required(ErrorMessage = "Missing password")]
        public string Password { get; set; } = null!;

        public string? ImageName { get; set; }

        public byte[]? ImagePath { get; set; }

        public string Role { get; set; } = "User";

        public string? JwtToken { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            UserID = user.UserId;
            Name = user.FullName;
            ID = user.Id;
            Username = user.Username;
            Birth = user.BirthDate;
            Gender = user.Sex;
            Email = user.Email;
            Password = user.Password;
            ImageName = user.UserImageName;
            ImagePath = user.UserImagePath;
        }

        public User ConvertToUser()
        {
            User user = new User
            {
                UserId = UserID,
                FullName = Name,
                Id = ID,
                Username = Username,
                BirthDate = Birth,
                Sex = Gender,
                Email = Email,
                Password = Password,
                UserImageName = ImageName,
                UserImagePath = ImagePath
            };
            return user;
        }
    }    
}
