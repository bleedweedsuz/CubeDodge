using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CubeController : MonoBehaviour {

	public float speed = 4f;
	private Rigidbody rb;
	public GameObject baseCube;
	public GameObject introPanel;
	public GameObject tiltText;
	public bool firstTouch;
	bool tiltTextGone = true;
	bool InvokeBoxGeneratorOnce = true;
	BoxGenerator boxGenerator;

	public GameObject MainCubeParticle;

	ControllerGame controllerGame;

	public Text accelerationCheck;
	public float boost1 = 1f;
	public float boost2 = 1f;

	public GameObject MainStartPanel;
	public bool AudioPlayOff = true;




   
	void Awake(){
		tiltText.SetActive(false);
		controllerGame = GameObject.FindObjectOfType<ControllerGame>();
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		//Physics.gravity = Physics.gravity * 5f;
		boxGenerator = GameObject.FindObjectOfType<BoxGenerator>();
	
	}

	public void OnPointerDown (PointerEventData eventData){
		print("Cicked");
		Debug.Log(""+eventData);
	}

	//bool IsPointerOverUIObject(){
	//	PointerEventData eventCurrentPosition = new PointerEventData(EventSystem.current);
	//	eventCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		//List<RaycastResult> results = new List<RaycastResult>();
		//EventSystem.current.RaycastAll(eventCurrentPosition, results);
		//return results.Count > 0;
	//}
	
	// Update is called once per frame
	void Update ()
	{	
		//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//RaycastHit hit;
		//Ray landingRay = new Ray (transform.position, Vector3.down);
		//if (Physics.Raycast (ray, out hit, 500f)) {
		//	Debug.DrawLine (ray.origin, hit.point, Color.blue);
		//	if (hit.transform.tag.Equals ("MainCube")) {
		//		Debug.Log ("RaycastHit");
		//	}
		//}


		if (Input.GetMouseButtonUp (0)) {
			boost1 = 1f;
			boost2 = 1f;
		}

		
		if (Input.GetMouseButtonDown (0)) {

			//	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//	RaycastHit hit;
			//	if (Physics.Raycast (ray, out hit)) {
			//		if (!IsPointerOverUIObject ()) {
			if (MainStartPanel.activeInHierarchy) {
				if (EventSystem.current.currentSelectedGameObject.CompareTag ("infoBtn")) {
					//Debug.Log ("Working Inside22");
					return;
				} else if (EventSystem.current.currentSelectedGameObject.CompareTag ("musicBtn")) {
					return;

				} else if (EventSystem.current.currentSelectedGameObject.CompareTag ("MainStartPanel")) {
					//Debug.Log("Working Inside");
					StartCoroutine (moveCubeActive ());
					introPanel.SetActive (false);
					if (tiltText.activeInHierarchy == false && tiltTextGone) {

						if (PlayerPrefs.GetInt ("controller") == 11) {
							tiltText.SetActive (true);
							StartCoroutine (removeTiltText ());
							tiltTextGone = false;
						}
						tiltTextGone = false;
						controllerGame.pauseImage.SetActive (true);
						controllerGame.CounterObject.SetActive (true);
						controllerGame.counterIncrease ();
					}
				}
			}
	
					
			//	} 
			//}
		
		}

		if (firstTouch) {
			if (InvokeBoxGeneratorOnce) {
				boxGenerator.InvokeBoxGenerator ();
				controllerGame.startingSound = false;
				InvokeBoxGeneratorOnce = false;
			}

			if (AudioPlayOff) {
				controllerGame.StopStartAudio ();
				AudioPlayOff = false;
				controllerGame.playGamePlayingSound ();
			}




			if (PlayerPrefs.GetInt ("controller") == 12) {
				if (Input.GetMouseButton (0)) {
					//Debug.Log("Is Inside");
					//Vector3 clickedPosition = Input.mousePosition;
					//Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint (baseCube.transform.position);
					//if (clickedPosition.x < playerScreenPoint.x && clickedPosition.y < -40f) {
					if(Input.mousePosition.x < Screen.width/2 && Input.mousePosition.y < Screen.height/1.1){
						moveLeft ();
						//Debug.Log("Left");
					} else if(Input.mousePosition.x > Screen.width/2 && Input.mousePosition.y < Screen.height/1.1) {
						moveRight ();
						//Debug.Log("Right");
					}


				}
			}
				
			
		
			if (PlayerPrefs.GetInt ("controller") == 11) {
				AccelerometerMove();
			}
	
			
				
			


	     	          
		}



		/*foreach (Touch touch in Input.touches) {
		   if (touch.position.x < Screen.width/2) {
		     moveLeft();
		   }
		   else if (touch.position.x > Screen.width/2) {
		     moveRight();
		   }   */

		/*	if(Input.GetMouseButton(0))
         {
             if (Input.mousePosition.x < Screen.width/2)
             {
                 //Move Player Left
                 moveLeft();

             }
             else if (Input.mousePosition.x > Screen.width/2)
             {
                 //Move Player Right
                 moveRight();

             }
         }   */

	}

	IEnumerator moveCubeActive(){
		yield return new WaitForSeconds(0.2f);
		firstTouch = true;
	}

	void AccelerometerMove (){
		float x = Input.acceleration.x;
		if (x < 0) {
			//moveLeft(x);
			accelerometerMoveLeft(x);
		} else if (x > 0) {
			//moveRight(x);
			accelerometerMoveRight(x);
		}
	}

	IEnumerator removeTiltText(){
		yield return new WaitForSeconds(2.36f);
		tiltText.SetActive(false);
	}

    void moveLeft ()
	{
		if (this.transform.position.y < 2.15f && transform.position.x > -11.3f) {
				boost2 = 1f; 
			if (boost1 < 5f) {
				rb.velocity = Vector3.left * speed * boost1;
				boost1 += 0.06f;
			} else {
				rb.velocity = Vector3.left * speed * 5f;
			}
		}	
	

		//Debug.Log(boost1+"");
	}

	void moveRight ()
	{	
		
		if (this.transform.position.y < 2.15f && transform.position.x < 11f) {
				boost1 = 1f;
			if (boost2 < 5f) {
				rb.velocity = Vector3.right * speed * boost2;
				boost2+=0.06f;
			}else {
				rb.velocity = Vector3.right * speed * 5f;
			}
		}
	

	}

	void accelerometerMoveLeft (float acceleration)
	{	
		if (this.transform.position.y < 2.15f && transform.position.x > -11.4f) {
			float accelerationIncrease = 3.5f;
			float accelerationConvert = Mathf.Abs (acceleration);
			if (accelerationConvert > 0.015f && accelerationConvert < 0.8f) {
				rb.velocity = Vector3.left * accelerationConvert * 5f * accelerationIncrease;
				accelerationIncrease += 1.1f;
				//For Testing
				//float value = accelerationConvert * 5f * accelerationIncrease;
				//accelerationCheck.text = value+"";
			} else if (accelerationConvert > 0.015f && accelerationConvert > 0.8f) {
				rb.velocity = Vector3.left * 0.8f * 5f * accelerationIncrease;
			}
		}

		//Debug.Log(""+acceleration);
		//accelerationCheck.text = ""+accelerationConvert;
	}

	void accelerometerMoveRight (float acceleration)
	{
		if (this.transform.position.y < 2.15f && transform.position.x < 11f) {
			float accelerationIncrease = 3.5f;
			float accelerationConvert = Mathf.Abs (acceleration);
			if (accelerationConvert > 0.015 && accelerationConvert < 0.8f) {
				rb.velocity = Vector3.right * acceleration * 5f * accelerationIncrease;
				accelerationIncrease += 1.1f;
				//For Testing
				//float value = accelerationConvert * 5f * accelerationIncrease;
				//accelerationCheck.text = value+"";
			} else if (accelerationConvert > 0.015f && accelerationConvert > 0.8f) {
				rb.velocity = Vector3.right * 0.8f * 5f * accelerationIncrease;
			}
		}
		//Debug.Log(""+acceleration);
		//accelerationCheck.text = ""+accelerationConvert;
	}


	void OnCollisionEnter (Collision target)
	{
		if (target.gameObject.tag == "rightFence") {
			//target.transform.gameObject.SetActive (false);
			//target.gameObject.SetActive (false);
			Debug.Log ("Right Part Collide");
		}
			
		if (target.gameObject.tag == "Box") {
			target.transform.gameObject.SetActive (false);
			target.gameObject.SetActive (false);

			Instantiate (MainCubeParticle, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - .4f), Quaternion.identity);
			boxGenerator.CancelBoxGenerator (); // Canceling Generating Boxes

			//Destroy All boxes is disabled 
			//controllerGame.DestroyAllBoxesOnScreen ();


			controllerGame.counterStart = false;

			int timerToInt = Mathf.RoundToInt (controllerGame.timer);
			controllerGame.ScoreValue.text = timerToInt + "";

			//if (timerToInt > controllerGame.bestScoreValue) {

			int totalGames = PlayerPrefs.GetInt("totalgames",0)+1;
			PlayerPrefs.SetInt ("totalgames", totalGames);
			try{
			PlayservicesManager.addTotalPlayedToLeaderBoard (GPGSIds.leaderboard_most_played, totalGames);
			}catch(System.Exception e){
				print (e.Message);
			}
			if (timerToInt > PlayerPrefs.GetInt ("bestScoreValue", 0)) {
				controllerGame.bestScoreValue = timerToInt;
				//PlayerPrefs.SetInt("bestScoreValue",controllerGame.bestScoreValue);
				controllerGame.saveValueToPrefab (timerToInt);

				controllerGame.BestScoreValue.text = "" + controllerGame.bestScoreValue;
				controllerGame.activeRibbon2 ();
			} else {
				controllerGame.activeRibbon1();
			}

			controllerGame.stopGamePlayingSound();
			controllerGame.playGameOverSound();
			
			controllerGame.GenerateFinalDelay();
			gameObject.SetActive (false);

		
		}
	}

	void OnCollisionExit (Collision target)
	{
		if (target.gameObject.tag == "rightFence") {
			Debug.Log("Out of right fence");
		}
	}






}
