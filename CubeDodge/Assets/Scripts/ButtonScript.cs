using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, ISelectHandler {

	public Image playImage;

	Animator fadeInAnim;

	void Awake(){
		//playImage.gameObject.SetActive(false);
	}

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
		Debug.Log ("yes is working Controller 1");
		//	print(eventData.selectedObject.transform.gameObject.tag);
		PlayerPrefs.SetInt ("controller", 11);
		//if (!playImage.gameObject.activeInHierarchy) {
			//playImage.gameObject.SetActive(true);
			fadeInAnim = playImage.GetComponent<Animator>();
			fadeInAnim.SetBool("playActive",true);
		//}

     }
}
