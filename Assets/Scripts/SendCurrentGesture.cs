using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SendCurrentGesture : MonoBehaviour {

	string fileUnity = @"C:\Users\ivoal\git\pythonML\communication\unity.txt";
    

    public Transform rightHand,leftHand;
    int cont = 0;
    String line = "";
    String lastAcess = "";
    public Transform rightPalm;
    public Transform[] fingers;
    Socket socket;
    IEnumerator Start ()
    {
        socket = GetComponent<Socket>();
        while (true)
        {
            //string temp = File.GetLastAccessTime(fileUnity).ToShortTimeString().ToString();
            //if (temp != lastAcess)
            {
                //lastAcess = temp;
                //File.WriteAllText(fileUnity, "0.01867951, -0.1701594, 0.430245, -0.01792057, -0.1585511, 0.4385388, -0.04171818, -0.1507002, 0.4444833, 0.02447525, -0.08338133, 0.4512593, 0.01844522, -0.05482322, 0.4582922, 0.01441459, -0.0383985, 0.4655928, 0.05023385, -0.0782541, 0.4527235, 0.05131966, -0.04483771, 0.4603717, 0.05127802, -0.02514544, 0.4679659, 0.09658827, -0.0974496, 0.4567671, 0.106867, -0.07637754, 0.4641158, 0.1127167, -0.06293365, 0.4715484, 0.07371579, -0.08433524, 0.45384, 0.07796626, -0.0534153, 0.4625016, 0.07983762, -0.03452575, 0.4708329");

                //int y = 0;
                string rawDataTemp= "";
              
               //ALREADY TESTED
                // float normalDist = Vector3.Distance(rightPalm.transform.position, rightHand.transform.GetChild(2).GetChild(2).position); // dedo medio
                float normalDist = 0.1257631F; // the maximum distance betwween middle finger and the hand middle point.
                                               ////////




                // }

                //rotation angles
                // for (int finger = 0; finger < 4; finger++)  //5 fingers
                //     {

                //         {

                //             float c = Vector3.Distance(fingers[finger].position, fingers[finger + 1].position);
                //             float a = Vector3.Distance(fingers[finger + 1].position, rightPalm.transform.position);
                //             float b = Vector3.Distance(fingers[finger].position, rightPalm.transform.position);







                //             float cosTheta = 0;

                //             //c^2 = a^2 + b^2 – 2·a·b·cosα
                //             // = a^2 + b^2 – 2·a·b·cosα - c^2
                //             //2·a·b·cosα  = a^2 + b^2 - c^2
                //             //cosα  = a^2 + b^2 - c^2 / 2·a·b


                //             cosTheta = ((a * a) + (b * b) - (c * c)) / (2 * a * b);



                //             float theta = Mathf.Acos(cosTheta);
                //             theta = theta * Mathf.Rad2Deg;

                //             // if(finger==0)  Debug.Log("theta  " + theta);
                //             //if (finger == 0) print(theta);


                //             //if (finger == 0)
                //             //{
                //             //    rawDataTemp = rawDataTemp + c + ",";
                //             //}
                //             rawDataTemp = rawDataTemp + theta + ",";



                //             //if (finger == 3)
                //             //{
                //             //    rawDataTemp = rawDataTemp + a + ",";
                //             //}


                //             // y++;

                //         }
                //     }

                for (int finger = 0; finger < 5; finger++)  //5 fingers
                {

                   {

                       //print(finger);


                       // if(finger==0)  Debug.Log("theta  " + theta);



                       //if (finger == 0)
                       //{
                       //    rawDataTemp = rawDataTemp + c + ",";
                       //}

                       Vector3 localPos =  fingers[finger].transform.position - rightPalm.transform.position;
                       for (int i = 0; i < 3; i++)
                       {

                           rawDataTemp = rawDataTemp + localPos[i]  + ",";

                         

                       }


                       //if (finger == 3)
                       //{
                       //    rawDataTemp = rawDataTemp + a + ",";
                       //}


                       //y++;

                   }
                }










                ////left hand position
                //for (int finger = 0; finger < 5; finger++)  //5 fingers
                //{
                //    //for (int bone = 0; bone < 3; bone++)
                //    int bone = 2;
                //    {
                //        for (int axis = 0; axis < 3; axis++)    //3 axis (X,y,z) position.
                //        {
                //            raw = raw + (leftHand.transform.GetChild(finger).GetChild(bone).position[axis] - leftPalm.transform.position[axis]) + ",";
                //            //raw = raw + rightHand.transform.GetChild(finger).GetChild(bone).eulerAngles[axis] + ",";

                //            //y++;
                //        }
                //    }
                //}

                rawDataTemp = rawDataTemp.Substring(0, rawDataTemp.Length - 1);

                socket.currentInput = rawDataTemp;
                //Debug.Log(positions);
                // File.WriteAllText(fileUnity, rawDataTemp);
                //print("changed!");
            }

            yield return new WaitForSeconds(.2F);
        }
    }


}
