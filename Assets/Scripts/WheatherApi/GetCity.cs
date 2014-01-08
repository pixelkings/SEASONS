using UnityEngine;
using System.Collections;


public class GetCity : MonoBehaviour {

	public static GetCity Instance;
	public string cityString;

	public string cityName;
	public string countryName;
	public string countryCode;
	public string regionCode;
	public string regionName;

	void Start()
	{
		Instance = this;
	}

//	public IEnumerator City(string ip)
//	{
//		ip = ip.Remove(0);
//
//		WWW www = new WWW("http://freegeoip.net/json/"+ip);
//		yield return www;
//		string data;
//		if(www != null && www.error != "null")
//		{
//			data = www.text;
//			ParseJson(data);
//			GetWheatherCondition.Instance.statusResponse = "Status: \n City: "+cityName+"... Getting Wheather...";
//			StartCoroutine(GetWheatherCondition.Instance.Wheather(countryCode,cityName));
//		}else
//		{
//			data = www.error;
//		}
//		cityString = data;
//		Debug.Log(cityString);
//}

	public void ParseJson(string jsonUrl)
	{
//		JsonData data = JsonMapper.ToObject(jsonUrl);
//		countryCode = data["country_code"].ToString();
//		countryName = data["country_name"].ToString();
//		regionCode = data["region_code"].ToString();
//		regionName = data["region_name"].ToString();
//		cityName = data["city"].ToString();
	}
}
