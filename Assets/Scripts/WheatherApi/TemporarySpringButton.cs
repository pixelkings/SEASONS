using UnityEngine;
using System.Collections;

public class TemporarySpringButton : MonoBehaviour {

	public float springPos1;
	public float springPos2;
	public float springPos3;
	public float springPos4;
	public float springPos5;

	public SpringPanel springPn;
	public UIGrid grid;
	bool canSwipe = false;

	public int actualButton = 0;

	public static TemporarySpringButton Instance;
	void Start()
	{
		Instance = this;
	}

	public void CheckIfIsDayOrNight(string timeString)
	{
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

	public void call1()
	{
		actualButton = 0;
		SpringBt.lastClicked = 0;
		springPn.target.x = springPos1;
		springPn.enabled = true;

		CheckIfIsDayOrNight(CitySwitcher.Instance.cities[0].GetComponent<CitiesLabelsManager>().noFormatedHour.ToString());

		if(BackgroundManager.isDay)
		{
			GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[0].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
			BackgroundManager.Instance.ChangeDayBackground();
		}else
		{
			GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[0].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
			BackgroundManager.Instance.ChangeNightBackground();
		}
	 
	}
	public void call2()
	{
		SpringBt.lastClicked = 1;
		actualButton = 1;
		springPn.target.x = springPos2;
		springPn.enabled = true;

		CheckIfIsDayOrNight(CitySwitcher.Instance.cities[1].GetComponent<CitiesLabelsManager>().noFormatedHour.ToString());

		if(BackgroundManager.isDay)
		{
			GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[1].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
			BackgroundManager.Instance.ChangeDayBackground();
		}else
		{
			GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[1].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
			BackgroundManager.Instance.ChangeNightBackground();
		}
	 
	}

	public void call3()
	{
		SpringBt.lastClicked = 2;
		actualButton = 2;
		springPn.target.x = springPos3;
		springPn.enabled = true;

		CheckIfIsDayOrNight(CitySwitcher.Instance.cities[2].GetComponent<CitiesLabelsManager>().noFormatedHour.ToString());

		if(BackgroundManager.isDay)
		{
			GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[2].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
			BackgroundManager.Instance.ChangeDayBackground();
		}else
		{
			GetWheatherCondition.Instance.weather = CitySwitcher.Instance.cities[2].GetComponent<CitiesLabelsManager>().WeatherCondition.text;
			BackgroundManager.Instance.ChangeNightBackground();
		}

	}
	public void call4()
	{
		actualButton = 3;
		SpringBt.lastClicked = 3;
		springPn.target.x = springPos4;
		springPn.enabled = true;

		CheckIfIsDayOrNight(CitySwitcher.Instance.cities[3].GetComponent<CitiesLabelsManager>().noFormatedHour.ToString());

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
	public void call5()
	{		
		actualButton = 4;
		SpringBt.lastClicked = 4;
		springPn.target.x = springPos5;
		springPn.enabled = true;

		CheckIfIsDayOrNight(CitySwitcher.Instance.cities[4].GetComponent<CitiesLabelsManager>().noFormatedHour.ToString());

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

	float counter = 0;

	void Update()
	{
		counter += Time.deltaTime;

		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began)
			{
				counter = 0;
				canSwipe = false;
			}

			if (touch.phase == TouchPhase.Moved)
			{
				canSwipe = true;
			}

			if (touch.phase == TouchPhase.Ended)
			{
				if(counter > 0.1f && canSwipe)
				{
					Debug.Log (touch.deltaPosition);
					if(touch.deltaPosition.x < -1.5f )
					{
						if((actualButton + 1) <= 3 && canSwipe)
						{
							int pos = actualButton+1;
							if(pos == 0)
							{
								call1();
							}else if(pos == 1)
							{
								call2();
							}else if(pos == 2)
							{
								call3();
							}else if(pos == 3)
							{
								call4();
							}else if(pos == 4)
							{
								call5();
							}
						}
					}else if(touch.deltaPosition.x > 1.5f && canSwipe)
					{
						if((actualButton - 1) >= 0)
						{
							int pos = actualButton-1;
							if(pos == 0)
							{
								call1();
							}else if(pos == 1)
							{
								call2();
							}else if(pos == 2)
							{
								call3();
							}else if(pos == 3)
							{
								call4();
							}else if(pos == 4)
							{
								call5();
							}
						}
					}
				}
			}
		}
	}

}
		