using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {
	
	float timer = 6.0f; //6 seconds
 
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
			RestartAnimation[] tweens = gameObject.GetComponentsInChildren<RestartAnimation>();
			for(int i = 0 ; i < tweens.Length; i++)
			{
				tweens[i].test = false;
				tweens[i].RestartAnim();
			}
            timer = 10.0f;
        }
    }
}
