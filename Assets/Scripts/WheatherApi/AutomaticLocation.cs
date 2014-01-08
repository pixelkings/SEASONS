#define ANDROID
using UnityEngine;
using System.Collections;
//BASE REQUESTS http://freegeoip.net/json/186.250.214.70
//BASE REQUEST OF THE WHEATER  ex: http://api.wunderground.com/api/5be3b45e9718dd56/conditions/q/BR/Limeira.json

public class AutomaticLocation : MonoBehaviour {
	public static AutomaticLocation Instance;
	public UILabel statusLabel;

	public UILabel CityInfo;
	public UILabel WeatherCondition;
	public UILabel Temperature;
	public UILabel TimeInfo;
	public UILabel High;
	public UILabel Low;
	public UILabel FeelsLike;
	public UILabel Humidity;
	public UILabel Wind;

	public string debug;

	public GameObject gpsManager;

	IEnumerator Start()
	{
		yield return new WaitForSeconds(1);
		Instance = this;
		//CallGetIp();
		CallGetGps();
	}

	void CallGetGps()
	{
		gpsManager.GetComponent<GPSManager>().enabled = true;
	}

	void CallGetIp()
	{
//		GetWheatherCondition.Instance.statusResponse = "Status: Getting IP...";
//		StartCoroutine(GetIp.Instance.ipCall());
	}

	void Update()
	{
//		statusLabel.text = GetWheatherCondition.Instance.statusResponse;
	}

	void OnGUI()
	{
		//Uncomment that line to show the Debug text!
		//GUI.Label(new Rect(20,150,200,100),debug);
	}
}
