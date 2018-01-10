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
        Models.UserOperations UO = new Models.UserOperations(); 

        // GET api/<controller>
        public async Task<IHttpActionResult> GetALLUser()
        {
            List<UserModel> UML = new List<UserModel>();
            await Task.Run(() => {
                UML = UO.GetAllUsers().Result;
            });
            return Ok(UML);
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> GetUser(int id)
        {
            UserModel UserRet = await UO.GetUser(id);
            //UserModel UM = new UserModel();
            //await Task.Run(() => {
            //    UM = UO.GetUser(id).Result;
            //});
            return Ok(UserRet);
        }

        // POST api/<controller> Create an user and return that user
        public async Task<IHttpActionResult> PostUser([FromBody]UserModel UM)
        {
            if (!ModelState.IsValid || !CEF.CheckUserWithoutID(UM))
            {
                return NotFound();
            }
            //Create user
             UO.CreateUser(UM); // This method is not awaited because now is void, but it's ready for it
                                //Return last user 
                                //var toReturn =  UO.GetLast();
            UserModel asd = new UserModel();
            await Task.Run(()=> asd = UO.GetLast().Result);                       
            return Ok(asd);
        }

        // PUT api/<controller>/5
        public async Task<IHttpActionResult> PutUser([FromBody]UserModel UM)
        {
            if (!ModelState.IsValid || !CEF.CheckUserWithID(UM))
            {
                return NotFound();
            }
            //Update user
            //The same case as in postUser
            UO.UpdateUser(UM);            
            UserModel toReturn = await UO.GetUser(UM.Id);
            return Ok(toReturn);
        }

        // DELETE api/<controller>/5
        
        public async Task<IHttpActionResult> Delete ([FromBody] int id)
        {           
            if (UO.UserExist(id))
            {
                await UO.DeleteUser(id);
                return Ok("Borrado");
            }
            else {
                return NotFound();
            }
        }
    }
}