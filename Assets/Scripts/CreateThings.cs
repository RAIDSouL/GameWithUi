using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateThings : MonoBehaviour
{
    public GameObject redBall;
 	public GameObject yellowBall;
    public float randomParam;
    public float delayTime;
    public bool force;
    Vector3 spawnPosition;
 	GameObject ball;
    public GameObject Light1;
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenBall",delayTime);
    }

    // Update is called once per frame
    IEnumerator GenBall(float delayTime){
        while(true){
            // spawnPosition.Set(Light1.transform.position.x,Light1.transform.position.y,Light1.transform.position.z);
            
            float rand_num = Random.value;
            if (rand_num < randomParam){
                ball = redBall;
            }
            else{
                ball = yellowBall;
            }
            GameObject clone = Instantiate(ball,Light1.transform.position,Light1.transform.localRotation);
            if (force)
                clone.transform.GetComponent<Rigidbody>().AddForce(clone.transform.forward * 1000f);
            yield return new WaitForSeconds(delayTime);

        }
    }
}
