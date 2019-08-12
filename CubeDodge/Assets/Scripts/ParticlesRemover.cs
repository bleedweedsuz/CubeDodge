using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesRemover : MonoBehaviour {


	// Use this for initialization
	void Start ()
	{
		InvokeRepeatingRemoveParticles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InvokeRepeatingRemoveParticles (){
		InvokeRepeating("removeParticles",2f,1f);
	}

	void removeParticles(){
		Destroy(gameObject);
	}
}
