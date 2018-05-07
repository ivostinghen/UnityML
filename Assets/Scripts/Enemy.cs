using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Transform character;
    public float speed;
    Rigidbody rb;
    Animator anim;
	void Start () {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        character = GameObject.Find("HandModels").transform ;
        transform.LookAt(character);
    }
	
	void Update () {
        rb.velocity = transform.forward * Time.deltaTime * speed;
        anim.SetFloat("speedh",rb.velocity.x);
        anim.SetFloat("speedv",rb.velocity.z);
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
