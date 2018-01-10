using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASarWebApi.Models
{
    public class UserOperations
    {
        UserContext context = new UserContext();

        public async Task<bool> UserExist(int id) {
            Utilities.CheckEF CEF = new Utilities.CheckEF();
            bool exist = false;
            var query = await (from data in context.Users
                               where data.Id == id
                               select data).FirstAsync();
            await Task.Run(() =>
            {
                exist = CEF.CheckUserWithID(query);
            });
            return exist;
        }


        //GET ONE
        public async Task<UserModel> GetUser(int id)
        {
            var query = await (from data in context.Users
                               where data.Id == id
                               select data).FirstAsync();
            return query;
        }

        //GET ALL
        public async Task<List<UserModel>> GetAllUsers() {
            var query = await (from data in context.Users
                         select data).ToListAsync();
            return query;

        }

        
        //CREATE
        public async Task<UserModel> CreateUser(UserModel UM) {
            context.Users.Add(new UserModel
            {
                Name = UM.Name,
                Birthdate = Convert.ToDateTime(UM.Birthdate)
            });
            await context.SaveChangesAsync();

            var query = new UserModel();
            await Task.Run(() => {
                query = (from datos in context.Users                           
                           select datos).Last(); 
            });
            return query;
        }

        //PUT


        //DELETE
    }
}