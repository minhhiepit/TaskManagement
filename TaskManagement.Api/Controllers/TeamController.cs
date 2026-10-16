using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.Dtos;
using TaskManagement.Business.Interfaces;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            return Ok(await _teamService.GetAllTeamsAsync());
        }

        [HttpGet("team/{name}")]
        public async Task<IActionResult> GetTeamByName(String name)
        {
            return Ok(await _teamService.GetTeamByNameAsync(name));
        }

        [HttpPost("team")]
        public async Task<IActionResult> AddTeam(TeamDto request)
        {
            return Ok(await _teamService.AddTeamAsync(request));
        }

        [HttpPut("member/{UserId}")]
        public async Task<IActionResult> AddMember(int UserId, [FromBody] AddUserToTeamDto request)
        {
            return Ok(await _teamService.AddMemberAsync(UserId, request));
        }

        [HttpPut("team")]
        public async Task<IActionResult> UpdateTeam(int TeamId, [FromBody] TeamDto request) {
            return Ok(await _teamService.UpdateTeamAsync(TeamId,request));
        }
    }
}
