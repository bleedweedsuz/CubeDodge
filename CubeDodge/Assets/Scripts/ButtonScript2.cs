using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript2 : MonoBehaviour, ISelectHandler {


	public Image playImage;
	Animator fadeOutAnim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnSelect (BaseEventData eventData)
	{
		// Do something.
		playImage.GetComponent<Button>().interactable = true;
		Debug.Log ("yes is working Controller2 ");
		PlayerPrefs.SetInt ("controller", 12);
		fadeOutAnim = playImage.GetComponent<Animator> ();
		fadeOutAnim.SetBool("playActive",true);
		
     }
}
