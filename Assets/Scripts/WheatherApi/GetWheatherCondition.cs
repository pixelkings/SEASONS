using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

//API KEY
//5be3b45e9718dd56
//api.wunderground.com

public class GetWheatherCondition : MonoBehaviour {

	public static GetWheatherCondition Instance;

	public string jsonUrl;
	public string weather;
	public CitiesLabelsManager firstElementData;

	void Start()
	{
		Instance = this;
	}
	
	public IEnumerator Wheather(string countryCode, string cityName)
	{
		WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/conditions/q/"+countryCode+"/"+cityName+".json");
		//WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/conditions/q/WA/kirkland.json");
		yield return www;

		//json Data
		string data;
		if(www != null && www.error != "null")
		{
			data = www.text;
			jsonUrl = data;
			ParseJson(jsonUrl);
			CitySwitcher.Instance.AddOtherCities();
		}else
		{
			data = www.error;
			AutomaticLocation.Instance.debug = www.error;
		}
	}

	public IEnumerator UpdateWheather(string countryCode, string cityName)
	{
		WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/conditions/q/"+countryCode+"/"+cityName+".json");
		//WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/conditions/q/WA/kirkland.json");
		yield return www;
		
		//json Data
		string data;
		if(www != null && www.error != "null")
		{
			data = www.text;
			jsonUrl = data;
			UpdateJson(jsonUrl);
			CitySwitcher.Instance.AddOtherCities();
		}else
		{
			data = www.error;
			AutomaticLocation.Instance.debug = www.error;
		}
	}

	public void ParseJson(string url)
	{
		//the Main Json Object
		JSONObject jsonObject = JSONObject.Parse(url);
		jsonObject = jsonObject["current_observation"].Obj;

		JSONObject locationJson = jsonObject["display_location"].Obj;

		AutomaticLocation.Instance.CityInfo.text = GetCity.Instance.cityName + ", " + locationJson["country_iso3166"].ToString().Replace("\"", "");

		float temp = float.Parse(jsonObject["temp_f"].ToString().Replace("\"", ""));
		temp = Mathf.Round(temp);
		AutomaticLocation.Instance.Temperature.text = temp.ToString() + "°";


		AutomaticLocation.Instance.WeatherCondition.text = jsonObject["weather"].ToString().Replace("\"", "");
		weather = jsonObject["weather"].ToString().Replace("\"", "");

		string timeString = jsonObject["local_time_rfc822"].ToString().Replace("\"", "");
		int stringCheck = timeString.IndexOf(":");
		stringCheck = timeString.IndexOf(":");
		timeString = timeString.Remove(stringCheck+6,((timeString.Length)-(stringCheck+6)));
		timeString = timeString.Remove(0,stringCheck-2);


		string[] splitedString = timeString.Split(':');
		string hour = splitedString[0];
		string minute = splitedString[1];
		string seconds = splitedString[2];

		firstElementData.noFormatedHour = int.Parse(hour);
		CheckIfIsDayOrNight(hour);

		string dayOrNight = "";

		if(int.Parse(hour) >=  12 && int.Parse(hour) <= 23)
		{
			dayOrNight = "PM";
			if(int.Parse(hour) == 12)
			{
				hour = "12";
			}else if(int.Parse(hour) == 13)
			{
				hour = "1";
			}else if(int.Parse(hour) == 14)
			{
				hour = "2";
			}else if(int.Parse(hour) == 15)
			{
				hour = "3";
			}else if(int.Parse(hour) == 16)
			{
				hour = "4";
			}else if(int.Parse(hour) == 17)
			{
				hour = "5";
			}else if(int.Parse(hour) == 18)
			{
				hour = "6";
			}else if(int.Parse(hour) == 19)
			{
				hour = "7";
			}else if(int.Parse(hour) == 20)
			{
				hour = "8";
			}else if(int.Parse(hour) == 21)
			{
				hour = "9";
			}else if(int.Parse(hour) == 22)
			{
				hour = "10";
			}else if(int.Parse(hour) == 23)
			{
				hour = "11";
			}

		}else
		{
			dayOrNight = "AM";
			if(int.Parse(hour) == 12)
			{
				hour = "00";
			}else if(int.Parse(hour) == 13)
			{
				hour = "1";
			}else if(int.Parse(hour) == 14)
			{
				hour = "2";
			}else if(int.Parse(hour) == 15)
			{
				hour = "3";
			}else if(int.Parse(hour) == 16)
			{
				hour = "4";
			}else if(int.Parse(hour) == 17)
			{
				hour = "5";
			}else if(int.Parse(hour) == 18)
			{
				hour = "6";
			}else if(int.Parse(hour) == 19)
			{
				hour = "7";
			}else if(int.Parse(hour) == 20)
			{
				hour = "8";
			}else if(int.Parse(hour) == 21)
			{
				hour = "9";
			}else if(int.Parse(hour) == 22)
			{
				hour = "10";
			}else if(int.Parse(hour) == 23)
			{
				hour = "11";
			}
		}

		AutomaticLocation.Instance.TimeInfo.text = "Time [ffffff]" + hour + ":" + minute + " " + dayOrNight;

		//dewpoint_c heat_index_c
		AutomaticLocation.Instance.FeelsLike.text = "Feels Like [ffffff]" + jsonObject["feelslike_f"].ToString().Replace("\"", "")+"°";

		StartCoroutine(GetHighAndLow(GetCity.Instance.countryCode,GetCity.Instance.cityName));

		//AutomaticLocation.Instance.High.text = "High [ffffff]" + jsonObject["heat_index_f"].ToString().Replace("\"", "")+"°";

		//AutomaticLocation.Instance.Low.text = "Low [ffffff]" + jsonObject["dewpoint_f"].ToString().Replace("\"", "")+"°";

		AutomaticLocation.Instance.Humidity.text = "Humidity [ffffff]" + jsonObject["relative_humidity"].ToString().Replace("\"", "");

		AutomaticLocation.Instance.Wind.text = "Wind [ffffff]" + jsonObject["wind_dir"].ToString().Replace("\"", "") + " " + jsonObject["wind_mph"].ToString().Replace("\"", "") + " mph";

	}

