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
    public Transform rightHand;
    private List<string[]> rowData = new List<string[]>();
    public String gestureName;
    string[] rowDataTemp;
    //public float limitRecordTime;
    public float recordRateTime;
    
    //string path = @"C:\Users\ivoal\Desktop\gestures.txt";

    public int samples;


    public Transform rightPalm;

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

        //rowDataTemp = new string[91];
        rowDataTemp = new string[16];



        rowDataTemp[0] = "pTHUMB_BONE3_X";
      
        rowDataTemp[1] = "pTHUMB_BONE3_Y";
        rowDataTemp[2] = "pTHUMB_BONE3_Z";
   

        rowDataTemp[3] = "pINDEX_BONE3_X";
      
        rowDataTemp[4] = "pINDEX_BONE3_Y";
    
        rowDataTemp[5] = "pINDEX_BONE3_Z";
     
        rowDataTemp[6] = "pMIDDLE_BONE3_X";
        
        rowDataTemp[7] = "pMIDDLE_BONE3_Y";
        
        rowDataTemp[8] = "pMIDDLE_BONE3_Z";
      


        rowDataTemp[9] = "pRING_BONE3_X";
       
        rowDataTemp[10] = "pRING_BONE3_Y";
     
        rowDataTemp[11] = "pRING_BONE3_Z";
      


        rowDataTemp[12] = "pPINKY_BONE3_X";
      
        rowDataTemp[13] = "pPINKY_BONE3_Y";
      
        rowDataTemp[14] = "pPINKY_BONE3_Z";
       
        rowDataTemp[15] = "target";
        //rowDataTemp[0] = "pTHUMB_BONE3_X";
        //rowDataTemp[1] = "rTHUMB_BONE3_X";
        //rowDataTemp[2] = "pTHUMB_BONE3_Y";
        //rowDataTemp[3] = "rTHUMB_BONE3_Y";
        //rowDataTemp[4] = "pTHUMB_BONE3_Z";
        //rowDataTemp[5] = "rTHUMB_BONE3_Z";

        //rowDataTemp[6] = "pINDEX_BONE3_X";
        //rowDataTemp[7] = "rINDEX_BONE3_X";
        //rowDataTemp[8] = "pINDEX_BONE3_Y";
        //rowDataTemp[9] = "rINDEX_BONE3_Y";
        //rowDataTemp[10] = "pINDEX_BONE3_Z";
        //rowDataTemp[11] = "rINDEX_BONE3_Z";

        //rowDataTemp[12] = "pMIDDLE_BONE3_X";
        //rowDataTemp[13] = "rMIDDLE_BONE3_X";
        //rowDataTemp[14] = "pMIDDLE_BONE3_Y";
        //rowDataTemp[15] = "rMIDDLE_BONE3_Y";
        //rowDataTemp[16] = "pMIDDLE_BONE3_Z";
        //rowDataTemp[17] = "rMIDDLE_BONE3_Z";


        //rowDataTemp[18] = "pRING_BONE3_X";
        //rowDataTemp[19] = "rRING_BONE3_X";
        //rowDataTemp[20] = "pRING_BONE3_Y";
        //rowDataTemp[21] = "rRING_BONE3_Y";
        //rowDataTemp[22] = "pRING_BONE3_Z";
        //rowDataTemp[23] = "rRING_BONE3_Z";


        //rowDataTemp[24] = "pPINKY_BONE3_X";
        //rowDataTemp[25] = "rPINKY_BONE3_X";
        //rowDataTemp[26] = "pPINKY_BONE3_Y";
        //rowDataTemp[27] = "rPINKY_BONE3_Y";
        //rowDataTemp[28] = "pPINKY_BONE3_Z";
        //rowDataTemp[29] = "rPINKY_BONE3_Z";
        //rowDataTemp[30] = "target";


        //rowDataTemp[0] = "pTHUMB_BONE1_X";
        //rowDataTemp[1] = "rTHUMB_BONE1_X";
        //rowDataTemp[2] = "pTHUMB_BONE1_Y";
        //rowDataTemp[3] = "rTHUMB_BONE1_Y";
        //rowDataTemp[4] = "pTHUMB_BONE1_Z";
        //rowDataTemp[5] = "rTHUMB_BONE1_Z";
        //rowDataTemp[6] = "pTHUMB_BONE2_X";
        //rowDataTemp[7] = "rTHUMB_BONE2_X";
        //rowDataTemp[8] = "pTHUMB_BONE2_Y";
        //rowDataTemp[9] = "rTHUMB_BONE2_Y";
        //rowDataTemp[10] = "pTHUMB_BONE2_Z";
        //rowDataTemp[11] = "rTHUMB_BONE2_Z";
        //rowDataTemp[12] = "pTHUMB_BONE3_X";
        //rowDataTemp[13] = "rTHUMB_BONE3_X";
        //rowDataTemp[14] = "pTHUMB_BONE3_Y";
        //rowDataTemp[15] = "rTHUMB_BONE3_Y";
        //rowDataTemp[16] = "pTHUMB_BONE3_Z";
        //rowDataTemp[17] = "rTHUMB_BONE3_Z";

        //rowDataTemp[18] = "pINDEX_BONE1_X";
        //rowDataTemp[19] = "rINDEX_BONE1_X";
        //rowDataTemp[20] = "pINDEX_BONE1_Y";
        //rowDataTemp[21] = "rINDEX_BONE1_Y";
        //rowDataTemp[22] = "pINDEX_BONE1_Z";
        //rowDataTemp[23] = "rINDEX_BONE1_Z";
        //rowDataTemp[24] = "pINDEX_BONE2_X";
        //rowDataTemp[25] = "rINDEX_BONE2_X";
        //rowDataTemp[26] = "pINDEX_BONE2_Y";
        //rowDataTemp[27] = "rINDEX_BONE2_Y";
        //rowDataTemp[28] = "pINDEX_BONE2_Z";
        //rowDataTemp[29] = "rINDEX_BONE2_Z";
        //rowDataTemp[30] = "pINDEX_BONE3_X";
        //rowDataTemp[31] = "rINDEX_BONE3_X";
        //rowDataTemp[32] = "pINDEX_BONE3_Y";
        //rowDataTemp[33] = "rINDEX_BONE3_Y";
        //rowDataTemp[34] = "pINDEX_BONE3_Z";
        //rowDataTemp[35] = "rINDEX_BONE3_Z";

        //rowDataTemp[36] = "pMIDDLE_BONE1_X";
        //rowDataTemp[37] = "rMIDDLE_BONE1_X";
        //rowDataTemp[38] = "pMIDDLE_BONE1_Y";
        //rowDataTemp[39] = "rMIDDLE_BONE1_Y";
        //rowDataTemp[40] = "pMIDDLE_BONE1_Z";
        //rowDataTemp[41] = "rMIDDLE_BONE1_Z";
        //rowDataTemp[42] = "pMIDDLE_BONE2_X";
        //rowDataTemp[43] = "rMIDDLE_BONE2_X";
        //rowDataTemp[44] = "pMIDDLE_BONE2_Y";
        //rowDataTemp[45] = "rMIDDLE_BONE2_Y";
        //rowDataTemp[46] = "pMIDDLE_BONE2_Z";
        //rowDataTemp[47] = "rMIDDLE_BONE2_Z";
        //rowDataTemp[48] = "pMIDDLE_BONE3_X";
        //rowDataTemp[49] = "rMIDDLE_BONE3_X";
        //rowDataTemp[50] = "pMIDDLE_BONE3_Y";
        //rowDataTemp[51] = "rMIDDLE_BONE3_Y";
        //rowDataTemp[52] = "pMIDDLE_BONE3_Z";
        //rowDataTemp[53] = "rMIDDLE_BONE3_Z";

        //rowDataTemp[54] = "pRING_BONE1_X";
        //rowDataTemp[55] = "rRING_BONE1_X";
        //rowDataTemp[56] = "pRING_BONE1_Y";
        //rowDataTemp[57] = "rRING_BONE1_Y";
        //rowDataTemp[58] = "pRING_BONE1_Z";
        //rowDataTemp[59] = "rRING_BONE1_Z";
        //rowDataTemp[60] = "pRING_BONE2_X";
        //rowDataTemp[61] = "rRING_BONE2_X";
        //rowDataTemp[62] = "pRING_BONE2_Y";
        //rowDataTemp[63] = "rRING_BONE2_Y";
        //rowDataTemp[64] = "pRING_BONE2_Z";
        //rowDataTemp[65] = "rRING_BONE2_Z";
        //rowDataTemp[66] = "pRING_BONE3_X";
        //rowDataTemp[67] = "rRING_BONE3_X";
        //rowDataTemp[68] = "pRING_BONE3_Y";
        //rowDataTemp[69] = "rRING_BONE3_Y";
        //rowDataTemp[70] = "pRING_BONE3_Z";
        //rowDataTemp[71] = "rRING_BONE3_Z";

        //rowDataTemp[72] = "pPINKY_BONE1_X";
        //rowDataTemp[73] = "rPINKY_BONE1_X";
        //rowDataTemp[74] = "pPINKY_BONE1_Y";
        //rowDataTemp[75] = "rPINKY_BONE1_Y";
        //rowDataTemp[76] = "pPINKY_BONE1_Z";
        //rowDataTemp[77] = "rPINKY_BONE1_Z";
        //rowDataTemp[78] = "pPINKY_BONE2_X";
        //rowDataTemp[79] = "rPINKY_BONE2_X";
        //rowDataTemp[80] = "pPINKY_BONE2_Y";
        //rowDataTemp[81] = "rPINKY_BONE2_Y";
        //rowDataTemp[82] = "pPINKY_BONE2_Z";
        //rowDataTemp[83] = "rPINKY_BONE2_Z";
        //rowDataTemp[84] = "pPINKY_BONE3_X";
        //rowDataTemp[85] = "rPINKY_BONE3_X";
        //rowDataTemp[86] = "pPINKY_BONE3_Y";
        //rowDataTemp[87] = "rPINKY_BONE3_Y";
        //rowDataTemp[88] = "pPINKY_BONE3_Z";
        //rowDataTemp[89] = "rPINKY_BONE3_Z";
        //rowDataTemp[90] = "target";

        rowData.Add(rowDataTemp);
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
        for (int i = samples; i >= 0; i--)
        {
            GetValues();
            yield return new WaitForSeconds(recordRateTime);
        }
        Debug.Log(gestureName + " finished Recording.");
        EditorApplication.isPlaying = false;

    }

    public void GetValues()
    {  
        rowDataTemp = new string[16];
        int y = 0;
        for (int finger = 0; finger < 5; finger++)  //5 fingers
        {
            //for (int bone = 0; bone < 3; bone++)
            int bone = 2;
            {
                for (int axis = 0; axis < 3; axis++)    //3 axis (X,y,z) position.
                {
                    rowDataTemp[y] = "" + (rightHand.transform.GetChild(finger).GetChild(bone).position[axis] - rightPalm.transform.position[axis]) ;
                   
                    y++;
                    //rowDataTemp[y] = "" + rightHand.transform.GetChild(finger).GetChild(bone).eulerAngles[axis] ;
                    
                    //y++;
                }
                
            }
        }


        rowDataTemp[y] = "" + gestureName;
        rowData.Add(rowDataTemp);

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = "," ;

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();


    }

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
        #if UNITY_EDITOR
                //return Application.dataPath + "/CSV/" + "Saved_data.csv";
                return @"C:\Users\ivoal\github\PythonML\gestures\gesture" + gestureName+".txt";
#elif UNITY_ANDROID
                    return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
                    return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
                    return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }

}
