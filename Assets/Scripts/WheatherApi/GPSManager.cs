using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Text;
using Boomlagoon.JSON;

public class GPSManager : MonoBehaviour {

	public static GPSManager Instance;

	string testeJson = @"{
   ""results"" : [
      {
         ""address_components"" : [
            {
               ""long_name"" : ""1409"",
               ""short_name"" : ""1409"",
               ""types"" : [ ""street_number"" ]
            },
            {
               ""long_name"" : ""Rua Carlos Chagas"",
               ""short_name"" : ""Rua Carlos Chagas"",
               ""types"" : [ ""route"" ]
            },
            {
               ""long_name"" : ""Tijuca"",
               ""short_name"" : ""Tijuca"",
               ""types"" : [ ""neighborhood"", ""political"" ]
            },
            {
               ""long_name"" : ""Alvorada"",
               ""short_name"" : ""Alvorada"",
               ""types"" : [ ""administrative_area_level_2"", ""political"" ]
            },
            {
               ""long_name"" : ""Rio Grande do Sul"",
               ""short_name"" : ""RS"",
               ""types"" : [ ""administrative_area_level_1"", ""political"" ]
            },
            {
               ""long_name"" : ""Brazil"",
               ""short_name"" : ""BR"",
               ""types"" : [ ""country"", ""political"" ]
            },
            {
               ""long_name"" : ""94836"",
               ""short_name"" : ""94836"",
               ""types"" : [ ""postal_code_prefix"", ""postal_code"" ]
            }
         ],
         ""formatted_address"" : ""Rua Carlos Chagas, 1409 - Tijuca, Rio Grande do Sul, Brazil"",
         ""geometry"" : {
            ""bounds"" : {
               ""northeast"" : {
                  ""lat"" : -29.998713,
                  ""lng"" : -51.0060301
               },
               ""southwest"" : {
                  ""lat"" : -30.0002003,
                  ""lng"" : -51.00706049999999
               }
            },
            ""location"" : {
               ""lat"" : -30.00019429999999,
               ""lng"" : -51.006013
            },
            ""location_type"" : ""RANGE_INTERPOLATED"",
            ""viewport"" : {
               ""northeast"" : {
                  ""lat"" : -29.9981076697085,
                  ""lng"" : -51.00519631970849
               },
               ""southwest"" : {
                  ""lat"" : -30.0008056302915,
                  ""lng"" : -51.00789428029149
               }
            }
         },
         ""types"" : [ ""street_address"" ]
      },
      {
         ""address_components"" : [
            {
               ""long_name"" : ""Vila Elsa"",
               ""short_name"" : ""Vila Elsa"",
               ""types"" : [ ""neighborhood"", ""political"" ]
            },
            {
               ""long_name"" : ""Viamão"",
               ""short_name"" : ""Viamão"",
               ""types"" : [ ""locality"", ""political"" ]
            },
            {
               ""long_name"" : ""Viamão"",
               ""short_name"" : ""Viamão"",
               ""types"" : [ ""administrative_area_level_2"", ""political"" ]
            },
            {
               ""long_name"" : ""Rio Grande do Sul"",
               ""short_name"" : ""RS"",
               ""types"" : [ ""administrative_area_level_1"", ""political"" ]
            },
            {
               ""long_name"" : ""Brazil"",
               ""short_name"" : ""BR"",
               ""types"" : [ ""country"", ""political"" ]
            }
         ],
         ""formatted_address"" : ""Vila Elsa, Viamão - Rio Grande do Sul, Brazil"",
         ""geometry"" : {
            ""bounds"" : {
               ""northeast"" : {
                  ""lat"" : -29.9973113,
                  ""lng"" : -50.9934819
               },
               ""southwest"" : {
                  ""lat"" : -30.0580656,
                  ""lng"" : -51.038912
               }
            },
            ""location"" : {
               ""lat"" : -30.0174417,
               ""lng"" : -51.0071102
            },
            ""location_type"" : ""APPROXIMATE"",
            ""viewport"" : {
               ""northeast"" : {
                  ""lat"" : -29.9973113,
                  ""lng"" : -50.9934819
               },
               ""southwest"" : {
                  ""lat"" : -30.0580656,
                  ""lng"" : -51.038912
               }
            }
         },
         ""types"" : [ ""neighborhood"", ""political"" ]
      },
      {
         ""address_components"" : [
            {
               ""long_name"" : ""Alvorada"",
               ""short_name"" : ""Alvorada"",
               ""types"" : [ ""administrative_area_level_2"", ""political"" ]
            },
            {
               ""long_name"" : ""Rio Grande do Sul"",
               ""short_name"" : ""RS"",
               ""types"" : [ ""administrative_area_level_1"", ""political"" ]
            },
            {
               ""long_name"" : ""Brazil"",
               ""short_name"" : ""BR"",
               ""types"" : [ ""country"", ""political"" ]
            }
         ],
         ""formatted_address"" : ""Alvorada, Rio Grande do Sul, Brazil"",
         ""geometry"" : {
            ""bounds"" : {
               ""northeast"" : {
                  ""lat"" : -29.9566072,
                  ""lng"" : -50.9486764
               },
               ""southwest"" : {
                  ""lat"" : -30.0517803,
                  ""lng"" : -51.0936219
               }
            },
            ""location"" : {
               ""lat"" : -29.9862756,
               ""lng"" : -51.04362949999999
            },
            ""location_type"" : ""APPROXIMATE"",
            ""viewport"" : {
               ""northeast"" : {
                  ""lat"" : -29.9566072,
                  ""lng"" : -50.9486764
               },
               ""southwest"" : {
                  ""lat"" : -30.0517803,
                  ""lng"" : -51.0936219
               }
            }
         },
         ""types"" : [ ""administrative_area_level_2"", ""political"" ]
      },
      {
         ""address_components"" : [
            {
               ""long_name"" : ""Viamão"",
               ""short_name"" : ""Viamão"",
               ""types"" : [ ""administrative_area_level_3"", ""political"" ]
            },
            {
               ""long_name"" : ""Viamão"",
               ""short_name"" : ""Viamão"",
               ""types"" : [ ""administrative_area_level_2"", ""political"" ]
            },
            {
               ""long_name"" : ""Rio Grande do Sul"",
               ""short_name"" : ""RS"",
               ""types"" : [ ""administrative_area_level_1"", ""political"" ]
            },
            {
               ""long_name"" : ""Brazil"",
               ""short_name"" : ""BR"",
               ""types"" : [ ""country"", ""political"" ]
            }
         ],
         ""formatted_address"" : ""Viamão, Rio Grande do Sul, Brazil"",
         ""geometry"" : {
            ""bounds"" : {
               ""northeast"" : {
                  ""lat"" : -29.9973113,
                  ""lng"" : -50.9090917
               },
               ""southwest"" : {
                  ""lat"" : -30.1977611,
                  ""lng"" : -51.12096289999999
               }
            },
            ""location"" : {
               ""lat"" : -30.0824005,
               ""lng"" : -51.0199456
            },
            ""location_type"" : ""APPROXIMATE"",
            ""viewport"" : {
               ""northeast"" : {
                  ""lat"" : -29.9973113,
                  ""lng"" : -50.9090917
               },
               ""southwest"" : {
                  ""lat"" : -30.1977611,
                  ""lng"" : -51.12096289999999
               }
            }
         },
         ""types"" : [ ""administrative_area_level_3"", ""political"" ]
      },
      {
         ""address_components"" : [
            {
               ""long_name"" : ""Rio Grande do Sul"",
               ""short_name"" : ""RS"",
               ""types"" : [ ""administrative_area_level_1"", ""political"" ]
            },
            {
               ""long_name"" : ""Brazil"",
               ""short_name"" : ""BR"",
               ""types"" : [ ""country"", ""political"" ]
            }
         ],
         ""formatted_address"" : ""Rio Grande do Sul, Brazil"",
         ""geometry"" : {
            ""bounds"" : {
               ""northeast"" : {
                  ""lat"" : -27.0805987,
                  ""lng"" : -49.6916345
               },
               ""southwest"" : {
                  ""lat"" : -33.752084,
                  ""lng"" : -57.6438782
               }
            },
            ""location"" : {
               ""lat"" : -29.534505,
               ""lng"" : -53.3906074
            },
            ""location_type"" : ""APPROXIMATE"",
            ""viewport"" : {
               ""northeast"" : {
                  ""lat"" : -27.0805987,
                  ""lng"" : -49.6916345
               },
               ""southwest"" : {
                  ""lat"" : -33.752084,
                  ""lng"" : -57.6438782
               }
            }
         },
         ""types"" : [ ""administrative_area_level_1"", ""political"" ]
      },
      {
         ""address_components"" : [
            {
               ""long_name"" : ""Brazil"",
               ""short_name"" : ""BR"",
               ""types"" : [ ""country"", ""political"" ]
            }
         ],
         ""formatted_address"" : ""Brazil"",
         ""geometry"" : {
            ""bounds"" : {
               ""northeast"" : {
                  ""lat"" : 5.271602,
                  ""lng"" : -29.3449879
               },
               ""southwest"" : {
                  ""lat"" : -33.7517484,
                  ""lng"" : -73.982817
               }
            },
            ""location"" : {
               ""lat"" : -14.235004,
               ""lng"" : -51.92528
            },
            ""location_type"" : ""APPROXIMATE"",
            ""viewport"" : {
               ""northeast"" : {
                  ""lat"" : 5.271602,
                  ""lng"" : -32.3781865
               },
               ""southwest"" : {
                  ""lat"" : -33.7517484,
                  ""lng"" : -73.982817
               }
            }
         },
         ""types"" : [ ""country"", ""political"" ]
      }
   ],
   ""status"" : ""OK""
}";


	public IEnumerator Start() {
		Instance = this;
		if (!Input.location.isEnabledByUser)
			AutomaticLocation.Instance.debug = "Disabled";
		
		Input.location.Start();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		if (maxWait < 1) {
			AutomaticLocation.Instance.debug = "Timed out";
		}
		if (Input.location.status == LocationServiceStatus.Failed) {
			AutomaticLocation.Instance.debug = "Unable to determine device location";
		} else
		{
			AutomaticLocation.Instance.debug = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
			//AutomaticLocation.Instance.debug = "Requesting city";
			StartCoroutine(City(Input.location.lastData.latitude.ToString(),Input.location.lastData.longitude.ToString()));
		}
		Input.location.Stop();
	}

	private string RemoveEspecials(string text)
	{
		string s = text.Normalize(NormalizationForm.FormD);
		
		StringBuilder sb = new StringBuilder();
		
		for (int k = 0; k < s.Length; k++)
		{
			UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
			if (uc != UnicodeCategory.NonSpacingMark)
			{
				sb.Append(s[k]);
			}
		}
		return sb.ToString();
	}

	public IEnumerator City(string latitude, string longitude)
	{
		WWW www = new WWW("http://maps.googleapis.com/maps/api/geocode/json?latlng="+latitude+","+longitude+"&sensor=false");
		AutomaticLocation.Instance.debug = latitude + "   " + longitude;
		//-34,59 e -58.42
		//WWW www = new WWW("http://maps.googleapis.com/maps/api/geocode/json?latlng=-34.59,-58.42&sensor=false");
		yield return www;

		string data;
		if(www != null && www.error != "null")
		{
			data = www.text;
			ParseJson(data);
			StartCoroutine(GetWheatherCondition.Instance.Wheather(GetCity.Instance.countryCode,GetCity.Instance.cityName));
		}else
		{
			data = www.error;
			AutomaticLocation.Instance.debug = www.error;
		}
	}

	public void ParseJson(string jsonUrl)
	{
		JSONObject jsonObject = JSONObject.Parse(jsonUrl);
		JSONArray nArray = jsonObject["results"].Array;
		JSONObject correctJsonObject = JSONObject.Parse(nArray[1].ToString());
		nArray = correctJsonObject["address_components"].Array;

		//get City
		for(int x = 0; x < nArray.Length; x++)
		{
			JSONObject checkObj = JSONObject.Parse(nArray[x].ToString());
			JSONArray checkArray = checkObj["types"].Array;
			
			if((checkArray[0].ToString().Replace("\"", "") == "locality" && checkArray[1].ToString().Replace("\"", "") == "political") || (checkArray[0].ToString().Replace("\"", "") == "administrative_area_level_2" && checkArray[1].ToString().Replace("\"", "") == "political"))
			{
				GetCity.Instance.cityName = checkObj["long_name"].ToString().Replace("\"", "");
				GetCity.Instance.cityName = RemoveEspecials(GetCity.Instance.cityName);
				GetCity.Instance.cityName = GetCity.Instance.cityName.Replace(" ","");
				Debug.Log("CITY NAME : " + GetCity.Instance.cityName);
				break;
			}
			
		}
		//get Country
		for(int x = 0; x < nArray.Length; x++)
		{
			JSONObject checkObj = JSONObject.Parse(nArray[x].ToString());
			JSONArray checkArray = checkObj["types"].Array;
			if(checkArray[0].ToString().Replace("\"", "") == "country" && checkArray[1].ToString().Replace("\"", "") == "political")
			{
				GetCity.Instance.countryCode = checkObj["short_name"].ToString().Replace("\"", "");
				GetCity.Instance.countryCode = GetCity.Instance.countryCode.Replace(" ","");
				GetCity.Instance.countryName = checkObj["long_name"].ToString().Replace("\"", "");
				GetCity.Instance.regionCode = checkObj["short_name"].ToString().Replace("\"", "");
				GetCity.Instance.regionCode = GetCity.Instance.regionCode.Replace(" ","");
				GetCity.Instance.regionName = checkObj["long_name"].ToString().Replace("\"", "");
				Debug.Log("Region NAME : " + GetCity.Instance.countryCode);
				break;
			}


			
		}

		if(GetCity.Instance.countryCode != "BR")
		{
			for(int x = 0; x < nArray.Length; x++)
			{
				JSONObject checkObj = JSONObject.Parse(nArray[x].ToString());
				JSONArray checkArray = checkObj["types"].Array;
				if(checkArray[0].ToString().Replace("\"", "") == "administrative_area_level_1" && checkArray[1].ToString().Replace("\"", "") == "political")
				{
					GetCity.Instance.countryCode = checkObj["short_name"].ToString().Replace("\"", "");
					GetCity.Instance.countryCode = GetCity.Instance.countryCode.Replace(" ","");
					GetCity.Instance.countryName = checkObj["long_name"].ToString().Replace("\"", "");
					GetCity.Instance.regionCode = checkObj["short_name"].ToString().Replace("\"", "");
					GetCity.Instance.regionCode = GetCity.Instance.regionCode.Replace(" ","");
					GetCity.Instance.regionName = checkObj["long_name"].ToString().Replace("\"", "");
					Debug.Log("Region NAME : " + GetCity.Instance.countryCode);
					break;
				}
			}
		}
	}
}
