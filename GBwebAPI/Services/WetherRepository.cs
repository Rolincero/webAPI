namespace GBwebAPI.Services;

public class WetherRepository
{
	private List<WeatherForecast> _wf;

	public WetherRepository()
	{
		_wf = new List<WeatherForecast>();
	}

	public string Add(WeatherForecast wf)
	{
		if (!_wf.Contains(wf))
		{
			_wf.Add(wf);
			return "Added new instance";
		}
		return "Entered instance exists";
	}

	public string Remove(DateOnly date)
	{
		if (_wf.Find(i => i.Date == date) != null)
		{
			_wf.Remove(_wf.Find(i => i.Date == date)!);
			return "Removed entred instance";
		}
		return "Entred instance doesn't exist";
	}

	public string Update(DateOnly entrdDate, int temp)
	{
		if (_wf.Find(i => i.Date == entrdDate) != null)
		{
			_wf.Find(i => i.Date == entrdDate)!.TemperatureC = temp;
			return "Temperature changed";
		}
		return "Obj not found";
	}

	public IEnumerable<WeatherForecast> GetDateInterval(DateOnly start, DateOnly end)
	{
		return _wf.Where(i => i.Date >= start && i.Date <= end);
	}

	public IEnumerable<WeatherForecast> GetAll() => _wf;
}
