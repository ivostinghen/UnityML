using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{

    public GameObject fireball;

    public string currentGesture;

    public Transform rightPalm;
    public GameObject shield;
    IEnumerator Start()
    {
        
        while (true)
        {


            if (currentGesture.Equals("OPEN"))
            {
                //print(result);
                // SpawnFireBall(rightPalm);
                shield.SetActive(false);
            }
            else if (currentGesture.Equals("CLOSE"))
            {

                shield.SetActive(true);
            }

            yield return new WaitForSeconds(.4F);
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
