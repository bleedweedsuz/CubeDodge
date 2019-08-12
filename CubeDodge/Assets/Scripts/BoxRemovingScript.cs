using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRemovingScript : MonoBehaviour {

	public GameObject BoxParticle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision target)
	{
		if (target.gameObject.tag == "MainCube") {
			transform.parent.gameObject.SetActive (false);
			gameObject.SetActive (false);
			//Destroy(transform.parent.gameObject);
			//Destroy(gameObject);
			//Destroy(target.gameObject);
			Instantiate (BoxParticle, new Vector3 (gameObject.transform.position.x - .9f, 1.9f, gameObject.transform.position.z - 0.9f), Quaternion.identity);
		}

		if (target.gameObject.tag == "MainGround") {
			transform.parent.gameObject.SetActive (false);
			gameObject.SetActive (false);

			//gameObject.transform.parent.position = new Vector3(0f,16f,0f);
	
			//Destroy(transform.parent.gameObject);
			//Destroy(gameObject);
			Instantiate (BoxParticle, new Vector3 (gameObject.transform.position.x - .9f, 1.9f, gameObject.transform.position.z - 0.9f), Quaternion.identity);
		}


		if (target.gameObject.tag == "leftFence") {
			transform.parent.gameObject.SetActive (false);
			gameObject.SetActive (false);
			Instantiate (BoxParticle, new Vector3 (gameObject.transform.position.x - .9f, 1.9f, gameObject.transform.position.z - 0.9f), Quaternion.identity);
		}

		if (target.gameObject.tag == "rightFence") {
			transform.parent.gameObject.SetActive (false);
			gameObject.SetActive (false);
			Instantiate (BoxParticle, new Vector3 (gameObject.transform.position.x - .9f, 1.9f, gameObject.transform.position.z - 0.9f), Quaternion.identity);
		}
	}
}
