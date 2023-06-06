using isk.Database.Repository;
using isk.GeneralAPI.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Diagnostics.Tracing.StackSources;

namespace isk.GeneralAPI.Controllers
{
    [Authorize]
    [Route("User")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IRepository repository) : base(repository)
        {

        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(string id)
        {
            //https://stackoverflow.com/questions/44500007/how-to-query-many-to-many-releationship-in-ef-core
            var usr = Repository
                .Get<User>()
                .Where(u => u.UserId.Equals(id))
                .FirstOrDefault();

            if (usr == null)
            {
                return NotFound();
            }

            return Ok(usr);
        }

        [HttpGet("{id}/Friends")]
        public IActionResult GetFriendsById(Guid id)
        {
            try
            {
                var users = Repository.Get<User>()
                    .Where(u => u.UserId.Equals(id));
                return Ok(users);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet("GetUsers")]
        [HttpGet("", Name = "GetUsers")]
        public IActionResult Get()
        {
            return Ok(Repository.Get<User>());
        }

        [HttpPost]
        public IActionResult Create(User entity)
        {
            Repository.Create(entity);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(User entity)
        {
            Repository.Update(entity);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(User entity)
        {
            Repository.Delete(entity);
            return Ok();
        }
    }
}