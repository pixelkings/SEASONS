using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class CitySwitcher : MonoBehaviour {

	public static CitySwitcher Instance;

	public GameObject labelElement;
	public int numberOfCities;
	public string weather;

	public string jsonUrl;

	public GameObject[] cities;

	void Start()
	{
		Instance = this;
	}

	public void AddOtherCities()
	{
		if(!UpdateData.updating)
		{
			cities = new GameObject[numberOfCities];
			for(int x = 0; x < cities.Length;x++)
			{
				if(x == 0)
				{
					cities[x] = labelElement;
					cities[x].SetActive(true);
					
				}else
				{
					cities[x] = (GameObject)GameObject.Instantiate(labelElement);
					cities[x].gameObject.transform.parent = labelElement.gameObject.transform.parent;
					cities[x].transform.localPosition = labelElement.transform.localPosition;
					cities[x].transform.localRotation = labelElement.transform.localRotation;
					cities[x].SetActive(true);
					
				}
			}
			TemporarySpringButton.Instance.grid.repositionNow = true;
		}
		StartCoroutine(GetCity1());
		//labelElement.SetActive(false);

	}

	public IEnumerator GetCity1()
	{
		WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/conditions/q/tx/dallas.json");
		yield return www;
		
		//json Data
		string data;
		if(www != null && www.error != "null")
		{
			data = www.text;
			ParseJson(data,1);
			StartCoroutine(GetCity2());
		}else
		{
			data = www.error;
			AutomaticLocation.Instance.debug = www.error;
		}
	}
	public IEnumerator GetCity2()
	{
		WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/conditions/q/hi/Honolulu.json");
		yield return www;
		
		//json Data
		string data;
		if(www != null && www.error != "null")
		{
			data = www.text;
			ParseJson(data,2);
			StartCoroutine(GetCity3());
		}else
		{
			data = www.error;
			AutomaticLocation.Instance.debug = www.error;
		}
	}
	public IEnumerator GetCity3()
	{
		WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/conditions/q/ny/NewYork.json");
		yield return www;
		
		//json Data
		string data;
		if(www != null && www.error != "null")
		{
			data = www.text;
			ParseJson(data,3);
//			StartCoroutine(GetCity4());
		}else
		{
			data = www.error;
			AutomaticLocation.Instance.debug = www.error;
		}
	}

	public void ParseJson(string json, int pos)
	{
		JSONObject jsonObject = JSONObject.Parse(json);
		jsonObject = jsonObject["current_observation"].Obj;
		
		JSONObject locationJson = jsonObject["display_location"].Obj;

		if(locationJson["country_iso3166"].ToString().Replace("\"", "") == "" || locationJson["country_iso3166"].ToString().Replace("\"", "") == " ")
		{
			cities[pos].GetComponent<CitiesLabelsManager>().CityInfo.text= locationJson["city"].ToString().Replace("\"", "") + ", " + locationJson["country_iso3166"].ToString().Replace("\"", "");
		}else
		{
			cities[pos].GetComponent<CitiesLabelsManager>().CityInfo.text= locationJson["city"].ToString().Replace("\"", "") + ", " + locationJson["state"].ToString().Replace("\"", "");
		}


		float temp = float.Parse(jsonObject["temp_f"].ToString().Replace("\"", ""));
		temp = Mathf.Round(temp);
		cities[pos].GetComponent<CitiesLabelsManager>().Temperature.text = temp.ToString() + "°";
		
		
		cities[pos].GetComponent<CitiesLabelsManager>().WeatherCondition.text = jsonObject["weather"].ToString().Replace("\"", "");
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

		string dayOrNight = "";

		cities[pos].GetComponent<CitiesLabelsManager>().noFormatedHour = int.Parse(hour);

		if(int.Parse(hour) >= 12 && int.Parse(hour) <= 23)
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
		}


		cities[pos].GetComponent<CitiesLabelsManager>().TimeInfo.text = "Time [ffffff]" + hour + ":" + minute + " " + dayOrNight;
		
		//dewpoint_c heat_index_c
		cities[pos].GetComponent<CitiesLabelsManager>().FeelsLike.text = "Feels Like [ffffff]" + jsonObject["feelslike_f"].ToString().Replace("\"", "")+"°";


		if(pos == 0)
		{
			StartCoroutine(GetHighAndLow(GetCity.Instance.countryCode,GetCity.Instance.cityName,pos));
		}else if(pos == 1)
		{
			StartCoroutine(GetHighAndLow("tx","Dallas",pos));
		}else if(pos == 2)
		{
			StartCoroutine(GetHighAndLow("hi","Honolulu",pos));
		}else if(pos == 3)
		{
			StartCoroutine(GetHighAndLow("ny","New_York",pos));
			if(UpdateData.updating)
			{
				if(SpringBt.lastClicked == 0)
				{
					TemporarySpringButton.Instance.call1();
					if(BackgroundManager.isDay)
					{
						GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[0].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
						BackgroundManager.Instance.ChangeDayBackground();
					}else
					{
						GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[0].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
						BackgroundManager.Instance.ChangeNightBackground();
					}
				}else if(SpringBt.lastClicked == 1)
				{
					TemporarySpringButton.Instance.call2();
					if(BackgroundManager.isDay)
					{
						GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[1].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
						BackgroundManager.Instance.ChangeDayBackground();
					}else
					{
						GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[1].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
						BackgroundManager.Instance.ChangeNightBackground();
					}
				}else if(SpringBt.lastClicked == 2)
				{
					TemporarySpringButton.Instance.call3();
					if(BackgroundManager.isDay)
					{
						GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[2].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
						BackgroundManager.Instance.ChangeDayBackground();
					}else
					{
						GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[2].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
						BackgroundManager.Instance.ChangeNightBackground();
					}
				}else if(SpringBt.lastClicked == 3)
				{
					TemporarySpringButton.Instance.call4();
					if(BackgroundManager.isDay)
					{
						GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[3].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
						BackgroundManager.Instance.ChangeDayBackground();
					}else
					{
						GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[3].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
						BackgroundManager.Instance.ChangeNightBackground();
					}
				}


			}
			UpdateData.updating = false;
		}

//		cities[pos].GetComponent<CitiesLabelsManager>().High.text = "High [ffffff]" + jsonObject["heat_index_f"].ToString().Replace("\"", "")+"°";
//		
//		cities[pos].GetComponent<CitiesLabelsManager>().Low.text = "Low [ffffff]" + jsonObject["dewpoint_f"].ToString().Replace("\"", "")+"°";
		
		cities[pos].GetComponent<CitiesLabelsManager>().Humidity.text = "Humidity [ffffff]" + jsonObject["relative_humidity"].ToString().Replace("\"", "");
		
		cities[pos].GetComponent<CitiesLabelsManager>().Wind.text = "Wind [ffffff]" + jsonObject["wind_dir"].ToString().Replace("\"", "") + " " + jsonObject["wind_mph"].ToString().Replace("\"", "") + " mph";

	}


	public void ParseJsonHighAndLow(string json,int pos)
	{
		//the Main Json Object
		JSONObject jsonObject = JSONObject.Parse(json);
		jsonObject = jsonObject["almanac"].Obj;
		
		JSONObject search = jsonObject["temp_high"].Obj;
		search = search["normal"].Obj;
		
		cities[pos].GetComponent<CitiesLabelsManager>().High.text = "High [ffffff]" + search["F"].ToString().Replace("\"", "") +"°";
		
		search = jsonObject["temp_low"].Obj;
		search = search["normal"].Obj;
		cities[pos].GetComponent<CitiesLabelsManager>().Low.text = "Low [ffffff]" + search["F"].ToString().Replace("\"", "") +"°";
	}

	public IEnumerator GetHighAndLow(string countryCode, string cityName,int pos)
	{
		WWW www = new WWW("http://api.wunderground.com/api/5be3b45e9718dd56/almanac/q/"+countryCode+"/"+cityName+".json");
		yield return www;
		
		//json Data
		string data;
		if(www != null && www.error != "null")
		{
			data = www.text;
			jsonUrl = data;
			ParseJsonHighAndLow(jsonUrl,pos);
		}else
		{
			data = www.error;
			AutomaticLocation.Instance.debug = www.error;
		}
	}
}

