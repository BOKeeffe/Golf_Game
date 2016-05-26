using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public bool trigger = false;
	public GameObject golfBall;
	public AudioSource audioSource;
	public AudioClip audioClip;

	public GolfBall3 golfBallScrpts;


	public Text scoreText, levelText, menuScreen2Text, startMenuText, youWinText;

	public RawImage rw;

	Collosions colScripts;

	public int score;
	public int level ;

	public float tempValue;

	public float startYRotation;

	void Start(){

		audioSource = GetComponent<AudioSource>();

		startYRotation = 70;
		score = 0;
		level = 1;
		
		golfBall = GameObject.FindGameObjectWithTag("golfBall");
		golfBallScrpts = golfBall.GetComponent<GolfBall3>();

		colScripts = golfBall.GetComponent<Collosions>();

		scoreText.text = "Score: " + score ;
		levelText.text = "Level : " + level;

		//rw.transform.rotation = imageWind;

	}



	void Update(){
		
		double windDirX = golfBallScrpts.tempWindX;
		double windDirY = golfBallScrpts.tempWindY;

		//-startYRotation+(float)windDirY

		//rotate wind direction arrow
		Quaternion imageWind = Quaternion.Euler(0, 0, -(float)windDirX);
		rw.transform.rotation = imageWind;

		score = colScripts.playerScore; 
		Debug.Log("UIController: " + score);
		scoreText.text = "Score: " + score;

		if(Application.loadedLevel == 1){
			Debug.Log("Level 1 loaded");
			levelText.text = "Level: 1";
		}
		if(Application.loadedLevel == 3){
			levelText.text = "Level: 2";
		}

		if(Application.loadedLevel == 1 && score == 5){
			Application.LoadLevel(3);
		}

		if(Application.loadedLevel == 3 && score == 5){
			Application.LoadLevel(4);
		}
	}




	/*
	 * Button which access a boolean value from the golfball3 script to trigger
	 * the motion of the ball (Ball is Hit).
	 */
	public void ButtonClick(){

		golfBallScrpts.hitBall = true;
		audioSource.PlayOneShot(audioClip, 5.7f);

	}

	public void ButtonClickLevelChange(){

		Debug.Log("Button Working");

		if(Application.loadedLevel == 0){
			Application.LoadLevel(1);
		}
		if(Application.loadedLevel == 2){
			Application.LoadLevel(3);
		}
		if(Application.loadedLevel == 4){
			Application.LoadLevel(1);
		}
	}

	/*
	 * Slider to controll the forward force to apply to the golfBall.
	 * Accesses forward velocity valve in GolfBall3 Scripts.
	 */ 
	public void SliderPowerControl(float newValue){
		
		golfBallScrpts.tempVy0 = newValue; 
	}


	/*
	 * Controls the direction X-Axis via on screen slider 
	 */
	public void SliderDirectionControl(float newValue){

		golfBallScrpts.tempVx0 = newValue;
	}


	/*
	 * Controls the height Y-Axis of via on screen controls
	 */ 
	public void SliderHeightControl(float newValue){

		golfBallScrpts.tempVz0 = newValue;
	}



}
