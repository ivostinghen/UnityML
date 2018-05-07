using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{

    public GameObject fireball;

    public string currentGesture = " ";

    public Transform rightPalm;
    public Sword sword;
    string lastGesture;

    string stateMachine = "";

    GameObject enemy;
    public GameObject thunderPower, flamesPower;
    public Transform lightningEnd;
    Coroutine curPower;

    //DEBUG PC
    // public void Update(){
    //     if(Input.GetMouseButtonDown(0)){

    //     StartCoroutine(ActivateThunder());
    //     }
    // }
    IEnumerator ActivateThunder(){
    	Debug.Log("*** THUNDER POWER  ***");

        enemy = GameObject.Find("Enemy");
        if(enemy!=null){


            lightningEnd.transform.parent = enemy.transform;
            lightningEnd.transform.localPosition = new Vector3(0,4,0);
        	Camera.main.GetComponent<PerlinShake>().test = true;
        	thunderPower.SetActive(true);
        	enemy.GetComponent<Rigidbody>().useGravity = true;
        	enemy.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 100);

        	// while(currentGesture.Equals("LOVEJUTSU"))
        	{
        		yield return new WaitForSeconds(.5F);

        	}
        	enemy.name = "TRASH";
        	thunderPower.SetActive(false);
        	curPower = null;
         }
         yield return null;
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
        			// Debug.Log("AAAAAAAAAAA");
        		if(curPower==null)curPower=StartCoroutine(ActivateThunder());

        	}
        	else if(stateMachine.Equals("FOUR") && currentGesture.Equals("COOL")){

        		if(curPower==null)curPower=StartCoroutine(ActivateFlames());

        	}

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
