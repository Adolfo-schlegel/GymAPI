using GymApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SyncController : Controller
    {
        public SyncController()
        {

        }
		[HttpPost("upload")]
		public async Task<IActionResult> UploadFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return BadRequest("No file uploaded.");

			var filePath = Path.Combine("uploads", file.FileName);

			// Ensure the directory exists
			Directory.CreateDirectory("uploads");

			// Save the file to the server
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return Ok(new { FilePath = filePath });
		}
		[HttpGet("sync")]
        public async Task<IActionResult> SyncUsers([FromQuery] int idBuilding)
        {
            int id = 1;

            var users = new List<User>()
            {
                new User
                {
                    allowed = true,
                    user_code = "62CE1051",
                    door_access = new List<int> { 1,2,3 }
				},
                new User
                {
				    allowed = true,
					user_code = "62FDAD51",
					door_access = new List<int> { 1,2 }
				},
				new User
				{
					allowed = true,
					user_code = "72164151",
					door_access = new List<int> { 1 }
				}
			};

            if (idBuilding != id)
                return BadRequest();

			return Ok(users);
		}
    }
}
