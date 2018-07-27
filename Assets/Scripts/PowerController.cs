using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    public SkinnedMeshRenderer handRenderer;
    public GameObject fireball;

    public string currentGesture = " ";

    public Transform rightPalm;
    public Sword sword;
    string lastGesture;
    string stateMachine = "";
    GameObject enemy;
    public GameObject thunderPower, flamesPower, plasmaPower,gun;
    public Transform lightningEnd;
    Coroutine curPower;


    IEnumerator GunResize(string value){
        if(value.Equals("bigger")){
            for(float i=.25f;i<1f;i+=0.15f){
                gun.transform.localScale = new Vector3(i,i,i);
                yield return new WaitForSeconds(0.02f);
            }
        }
        else{
            for(float i=1F;i>.25f;i-=0.15f){
                gun.transform.localScale = new Vector3(i,i,i);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

   
    IEnumerator ActivatePlasmaBall(){
        gun.SetActive(true);
      
        StartCoroutine(GunResize("bigger"));
        yield return new WaitForSeconds(.5F);
        while(true)
        {
            GameObject plasma = Instantiate(plasmaPower,gun.transform.position,gun.transform.rotation) as GameObject;
            yield return new WaitForSeconds(.5F);
            if(!currentGesture.Equals("FIRE")){
                break;
            }
        }
        StartCoroutine(GunResize("smaller"));
        yield return new WaitForSeconds(.2F);
        gun.SetActive(false);
        curPower = null;
    }
   
    IEnumerator ActivateThunder(){
        try{
        	enemy = GameObject.Find("Enemy");
        }
        catch{
        	print("n achou");
        	curPower = null;
        }
        if(enemy!=null){
            lightningEnd.transform.parent = enemy.transform;
            lightningEnd.transform.position = enemy.transform.position;
        	Camera.main.GetComponent<PerlinShake>().test = true;
        	thunderPower.SetActive(true);
        	enemy.GetComponent<Rigidbody>().useGravity = true;        	
			enemy.GetComponent<Rigidbody>().isKinematic = false;
        	enemy.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 100);
            yield return new WaitForSeconds(.5F);
        	enemy.name = "TRASH";
        	lightningEnd.transform.parent = null;
        	thunderPower.SetActive(false);
         }
         curPower = null;
         yield return null;
    }

     IEnumerator ActivateFlames(){
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

 	public void Update(){
        if(Input.GetKeyDown("a"))
        {
            StartCoroutine(ActivatePlasmaBall());
        }
    }
    IEnumerator Start()
    {
        
        while (true)
        {
            if(stateMachine.Equals("THUMB") && currentGesture.Equals("FIRE"))
            {
                Debug.Log("FIRE");
                if(curPower==null)curPower=StartCoroutine(ActivatePlasmaBall());
            }
        	else if(stateMachine.Equals("TWO") && currentGesture.Equals("LOVE")){
        		Debug.Log("THUNDER");
        		if(curPower==null)curPower=StartCoroutine(ActivateThunder());
        	}
        	else if(stateMachine.Equals("FOUR") && currentGesture.Equals("COOL")){
        		Debug.Log("FLAMES");
                if(curPower==null)curPower=StartCoroutine(ActivateFlames());
            }
            // else if(stateMachine.Equals("ITALIAN") && currentGesture.Equals("HANG_LOOSE")){
            //     if(curPower==null)curPower=StartCoroutine(ActivatePlasmaBar());
            // }
			stateMachine = currentGesture;
            yield return new WaitForSeconds(.2F);
        }
    }

}
