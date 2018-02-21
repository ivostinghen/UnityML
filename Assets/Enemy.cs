using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Transform character;
    public float speed;
    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
        character = GameObject.Find("HandModels").transform ;
        transform.LookAt(character);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer.Equals(8))
        {
            
            Destroy(this.gameObject);
            //todo:spawn
        }
    }
}