	public void UpdateJson(string url)
	{
		//the Main Json Object
		JSONObject jsonObject = JSONObject.Parse(url);
		jsonObject = jsonObject["current_observation"].Obj;
		
		JSONObject locationJson = jsonObject["display_location"].Obj;
		
		AutomaticLocation.Instance.CityInfo.text = locationJson["city"].ToString().Replace("\"", "") + ", " + locationJson["country_iso3166"].ToString().Replace("\"", "");
		
		float temp = float.Parse(jsonObject["temp_f"].ToString().Replace("\"", ""));
		temp = Mathf.Round(temp);
		AutomaticLocation.Instance.Temperature.text = temp.ToString() + "°";
		
		
		AutomaticLocation.Instance.WeatherCondition.text = jsonObject["weather"].ToString().Replace("\"", "");
		weather = jsonObject["weather"].ToString().Replace("\"", "");
		
		string timeString = jsonObject["local_time_rfc822"].ToString().Replace("\"", "");
		int stringCheck = timeString.IndexOf(":");
		stringCheck = timeString.IndexOf(":");
		timeString = timeString.Remove(stringCheck+6,((timeString.Length)-(stringCheck+6)));
		timeString = timeString.Remove(0,stringCheck-2);
		
		
		string[] splitedString = timeString.Split(':');
		string hour = splitedString[0];
		string minute = splitedString[1];
		string seconds = splitedString[2];
		
		firstElementData.noFormatedHour = int.Parse(hour);
		string dayOrNight = "";
		
		if(int.Parse(hour) >=  12 && int.Parse(hour) <= 23)
		{
			dayOrNight = "PM";
			if(int.Parse(hour) == 12)
			{
				hour = "12";
			}else if(int.Parse(hour) == 13)
			{
				hour = "1";
			}else if(int.Parse(hour) == 14)
			{
				hour = "2";
			}else if(int.Parse(hour) == 15)
			{
				hour = "3";
			}else if(int.Parse(hour) == 16)
			{
				hour = "4";
			}else if(int.Parse(hour) == 17)
			{
				hour = "5";
			}else if(int.Parse(hour) == 18)
			{
				hour = "6";
			}else if(int.Parse(hour) == 19)
			{
				hour = "7";
			}else if(int.Parse(hour) == 20)
			{
				hour = "8";
			}else if(int.Parse(hour) == 21)
			{
				hour = "9";
			}else if(int.Parse(hour) == 22)
			{
				hour = "10";
			}else if(int.Parse(hour) == 23)
			{
				hour = "11";
			}
			
		}else
		{
			dayOrNight = "AM";
			if(int.Parse(hour) == 12)
			{
				hour = "00";
			}else if(int.Parse(hour) == 13)
			{
				hour = "1";
			}else if(int.Parse(hour) == 14)
			{
				hour = "2";
			}else if(int.Parse(hour) == 15)
			{
				hour = "3";
			}else if(int.Parse(hour) == 16)
			{
				hour = "4";
			}else if(int.Parse(hour) == 17)
			{
				hour = "5";
			}else if(int.Parse(hour) == 18)
			{
				hour = "6";
			}else if(int.Parse(hour) == 19)
			{
				hour = "7";
			}else if(int.Parse(hour) == 20)
			{
				hour = "8";
			}else if(int.Parse(hour) == 21)
			{
				hour = "9";
			}else if(int.Parse(hour) == 22)
			{
				hour = "10";
			}else if(int.Parse(hour) == 23)
			{
				hour = "11";
			}
		}
		
		AutomaticLocation.Instance.TimeInfo.text = "Time [ffffff]" + hour + ":" + minute + " " + dayOrNight;
		
		//dewpoint_c heat_index_c
		AutomaticLocation.Instance.FeelsLike.text = "Feels Like [ffffff]" + jsonObject["feelslike_f"].ToString().Replace("\"", "")+"°";
		
		StartCoroutine(GetHighAndLow(GetCity.Instance.countryCode,GetCity.Instance.cityName));
		
		//AutomaticLocation.Instance.High.text = "High [ffffff]" + jsonObject["heat_index_f"].ToString().Replace("\"", "")+"°";
		
		//AutomaticLocation.Instance.Low.text = "Low [ffffff]" + jsonObject["dewpoint_f"].ToString().Replace("\"", "")+"°";
		
		AutomaticLocation.Instance.Humidity.text = "Humidity [ffffff]" + jsonObject["relative_humidity"].ToString().Replace("\"", "");
		
		AutomaticLocation.Instance.Wind.text = "Wind [ffffff]" + jsonObject["wind_dir"].ToString().Replace("\"", "") + " " + jsonObject["wind_mph"].ToString().Replace("\"", "") + " mph";
		
	}

