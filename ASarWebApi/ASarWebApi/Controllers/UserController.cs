using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASarWebApi.Controllers
{
    public class UserController : ApiController
    {
        Utilities.CheckEF CEF = new Utilities.CheckEF();
        Utilities.LogUtility LU = new Utilities.LogUtility();
        Models.UserOperations UO = new Models.UserOperations(); 
        

        // GET api/<controller>
        public async Task<IHttpActionResult> GetALLUser()
        {
            try
            {
                List<UserModel> UML = new List<UserModel>();
                await Task.Run(() =>
                {
                    UML = UO.GetAllUsers().Result;
                });
                return Ok(UML);
            }
            catch(Exception ex)
            {
                LU.WriteLog("Error in GetALLUser "+ ex);
                return Content(HttpStatusCode.InternalServerError, "Error getting all users, contact with your admin");
            }
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> GetUser(int id)
        {
            try
            {
                if (!UO.UserExist(id))
                {
                    return Content(HttpStatusCode.InternalServerError, "This user don´t exist");
                }
                else
                {
                    UserModel UserRet = await UO.GetUser(id);
                    return Ok(UserRet);
                }
            }
            catch (Exception ex)
            {
                LU.WriteLog("Error in GetUser " + ex);
                return Content(HttpStatusCode.InternalServerError, "Error getting user, contact with your admin");
            }
        }

        // POST api/<controller> Create an user and return that user
        public async Task<IHttpActionResult> PostUser([FromBody]UserModel UM)
        {
            try
            {
                if (!ModelState.IsValid || !CEF.CheckUserWithoutID(UM))
                {
                    return Content(HttpStatusCode.InternalServerError, "Error creating user, check the model User(string), Birthdate(datetime(2000-01-14))");
                }
                //Create user
                UO.CreateUser(UM); // This method is not awaited because now is void, but it's ready for it
                                   //Return last user 
                                   //var toReturn =  UO.GetLast();
                UserModel toReturn = new UserModel();
                await Task.Run(() => toReturn = UO.GetLast().Result);
                return Ok(toReturn);
            }
            catch (Exception ex)
            {
                LU.WriteLog("Error in PostUser " + ex);
                return Content(HttpStatusCode.InternalServerError, "Error creating user, contact with your admin");
            }
        }

        // PUT api/<controller>/5
        public async Task<IHttpActionResult> PutUser([FromBody]UserModel UM)
        {
            try
            {
                if (!ModelState.IsValid || !CEF.CheckUserWithID(UM))
                {
                    return Content(HttpStatusCode.InternalServerError, "Error updating user, check the model ID(int), User(string), Birthdate(datetime(2000-01-14))");
                }
                //Update user
                //The same case as in postUser
                UO.UpdateUser(UM);
                UserModel toReturn = await UO.GetUser(UM.Id);
                return Ok(toReturn);
            }
            catch (Exception ex)
            {
                LU.WriteLog("Error in PutUser " + ex);
                return Content(HttpStatusCode.InternalServerError, "Error updating user, contact with your admin");
            }
        }

        // DELETE api/<controller>/5
        
        public async Task<IHttpActionResult> Delete ([FromBody] int id)
        {
            try
            {   
                if (UO.UserExist(id))
                {
                    await UO.DeleteUser(id);
                    return Ok("Borrado");
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, "This user don´t exist");
                }
            }
            catch (Exception ex)
            {
                LU.WriteLog("Error in Delete" + ex);
                return Content(HttpStatusCode.InternalServerError, "Error deleting user, contact with your admin");
            }
        }
    }
}