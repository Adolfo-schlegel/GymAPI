using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : Controller
	{
		public UserController() { }
		[HttpPost("sync")]
		public IActionResult addUser([FromQuery] int idBuilding, int Code)
		{
			//.add(INSERT INTO User VALUES (idBuilding, Code) )

			return Ok("User added succefully!");
		}
	}
}
