using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour {

	Animator translateAnim;
	//public GameObject SettingPanel;
	public ControllerGame controllerGame;
	// Use this for initialization
	void Start ()
	{

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchScreen(){
		translateAnim = GetComponent<Animator>();

		translateAnim.SetBool("IsOpen",true);
	}

	public void ScreenOff ()
	{
		translateAnim = GetComponent<Animator> ();

		translateAnim.SetBool ("IsOpen", false);
		if (controllerGame.acceleromterToggle.isOn == true) {
			PlayerPrefs.SetInt ("controller", 11);

		Debug.Log("=====>>>Accelerometer Ticked");
		}

		if (controllerGame.touchToggle.isOn == true) {
			PlayerPrefs.SetInt ("controller", 12);

		Debug.Log("=====>>>Touch Ticked");
		}
	}

	public void toggleMaker (){
		if (PlayerPrefs.GetInt ("controller") == 11) {
				controllerGame.acceleromterToggle.isOn = true;
			}

		if (PlayerPrefs.GetInt ("controller") == 12) {
				controllerGame.touchToggle.isOn = true;
			}
	}


}
