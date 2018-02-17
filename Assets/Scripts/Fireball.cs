using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    float time;
    public float fireSpeed;


    void LateUpdate()
    {

        transform.position += -transform.up * fireSpeed * Time.deltaTime;
       

        time += Time.deltaTime;
        if (time > 4) Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.layer != 8)
        {
        	//print(col.gameObject.name);
            //Destroy(this.gameObject);
        }

    }
}
