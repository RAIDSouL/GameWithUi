using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float startTime;
	float lifeTime;
	float timer;
	

	void Start(){
		
		lifeTime = 2.0f;
		startTime = Time.time;

	}

	void Update () {

		if(Time.time >= (startTime+lifeTime)){
			Destroy(gameObject);
		}
	}	

	void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Ball"))
        {
			GameController.instance.AddScore(obj.gameObject.GetComponent<BallScore>().score);
            Destroy(obj.gameObject);
			Destroy(gameObject);
        }
    }

}
