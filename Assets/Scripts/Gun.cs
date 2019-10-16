using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bullet;
	public float initialSpeed;
	void Update(){
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitPoint;
		if (Input.GetMouseButtonDown(0)) {
			
			if (Physics.Raycast (cameraRay, out hitPoint, Mathf.Infinity)) 
			{ 
				
				Vector3 distanceToMouse = hitPoint.point - transform.position;

				GameObject gunBullet = (GameObject)Instantiate (bullet, transform.position, transform.rotation);

				gunBullet.GetComponent<Rigidbody> ().velocity = distanceToMouse.normalized * initialSpeed;

			}
		}	
	}
}





		
	

