using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GolfBall3 : MonoBehaviour {

	public Vector3 position = Vector3.zero;
	public Vector3 velocity = Vector3.zero;
	public Vector3 acceleration = new Vector3(0, -9.81f, 0);

	public float radius = 0.5f;
	[Range(0,1)]
	public float damping = .3f;

	public Camera[] ballCamera;

	WindProjectile golfBall;
	//DragProjectile golfBall;

	public float time = 0.0f;

	public double vx0 = 0f;
	public double vy0 = 0f;
	public double vz0 = 0f;

	public double windVx;
	public double windVy;

	public double mass;
	public double area;
	public double cd;
	public double density;

	[HideInInspector ]
	public bool restatPosition;
	public bool hitBall;
	public bool init;
	bool trailSwitch;

	public float tempVx0;
	public float tempVy0;
	public float tempVz0;

	Vector3 startPos;
	Vector3 startVelocity;


	// path trajector variables
	public GameObject TrajectoryPointPrefeb;
	public GameObject BallPrefb;
	private int numOfTrajectoryPoints = 30;
	public List<GameObject> trajectoryPoints;

	public double tempWindX;
	public double tempWindY;

	void Start () 
	{
		position = transform.position;

		restatPosition = false;
	
		init = true;
		trailSwitch = false;
		trajectoryPoints = new List<GameObject>();

		 vx0 = 0f;
		 vy0 = 0;
		 vz0 = 0f;
		 mass = 0;
		 area = .2f;
		 cd = .4f;
		 density = 1.2f;

		windVx = 0;
		windVy = 0;

		float ranx = Random.Range(-70, 70);
		float rany = Random.Range(-70, 70);


		if(Application.loadedLevel == 3){
			tempWindX = ranx;
			tempWindY = rany;
		}
	


		//golfBall = new DragProjectile(gameObject.transform.position.x, gameObject.transform.position.z, gameObject.transform.position.y,
		//	vx0, vy0, vz0, 0.0, mass, area, density, cd, windVx, windVy);

		//golfBall = new WindProjectile(gameObject.transform.position.x, gameObject.transform.position.z, gameObject.transform.position.y,
		//	vx0, vy0, vz0, 0.0, mass, area, density, cd, windVx, windVy);

		//gameObject.transform.position = new Vector3((float)golfBall.GetX(), (float)golfBall.GetZ(), (float)golfBall.GetZ());

	}


	float randomValue(float value){
		return value;
	}
		


	void trajectoryPointsInit(){

		//isPressed = isBallThrown =false;
		// TrajectoryPoints are instatiated
		for(int i=0;i<numOfTrajectoryPoints;i++)
		{
			GameObject dot = (GameObject) Instantiate(TrajectoryPointPrefeb);
			//dot.GetComponent<Renderer>().enabled = false;
			trajectoryPoints.Insert(i,dot);

		}
	}

	/*
	 * Initialize the starting variables again after setting with UI inputs;
	 */
	void initialize(){

		if(init){

			trailSwitch = true;
			vx0 = tempVx0;
			vy0 = tempVy0;
			vz0 = tempVz0;
			mass = 20.0f;
			area = .2f;
			cd = .4f;
			density = 1.2f;

			/*
			if(Application.loadedLevel == 3){
				tempWindX = Random.Range(-50, 50);
				tempWindY = Random.Range(-50, 50);
				windVx = tempWindX;
				windVy = tempWindY;
			}
			else{
				windVx = 0;
				windVy = 0;
			}
			*/
				

			golfBall = new WindProjectile(gameObject.transform.position.x, gameObject.transform.position.z, gameObject.transform.position.y,
				vx0, vy0, vz0, 0.0, mass, area, density, cd, windVx, windVy);

	
			gameObject.transform.position = new Vector3((float)golfBall.GetX(), (float)golfBall.GetZ(), (float)golfBall.GetY());

			init = false;
		//	reverseVz = false;
			if(Application.loadedLevel == 3){
				tempWindX = Random.Range(-50, 50);
				tempWindY = Random.Range(-50, 50);
				windVx = tempWindX;
				windVy = tempWindY;
			}
			else{
				windVx = 0;
				windVy = 0;
			}
		}

	}


	void Update () 
	{

		vx0 = tempVx0;
		vy0 = tempVy0;
		vz0 = tempVz0;
		//Debug.Log("TempVx: " + tempVx0);
		//Debug.Log("TempVy: " + tempVy0);
		//Debug.Log("TempVz: " + tempVz0);

		HitBall();

		//setTrajectoryPoints(startPos, startVelocity);

		StartCoroutine(renderTrail());


	}
		
	public void restartShoot(){

		Vector3 startPos = new Vector3(0.01f, 1.44f, 1.17f);
		gameObject.transform.position = startPos;
		ballCamera[1].GetComponent<Camera>().enabled = false;
		ballCamera[0].GetComponent<Camera>().enabled  = true;
		hitBall = true;
		init = true;
		trailSwitch = true;

		//HitBall();

	}


	IEnumerator renderTrail(){
		float counter = 3f;

		if(trailSwitch){
			counter -= Time.deltaTime;
			GameObject dot = (GameObject) Instantiate(TrajectoryPointPrefeb);
			dot.gameObject.transform.position = gameObject.transform.position;
			yield return new WaitForSeconds(counter);
			Destroy(dot);
		}
	}



	/*
	 * Only hit the golfball and simulate movement based on input from the UI button in the UIController class
	 * 
	 */
	void HitBall(){
		if(hitBall){

			// inialize again, But only once
			initialize();

		
			if (golfBall.GetZ() >= 0.0)
			{
				time+=Time.deltaTime;
				time /= 5;
				golfBall.UpdateLocationAndVelocity(time);

				gameObject.transform.position = new Vector3((float)golfBall.GetX(), (float)golfBall.GetZ(), (float)golfBall.GetY());
				
				//print ("x="+golfBall.GetX() +" y="+golfBall.GetZ());
			}else
				{
				
				restartShoot();
					//gameObject.transform.position = new Vector3((float)golfBall.GetX(), (float)golfBall.GetZ(), (float)golfBall.GetY());
					hitBall = false;
					trailSwitch = false;
				}
						//print ("x="+golfBall.GetX() +" y="+golfBall.GetZ());
			}
	}



	/*
	 * Calculate golfball projected path;
	 */
	void setTrajectoryPoints(Vector3 pStartPosition , Vector3 pVelocity )
	{
		float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
		float angle = Mathf.Rad2Deg*(Mathf.Atan2(pVelocity.y , pVelocity.x));
		float fTime = 0;
		fTime += 0.1f;
		for (int i = 0 ; i < numOfTrajectoryPoints ; i++)
		{
			float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
			float dz = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
			float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
			Vector3 pos = new Vector3(pStartPosition.x + dx , pStartPosition.y + dy , pStartPosition.y + dz);
			trajectoryPoints[i].transform.position = pos;
			trajectoryPoints[i].GetComponent<Renderer>().enabled = true;
			trajectoryPoints[i].transform.eulerAngles = new Vector3(0,0,Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude)*fTime,pVelocity.x)*Mathf.Rad2Deg);
			fTime += 0.1f;
		}
	}

}
