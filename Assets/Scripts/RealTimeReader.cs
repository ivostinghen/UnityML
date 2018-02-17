// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Text;
// using System.IO;
// using System;

// using UnityEngine.UI;
// public class RealTimeReader : MonoBehaviour
// {
   
//     public Transform rightHand;

//     private List<string[]> rowData = new List<string[]>();
  
//     string[] rowDataTemp;
//     //public float limitRecordTime;
//     public float recordRateTime;
//     //string path = @"C:\Users\ivoal\Desktop\gestures.txt";
//     public int samples;
//     public Text beginRecordTxt;



//     private void Start()
//     {
//         StartCoroutine(WaitForStart());

//     }

//     IEnumerator WaitForStart()
//     {
//         //while (!Input.GetKeyDown(KeyCode.Return))
//         //{
//         //    yield return new WaitForSeconds(.02F);
//         //}
//         yield return new WaitForSeconds(1);
//         beginRecordTxt.text = "2";
//         yield return new WaitForSeconds(1);
//         beginRecordTxt.text = "1";
//         yield return new WaitForSeconds(1);
//         beginRecordTxt.text = "0";
//         yield return new WaitForSeconds(.5F);
//         beginRecordTxt.enabled = false;
//         StartCoroutine(RecordHandPos());
//     }

//     IEnumerator RecordHandPos()
//     {

//         for (int i = 0; i < samples; i++)
//         {
//             GetValues();
//             yield return new WaitForSeconds(recordRateTime);
//         }
//         //EditorApplication.isPlaying = false;
//     }

//     public void GetValues()
//     {

//         string raw = "";
        
       
//         for (int finger = 0; finger < 5; finger++)  //5 fingers
//         {
//             for (int bone = 0; bone < 3; bone++)
//             {
//                 for (int axis = 0; axis < 3; axis++)    //3 axis (X,y,z) position.
//                 {
//                     raw = raw + rightHand.transform.GetChild(finger).GetChild(bone).position[axis] + ",";
//                     raw = raw + rightHand.transform.GetChild(finger).GetChild(bone).rotation[axis] + ",";
//                 }
//             }
//         }
        

//         raw = raw.Substring(0, raw.Length - 1);

//         string filePath = getPath();
//         StreamWriter outStream = System.IO.File.CreateText(filePath);
//         outStream.WriteLine(raw);
//         outStream.Close();

//         Debug.Log("Gesture Sended!");
//     }





//     private string getPath()
//     {
// #if UNITY_EDITOR
//         //return Application.dataPath + "/CSV/" + "Saved_data.csv";
//         return @"C:\Users\ivoal\Documents\GitHub\Machine-Learning-Gesture-Recognition\input.txt";
// #elif UNITY_ANDROID
//                     return Application.persistentDataPath+"Saved_data.csv";
// #elif UNITY_IPHONE
//                     return Application.persistentDataPath+"/"+"Saved_data.csv";
// #else
//                     return Application.dataPath +"/"+"Saved_data.csv";
// #endif
//     }

// }
