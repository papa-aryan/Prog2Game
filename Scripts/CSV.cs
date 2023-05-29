using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Unity.VisualScripting;

public class CSV : MonoBehaviour
{
    string filename = "";
    private int testScore;
    public TextAsset textAssetData;

    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/test.csv";
        readCSV();
    }

    // Update is called once per frame
    void Update()
    {
        //för att testa
        if (Input.GetKeyDown(KeyCode.O))
        {
            writeCSV();
        }
    }

    public void importCoins(int coins)
    {
        testScore = coins;
        print(testScore);
    }

    public void writeCSV()
    {
        if(testScore > 0)
        {
            print("running writeCSV");
            // false så den från början ska delete allt och overrite
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("Score");
            
            tw.Close();

            tw = new StreamWriter(filename, true);
            tw.Write(testScore.ToString());
            tw.Close();
        }
    }

    public void readCSV()
    {
        StreamReader sr = new StreamReader("Assets/test.csv");
        bool endOfFile = false;
        while(!endOfFile)
        {
            string dataString = sr.ReadLine();
            if (dataString == null)
            {
                endOfFile = true;
                break;
            }
            var dataValues = dataString.Split(",");

            Debug.Log(dataValues[0].ToString());
            /*
            for (int i = 0; i < dataValues.Length; i++)
            {
                Debug.Log("value: " + i.ToString() + " " + dataValues[i].ToString());
            }
            */
        }
    }

}
