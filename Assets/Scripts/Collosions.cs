using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collosions : MonoBehaviour {
	
	public Camera[] ballFollowCamera;
	bool switchCamera;
	public int playerScore = 3;

	public GameObject golfBall;
	public GolfBall3 golfBallScrpts;

	bool triggetCollision;

	// Use this for initialization
	void Start () {

		golfBall = GameObject.FindGameObjectWithTag("golfBall");
		golfBallScrpts = golfBall.GetComponent<GolfBall3>();

		playerScore = 3;

		triggetCollision = true;
		ballFollowCamera[0].enabled = false;
		switchCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		checkCollisions();
		TargetCollisions();

		if(playerScore == 5 ){
			//LoadLevel Now
		}
	}

	//toggle cameras based on collisions
	void switchCameras(){
		
		//check for collision between galfBall and camera trigger (Changes camera views)
		if(ballFollowCamera[0].enabled){
			ballFollowCamera[0].enabled = false;
			ballFollowCamera[1].enabled = true;
		}
		else{
			ballFollowCamera[0].enabled = true;
			ballFollowCamera[1].enabled = false;
		}

		//switchCamera = false;
	}

	/*
	 * Handle Collision between tea-off platform and ball 
	 * (I.E stop ball falling throught the tea-off box floor)
	 */
	void teaPlatformCollision(){
		/*
		if(gameObject.transform.position.z < GameObject.FindGameObjectWithTag("massTriggerBox").transform.position.y){

			GetComponent<GolfBall3>().mass =
			Debug.Log("Collision with teaBox");
		}	
		*/
	}

	void target1(){
		if(transform.position.y  < GameObject.FindGameObjectWithTag("targetImage1").transform.position.y + GameObject.FindGameObjectWithTag("targetImage1").transform.localScale.y/2 
			&& transform.position.y > GameObject.FindGameObjectWithTag("targetImage1").transform.position.y - GameObject.FindGameObjectWithTag("targetImage1").transform.localScale.y/2)
		{

			//Debug.Log("Collision with Target 1 Y axis");

			if(transform.position.x < GameObject.FindGameObjectWithTag("targetImage1").transform.position.x+GameObject.FindGameObjectWithTag("targetImage1").transform.localScale.x/2
				&& transform.position.x  > GameObject.FindGameObjectWithTag("targetImage1").transform.position.x - GameObject.FindGameObjectWithTag("targetImage1").transform.localScale.x/2)

			{
				//Debug.Log("Collision with Target 1 X axis");

				//Check z Axis
				if(transform.position.z < GameObject.FindGameObjectWithTag("targetImage1").transform.position.z+GameObject.FindGameObjectWithTag("targetImage1").transform.localScale.z/2
					&& transform.position.z  > GameObject.FindGameObjectWithTag("targetImage1").transform.position.z - GameObject.FindGameObjectWithTag("targetImage1").transform.localScale.z/2)

				{
					//If collision is true increment score and update HUD;
					//Only implement once through the collision process; (Keep score incrementation to 1)
					if(triggetCollision){
						//triggetCollision = false;
						Debug.Log("playerScore: " + playerScore);
						playerScore += 1;
						ballFollowCamera[1].GetComponent<Camera>().enabled = false;
						ballFollowCamera[0].GetComponent<Camera>().enabled = true;


						//reset ball position bat to original
						golfBallScrpts.restartShoot();
						golfBallScrpts.hitBall = false;
						//golfBallScrpts.hitBall = true;
						Debug.Log("restart: " + golfBallScrpts.restatPosition);
						Debug.Log("hit`ball: " + golfBallScrpts.hitBall);
					}
				}
			}
		}
	}

	void target2(){
		if(transform.position.y  < GameObject.FindGameObjectWithTag("targetImage2").transform.position.y + GameObject.FindGameObjectWithTag("targetImage2").transform.localScale.y/2 
			&& transform.position.y > GameObject.FindGameObjectWithTag("targetImage2").transform.position.y - GameObject.FindGameObjectWithTag("targetImage2").transform.localScale.y/2)
		{

			//Debug.Log("Collision with Target 1 Y axis");

			if(transform.position.x < GameObject.FindGameObjectWithTag("targetImage2").transform.position.x+GameObject.FindGameObjectWithTag("targetImage2").transform.localScale.x/2
				&& transform.position.x  > GameObject.FindGameObjectWithTag("targetImage2").transform.position.x - GameObject.FindGameObjectWithTag("targetImage2").transform.localScale.x/2)

			{
				//Debug.Log("Collision with Target 1 X axis");

				//Check z Axis
				if(transform.position.z < GameObject.FindGameObjectWithTag("targetImage2").transform.position.z+GameObject.FindGameObjectWithTag("targetImage2").transform.localScale.z/2
					&& transform.position.z  > GameObject.FindGameObjectWithTag("targetImage2").transform.position.z - GameObject.FindGameObjectWithTag("targetImage2").transform.localScale.z/2)

				{
					//If collision is true increment score and update HUD;
					//Only implement once through the collision process; (Keep score incrementation to 1)
					if(triggetCollision){
						//triggetCollision = false;
						Debug.Log("playerScore: " + playerScore);
						playerScore += 1;
						ballFollowCamera[1].GetComponent<Camera>().enabled = false;
						ballFollowCamera[0].GetComponent<Camera>().enabled = true;

						//reset ball position bat to original
						golfBallScrpts.restartShoot();
						golfBallScrpts.hitBall = false;
						//golfBallScrpts.hitBall = true;
						Debug.Log("restart: " + golfBallScrpts.restatPosition);
						Debug.Log("hit`ball: " + golfBallScrpts.hitBall);
					}
				}
			}
		}
	}

	void target3(){

		if(transform.position.y  < GameObject.FindGameObjectWithTag("targetImage3").transform.position.y + GameObject.FindGameObjectWithTag("targetImage3").transform.localScale.y/2 
			&& transform.position.y > GameObject.FindGameObjectWithTag("targetImage3").transform.position.y - GameObject.FindGameObjectWithTag("targetImage3").transform.localScale.y/2)
		{

			//Debug.Log("Collision with Target 1 Y axis");

			if(transform.position.x < GameObject.FindGameObjectWithTag("targetImage3").transform.position.x+GameObject.FindGameObjectWithTag("targetImage3").transform.localScale.x/2
				&& transform.position.x  > GameObject.FindGameObjectWithTag("targetImage3").transform.position.x - GameObject.FindGameObjectWithTag("targetImage3").transform.localScale.x/2)
					
			{
				//Debug.Log("Collision with Target 1 X axis");

				//Check z Axis
				if(transform.position.z < GameObject.FindGameObjectWithTag("targetImage3").transform.position.z+GameObject.FindGameObjectWithTag("targetImage3").transform.localScale.z/2
					&& transform.position.z  > GameObject.FindGameObjectWithTag("targetImage3").transform.position.z - GameObject.FindGameObjectWithTag("targetImage3").transform.localScale.z/2)

				{
					//If collision is true increment score and update HUD;
					//Only implement once through the collision process; (Keep score incrementation to 1)
					if(triggetCollision){
						//triggetCollision = false;
						Debug.Log("playerScore: " + playerScore);
						playerScore += 1;
						ballFollowCamera[1].GetComponent<Camera>().enabled = false;
						ballFollowCamera[0].GetComponent<Camera>().enabled = true;


						//reset ball position bat to original
						golfBallScrpts.restartShoot();
						golfBallScrpts.hitBall = false;
						//golfBallScrpts.hitBall = true;
						Debug.Log("restart: " + golfBallScrpts.restatPosition);
						Debug.Log("hit`ball: " + golfBallScrpts.hitBall);
					}
				}
			}
		}
	}


	void target4(){
		if(transform.position.y  < GameObject.FindGameObjectWithTag("targetImage4").transform.position.y + GameObject.FindGameObjectWithTag("targetImage4").transform.localScale.y/2 
			&& transform.position.y > GameObject.FindGameObjectWithTag("targetImage4").transform.position.y - GameObject.FindGameObjectWithTag("targetImage4").transform.localScale.y/2)
		{

			//Debug.Log("Collision with Target 1 Y axis");

			if(transform.position.x < GameObject.FindGameObjectWithTag("targetImage4").transform.position.x+GameObject.FindGameObjectWithTag("targetImage4").transform.localScale.x/2
				&& transform.position.x  > GameObject.FindGameObjectWithTag("targetImage4").transform.position.x - GameObject.FindGameObjectWithTag("targetImage4").transform.localScale.x/2)

			{
				//Debug.Log("Collision with Target 1 X axis");

				//Check z Axis
				if(transform.position.z < GameObject.FindGameObjectWithTag("targetImage4").transform.position.z+GameObject.FindGameObjectWithTag("targetImage4").transform.localScale.z/2
					&& transform.position.z  > GameObject.FindGameObjectWithTag("targetImage4").transform.position.z - GameObject.FindGameObjectWithTag("targetImage4").transform.localScale.z/2)

				{
					//If collision is true increment score and update HUD;
					//Only implement once through the collision process; (Keep score incrementation to 1)
					if(triggetCollision){
						//triggetCollision = false;
						Debug.Log("playerScore: " + playerScore);
						playerScore += 1;
						ballFollowCamera[1].GetComponent<Camera>().enabled = false;
						ballFollowCamera[0].GetComponent<Camera>().enabled = true;


						//reset ball position bat to original
						golfBallScrpts.restartShoot();
						golfBallScrpts.hitBall = false;
						//golfBallScrpts.hitBall = true;
						Debug.Log("restart: " + golfBallScrpts.restatPosition);
						Debug.Log("hit`ball: " + golfBallScrpts.hitBall);
					}
				}
			}
		}
	}

	void target5(){
		if(transform.position.y  < GameObject.FindGameObjectWithTag("targetImage5").transform.position.y + GameObject.FindGameObjectWithTag("targetImage5").transform.localScale.y/2 
			&& transform.position.y > GameObject.FindGameObjectWithTag("targetImage5").transform.position.y - GameObject.FindGameObjectWithTag("targetImage5").transform.localScale.y/2)
		{

			//Debug.Log("Collision with Target 1 Y axis");

			if(transform.position.x < GameObject.FindGameObjectWithTag("targetImage5").transform.position.x+GameObject.FindGameObjectWithTag("targetImage5").transform.localScale.x/2
				&& transform.position.x  > GameObject.FindGameObjectWithTag("targetImage5").transform.position.x - GameObject.FindGameObjectWithTag("targetImage5").transform.localScale.x/2)

			{
				//Debug.Log("Collision with Target 1 X axis");

				//Check z Axis
				if(transform.position.z < GameObject.FindGameObjectWithTag("targetImage5").transform.position.z+GameObject.FindGameObjectWithTag("targetImage5").transform.localScale.z/2
					&& transform.position.z  > GameObject.FindGameObjectWithTag("targetImage5").transform.position.z - GameObject.FindGameObjectWithTag("targetImage5").transform.localScale.z/2)

				{
					//If collision is true increment score and update HUD;
					//Only implement once through the collision process; (Keep score incrementation to 1)
					if(triggetCollision){
						//triggetCollision = false;
						Debug.Log("playerScore: " + playerScore);
						playerScore += 1;
						ballFollowCamera[1].GetComponent<Camera>().enabled = false;
						ballFollowCamera[0].GetComponent<Camera>().enabled = true;


						//reset ball position bat to original
						golfBallScrpts.restartShoot();
						golfBallScrpts.hitBall = false;
						//golfBallScrpts.hitBall = true;
						Debug.Log("restart: " + golfBallScrpts.restatPosition);
						Debug.Log("hit`ball: " + golfBallScrpts.hitBall);
					}
				}
			}
		}
	}


	void TargetCollisions(){

			target1();
			target2();
			target3();
			target4();
			target5();
		//Target 1
		//Check y Axis, the biggest fir

	}



	//check for collisions
	void checkCollisions(){


		if(transform.position.z < GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.position.z+GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.localScale.z/2
			&& transform.position.z  > GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.position.z - GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.localScale.z/2)

		{
			Debug.Log("Camera Collision");
			ballFollowCamera[1].GetComponent<Camera>().enabled = true;
			ballFollowCamera[0].GetComponent<Camera>().enabled = false;
			//If collision is true increment score and update HUD;
			//Only implement once through the collision process; (Keep score incrementation to 1)

			if(transform.position.y  < GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.position.y + GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.localScale.y/2 
				&& transform.position.y > GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.position.y - GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.localScale.y/2)
			{

				//Debug.Log("Collision with Target 1 Y axis");

				if(transform.position.x < GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.position.x+GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.localScale.x/2
					&& transform.position.x  > GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.position.x - GameObject.FindGameObjectWithTag("boxCameraTrigger").transform.localScale.x/2)

				{
					//Debug.Log("Collision with Target 1 X axis");

					//Check z Axis

				}
			}
		}
	}
}
