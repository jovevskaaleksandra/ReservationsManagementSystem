using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using ReservationSystem.API.Models;

namespace ReservationSystem.API.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ReservationSystemContext _context;

        public UsersController(ReservationSystemContext context) 
        {
            _context = context;
        }

        [HttpGet]
        [Route("roles")]
        public IActionResult GetUsersAndRoles()
        {
            var users = _context.UsersRoles.ToList();
            return Ok(users);
        }

        [HttpGet]
        [Route("reservations")]
        public IActionResult GetReservationsPerUsers()
        {
            var reservations = _context.ReservationsPerUsers.ToList();
            return Ok(reservations);
        }

        [HttpGet]
        [Route("{id}-info")]
        public IActionResult GetUserInfo([FromRoute]int id) 
        {
            var user = _context.Users.FromSqlRaw("SELECT * FROM get_user_info({0})",id);
            return Ok(user);
        }

        [HttpPost("edit")]
        public IActionResult EditUser(int userId, string firstName, string lastName, string username, string password, string email)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@user_id", NpgsqlDbType.Integer) { Value = userId },
                new NpgsqlParameter("@p_firstname", NpgsqlDbType.Varchar) { Value = firstName },
                new NpgsqlParameter("@p_lastname", NpgsqlDbType.Varchar) { Value = lastName },
                new NpgsqlParameter("@p_username", NpgsqlDbType.Varchar) { Value = username },
                new NpgsqlParameter("@p_password", NpgsqlDbType.Varchar) { Value = password },
                new NpgsqlParameter("@p_email", NpgsqlDbType.Varchar) { Value = email }
            };

            _context.Database.ExecuteSqlRaw("CALL edit_user(@user_id, @p_firstname, @p_lastname, @p_username, @p_password, @p_email)", parameters);

            return Ok();
        }

        [HttpDelete("delete-{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var parameter = new NpgsqlParameter("@user_id", NpgsqlDbType.Integer) { Value = userId };

            _context.Database.ExecuteSqlRaw("CALL delete_user(@user_id)", parameter);

            return Ok();
        }


        // this method doesn't work 
        [HttpPost("register")]
        public IActionResult InsertUser(string firstName, string lastName, string username, string password, string email, int roleId)
        {

            var parameters = new[]
            {
                new NpgsqlParameter("@p_firstname", NpgsqlDbType.Varchar) { Value = firstName },
                new NpgsqlParameter("@p_lastname", NpgsqlDbType.Varchar) { Value = lastName },
                new NpgsqlParameter("@p_username", NpgsqlDbType.Varchar) { Value = username },
                new NpgsqlParameter("@p_password", NpgsqlDbType.Varchar) { Value = password },
                new NpgsqlParameter("@p_email", NpgsqlDbType.Varchar) { Value = email },
                new NpgsqlParameter("@p_roleid", NpgsqlDbType.Integer) { Value = roleId },
            };

            var result =  _context.Users.FromSqlRaw("SELECT insert_user(@p_firstname, @p_lastname, @p_username, @p_password, @p_email, @p_roleid)", parameters).FirstOrDefault();

            return Ok(result);
        }



    }
}
