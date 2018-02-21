using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    Coroutine cor;
    public Transform rightHand;
    Rigidbody rb;
    bool grabbed;



    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Fall()
    {

        if (!grabbed)
        {
            rb.isKinematic = false;

            if (cor != null)
            {
                StopCoroutine(cor);
                cor = null;
            }


            rb.useGravity = true;
        }
       



    }

    public void TurnOnOff()
    {
        if(grabbed) GetComponentInChildren<Lightsaber>().ToggleLightsaberOnOff();
    }

    public void Grab()
    {
        if (!grabbed)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            if (cor == null)
            {
                cor = StartCoroutine(GoToHand());
            }
        }
      
    
    }

    IEnumerator GoToHand()
    {
        float dist = 0;
        while ((dist = Vector3.Distance(transform.position, rightHand.position)) > .05F)
        {

            transform.position = Vector3.MoveTowards(transform.position, rightHand.position, (Time.deltaTime * dist * .5f) +.1f);
            
            
            yield return new WaitForSeconds(.01F);

        }

        cor = null;
        transform.parent = rightHand.transform;
        transform.localEulerAngles = new Vector3(-90, 90, 180);
        transform.localPosition = new Vector3(-0.15F, -0.03000011F, -0.02000004F);

        grabbed = true;

    }
}
