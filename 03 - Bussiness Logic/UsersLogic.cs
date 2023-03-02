using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class UsersLogic : BaseLogic
    {
        public bool IsUsernameExists(string username)
        {
            return db.Users.Any(u => u.Username == username);
        }

        public UserModel AddUser(UserModel userModel)
        {
            User userDB = userModel.ConvertToUser();
            db.Users.Add(userDB);
            db.SaveChanges();
            userModel.UserID = userDB.UserId;
            return userModel;
        }

        public UserModel? GetUserByCredentials(CredentialsModel credentials)
        {
            UserModel? userModel = db.Users
                .Where(u => u.Username == credentials.Username && u.Password == credentials.Password)
                .Select(u => new UserModel(u)).SingleOrDefault();
            return userModel;
        }

        public List<UserModel> GetAllUsers()
        {
            return db.Users.Select(u => new UserModel(u)).ToList();
        }

        public UserModel? GetUser(int id)
        {
            return db.Users.Where(u => u.UserId == id).Select(u => new UserModel(u)).SingleOrDefault();
        }

        public void RemoveUser(int id)
        {
            User? userToDelete = db.Users.SingleOrDefault(u => u.UserId == id);
            if (userToDelete == null)
                return;
            db.Users.Remove(userToDelete);
            db.SaveChanges();
        }

        public UserModel? FullUserUpdate(UserModel userModel)
        {
            User? userDB = db.Users.SingleOrDefault(u => u.UserId == userModel.UserID);

            if (userDB == null)
                return null;
            userDB.FullName = userModel.Name;
            userDB.Id = userModel.ID;
            userDB.Username = userModel.Username;
            userDB.BirthDate = userModel.Birth;
            userDB.Sex = userModel.Gender;
            userDB.Email = userModel.Email;
            userDB.Password = userModel.Password;
            userDB.UserImageName = userModel.ImageName;
            userDB.UserImagePath = userModel.ImagePath;
            db.SaveChanges();

            return userModel;
        }

        public UserModel? PartialUserUpdate(UserModel userModel)
        {
            User? userDB = db.Users.SingleOrDefault(u => u.UserId == userModel.UserID);

            if (userDB == null)
                return null;

            if (userModel.Name != null)
                userDB.FullName = userModel.Name;

            //if (userModel.ID != null)
            //    userDB.Id = userModel.ID;

            if (userModel.Username != null)
                userDB.Username = userModel.Username;

            if (userModel.Birth != null)
                userDB.BirthDate = userModel.Birth;

            //if (userModel.Gender != null)
            //    userDB.Sex = userModel.Gender;

            if (userModel.Email != null)
                userDB.Email = userModel.Email;

            if (userModel.Password != null)
                userDB.Password = userModel.Password;

            if (userModel.ImageName != null)
                userDB.UserImageName = userModel.ImageName;

            if (userModel.ImagePath != null)
                userDB.UserImagePath = userModel.ImagePath;

            db.SaveChanges();
            return userModel;
        }
    }
}
