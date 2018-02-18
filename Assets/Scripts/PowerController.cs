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
    IEnumerator Start()
    {
        
        while (true)
        {


            if (currentGesture.Equals("CLOSE"))
            {
                if (lastGesture != "CLOSE")
                {
                    lastGesture = "CLOSE";
                    if (sword) sword.Fall();

                }

            }
            else if (currentGesture.Equals("OPEN"))
            {
                if (lastGesture != "OPEN")
                {
                    lastGesture = "OPEN";
                    if (sword) sword.Grab();
                }

            }
            else if (currentGesture.Equals("THUMB_UP"))
            {
                if (lastGesture != "THUMB_UP")
                {
                    lastGesture = "THUMB_UP";
                    if (sword) sword.TurnOn();
                }

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
