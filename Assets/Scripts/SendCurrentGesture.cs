using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SendCurrentGesture : MonoBehaviour {

	string fileUnity = @"C:\Users\ivoal\github\PythonML\communication\unity.txt";
    string filePython = @"C:\Users\ivoal\github\PythonML\communication\python.txt";

    public Transform rightHand;
    int cont = 0;
    String line = "";
    String lastAcess = "";

    
    IEnumerator Start ()
    {
        while (true)
        {
            //string temp = File.GetLastAccessTime(fileUnity).ToShortTimeString().ToString();
            //if (temp != lastAcess)
            {
                //lastAcess = temp;
                //File.WriteAllText(fileUnity, "0.01867951, -0.1701594, 0.430245, -0.01792057, -0.1585511, 0.4385388, -0.04171818, -0.1507002, 0.4444833, 0.02447525, -0.08338133, 0.4512593, 0.01844522, -0.05482322, 0.4582922, 0.01441459, -0.0383985, 0.4655928, 0.05023385, -0.0782541, 0.4527235, 0.05131966, -0.04483771, 0.4603717, 0.05127802, -0.02514544, 0.4679659, 0.09658827, -0.0974496, 0.4567671, 0.106867, -0.07637754, 0.4641158, 0.1127167, -0.06293365, 0.4715484, 0.07371579, -0.08433524, 0.45384, 0.07796626, -0.0534153, 0.4625016, 0.07983762, -0.03452575, 0.4708329");

                //int y = 0;
                string raw = "";

                for (int finger = 0; finger < 5; finger++)  //5 fingers
                {
                    for (int bone = 0; bone < 3; bone++)
                    {
                        for (int axis = 0; axis < 3; axis++)    //3 axis (X,y,z) position.
                        {
                            raw = raw + rightHand.transform.GetChild(finger).GetChild(bone).position[axis] + ",";
                            raw = raw + rightHand.transform.GetChild(finger).GetChild(bone).eulerAngles[axis] + ",";

                            //y++;
                        }
                    }
                }

                raw = raw.Substring(0, raw.Length - 1);

                //Debug.Log(positions);
                File.WriteAllText(fileUnity, raw);
                //print("changed!");
            }

            yield return new WaitForSeconds(.2F);
        }
    }


}
