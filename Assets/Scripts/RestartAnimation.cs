using UnityEngine;
using System.Collections;

public class RestartAnimation : MonoBehaviour {
	
	public bool test = true;
	
	public void RestartAnim()
	{
		if(!test)
		{
			this.gameObject.GetComponent<TweenAlpha>().Play(false);
			test = true;
		}else
		{
			this.gameObject.GetComponent<TweenAlpha>().Play(true);
		}
	}
	
}
