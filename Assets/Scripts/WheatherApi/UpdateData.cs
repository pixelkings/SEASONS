using UnityEngine;
using System.Collections;

public class UpdateData : MonoBehaviour {

	public float UpdateTime = 60;
	public static bool updating = false;

	float timer;

	void Start()
	{
		timer = UpdateTime;
	}

	void Update () {
		timer -= Time.deltaTime;
		if(timer > 0)
		{
			//time running;
		}else 
		{
			Debug.Log("Updated!");
			//time over
			updating = true;
			StartCoroutine(GetWheatherCondition.Instance.UpdateWheather(GetCity.Instance.countryCode,GetCity.Instance.cityName));
			timer = UpdateTime;
		}
	}
}
