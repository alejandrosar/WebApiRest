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

        //GET LAST
        public async Task<UserModel> GetLast()
        {
            var query = await (from data in context.Users
                                select data).ToListAsync();
            var ret = query.Last();
            return ret;
       
             
             
        }
        //CREATE 
        public  void CreateUser(UserModel UM) {
            context.Users.Add(new UserModel
            {
                Name = UM.Name,
                Birthdate = Convert.ToDateTime(UM.Birthdate)
            });
            context.SaveChanges();
            //GetLast to return this user? (I do not know how you like it more) 
        }

        //PUT
        public async void UpdateUser(UserModel UM)
        {
            var consulta = (from datos in context.Users
                            where datos.Id == UM.Id
                            select datos).FirstOrDefault();

            consulta.Name = UM.Name;
            consulta.Birthdate = Convert.ToDateTime(UM.Birthdate);

            await context.SaveChangesAsync();

            
        }

        //DELETE

        public async Task<bool> DeleteUser(int id) {
            var consulta = (from datos in context.Users
                            where datos.Id == id
                            select datos).FirstOrDefault();
            context.Users.Remove(consulta);
            try {
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            }

    }

}