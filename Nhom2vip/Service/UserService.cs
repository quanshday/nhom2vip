using System;
using System.Linq;
using System.Threading.Tasks;
using Nhom2vip.Model;
using Firebase.Database;
using Firebase.Database.Query;


namespace Nhom2vip.Service
{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://nhom2project-63649-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> IsUserExists (string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where( u => u.Object.Username == uname).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if (await IsUserExists(uname) == false)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    Username = uname,
                    Password = passwd
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();

            return (user != null);
        }
    }
}
