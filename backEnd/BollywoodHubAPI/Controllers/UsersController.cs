using BollywoodHubAPI.Data;
using BollywoodHubAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BollywoodHubAPI.Controllers
{
    //localhost:xxxx/api/users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = dbContext.User.ToList();

            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserId(Guid id) 
        {
            var specificUser = dbContext.User.Find(id);

            if (specificUser == null) 
            {
                return NotFound();
            }
            return Ok(specificUser);
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity = new Models.Entities.Users()
            {
                Name = addUserDto.Name,
                Email = addUserDto.Email,
                Password = addUserDto.Password
            };

            dbContext.User.Add(userEntity);
            dbContext.SaveChanges();
            return Ok(userEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateUser(Guid id, UpdateUserDto updateUserDto)  
        {
            var updateUser = dbContext.User.Find(id);
            if (updateUser == null) 
            {
                return NotFound();
            }

            updateUser.Name = updateUserDto.Name;
            updateUser.Email = updateUserDto.Email;
            updateUser.Password = updateUserDto.Password;

            dbContext.SaveChanges();
            return Ok(updateUser);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUser(Guid id) 
        {
            var deleteUser = dbContext.User.Find(id);
            if (deleteUser == null)
            {
                return NotFound();
            }
            dbContext.User.Remove(deleteUser);
            dbContext.SaveChanges();
            return Ok(deleteUser);
        }
    }
}
