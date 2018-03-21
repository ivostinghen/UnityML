using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{

    public GameObject fireball;

    public string currentGesture;

    public Transform rightPalm;
    public Sword sword;
    string lastGesture;

    string stateMachine = "";

    GameObject enemy;
    public GameObject thunderPower, flamesPower;
    public Transform lightningEnd;
    Coroutine curPower;

    IEnumerator ActivateThunder(){
    	Debug.Log("*** THUNDER POWER  ***");

        enemy = GameObject.Find("Enemy");
        lightningEnd.transform.parent = enemy.transform.GetChild(0).transform;
        lightningEnd.transform.localPosition = Vector3.zero;
    	Camera.main.GetComponent<PerlinShake>().test = true;
    	thunderPower.SetActive(true);
    	enemy.GetComponent<Rigidbody>().isKinematic = false;
    	enemy.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10000);

    	// while(currentGesture.Equals("LOVEJUTSU"))
    	{
			yield return new WaitForSeconds(.3F);

    	}
    	enemy.name = "TRASH";
    	thunderPower.SetActive(false);
    	curPower = null;
    }

     IEnumerator ActivateFlames(){
    	Debug.Log("*** Flames POWER  ***");

    	// Camera.main.GetComponent<PerlinShake>().test = true;
    	flamesPower.SetActive(true);
    	// enemy.GetComponent<Rigidbody>().isKinematic = false;
    	// enemy.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10000);

    	while(currentGesture.Equals("COOL"))
    	{
			yield return new WaitForSeconds(.3F);

    	}
    	
    	flamesPower.SetActive(false);
    	curPower = null;
    }

    IEnumerator Start()
    {
        
        while (true)
        {
// 
        	// Debug.Log(stateMachine + "			" + currentGesture);
        	if(stateMachine.Equals("TWO") && currentGesture.Equals("LOVE")){
        			Debug.Log("AAAAAAAAAAA");
        		if(curPower==null)curPower=StartCoroutine(ActivateThunder());

        	}
        	else if(stateMachine.Equals("FOUR") && currentGesture.Equals("COOL")){

        		if(curPower==null)curPower=StartCoroutine(ActivateFlames());

        	}

            // if (currentGesture.Equals("CLOSE"))
            // {
            //     if (lastGesture != "CLOSE")
            //     {
            //         lastGesture = "CLOSE";
            //         if (sword) sword.Fall();

            //     }

            // }
            // else if (currentGesture.Equals("OPEN"))
            // {
            //     if (lastGesture != "OPEN")
            //     {
            //         lastGesture = "OPEN";
            //         if (sword) sword.Grab();
            //     }

            // }
            // else if (currentGesture.Equals("THUMB"))
            // {
            //     if (lastGesture != "THUMB")
            //     {
            //         lastGesture = "THUMB";
            //         if (sword) sword.TurnOnOff();
            //     }

            // }
            //  else if (currentGesture.Equals("GRAB"))
            // {
            //     if (lastGesture != "GRAB")
            //     {
            //         lastGesture = "GRAB";
            //         if (sword) sword.TurnOnOff();
            //     }

            // }
            //  else if (currentGesture.Equals("COOL"))
            // {
            //     if (lastGesture != "COOL")
            //     {
            //         lastGesture = "COOL";
            //         if (sword) sword.TurnOnOff();
            //     }

            // }

			stateMachine = currentGesture;

        	
            yield return new WaitForSeconds(.2F);
        }
    }


    public void SpawnFireBall(Transform spawnPoint)
    {
        print("FIRE");
        GameObject power = Instantiate(fireball, spawnPoint.position, spawnPoint.rotation);
        //fireball.GetComponent<FireBall>().target = target;
        //fireball.gameObject.SetActive(true);

    }
}
