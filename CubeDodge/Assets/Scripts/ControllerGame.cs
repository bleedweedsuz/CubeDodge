using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ControllerGame : MonoBehaviour {
	public GameObject introPanel;
	public GameObject tiltText;
	public GameObject pauseImage;

    public GameObject pausePanel;

	//GameObject[] Boxes;
	public GameObject BoxParticles;

	//bool destroyNow = false;

	BoxGenerator boxGenerator;
	public GameObject mainCube;

	[SerializeField]
	public Text counter;
	public GameObject CounterObject;

	public bool counterStart = false;
	public float timer = 0f;

	//bool restartButtonIsTrue;

	public GameObject gameOverPanel;

	public Text ScoreValue;
	public Text BestScoreValue;
	public int bestScoreValue;

//	bool pausePanelWorking = false;

	//public BoxGenerator boxGenerator;
	public CubeController cubeController;

	AudioSource playAudio;

	public AudioClip startSound;
	public AudioClip gamePlayingSound;
	public GameObject gameFinish;

	bool defaultMusic = true;

	public Sprite musicOffSprite, musicOnSprite;
	public Image musicImage;
	public Image musicImage2;
	bool onceMusicLoad = true;

	public bool startingSound = true;

	bool isPaused;

	public Image playImage;
	Animator fadeOutAnim, mainStartPanelAnimator,infoPanelOuterAnim,infoPanelInnerAnim;
	public Button controller1, controller2;
	public GameObject mainStartPanel;
	public GameObject infoPanelOuter,infoPanelInner;

	public Toggle acceleromterToggle, touchToggle;

	public GameObject ribbon1, ribbon2;

	public GameObject infoPanel;
	Animator infoAnimator;

	public Text counterUpdateSpeed;

	int timerCheckForSpeedUpdate;
	bool tenUp = true;
	bool ten2Up = true;
	bool ten3Up = true;
	bool ten4Up = true;
	bool ten5Up = true;
	bool ten6Up = true;
	bool ten7Up = true;
	bool ten8Up = true;
	bool ten9Up = true;

	Coroutine extiPanelCoroutine;
	bool coroutinePanelCheck = false;
	//public GameObject boxSpeed;
	//GameObject yoo;
	//Rigidbody mainBoxSpeed;

	//public Toggle currentSelection {
		//get { 
			//return toggleAccelerometerTouch.ActiveToggles().FirstOrDefault();
		//}
	//}

	void Awake ()
	{
		//yoo = boxSpeed.transform.GetChild(0).gameObject;
		//mainBoxSpeed = yoo.gameObject.transform.GetComponent<Rigidbody>();



		ribbon1.SetActive(false);
		ribbon2.SetActive(false);
		playImage.GetComponent<Button>().interactable = false;
		if (PlayerPrefs.GetInt ("FirstTimeGameEnter") == 31) {
			mainStartPanel.SetActive(false);
			infoPanelOuter.SetActive(false);
			Destroy(mainStartPanel);
			Destroy(infoPanelOuter);
		}
		//tiltText.SetActive(false);
		infoPanelOuter.SetActive(false);
		CounterObject.SetActive(false);
		//counter.enabled = false;
		//pauseImage = GameObject.FindGameObjectWithTag("imagePause");
		pauseImage.SetActive(false);
		pausePanel.SetActive(false);
		//mainCube = GameObject.FindGameObjectWithTag("MainCube");
		gameOverPanel.SetActive(false);
		playAudio = GetComponent<AudioSource>();
		//startSoundPlay.clip = startSound;

		counterUpdateSpeed = GetComponent<Text>();
	}



	// Use this for initialization
	void Start ()
	{
		
		//Debug.Log("First Selected" + currentSelection.name);
		//Debug.Log("==>",toggleAccelerometerTouch.ActiveToggles().FirstOrDefault());
		if (PlayerPrefs.GetInt ("onceMusic") == 17) {
			onceMusicLoad = false;
			Debug.Log ("isInsideAlready");
			defaultMusic = false;
		}

		if (!onceMusicLoad && !defaultMusic) {
			if (PlayerPrefs.GetInt ("musicButtonOff") == 0 ) {
				Debug.Log ("isOn");
				playAudio.clip = startSound;
				playAudio.Play();
				playAudio.loop = true;
				musicImage.sprite = musicOnSprite;
				musicImage2.sprite = musicOnSprite;
			} else if(PlayerPrefs.GetInt ("musicButtonOff") == 1 ){
				musicImage.sprite = musicOffSprite;
				musicImage2.sprite = musicOffSprite;
				Debug.Log ("isOff");
			}
		}

		//playAudio = GetComponent<AudioSource>();
		BestScoreValue.text = PlayerPrefs.GetInt("bestScoreValue",0).ToString();
		boxGenerator = GameObject.FindObjectOfType<BoxGenerator>();
		//playAudio.Play();                                
		//gameObject.GetComponent<AudioSource>().clip = startSound;
		//gameObject.GetComponent<AudioSource>().Play();
		if(defaultMusic){
			playAudio.clip = startSound;
			playAudio.Play();
			playAudio.loop = true;
		}
		    
	}
	
	// Update is called once per frame
	void Update ()
	{
		timerCheckForSpeedUpdate =  int.Parse(counter.text);
		if (timerCheckForSpeedUpdate == 10 && tenUp) {
			boxGenerator.setDragIncrease1();
			Debug.Log("==>5");
			tenUp = false;
		}

		if (timerCheckForSpeedUpdate == 20 && ten2Up) {
			boxGenerator.setDragIncrease2();
			ten2Up = false;
			Debug.Log("==>20");
		}

		if (timerCheckForSpeedUpdate == 30 && ten3Up) {
			boxGenerator.setDragIncrease3();
			ten3Up = false;
			Debug.Log("==>30");
		}

		if (timerCheckForSpeedUpdate == 40 && ten4Up) {
			boxGenerator.setDragIncrease4();
			ten4Up = false;
			Debug.Log("==>40");
		}

		if (timerCheckForSpeedUpdate == 50 && ten5Up) {
			boxGenerator.setDragIncrease5();
			ten5Up = false;
			Debug.Log("==>50");
		}

		if (timerCheckForSpeedUpdate == 60 && ten6Up) {
			boxGenerator.setDragIncrease6();
			ten6Up = false;
			Debug.Log("==>60");
		}

		if (timerCheckForSpeedUpdate == 70 && ten7Up) {
			boxGenerator.setDragIncrease7();
			ten7Up = false;
			Debug.Log("==>70");
		}

		if (timerCheckForSpeedUpdate == 80 && ten8Up) {
			boxGenerator.setDragIncrease8();
			ten8Up = false;
			Debug.Log("==>80");
		}

		if (timerCheckForSpeedUpdate == 90 && ten9Up) {
			boxGenerator.setDragIncrease9();
			ten9Up = false;
			Debug.Log("==>90");
		}


		//if (counterUpdateSpeed.text.Equals("5")) {
		//	Debug.Log("==>");
		//}


		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	Debug.Log("==>"+ScoreValue.text);
		//}
		//Boxes = GameObject.FindGameObjectsWithTag ("Box");

	//	if (destroyNow) {
		//	for (int i = 0; i < Boxes.Length; i++) {
		//		Instantiate (BoxParticles, new Vector3 (Boxes [i].transform.position.x-.9f, Boxes [i].transform.position.y+.5f, Boxes [i].transform.position.z-1f), Quaternion.identity);
		//		Destroy (Boxes [i].transform.parent.gameObject);
		//		Destroy (Boxes [i]);

			//}
		//}


		if (counterStart) {
			timer += Time.deltaTime;
			int timerToInt = Mathf.RoundToInt (timer);
			counter.text = timerToInt + "";
		}

		//if (restartButtonIsTrue) {
			
			//counterStart = true;
		//}


	}


	public void MusicButtonToggle ()
	{	
		if (startingSound) {

		if (onceMusicLoad) {
			if (defaultMusic) {
				musicImage.sprite = musicOffSprite;
				musicImage2.sprite = musicOffSprite;
				defaultMusic = false;
				playAudio.Stop ();
				PlayerPrefs.SetInt ("musicButtonOff", 1);
				onceMusicLoad = false;
				Debug.Log ("" + onceMusicLoad);
				PlayerPrefs.SetInt ("onceMusic", 17);
			} 
		} else {
			if (PlayerPrefs.GetInt ("musicButtonOff") == 0) {
				musicImage.sprite = musicOffSprite;
				musicImage2.sprite = musicOffSprite;
				playAudio.Stop ();
				PlayerPrefs.SetInt ("musicButtonOff", 1);

			} else if (PlayerPrefs.GetInt ("musicButtonOff") == 1) {
				musicImage.sprite = musicOnSprite;
				musicImage2.sprite = musicOnSprite;

			
					playAudio.clip = startSound;
					playAudio.Play ();
				

					PlayerPrefs.SetInt("musicButtonOff",0);
				}
		}
		}

	}


	public void MusicButtonToggle2 ()
	{	
		if (!startingSound) {
			if (PlayerPrefs.GetInt ("musicButtonOff") == 0) {
				musicImage.sprite = musicOffSprite;
				musicImage2.sprite = musicOffSprite;
				playAudio.Stop ();
				PlayerPrefs.SetInt ("musicButtonOff", 1);

			} else if (PlayerPrefs.GetInt ("musicButtonOff") == 1) {
				musicImage.sprite = musicOnSprite;
				musicImage2.sprite = musicOnSprite;
				playAudio.clip = gamePlayingSound;	
				PlayerPrefs.SetInt("musicButtonOff",0);

			}	
		}
			

	}

	//void FixedUpdate ()
	//{
	//	if (pausePanelWorking) {
	//		pausePanelActive();
	//		pausePanelWorking = false;
	//	}
	//}

	public void pauseButtonClicked ()
	{
		//Debug.Log("Working");
		//	pausePanelWorking = true;
		if (PlayerPrefs.GetInt ("musicButtonOff") == 0) {
			playAudio.Pause();
		}

		pauseImage.SetActive (false);
		pausePanel.SetActive (true);
		Time.timeScale = 0f;
		//StartCoroutine(pauseGameDelay());
	}

	//IEnumerator pauseGameDelay(){
	//	yield return new WaitForSeconds(1f);
	//	Time.timeScale = 0f;
	//}


	//void pausePanelActive (){
	//	pausePanel.SetActive (true);
	//}

	public void resumeButtonClick ()
	{
		pausePanel.SetActive (false);
		pauseImage.SetActive (true);
		Time.timeScale = 1f;
		if (PlayerPrefs.GetInt ("musicButtonOff") == 0) {
			if (mainCube.activeInHierarchy) {
				playAudio.Play();
			}
		}

	}

	public void restartButtonClick ()
	{	
		if (coroutinePanelCheck) {
			StopCoroutine(extiPanelCoroutine);
			coroutinePanelCheck = false;
			Debug.Log("Coroutine Deactivated");
		}


		defaultSpeedCondition ();
		boxGenerator.setDragToDefault ();
		
		if (PlayerPrefs.GetInt ("musicButtonOff") == 0) {
			playAudio.Stop ();
			playAudio.Play ();
		}

		counterStart = false;
		//restartButtonIsTrue = true;
		boxGenerator.CancelBoxGenerator ();

		cubeController.boost1 = 1f;
		cubeController.boost2 = 1f;

		//destroyNow = true;
		DestroyAllBoxesOnScreen ();
		//StartCoroutine (resetDestroyNow ());

		pausePanel.SetActive (false);
		pauseImage.SetActive (true);
		Time.timeScale = 1f;

		StartCoroutine (regenerateBoxDelay ());

		//if(mainCube.activeInHierarchy){
		mainCube.transform.position = new Vector3 (0.44f, 1.55f, -41.48f);
		mainCube.SetActive (true);
		//
		StartCoroutine (resetRestartButtonIsTrue ());

		if (gameOverPanel.activeInHierarchy) {
			gameOverPanel.SetActive (false);
		}

		if (tiltText.activeInHierarchy) {
			tiltText.SetActive (false);
		}


	}

	IEnumerator regenerateBoxDelay(){
		yield return new WaitForSeconds(.5f);
		boxGenerator.InvokeBoxGenerator();
	}

	public void quitButtonClick(){
		Application.Quit();
	}

	public void DestroyAllBoxesOnScreen ()
	{
		//destroyNow = true;
		//	StartCoroutine (resetDestroyNow ());

		for (int i = 0; i < boxGenerator.pooledObjects.Count; i++) {
			if (boxGenerator.pooledObjects [i].activeInHierarchy) {
				boxGenerator.pooledObjects[i].SetActive(false);
				Instantiate (BoxParticles, new Vector3 (boxGenerator.pooledObjects[i].gameObject.transform.GetChild(0).position.x-.9f, boxGenerator.pooledObjects[i].gameObject.transform.GetChild(0).position.y+.5f, boxGenerator.pooledObjects[i].gameObject.transform.GetChild(0).position.z-1f), Quaternion.identity);
			}
		}
	}

	//IEnumerator resetDestroyNow(){
	//	yield return new WaitForSeconds(.5f);
	//	destroyNow = false;
	//}

	public void counterIncrease (){
		counterStart = true;
	}

	IEnumerator resetRestartButtonIsTrue ()
	{
		if (!CounterObject.activeInHierarchy) {
			CounterObject.SetActive(true);
		}
		pauseImage.SetActive(true);
		yield return new WaitForSeconds (.5f);
		//restartButtonIsTrue = false;
		counter.text = 0 + "";
		timer = 0;
		StartCoroutine (counterStartDelay ());

	}

	IEnumerator counterStartDelay(){
		yield return new WaitForSeconds(.2f);
		counterStart = true;
	}

	public void saveValueToPrefab(int bestScore){
		PlayerPrefs.SetInt("bestScoreValue",bestScore);
		PlayservicesManager.addScoreToLeaderBoard (GPGSIds.leaderboard_high_score, bestScore);
	}



	public void GenerateFinalDelay(){
	    extiPanelCoroutine = StartCoroutine(GenerateFinalScreen());
	}

	IEnumerator GenerateFinalScreen(){
		coroutinePanelCheck = true;
		Debug.Log("Coroutine activated");
		yield return new WaitForSeconds(1.5f);
		//Debug.Log("GameExitPanelOn");
		gameOverPanel.SetActive(true);
		CounterObject.SetActive(false);
		pauseImage.SetActive(false);

		counter.text = 0 +"";
	}

	public void StopStartAudio(){
		//playAudio.Stop();
		gameObject.GetComponent<AudioSource>().Stop();
	}

	public void playGamePlayingSound ()
	{
		//gameObject.GetComponent<AudioSource>().clip = gamePlayingSound;
		//gameObject.GetComponent<AudioSource>().Play();
		if (PlayerPrefs.GetInt("musicButtonOff") == 0) {
			playAudio.clip = gamePlayingSound;
			playAudio.Play();
			//startingSound = false;
		}

	}

	public void playGameOverSound ()
	{
		//playAudio.clip = gameFinish;
		//playAudio.Play();
		if ( PlayerPrefs.GetInt("musicButtonOff") == 0) {
			gameFinish.GetComponent<AudioSource>().Play();
		}

	}

	public void stopGamePlayingSound ()
	{
		if (PlayerPrefs.GetInt("musicButtonOff") == 0) {
			playAudio.Stop();
		}

	}

	public void LoadScene(){
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene("GamePlay");
	}
	public void showLeaderBoard(){
		//Application.LoadLevel(Application.loadedLevel);
			PlayservicesManager.showLeaderBoardUI ();
	}

	public void LoadScene2(){
		Time.timeScale = 1f;
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene("GamePlay");
	}


	public void TurnPlayButtonOff ()
	{
		Debug.Log ("Play button off");
		//playImage.gameObject.SetActive(false);
		//	Color temp =  playImage.GetComponent<Image>().color;
		//temp.a = 0.5f;
		//playImage.color = temp;
		playImage.GetComponent<Button>().interactable = false;
		fadeOutAnim = playImage.GetComponent<Animator> ();
		if (fadeOutAnim.GetBool("playActive") == true) {
			fadeOutAnim.SetBool("playActive", false);
		}

	}

	public void GameStart(){
		Debug.Log("Game Start");
		controller1.GetComponent<Button>().interactable = false;
		controller2.GetComponent<Button>().interactable = false;
		//mainStartPanelAnimator = mainStartPanel.GetComponent<Animator>();
		//mainStartPanelAnimator.SetBool("hidePanel",true);
		playImage.GetComponent<Button>().interactable = false;
		//fadeOutAnim = playImage.GetComponent<Animator> ();
		//fadeOutAnim.SetBool("playAcive",false);
		infoPanelOuter.SetActive(true);
		infoPanelOuterAnim = infoPanelOuter.GetComponent<Animator>();
		infoPanelOuterAnim.SetBool("slidePanelOuter",true);
		infoPanelInnerAnim = infoPanelInner.GetComponent<Animator>();
		infoPanelInnerAnim.SetBool("slidePanelOpen",true);

	}

	public void GameStartFinal (){
		infoPanelOuterAnim = infoPanelOuter.GetComponent<Animator>();
		infoPanelOuterAnim.SetBool("slidePanelOuter",false);
		infoPanelInnerAnim = infoPanelInner.GetComponent<Animator>();
		infoPanelInnerAnim.SetBool("slidePanelOpen",false);
		StartCoroutine(mainPanelSlide());
	}

	IEnumerator mainPanelSlide(){
		yield return new WaitForSeconds(0.4f);
		mainStartPanelAnimator = mainStartPanel.GetComponent<Animator>();
		mainStartPanelAnimator.SetBool("hidePanel",true);
		PlayerPrefs.SetInt("FirstTimeGameEnter",31);
		StartCoroutine(destroyNotNeededPanel());
	}

	IEnumerator destroyNotNeededPanel(){
		yield return new WaitForSeconds(.5f);
		infoPanelOuter.SetActive(false);
	}


	public void activeRibbon1(){
		ribbon1.SetActive(true);
		ribbon2.SetActive(false);
	}

	public void activeRibbon2 (){
		ribbon2.SetActive(true);
		ribbon1.SetActive(false);
	}

	public void shareHighScore(){
		//execute the below lines if being run on a Android device
        #if UNITY_ANDROID
        //Reference of AndroidJavaClass class for intent
        AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
        //Reference of AndroidJavaObject class for intent
        AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
        //call setAction method of the Intent object created
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        //set the type of sharing that is happening
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        //add data to be passed to the other activity i.e., the data to be sent
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Play Dodge Cube Game ");
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), "https://play.google.com/store/apps/details?id=io.yarsa.dodgecube");
        //get the current activity
        AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        //start the activity by sending the intent data
        currentActivity.Call ("startActivity", intentObject);
        #endif
	}


	public void SwitchScreenInfo(){
		infoAnimator = infoPanel.GetComponent<Animator>();
		infoAnimator.SetBool("infoSlideIn",true);
	}


	public void SwitchScreenInfoOff(){
		infoAnimator = infoPanel.GetComponent<Animator>();
		infoAnimator.SetBool("infoSlideIn",false);
	}


	public void defaultSpeedCondition(){
	 	tenUp = true;
	 	ten2Up = true;
		ten3Up = true;
		 ten4Up = true;
		 ten5Up = true;
		ten6Up = true;
		ten7Up = true;
		 ten8Up = true;
	 	ten9Up = true;
	}

}
