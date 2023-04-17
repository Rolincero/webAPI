using GBwebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GBwebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChangerController : ControllerBase
{
	private WetherRepository _WRepos;

	public ChangerController(WetherRepository wf)
	{
		_WRepos = wf;
	}

	[HttpPost("Add")]
	public IActionResult Add([FromBody] WeatherForecast wf)
	{
		return Ok(_WRepos.Add(wf));
	}

	[HttpDelete("Remove")]
	public IActionResult Remove(DateOnly date)
	{
		return Ok(_WRepos.Remove(date));
	}

	[HttpGet("GetAll")]
	public IEnumerable<WeatherForecast> AllInstances()
	{
		return _WRepos.GetAll();
	}

	[HttpGet("GetInterval")]
	public IEnumerable<WeatherForecast> DateInterval(DateOnly start, DateOnly end)
	{
		return _WRepos.GetDateInterval(start, end);
	}

	[HttpPut("UpdInstance")]
	public IActionResult Update(DateOnly date, int temp)
	{
		return Ok(_WRepos.Update(date, temp));
	}
}
