using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicSprite : MonoBehaviour {

	public Sprite musicOffSprite, musicOnSprite;
	Image mainImage;
	bool musicCheck;
	public Image musicImage;
	// Use this for initialization
	void Start () {

		mainImage = GetComponent<Image>();
		if (PlayerPrefs.GetInt("musicButtonOff") == 0) {
				musicImage.sprite = musicOffSprite;

			} else if(PlayerPrefs.GetInt("musicButtonOff") == 1) {
					musicImage.sprite = musicOnSprite;
				}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeSpriteSheet ()
	{
		//gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("musicOff");
		if (musicCheck) {
			mainImage.sprite = musicOnSprite;
			musicCheck = false;
		} else {
			mainImage.sprite = musicOffSprite;
			musicCheck = true;
		}
	}

}
