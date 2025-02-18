using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Serilog;

namespace CodeShareUsers.Service
{
    public class ManagementUser: IManagentUser
    {

        private static ManagementUser _instance;

        public CodeShareDB _CodeShareDB;
        public ManagementUser(CodeShareDB codeShareDB )
        {
            _CodeShareDB = codeShareDB;
        }

      
        public async Task Registration(Users user )
        {
            try
            {


                await _CodeShareDB.Users.AddAsync(user);
                await _CodeShareDB.SaveChangesAsync();


                var Image = await  File.ReadAllBytesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Users.png"));
                //Image image = new Image() { UserId =user.UsersId,CreateAt =$"{DateTime.Now}",ImageDate=Convert.ToBase64String(Image) };


                var image = new Image
                {
                    UserId = user.UsersId,
                    ImageDate  = Convert.ToBase64String(Image),
                    CreateAt = DateTime.Now.ToString(),
                };
                await _CodeShareDB.Image.AddAsync(image);
                await _CodeShareDB.SaveChangesAsync();

                Log.Warning("Registration User {@User} registered successfully", user);


            }
            catch (Exception ex)
            {
                Log.Error("Exception User {@User} registered successfully", user, ex);

            }

        }

        public async Task<Users> Update(Users user)
        {
            try
            {


                var users = await _CodeShareDB.Users.FirstOrDefaultAsync(u => u.UsersId == user.UsersId);

                users.UsersName = user.UsersName;
                users.UsersId = user.UsersId;
                users.RoleId = user.RoleId;
                users.Email = user.Email;
                users.Password = user.Password;
                users.Phone = user.Phone;
                users.CreateAt = user.CreateAt;
                users.UpdatedAt = user.UpdatedAt;

                //_CodeShareDB.Users.Update(user);
                await _CodeShareDB.SaveChangesAsync();
                return users;
            }
            catch(Exception ex) 
            {
                Log.Error($"{ex.Message}", user);
                return new Users();
            }
        }

        public async Task<Users> Delete(Users user)
        {
            try
            {

                user = await _CodeShareDB.Users.FirstOrDefaultAsync(u => u.UsersId == user.UsersId);


                _CodeShareDB.Users.Remove(user);



                await _CodeShareDB.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", user);
                return new Users();
            }
        }

        public async Task<Users> GetUser(long Id)
        {
            try
            {


                var user = await _CodeShareDB.Users.FirstOrDefaultAsync(u => u.UsersId == Id);

                return user;
            }
            catch (Exception ex)
            {
                Log.Error("Exception User {@User} registered successfully", ex);
                return new Users() { };


            }
        }

        public async Task<Users> CheckUser(string Email, string Password)
        {
          return    await _CodeShareDB.Users.FirstOrDefaultAsync(u => u.Email == Email && u.Password ==Password);
        }
    }
}
