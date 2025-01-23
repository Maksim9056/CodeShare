using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
            await    _CodeShareDB.Users.AddAsync( user );
            await _CodeShareDB.SaveChangesAsync();


        }

        public async Task Update(Users user)
        {
             _CodeShareDB.Users.Update(user);
             await  _CodeShareDB.SaveChangesAsync();

        }

        public async Task Delete(Users user)        
        {
            user  = await _CodeShareDB.Users.FirstOrDefaultAsync(u =>u.UsersId ==user.UsersId);
            
            
             _CodeShareDB.Remove(user);


             var topic =  await _CodeShareDB.CodeSnippets.Where(u =>u.UserId == user.UsersId).ToListAsync();
            foreach (var i in topic)
            {
                Console.WriteLine($"{i.Title} {i.CodeSnippetsId} {i.UserId} {i.Programming_language} {i.Code}");
            
            } 
            await _CodeShareDB.SaveChangesAsync();

        }

        public async Task GetUser(long Id)
        {


        }

        public async Task<Users> CheckUser(string Email, string Password)
        {
          return    await _CodeShareDB.Users.FirstOrDefaultAsync(u => u.Email == Email && u.Password ==Password);
        }
    }
}
