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


    //string values = "[ ";
    //foreach (Transform finger in hand)
    //{
    //    values = values + finger.position + ", ";
    //}
    //values = values.Remove(values.Length - 2, 1);
    //values = values + "]";
    //return values;




    void Awake()
    {
        //GameObject countTxt = Instantiate(Resources.Load("CountTxt") as GameObject);
        //beginRecordTxt  =  countTxt.GetComponentInChildren<Text>();

        //rawDataTemp = new string[91];
        //rawDataTemp = new string[16];
        // rawDataTemp = new string[20];
        rawDataTemp = "";
        //rawDataTemp = new string[31];

        // rawDataTemp[0] = "pTHUMB_BONE3_X";
        // rawDataTemp[1] = "pTHUMB_BONE3_Y";
        // rawDataTemp[2] = "pTHUMB_BONE3_Z";

        // rawDataTemp[3] = "pINDEX_BONE3_X";
        // rawDataTemp[4] = "pINDEX_BONE3_Y";
        // rawDataTemp[5] = "pINDEX_BONE3_Z";

        // rawDataTemp[6] = "pMIDDLE_BONE3_X";
        // rawDataTemp[7] = "pMIDDLE_BONE3_Y";
        // rawDataTemp[8] = "pMIDDLE_BONE3_Z";

        // rawDataTemp[9] = "pRING_BONE3_X";
        // rawDataTemp[10] = "pRING_BONE3_Y";
        // rawDataTemp[11] = "pRING_BONE3_Z";

        // rawDataTemp[12] = "pPINKY_BONE3_X";
        // rawDataTemp[13] = "pPINKY_BONE3_Y";
        // rawDataTemp[14] = "pPINKY_BONE3_Z";


        //rawDataTemp = "THUMB_INDEX_ANGLE,THUMB_DIST,INDEX_MIDDLE_ANGLE,INDEX_DIST,MIDDLE_RING_ANGLE,MIDDLE_DIST,RING_PINKY_ANGLE,RING_DIST,PINKY_DIST,target";
        rawDataTemp = "THUMB_POS_X,THUMB_POS_Y,THUMB_POS_Z,INDEX_POS_X,INDEX_POS_Y,INDEX_POS_Z,MIDDLE_POS_X,MIDDLE_POS_Y,MIDDLE_POS_Z,RING_POS_X,RING_POS_Y,RING_POS_Z,PINKY_POS_X,PINKY_POS_Y,PINKY_POS_Z";
        // rawDataTemp = "THUMB_INDEX_ANGLE,INDEX_MIDDLE_ANGLE,MIDDLE_RING_ANGLE,RING_PINKY_ANGLE,target";


        string filePath = getPath();

       
        File.AppendAllText(filePath, 
                   rawDataTemp + Environment.NewLine);
       
        rawDataTemp = "";



        // rawDataTemp[9] = "target";
        //rawDataTemp[0] = "(pTHUMB_BONE3_X";
        //rawDataTemp[1] = "pTHUMB_BONE3_Y";
        //rawDataTemp[2] = "pTHUMB_BONE3_Z)";

        //rawDataTemp[3] = "(pINDEX_BONE3_X";
        //rawDataTemp[4] = "pINDEX_BONE3_Y";
        //rawDataTemp[5] = "pINDEX_BONE3_Z)";

        //rawDataTemp[6] = "(pMIDDLE_BONE3_X";
        //rawDataTemp[7] = "pMIDDLE_BONE3_Y";
        //rawDataTemp[8] = "pMIDDLE_BONE3_Z)";

        //rawDataTemp[9] = "(pRING_BONE3_X";
        //rawDataTemp[10] = "pRING_BONE3_Y";
        //rawDataTemp[11] = "pRING_BONE3_Z)";

        //rawDataTemp[12] = "(pPINKY_BONE3_X";
        //rawDataTemp[13] = "pPINKY_BONE3_Y";
        //rawDataTemp[14] = "pPINKY_BONE3_Z)";
        //rawDataTemp[15] = "target";




        //rawDataTemp[0] = "pTHUMB_BONE3_X";

        //rawDataTemp[1] = "pTHUMB_BONE3_Y";
        //rawDataTemp[2] = "pTHUMB_BONE3_Z";


        //rawDataTemp[3] = "pINDEX_BONE3_X";

        //rawDataTemp[4] = "pINDEX_BONE3_Y";

        //rawDataTemp[5] = "pINDEX_BONE3_Z";

        //rawDataTemp[6] = "pMIDDLE_BONE3_X";

        //rawDataTemp[7] = "pMIDDLE_BONE3_Y";

        //rawDataTemp[8] = "pMIDDLE_BONE3_Z";



        //rawDataTemp[9] = "pRING_BONE3_X";

        //rawDataTemp[10] = "pRING_BONE3_Y";

        //rawDataTemp[11] = "pRING_BONE3_Z";



        //rawDataTemp[12] = "pPINKY_BONE3_X";

        //rawDataTemp[13] = "pPINKY_BONE3_Y";

        //rawDataTemp[14] = "pPINKY_BONE3_Z";



        //rawDataTemp[15] = "right_pTHUMB_BONE3_X";

        //rawDataTemp[16] = "right_pTHUMB_BONE3_Y";
        //rawDataTemp[17] = "right_pTHUMB_BONE3_Z";


        //rawDataTemp[18] = "right_pINDEX_BONE3_X";

        //rawDataTemp[19] = "right_pINDEX_BONE3_Y";

        //rawDataTemp[20] = "right_pINDEX_BONE3_Z";

        //rawDataTemp[21] = "right_pMIDDLE_BONE3_X";

        //rawDataTemp[22] = "right_pMIDDLE_BONE3_Y";

        //rawDataTemp[23] = "right_pMIDDLE_BONE3_Z";



        //rawDataTemp[24] = "right_pRING_BONE3_X";

        //rawDataTemp[25] = "right_pRING_BONE3_Y";

        //rawDataTemp[26] = "right_pRING_BONE3_Z";



        //rawDataTemp[27] = "right_pPINKY_BONE3_X";

        //rawDataTemp[28] = "right_pPINKY_BONE3_Y";

        //rawDataTemp[29] = "right_pPINKY_BONE3_Z";

        //rawDataTemp[30] = "target";






        //rawDataTemp[0] = "pTHUMB_BONE3_X";
        //rawDataTemp[1] = "rTHUMB_BONE3_X";
        //rawDataTemp[2] = "pTHUMB_BONE3_Y";
        //rawDataTemp[3] = "rTHUMB_BONE3_Y";
        //rawDataTemp[4] = "pTHUMB_BONE3_Z";
        //rawDataTemp[5] = "rTHUMB_BONE3_Z";

        //rawDataTemp[6] = "pINDEX_BONE3_X";
        //rawDataTemp[7] = "rINDEX_BONE3_X";
        //rawDataTemp[8] = "pINDEX_BONE3_Y";
        //rawDataTemp[9] = "rINDEX_BONE3_Y";
        //rawDataTemp[10] = "pINDEX_BONE3_Z";
        //rawDataTemp[11] = "rINDEX_BONE3_Z";

        //rawDataTemp[12] = "pMIDDLE_BONE3_X";
        //rawDataTemp[13] = "rMIDDLE_BONE3_X";
        //rawDataTemp[14] = "pMIDDLE_BONE3_Y";
        //rawDataTemp[15] = "rMIDDLE_BONE3_Y";
        //rawDataTemp[16] = "pMIDDLE_BONE3_Z";
        //rawDataTemp[17] = "rMIDDLE_BONE3_Z";


        //rawDataTemp[18] = "pRING_BONE3_X";
        //rawDataTemp[19] = "rRING_BONE3_X";
        //rawDataTemp[20] = "pRING_BONE3_Y";
        //rawDataTemp[21] = "rRING_BONE3_Y";
        //rawDataTemp[22] = "pRING_BONE3_Z";
        //rawDataTemp[23] = "rRING_BONE3_Z";


        //rawDataTemp[24] = "pPINKY_BONE3_X";
        //rawDataTemp[25] = "rPINKY_BONE3_X";
        //rawDataTemp[26] = "pPINKY_BONE3_Y";
        //rawDataTemp[27] = "rPINKY_BONE3_Y";
        //rawDataTemp[28] = "pPINKY_BONE3_Z";
        //rawDataTemp[29] = "rPINKY_BONE3_Z";
        //rawDataTemp[30] = "target";


        //rawDataTemp[0] = "pTHUMB_BONE1_X";
        //rawDataTemp[1] = "rTHUMB_BONE1_X";
        //rawDataTemp[2] = "pTHUMB_BONE1_Y";
        //rawDataTemp[3] = "rTHUMB_BONE1_Y";
        //rawDataTemp[4] = "pTHUMB_BONE1_Z";
        //rawDataTemp[5] = "rTHUMB_BONE1_Z";
        //rawDataTemp[6] = "pTHUMB_BONE2_X";
        //rawDataTemp[7] = "rTHUMB_BONE2_X";
        //rawDataTemp[8] = "pTHUMB_BONE2_Y";
        //rawDataTemp[9] = "rTHUMB_BONE2_Y";
        //rawDataTemp[10] = "pTHUMB_BONE2_Z";
        //rawDataTemp[11] = "rTHUMB_BONE2_Z";
        //rawDataTemp[12] = "pTHUMB_BONE3_X";
        //rawDataTemp[13] = "rTHUMB_BONE3_X";
        //rawDataTemp[14] = "pTHUMB_BONE3_Y";
        //rawDataTemp[15] = "rTHUMB_BONE3_Y";
        //rawDataTemp[16] = "pTHUMB_BONE3_Z";
        //rawDataTemp[17] = "rTHUMB_BONE3_Z";

        //rawDataTemp[18] = "pINDEX_BONE1_X";
        //rawDataTemp[19] = "rINDEX_BONE1_X";
        //rawDataTemp[20] = "pINDEX_BONE1_Y";
        //rawDataTemp[21] = "rINDEX_BONE1_Y";
        //rawDataTemp[22] = "pINDEX_BONE1_Z";
        //rawDataTemp[23] = "rINDEX_BONE1_Z";
        //rawDataTemp[24] = "pINDEX_BONE2_X";
        //rawDataTemp[25] = "rINDEX_BONE2_X";
        //rawDataTemp[26] = "pINDEX_BONE2_Y";
        //rawDataTemp[27] = "rINDEX_BONE2_Y";
        //rawDataTemp[28] = "pINDEX_BONE2_Z";
        //rawDataTemp[29] = "rINDEX_BONE2_Z";
        //rawDataTemp[30] = "pINDEX_BONE3_X";
        //rawDataTemp[31] = "rINDEX_BONE3_X";
        //rawDataTemp[32] = "pINDEX_BONE3_Y";
        //rawDataTemp[33] = "rINDEX_BONE3_Y";
        //rawDataTemp[34] = "pINDEX_BONE3_Z";
        //rawDataTemp[35] = "rINDEX_BONE3_Z";

        //rawDataTemp[36] = "pMIDDLE_BONE1_X";
        //rawDataTemp[37] = "rMIDDLE_BONE1_X";
        //rawDataTemp[38] = "pMIDDLE_BONE1_Y";
        //rawDataTemp[39] = "rMIDDLE_BONE1_Y";
        //rawDataTemp[40] = "pMIDDLE_BONE1_Z";
        //rawDataTemp[41] = "rMIDDLE_BONE1_Z";
        //rawDataTemp[42] = "pMIDDLE_BONE2_X";
        //rawDataTemp[43] = "rMIDDLE_BONE2_X";
        //rawDataTemp[44] = "pMIDDLE_BONE2_Y";
        //rawDataTemp[45] = "rMIDDLE_BONE2_Y";
        //rawDataTemp[46] = "pMIDDLE_BONE2_Z";
        //rawDataTemp[47] = "rMIDDLE_BONE2_Z";
        //rawDataTemp[48] = "pMIDDLE_BONE3_X";
        //rawDataTemp[49] = "rMIDDLE_BONE3_X";
        //rawDataTemp[50] = "pMIDDLE_BONE3_Y";
        //rawDataTemp[51] = "rMIDDLE_BONE3_Y";
        //rawDataTemp[52] = "pMIDDLE_BONE3_Z";
        //rawDataTemp[53] = "rMIDDLE_BONE3_Z";

        //rawDataTemp[54] = "pRING_BONE1_X";
        //rawDataTemp[55] = "rRING_BONE1_X";
        //rawDataTemp[56] = "pRING_BONE1_Y";
        //rawDataTemp[57] = "rRING_BONE1_Y";
        //rawDataTemp[58] = "pRING_BONE1_Z";
        //rawDataTemp[59] = "rRING_BONE1_Z";
        //rawDataTemp[60] = "pRING_BONE2_X";
        //rawDataTemp[61] = "rRING_BONE2_X";
        //rawDataTemp[62] = "pRING_BONE2_Y";
        //rawDataTemp[63] = "rRING_BONE2_Y";
        //rawDataTemp[64] = "pRING_BONE2_Z";
        //rawDataTemp[65] = "rRING_BONE2_Z";
        //rawDataTemp[66] = "pRING_BONE3_X";
        //rawDataTemp[67] = "rRING_BONE3_X";
        //rawDataTemp[68] = "pRING_BONE3_Y";
        //rawDataTemp[69] = "rRING_BONE3_Y";
        //rawDataTemp[70] = "pRING_BONE3_Z";
        //rawDataTemp[71] = "rRING_BONE3_Z";

        //rawDataTemp[72] = "pPINKY_BONE1_X";
        //rawDataTemp[73] = "rPINKY_BONE1_X";
        //rawDataTemp[74] = "pPINKY_BONE1_Y";
        //rawDataTemp[75] = "rPINKY_BONE1_Y";
        //rawDataTemp[76] = "pPINKY_BONE1_Z";
        //rawDataTemp[77] = "rPINKY_BONE1_Z";
        //rawDataTemp[78] = "pPINKY_BONE2_X";
        //rawDataTemp[79] = "rPINKY_BONE2_X";
        //rawDataTemp[80] = "pPINKY_BONE2_Y";
        //rawDataTemp[81] = "rPINKY_BONE2_Y";
        //rawDataTemp[82] = "pPINKY_BONE2_Z";
        //rawDataTemp[83] = "rPINKY_BONE2_Z";
        //rawDataTemp[84] = "pPINKY_BONE3_X";
        //rawDataTemp[85] = "rPINKY_BONE3_X";
        //rawDataTemp[86] = "pPINKY_BONE3_Y";
        //rawDataTemp[87] = "rPINKY_BONE3_Y";
        //rawDataTemp[88] = "pPINKY_BONE3_Z";
        //rawDataTemp[89] = "rPINKY_BONE3_Z";
        //rawDataTemp[90] = "target";

        // rowData.Add(rawDataTemp);
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
        //rawDataTemp = new string[31];
        // rawDataTemp = new string[16];
        // rawDataTemp = new string[20]; //15positions + 4 angles + class(target)
        // rawDataTemp = new string[10];
        int y = 0;

        //ALREADY TESTED
        //////// float normalDist = Vector3.Distance(rightPalm.transform.position, rightHand.transform.GetChild(2).GetChild(2).position); // dedo medio
        float normalDist = 0.1257631F; // the maximum distance betwween middle finger and the hand middle point.
                                       ////////

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

        //add rotation normalized



        // for (int finger = 0; finger < 4; finger++)  //5 fingers
        // {

        //    {

        //        float c = Vector3.Distance(fingers[finger].position, fingers[finger + 1].position);
        //        float a = Vector3.Distance(fingers[finger + 1].position, rightPalm.transform.position);
        //        float b = Vector3.Distance(fingers[finger].position, rightPalm.transform.position);


        //        float cosTheta = 0;

        //        //c^2 = a^2 + b^2 – 2·a·b·cosα
        //        // = a^2 + b^2 – 2·a·b·cosα - c^2
        //        //2·a·b·cosα  = a^2 + b^2 - c^2
        //        //cosα  = a^2 + b^2 - c^2 / 2·a·b

        //        cosTheta = ((a * a) + (b * b) - (c * c)) / (2 * a * b);

        //        float theta = Mathf.Acos(cosTheta);
        //        theta = theta * Mathf.Rad2Deg;

        //        // if (finger == 0) print(theta);


        //        // if(finger==0)  Debug.Log("theta  " + theta);



        //        //if (finger == 0)
        //        //{
        //        //    rawDataTemp = rawDataTemp + c + ",";
        //        //}
        //        rawDataTemp = rawDataTemp + theta + ",";


        //        //if (finger == 3)
        //        //{
        //        //    rawDataTemp = rawDataTemp + a + ",";
        //        //}


        //        //y++;

        //    }
        // }

        //POSIÇÕES DOS DEDOS
        for (int finger = 0; finger < 5; finger++)  //5 fingers
        {

            

           Vector3 localPos =  fingers[finger].transform.position - rightPalm.transform.position;
           for (int i = 0; i < 3; i++)
           {

               rawDataTemp = rawDataTemp + localPos[i]  + ",";
           }

        }







        ////left hand
        //for (int finger = 0; finger < 5; finger++)  //5 fingers
        //{
        //    //for (int bone = 0; bone < 3; bone++)
        //    int bone = 2;
        //    {
        //        for (int axis = 0; axis < 3; axis++)    //3 axis (X,y,z) position.
        //        {
        //            rawDataTemp[y] = "" + (leftHand.transform.GetChild(finger).GetChild(bone).position[axis] - leftPalm.transform.position[axis]);

        //            y++;
        //            //rawDataTemp[y] = "" + rightHand.transform.GetChild(finger).GetChild(bone).eulerAngles[axis] ;
        //            //y++;
        //        }

        //    }
        //}


        rawDataTemp = rawDataTemp + gestureName;
        // rowData.Add(rawDataTemp);

        // string[][] output = new string[rowData.Count][];

        // for (int i = 0; i < output.Length; i++)
        // {
        //     output[i] = rowData[i];
        // }

        // int length = output.GetLength(0);
        // string delimiter = "," ;

        // StringBuilder sb = new StringBuilder();

        // for (int index = 0; index < length; index++)
        //     sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        // StreamWriter outStream = System.IO.File.CreateText(filePath);
        // File.AppendAllText(filePath, rawDataTemp);
        File.AppendAllText(filePath, 
                   rawDataTemp + Environment.NewLine);
        // outStream.WriteLine(sb);
        // outStream.WriteLine("\n");
        // outStream.WriteLine(rawDataTemp);
        rawDataTemp = "";
        // outStream.Close();


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
