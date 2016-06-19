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


    public void loadFile(string path, string fileName)
    {
        m_arraydata.Clear();
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "//" + fileName);
        }
        catch
        {
            return;
        }
        string line;
        while ((line = sr.ReadLine()) != null)
        {//按，分列
            m_arraydata.Add(line.Split(','));
        }
        sr.Close();
        sr.Dispose();

    }

}
