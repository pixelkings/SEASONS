using UnityEngine;
using System.Collections;
using System.Net;

public class GetIp : MonoBehaviour {

	//base get from http://checkip.dyndns.org/

	public static GetIp Instance;
	public string ip = "Getting Ip .... wait";
	public bool response = false;


	void Start()
	{
		Instance = this;
	}

//	public IEnumerator ipCall()
//	{
//		WWW www = new WWW("http://checkip.dyndns.org/");
//		yield return www;
//		string data;
//		if(www != null && www.error != "null")
//		{
//			Debug.Log("DATA GET!!!!");
//			data = www.text;
//			data = data.Substring(data.IndexOf(":")+1);
//			data = data.Substring(0,data.IndexOf("<"));
//			response = true;
//			GetWheatherCondition.Instance.statusResponse = "Status: Getting Location...";
//			//StartCoroutine(GetCity.Instance.City(data));
//		}else
//		{
//			Debug.Log("Error!!");
//			GetWheatherCondition.Instance.statusResponse = "Status: \n Error... Trying Again";
//			StartCoroutine(ipCall());
//			response = false;
//			data = www.error;
//		}
//
//		ip = data;
//	}

	void OnGUI()
	{
//		if(GUI.Button(new Rect(10,10,100,100)," Pegar cidade "))
//		{
//			StartCoroutine(GetCity.Instance.City(ip));
//		}
//		if(GUI.Button(new Rect(10,110,100,100)," Pegar tempo "))
//		{
//			StartCoroutine(GetWheatherCondition.Instance.Wheather());
//		}
	}

	void Update()
	{
		//implement recheck if response is true;
	}
}
