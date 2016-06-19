using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class mybook : MonoBehaviour {

    public Text text;

    public GameObject button;

    private string[][] Array;

    void Start()
    {
        //读取csv二进制文件  
        TextAsset binAsset = Resources.Load("word", typeof(TextAsset)) as TextAsset;

        //读取每一行的内容  
        string[] lineArray = binAsset.text.Split("\r"[0]);

        //创建二维数组  
        Array = new string[lineArray.Length][];

        //把csv中的数据储存在二位数组中  
        for (int i = 0; i < lineArray.Length; i++)
        {
            Array[i] = lineArray[i].Split(',');
        }
    }


    string GetDataByIdAndName(int nId, string strName)
    {
        if (Array.Length <= 0)
            return "";

        int nRow = Array.Length;
        int nCol = Array[0].Length;
        for (int i = 1; i < nRow; ++i)
        {
            string strId = string.Format("\n{0}", nId);
            if (Array[i][0] == strId)
            {
                for (int j = 0; j < nCol; ++j)
                {
                    if (Array[0][j] == strName)
                    {
                        return Array[i][j];
                    }
                }
            }
        }

        return "";
    }

    // Update is called once per frame
    void Update () {
        string txt = GetDataByIdAndName(4, "name");
        print(txt.ToString());
	}
}
