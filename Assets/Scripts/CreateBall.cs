using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    public GameObject blueBall;
 	public GameObject greenBall;
	public GameObject redBall;
    public GameObject blackBall;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;


 	Vector3 spawnPosition;
 
 	GameObject ball;
 
 	void Start () {
		
 	 	StartCoroutine("GenBall",1f);
 	}
 
 	IEnumerator GenBall(float delayTime){
       	while(true){
 
                float rand_num = Random.value;
				float Rand_Spawn = Random.Range(0,3);
                // Debug.Log(Rand_Spawn);
                if(Rand_Spawn == 0) {
                    spawnPosition.Set(Light1.transform.position.x,Light1.transform.position.y,Light1.transform.position.z);
                }
            	else if(Rand_Spawn == 1){
                    spawnPosition.Set(Light2.transform.position.x,Light2.transform.position.y,Light2.transform.position.z);
                }
                else{
                    spawnPosition.Set(Light3.transform.position.x,Light3.transform.position.y,Light3.transform.position.z);
                }
                
                if (rand_num < 0.25f){
                    ball = blueBall;
                }
                else if(0.25f <= rand_num && rand_num < 0.5f){
                    ball = greenBall;
                }
                else if(0.5f <= rand_num && rand_num < 0.75f){
                    ball = redBall;
                }
                else{
                    ball = blackBall;
                }

            	Instantiate(ball,spawnPosition,Quaternion.identity);

            	yield return new WaitForSeconds(delayTime);
       	} 
 	}
}
