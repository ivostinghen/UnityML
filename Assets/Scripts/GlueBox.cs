using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueBox : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.layer == 8)
        {
            transform.parent = collision.transform;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<GlueBox>().enabled = false;

        }

    }
}
