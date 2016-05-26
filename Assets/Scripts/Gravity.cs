using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	float initialPosX;
	float initialPosY;
	float initialPosZ;

	float initialVelX;
	float initialVelY;
	float initialVelZ;

	float time;
	float gravity;



	Vector3 initialPos;

	// Use this for initialization
	void Start () {
		gravity = 9.81f;
		time = 0;

		initialPosX = transform.position.x;
		initialPosY = transform.position.y;
		initialPosZ = transform.position.z;

		initialPos = new Vector3(initialPosX, initialPosY, initialPosZ);

		initialVelY = 1f;
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if(gameObject.transform.position.y > 0.5f){
			
			initialPos.y = initialPosY + initialVelY*time + (-.5f*gravity*time*time);
			initialPos.x = gameObject.transform.position.x;
			initialPos.z = gameObject.transform.position.z;

			gameObject.transform.position = initialPos;
		}

	}
}
