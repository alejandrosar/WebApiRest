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
            UserModel UM = new UserModel();
            await Task.Run(() => {
                UM = UO.GetUser(id).Result;
            });
            return Ok(UM);
        }

        // POST api/<controller>
        public async IHttpActionResult PostUser([FromBody]UserModel UM)
        {
            if (!ModelState.IsValid || !CEF.CheckUserWithoutID(UM))
            {
                return NotFound();
            }

        }

        // PUT api/<controller>/5
        public async IHttpActionResult PutUser([FromBody]UserModel UM)
        {
            if (!ModelState.IsValid || !CEF.CheckUserWithID(UM))
            {
                return NotFound();
            }
        }

        // DELETE api/<controller>/5
        public async IHttpActionResult DeleteUser(int id)
        {
            if (await UO.UserExist(id)) {

            }
        }
    }
}