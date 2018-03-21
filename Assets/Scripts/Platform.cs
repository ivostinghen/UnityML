using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

void OnParticleCollision(GameObject col) {
        
		Debug.Log(col.name);
		col.GetComponent<Rigidbody>().isKinematic = false;
    }
	void OnCollisionEnter(Collision col){

	}
}
