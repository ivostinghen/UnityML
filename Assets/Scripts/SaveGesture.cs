using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

using UnityEngine.UI;
using UnityEditor;

public class SaveGesture : MonoBehaviour
{
    public Transform rightHand, leftHand;
    // private List<string[]> rowData = new List<string[]>();
    public String gestureName;
    string rawDataTemp;
    //public float limitRecordTime;
    public float recordRateTime;
    //string path = @"C:\Users\ivoal\Desktop\gestures.txt";
    public Transform[] fingers;
    public int samples;
    float max;
    public Transform rightPalm /*, leftPalm*/;
    Text beginRecordTxt;


    void Awake()
    {
        rawDataTemp = "";
        //POSITIONS + ANGLES
        rawDataTemp = "THUMB_POS_X,THUMB_POS_Y,THUMB_POS_Z,INDEX_POS_X,INDEX_POS_Y,INDEX_POS_Z,MIDDLE_POS_X,MIDDLE_POS_Y,MIDDLE_POS_Z,RING_POS_X,RING_POS_Y,RING_POS_Z,PINKY_POS_X,PINKY_POS_Y,PINKY_POS_Z,THUMB_INDEX_ANGLE,INDEX_MIDDLE_ANGLE,MIDDLE_RING_ANGLE,RING_PINKY_ANGLE,target";
        //POSITION
        // rawDataTemp = "THUMB_POS_X,THUMB_POS_Y,THUMB_POS_Z,INDEX_POS_X,INDEX_POS_Y,INDEX_POS_Z,MIDDLE_POS_X,MIDDLE_POS_Y,MIDDLE_POS_Z,RING_POS_X,RING_POS_Y,RING_POS_Z,PINKY_POS_X,PINKY_POS_Y,PINKY_POS_Z";
        //ANGLES
        // rawDataTemp = "THUMB_INDEX_ANGLE,INDEX_MIDDLE_ANGLE,MIDDLE_RING_ANGLE,RING_PINKY_ANGLE,target";
        string filePath = getPath();
        File.AppendAllText(filePath, 
        rawDataTemp + Environment.NewLine);
        rawDataTemp = "";
    }

    private void Start()
    {
        StartCoroutine(WaitForStart());

    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(.5F);
        //beginRecordTxt.text = "2";
        yield return new WaitForSeconds(.5F);
        //beginRecordTxt.text = "1";
        yield return new WaitForSeconds(.5F);
        //beginRecordTxt.enabled = false;
        StartCoroutine(RecordHandPos());
    }

    IEnumerator RecordHandPos()
    {
        for (int i = 0; i < samples; i++)
        {
            GetValues();
            // Debug.Log(i + "");
            yield return new WaitForSeconds(recordRateTime);
        }
        Debug.Log(gestureName + " finished Recording.");
        EditorApplication.isPlaying = false;

    }

