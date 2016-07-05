using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CSV
{

    static CSV csv;

    public List<string[]> m_arraydata;

    public static CSV GetInstance()
    {
        if (csv == null)
        {
            csv = new CSV();
        }
        return csv;
    }

    private CSV() { m_arraydata = new List<string[]>(); }

    public string getString(int row, int col)
    {
        return m_arraydata[row][col];
    }

    public int getInt(int row, int col)
    {
        return int.Parse(m_arraydata[row][col]);
    }


    //public void loadFile(string path, string fileName)
    //{
    //    m_arraydata.Clear();
    //    StreamReader sr = null;
    //    try
    //    {
    //        sr = File.OpenText(path + "//" + fileName);
    //    }
    //    catch
    //    {
    //        return;
    //    }
    //    string line;
    //    while ((line = sr.ReadLine()) != null)
    //    {//按，分列
    //        m_arraydata.Add(line.Split(','));
    //    }
    //    sr.Close();
    //    sr.Dispose();

    //}
     string LoadFile(string fileName)
    {//读取静态路径方式
        string url = Application.streamingAssetsPath + "/" + fileName;
        //预制条件判断
#if UNITY_EDITOR
        //读取文件内容
        return File.ReadAllText(url);

#elif UNITY_ANDROID
        //www方式读取
    WWW www = new WWW(url);
    while (!www.isDone) { }
    return www.text;
        //return url;
#endif
    }
    public void readtest(string name){
        string temp = LoadFile(name);

        string yihang = "";
        foreach (var item in temp)
        {

            yihang += item.ToString();
            if (item == '\n')
            {
                //print(yihang);
                // testlist.Add(yihang.Split(','));
                m_arraydata.Add(yihang.Split(','));
                yihang = "";
            }

        }
    
    }




}
