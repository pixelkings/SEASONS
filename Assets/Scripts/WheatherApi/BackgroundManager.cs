using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

	public static bool isDay = false;
	public UISprite backgroundSprite;

	public GameObject Sun;
	public GameObject Moon;
	public GameObject Cloud;
	public GameObject Rain;
	public GameObject Lightning;
	public GameObject Snow;


	public UIAtlas bgDayAtlas;
	public UIAtlas bgNightAtlas;
	public UIAtlas bgWarmSun;
	public UIAtlas bgNightRain;


	public UIAtlas cloudPartlyCloudy;
	public UIAtlas scatteredCloudy;
	public UIAtlas warmCloud;
	public UIAtlas cloudFog;

	public static BackgroundManager Instance;

	void Start()
	{
		Instance = this;
	}


	public void ChangeDayBackground()
	{
		Sun.SetActive(true);
		Moon.SetActive(false);
		Rain.SetActive(false);
		//check temperature
		//if  40-70 blue with rounded
		//if 39 or < clear blue
		//if sunrise make change to sunrise bg
		//if 71 - 89 orange bg
		//90 > red bg

		backgroundSprite.atlas = bgDayAtlas;
		backgroundSprite.spriteName = "background_day";

		if(GetWheatherCondition.Instance.weather == "Drizzle")
		{
			
			Lightning.SetActive(false);
			Snow.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Rain")
		{
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Lightning.SetActive(false);
			Snow.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Snow" || GetWheatherCondition.Instance.weather == "Snow Grains" || GetWheatherCondition.Instance.weather == "Ice Crystals" || GetWheatherCondition.Instance.weather == "Ice Pellets"
		         || GetWheatherCondition.Instance.weather == "Hail" || GetWheatherCondition.Instance.weather == "Freezing Drizzle" || GetWheatherCondition.Instance.weather == "Freezing Rain" || GetWheatherCondition.Instance.weather == "Freezing Fog"){

			Sun.SetActive(false);
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Lightning.SetActive(false);
			Snow.SetActive(true);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Mist")
		{
			
			Lightning.SetActive(false);
			Snow.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Fog" || GetWheatherCondition.Instance.weather == "Fog Patches" || GetWheatherCondition.Instance.weather == "Patches of Fog" ||
		         GetWheatherCondition.Instance.weather == "Shallow Fog" ||  GetWheatherCondition.Instance.weather == "Partial Fog")
		{
			
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudFog;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Fog";
			
		}else if(GetWheatherCondition.Instance.weather == "Smoke")
		{
			
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudFog;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Fog";
			
		}else if(GetWheatherCondition.Instance.weather == "Haze")
		{
			
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudFog;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Fog";
			
		}else if(GetWheatherCondition.Instance.weather == "Thunderstorm" || GetWheatherCondition.Instance.weather == "Thunderstorms and Rain" )
		{
			Sun.SetActive(false);
			Snow.SetActive(false);
			Lightning.SetActive(true);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Rain.SetActive(true);
			
		}else if(GetWheatherCondition.Instance.weather == "Overcast")
		{
			Sun.SetActive(false);
			Snow.SetActive(false);
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Clear")
		{
			
			Snow.SetActive(false);
			Lightning.SetActive(false);
			Cloud.SetActive(false);
			Rain.SetActive(false);
			
		}else if(GetWheatherCondition.Instance.weather == "Partly Cloudy")
		{
			
			Lightning.SetActive(false);
			Snow.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Mostly Cloudy")
		{
			Snow.SetActive(false);
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Scattered Clouds")
		{
			Snow.SetActive(false);
			Lightning.SetActive(false);
			//add partly cloudy sprite
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = scatteredCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Partly";
			
		}else if(GetWheatherCondition.Instance.weather == "Small Hail")
		{
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Lightning.SetActive(false);
			Snow.SetActive(true);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Squalls")
		{
			Snow.SetActive(false);
			Lightning.SetActive(true);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Rain.SetActive(true);
			
		}else if(GetWheatherCondition.Instance.weather == "Funnel Cloud")
		{
			Snow.SetActive(false);
			Lightning.SetActive(true);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Rain.SetActive(true);
			
		}else if(GetWheatherCondition.Instance.weather == "Unknown" || GetWheatherCondition.Instance.weather == "Unknown Precipitation")
		{
			
			Snow.SetActive(false);
			Lightning.SetActive(true);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Rain.SetActive(true);
			
		}

	}

	public void ChangeNightBackground()
	{
		Sun.SetActive(false);
		Moon.SetActive(true);
		Rain.SetActive(false);
		backgroundSprite.atlas = bgNightAtlas;
		backgroundSprite.spriteName = "background_night";

		/*
		 * [Light/Heavy] Drizzle
[Light/Heavy] Rain
[Light/Heavy] Snow
[Light/Heavy] Snow Grains
[Light/Heavy] Ice Crystals
[Light/Heavy] Ice Pellets
[Light/Heavy] Hail
[Light/Heavy] Mist
[Light/Heavy] Fog
[Light/Heavy] Fog Patches
[Light/Heavy] Smoke
[Light/Heavy] Volcanic Ash
[Light/Heavy] Widespread Dust
[Light/Heavy] Sand
[Light/Heavy] Haze
[Light/Heavy] Spray
[Light/Heavy] Dust Whirls
[Light/Heavy] Sandstorm
[Light/Heavy] Low Drifting Snow
[Light/Heavy] Low Drifting Widespread Dust
[Light/Heavy] Low Drifting Sand
[Light/Heavy] Blowing Snow
[Light/Heavy] Blowing Widespread Dust
[Light/Heavy] Blowing Sand
[Light/Heavy] Rain Mist
[Light/Heavy] Rain Showers
[Light/Heavy] Snow Showers
[Light/Heavy] Snow Blowing Snow Mist
[Light/Heavy] Ice Pellet Showers
[Light/Heavy] Hail Showers
[Light/Heavy] Small Hail Showers
[Light/Heavy] Thunderstorm
[Light/Heavy] Thunderstorms and Rain
[Light/Heavy] Thunderstorms and Snow
[Light/Heavy] Thunderstorms and Ice Pellets
[Light/Heavy] Thunderstorms with Hail
[Light/Heavy] Thunderstorms with Small Hail
[Light/Heavy] Freezing Drizzle
[Light/Heavy] Freezing Rain
[Light/Heavy] Freezing Fog
Patches of Fog
Shallow Fog
Partial Fog
Overcast
Clear
Partly Cloudy
Mostly Cloudy
Scattered Clouds
Small Hail
Squalls
Funnel Cloud
Unknown Precipitation
Unknown*/

		if(GetWheatherCondition.Instance.weather == "Drizzle")
		{

			Lightning.SetActive(false);
			Snow.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";

		}else if(GetWheatherCondition.Instance.weather == "Rain")
		{
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";

			Lightning.SetActive(false);
			Snow.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";

		}else if(GetWheatherCondition.Instance.weather == "Snow" || GetWheatherCondition.Instance.weather == "Snow Grains" || GetWheatherCondition.Instance.weather == "Ice Crystals" || GetWheatherCondition.Instance.weather == "Ice Pellets"
		         || GetWheatherCondition.Instance.weather == "Hail" || GetWheatherCondition.Instance.weather == "Freezing Drizzle" || GetWheatherCondition.Instance.weather == "Freezing Rain" || GetWheatherCondition.Instance.weather == "Freezing Fog"){

			Moon.SetActive(false);
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Lightning.SetActive(false);
			Snow.SetActive(true);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Mist")
		{

			Lightning.SetActive(false);
			Snow.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Fog" || GetWheatherCondition.Instance.weather == "Fog Patches" || GetWheatherCondition.Instance.weather == "Patches of Fog" ||
		GetWheatherCondition.Instance.weather == "Shallow Fog" ||  GetWheatherCondition.Instance.weather == "Partial Fog")
		{
			
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudFog;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Fog";
			
		}else if(GetWheatherCondition.Instance.weather == "Smoke")
		{
			
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudFog;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Fog";
			
		}else if(GetWheatherCondition.Instance.weather == "Haze")
		{
			
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudFog;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Fog";
			
		}else if(GetWheatherCondition.Instance.weather == "Thunderstorm" || GetWheatherCondition.Instance.weather == "Thunderstorms and Rain" )
		{
			Moon.SetActive(false);
			Snow.SetActive(false);
			Lightning.SetActive(true);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Rain.SetActive(true);
			
		}else if(GetWheatherCondition.Instance.weather == "Overcast")
		{

			Moon.SetActive(false);
			Snow.SetActive(false);
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Clear")
		{

			Snow.SetActive(false);
			Lightning.SetActive(false);
			Cloud.SetActive(false);
			Rain.SetActive(false);

		}else if(GetWheatherCondition.Instance.weather == "Partly Cloudy")
		{

			Lightning.SetActive(false);
			Snow.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";

		}else if(GetWheatherCondition.Instance.weather == "Mostly Cloudy")
		{
			Snow.SetActive(false);
			Lightning.SetActive(false);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";

		}else if(GetWheatherCondition.Instance.weather == "Scattered Clouds")
		{
			Snow.SetActive(false);
			Lightning.SetActive(false);
			//add partly cloudy sprite
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = scatteredCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Partly";

		}else if(GetWheatherCondition.Instance.weather == "Small Hail")
		{
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Lightning.SetActive(false);
			Snow.SetActive(true);
			Cloud.SetActive(true);
			Rain.SetActive(false);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
		}else if(GetWheatherCondition.Instance.weather == "Squalls")
		{
			Snow.SetActive(false);
			Lightning.SetActive(true);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Rain.SetActive(true);
			
		}else if(GetWheatherCondition.Instance.weather == "Funnel Cloud")
		{
			Snow.SetActive(false);
			Lightning.SetActive(true);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Rain.SetActive(true);
			
		}else if(GetWheatherCondition.Instance.weather == "Unknown" || GetWheatherCondition.Instance.weather == "Unknown Precipitation")
		{

			Snow.SetActive(false);
			Lightning.SetActive(true);
			Cloud.SetActive(true);
			Cloud.GetComponent<UISprite>().atlas = cloudPartlyCloudy;
			Cloud.GetComponent<UISprite>().spriteName = "Icon_Cloud_Rain";
			
			backgroundSprite.atlas = bgNightRain;
			backgroundSprite.spriteName = "background_night_rain";
			
			Rain.SetActive(true);
			
		}
	}

//	void OnGUI()
//	{
//		if(GUI.Button(new Rect(10,Screen.height-40,100,30),"Rain"))
//		{
//			MakeRain();
//		}
//		if(GUI.Button(new Rect(Screen.width - 110,Screen.height-40,100,30),"Warm Sun"))
//		{
//			HotSun();
//		}
//	}
}
