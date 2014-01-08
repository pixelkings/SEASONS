using UnityEngine;
using System.Collections;

public class SpringBt : MonoBehaviour {

	public static int lastClicked = 0;

	public void OnMouseOver()
	{
		if(Input.GetMouseButton(0))
		{
			Debug.Log("Clicked!!");
			if(gameObject.name == "Icon1")
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

			}else if(gameObject.name == "Icon2")
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
			}else if(gameObject.name == "Icon3")
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
			}else if(gameObject.name == "Icon4")
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
			}else if(gameObject.name == "Icon5")
			{
				TemporarySpringButton.Instance.call5();
				if(BackgroundManager.isDay)
				{
					GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[4].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
					BackgroundManager.Instance.ChangeDayBackground();
				}else
				{
					GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[4].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
					BackgroundManager.Instance.ChangeNightBackground();
				}
			}
		}

	}
}
