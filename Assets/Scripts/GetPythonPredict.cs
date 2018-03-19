﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class GetPythonPredict : MonoBehaviour {

    string filePython = @"C:\Users\ivoal\git\pythonML\communication\python.txt";

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
                result = result.Trim();
                // if (result.Equals("ZERO") ||result.Equals("ONE") || result.Equals("TWO") || result.Equals("THREE") || result.Equals("FOUR") || result.Equals("FIVE") || result.Equals("OPEN") || result.Equals("CLOSE") || result.Equals("ET") || result.Equals("THUMB") || result.Equals("GRAB") || result.Equals("COOL") ) 
                {
                    powerController.currentGesture = result;
                    textMesh.text = result;
                }

            }
            catch (Exception )
            {
                //Debug.Log("Erro ao ler arquivo. Possivelmente arquivo .txt sendo usado por 2 programas ao mesmo tempo.");
            }
           
            yield return new WaitForSeconds(.5F);
        }
    }


}

