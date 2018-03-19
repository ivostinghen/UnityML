﻿using System.Collections;
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
            else if (currentGesture.Equals("THUMB"))
            {
                if (lastGesture != "THUMB")
                {
                    lastGesture = "THUMB";
                    if (sword) sword.TurnOnOff();
                }

            }
             else if (currentGesture.Equals("GRAB"))
            {
                if (lastGesture != "GRAB")
                {
                    lastGesture = "GRAB";
                    if (sword) sword.TurnOnOff();
                }

            }
             else if (currentGesture.Equals("COOL"))
            {
                if (lastGesture != "COOL")
                {
                    lastGesture = "COOL";
                    if (sword) sword.TurnOnOff();
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