    public void GetValues()
    {

        // int y = 0;

        //ALREADY TESTED
        //////// float normalDist = Vector3.Distance(rightPalm.transform.position, rightHand.transform.GetChild(2).GetChild(2).position); // dedo medio
       // float normalDist = 0.1257631F; // the maximum distance betwween middle finger and the hand middle point.
                                    

        //right hand
        //var ax = rightHand.transform.GetChild(2).GetChild(2).position.x - rightPalm.transform.position.x ;
        //var ay = rightHand.transform.GetChild(2).GetChild(2).position.y - rightPalm.transform.position.y ; // z and y has a fake impression that are inverted on leap motion, but is only in editor, or local position, global is fine
        //var az = rightHand.transform.GetChild(2).GetChild(2).position.z - (rightPalm.transform.position.z/* - 0.071F*/)  ;
        //float normalDist = Mathf.Sqrt((ax * ax) + (ay * ay) + (az * az)) ;

        //Debug.Log((rightHand.transform.GetChild(2).GetChild(2).position.y - rightPalm.transform.position.y) / normalDist);
        // for (int finger = 0; finger < 5; finger++)  //5 fingers
        // {
        //     //for (int bone = 0; bone < 3; bone++)
        //     int bone = 2;
        //     {
        //         for (int axis = 0; axis < 3; axis++)    //3 axis (X,y,z) position.
        //         {
        //             //if (axis==0) rawDataTemp[y] = "(" + (rightHand.transform.GetChild(finger).GetChild(bone).position[axis] / normalDist);
        //             //else if(axis==2) rawDataTemp[y] = "" + (rightHand.transform.GetChild(finger).GetChild(bone).position[axis-1] / normalDist + ")");
        //             ///*else*/ rawDataTemp[y] = "" + (rightHand.transform.GetChild(finger).GetChild(bone).position[axis+1]/ normalDist);
        //             /*else*/ rawDataTemp[y] = "" + ((rightHand.transform.GetChild(finger).GetChild(bone).position[axis] - rightPalm.transform.position[axis]) / normalDist);
        //             y++;
        //             //rawDataTemp[y] = "" + rightHand.transform.GetChild(finger).GetChild(bone).eulerAngles[axis] ;
        //             //y++;   
        //         }
        //     }
        // }

        // //Angles between fingers
        // for (int finger = 0; finger < 4; finger++)  //5 fingers
        // {
        //    {
        //        float c = Vector3.Distance(fingers[finger].position, fingers[finger + 1].position);
        //        float a = Vector3.Distance(fingers[finger + 1].position, rightPalm.transform.position);
        //        float b = Vector3.Distance(fingers[finger].position, rightPalm.transform.position);
        //        float cosTheta = 0;
        //        //Calculate: c^2 = a^2 + b^2 – 2·a·b·cosα
        //        // = a^2 + b^2 – 2·a·b·cosα - c^2
        //        //2·a·b·cosα  = a^2 + b^2 - c^2
        //        //cosα  = a^2 + b^2 - c^2 / 2·a·b
        //        cosTheta = ((a * a) + (b * b) - (c * c)) / (2 * a * b);
        //        float theta = Mathf.Acos(cosTheta);
        //        theta = theta * Mathf.Rad2Deg;
        //        rawDataTemp = rawDataTemp + theta + ",";
        //    }
        // }

        // //POSIÇÕES DOS DEDOS
        // for (int finger = 0; finger < 5; finger++)  //5 fingers
        // {
        //    Vector3 localPos =  fingers[finger].transform.position - rightPalm.transform.position;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        rawDataTemp = rawDataTemp + localPos[i]  + ",";
        //    }
        // }
        // rawDataTemp = rawDataTemp + gestureName;
        // string filePath = getPath();
        // File.AppendAllText(filePath,rawDataTemp + Environment.NewLine);       
        // rawDataTemp = "";


        //Angles between fingers + POSIÇÕES DOS DEDOS
        

        for (int finger = 0; finger < 5; finger++)  //5 fingers
        {
           Vector3 localPos =  fingers[finger].transform.position - rightPalm.transform.position;
           for (int i = 0; i < 3; i++)
           {
               rawDataTemp = rawDataTemp + localPos[i]  + ",";
           }
        }

        for (int finger = 0; finger < 4; finger++)  //5 fingers
        {
           {
               float c = Vector3.Distance(fingers[finger].position, fingers[finger + 1].position);
               float a = Vector3.Distance(fingers[finger + 1].position, rightPalm.transform.position);
               float b = Vector3.Distance(fingers[finger].position, rightPalm.transform.position);
               float cosTheta = 0;
               
               cosTheta = ((a * a) + (b * b) - (c * c)) / (2 * a * b);
               float theta = Mathf.Acos(cosTheta);
               theta = theta * Mathf.Rad2Deg;
               rawDataTemp = rawDataTemp + theta + ",";
           }
        }



        
        rawDataTemp = rawDataTemp + gestureName;
        string filePath = getPath();
        File.AppendAllText(filePath,rawDataTemp + Environment.NewLine);       
        rawDataTemp = "";
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
        #if UNITY_EDITOR
                //return Application.dataPath + "/CSV/" + "Saved_data.csv";
                return @"C:\Users\ivoal\git\pythonML\gestures\gesture" + gestureName+".txt";
        #elif UNITY_ANDROID
                            return Application.persistentDataPath+"Saved_data.csv";
        #elif UNITY_IPHONE
                            return Application.persistentDataPath+"/"+"Saved_data.csv";
        #else
                            return Application.dataPath +"/"+"Saved_data.csv";
        #endif
    }

}
