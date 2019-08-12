using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxGenerator : MonoBehaviour {

	//public GameObject box;
	Vector3 currentPosition;
	//CubeController cubeController;

	public GameObject box;
	public int pooledAmount;
	public List<GameObject> pooledObjects;

	public Text CounterAgain;
	Rigidbody childRigidBody;

	void Start ()
	{
		
		currentPosition = new Vector3 (0f, 0f, 0f);
		//cubeController = GameObject.FindObjectOfType<CubeController>();
		pooledObjects = new List<GameObject> ();

		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = Instantiate(box) as GameObject;
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}

	}

	void Update ()
	{
		//if(Input.GetKey(KeyCode.Space)){
		//	CancelInvoke("GenerateRandomBoxes");
		//}

		if (Input.GetKeyDown (KeyCode.Space)) {
			for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 0;
			}
		}

	
		
	}

	public void generateBoxes (){
		GenerateRandomBoxes();
			GenerateRandomBoxes2();
	}

	public void InvokeBoxGenerator(){
		InvokeRepeating("GenerateRandomBoxes",1f,.7f);
		InvokeRepeating("GenerateRandomBoxes2",1f,.6f);
	}

	void GenerateRandomBoxes ()
	{
		int randCheck = Random.Range (0, 5);
		if (randCheck < 3) {
			float[] random1 = new float[] {0f, 1.5f, 3f, 4.5f};
			int rand1 = Random.Range(0,random1.Length);
			Generator1(random1[rand1]);
		} else {
			float[] random4 = new float[] { -6f ,-7.5f, -9f, -10.5f};
			int rand4 = Random.Range(0,random4.Length);
			Generator4(random4[rand4]);
		}

	}

	void GenerateRandomBoxes2 ()
	{
		int randCheck = Random.Range (0, 5);
		if (randCheck < 3) {
			float[] random2 = new float[] { -1.5f, -3f, -4.5f};
			int rand2 = Random.Range (0, random2.Length);
			Generator2 (random2 [rand2]);
		} else {
			float[] random3 = new float[] { 6f, 7.5f, 9f, 10.5f,12f};
			int rand3 = Random.Range(0,random3.Length);
			Generator3(random3[rand3]);
		}

	}


		GameObject GetPooledObject (){

			for (int i = 0; i < pooledObjects.Count; i++) {
				if (!pooledObjects [i].activeInHierarchy) {
					return pooledObjects[i];
				}
				//return box;
			}

			GameObject obj = Instantiate(box) as GameObject;
		    obj.SetActive(false);
			pooledObjects.Add(obj);
			return obj;
		}



	void Generator1 (float rand){
		//Vector3 pos = currentPosition;
		//pos.x = rand;
		//Instantiate(box,pos,Quaternion.identity);

		GameObject newObject = GetPooledObject();
		//Vector3 pos = currentPosition;
		//pos.x = rand;
		//pos.y = 16f;
		//newObject.transform.position = pos;
		newObject.transform.GetChild(0).position = new Vector3(rand,14.79f,-41f);
		//newObject.transform.position = transform.position;
		//newObject.transform.rotation = transform.rotation;
		newObject.SetActive(true);
		newObject.transform.GetChild(0).gameObject.SetActive(true);

	}

	void Generator2 (float rand){
		///Vector3 pos = currentPosition;
		///pos.x = rand;
		///Instantiate(box,pos,Quaternion.identity);
		GameObject newObject = GetPooledObject();
		//Vector3 pos = currentPosition;
		//pos.x = rand;
		//pos.y = 16f;
		//newObject.transform.position = pos;
		newObject.transform.GetChild(0).position = new Vector3(rand,14.79f,-41f);
		newObject.SetActive(true);
		newObject.transform.GetChild(0).gameObject.SetActive(true);
	}

	void Generator3 (float rand){
		//Vector3 pos = currentPosition;
		//pos.x = rand;
		//Instantiate(box,pos,Quaternion.identity);
		GameObject newObject = GetPooledObject();
		Vector3 pos = currentPosition;
		pos.x = rand;
		//pos.y = 16f;
		newObject.transform.position = pos;
		newObject.transform.GetChild(0).position = new Vector3(rand,14.79f,-41f);
		newObject.SetActive(true);
		newObject.transform.GetChild(0).gameObject.SetActive(true);

	}

	void Generator4 (float rand){
		//Vector3 pos = currentPosition;
		//pos.x = rand;
		//Instantiate(box,pos,Quaternion.identity);
		GameObject newObject = GetPooledObject();
		//Vector3 pos = currentPosition;
		//pos.x = rand;
		//pos.y = 16f;
		//newObject.transform.position = pos;
		newObject.transform.GetChild(0).position = new Vector3(rand,14.79f,-41f);
		newObject.SetActive(true);
		newObject.transform.GetChild(0).gameObject.SetActive(true);
	}


	public void CancelBoxGenerator(){
		CancelInvoke("GenerateRandomBoxes");
		CancelInvoke("GenerateRandomBoxes2");
	}


	public void setDragToDefault(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 4;
			}
	}

	public void setDragIncrease1(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 3.5f;
			}
	}

	public void setDragIncrease2(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 3f;
			}
	}

	public void setDragIncrease3(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 2.8f;
			}
	}

	public void setDragIncrease4(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 2.5f;
			}
	}

	public void setDragIncrease5(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 2.2f;
			}
	}

	public void setDragIncrease6(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 2f;
			}
	}

	public void setDragIncrease7(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 1.8f;
			}
	}

	public void setDragIncrease8(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 1.4f;
			}
	}

	public void setDragIncrease9(){
		for (int i = 0; i < pooledObjects.Count; i++) {
				GameObject obj2 = pooledObjects[i].transform.GetChild(0).gameObject;
				childRigidBody = obj2.gameObject.transform.GetComponent<Rigidbody>();
				childRigidBody.drag = 1.1f;
			}
	}

}