	public void ParseJsonHighAndLow(string json)
	{
		//the Main Json Object
		JSONObject jsonObject = JSONObject.Parse(json);
		jsonObject = jsonObject["almanac"].Obj;

		JSONObject search = jsonObject["temp_high"].Obj;
		search = search["normal"].Obj;

		AutomaticLocation.Instance.High.text = "High [ffffff]" + search["F"].ToString().Replace("\"", "") +"°";

		search = jsonObject["temp_low"].Obj;
		search = search["normal"].Obj;
		AutomaticLocation.Instance.Low.text = "Low [ffffff]" + search["F"].ToString().Replace("\"", "") +"°";

	}

	public IEnumerator GetHighAndLow(string countryCode, string cityName)
	{
		WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/almanac/q/"+countryCode+"/"+cityName+".json");
		yield return www;
		
		//json Data
		string data;
		if(www != null && www.error != "null")
		{
			data = www.text;
			jsonUrl = data;
			ParseJsonHighAndLow(jsonUrl);
		}else
		{
			data = www.error;
			AutomaticLocation.Instance.debug = www.error;
		}
	}

	public void CheckIfIsDayOrNight(string timeString)
	{
		Debug.Log((int.Parse(timeString) < 18));
		if(int.Parse(timeString) > 6 && int.Parse(timeString) < 18)
		{
			//day
			BackgroundManager.Instance.ChangeDayBackground();
			BackgroundManager.isDay = true;
			Debug.Log("Day");

		}else
		{
			//night
			BackgroundManager.Instance.ChangeNightBackground();
			BackgroundManager.isDay = false;
			Debug.Log("Night");
		}
	}
	
}
