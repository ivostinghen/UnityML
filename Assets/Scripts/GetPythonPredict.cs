using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class GetPythonPredict : MonoBehaviour {

    string filePython = @"C:\Users\ivoal\Documents\GitHub\Machine-Learning-Gesture-Recognition\communication\python.txt";

    public TextMesh textMesh;

    int cont = 0;
    String line = "";
    String lastAcess = "";
    
    String result = "";

    public PowerController powerController;
    public Transform rightPalm;
    
    IEnumerator Start()
    {
        


        while (true)
        {
            try
            {
                result = File.ReadAllText(filePython);

                if (result.Substring(0, 4).Equals("OPEN"))
                {
                    //print(result);
                    textMesh.text = result;
                    powerController.currentGesture = result.Substring(0, 4);
                  

                }
                else if (result.Substring(0, 5).Equals("CLOSE"))
                {
                    //print(result);
                 
                    powerController.currentGesture = result.Substring(0, 5);

                    textMesh.text = result;

                }


            }
            catch (Exception )
            {
                Debug.Log("Erro ao ler arquivo. Possivelmente arquivo .txt sendo usado por 2 programas ao mesmo tempo.");
            }
           
            yield return new WaitForSeconds(.5F);
        }
    }


}

