using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class filectrl : MonoBehaviour
{

    public Text text;

    public GameObject button01;

    public Text buttiontext01;

    public GameObject button02;

    public Text buttiontext02;

    public GameObject button03;

    public Scrollbar huagan;

    private string neirong;

    private bool kaiguan = true;

    int hanghao = 1;

    int liehao = 1;

    string _result;
    // Use this for initialization
    void Start()
    {
      //  StartCoroutine(LoadXML());

        
     //   CSV.GetInstance().loadFile(_result, "mybook2.csv");

        //调试用路径
        //CSV.GetInstance().loadFile(Application.dataPath + "/Resources", "mybook2.csv");

        //ios,安卓使用下面路径
        CSV.GetInstance().loadFile(Application.streamingAssetsPath , "/mybook2.csv");

        // print("string" + CSV.GetInstance().getString(2, 2));
        //print("int" + CSV.GetInstance().getInt(1, 4));
        //开启协程
        
    }

    //private IEnumerator LoadXML()
    //{
    //    string sPath = Application.streamingAssetsPath + "/mybook2.csv";

    //    print(sPath);

    //    WWW www = new WWW(sPath);

    //    yield return www;

    //    _result = www.text;
    //    print(_result);
    //}

    // Update is called once per frame
    void Update()
    {
        //if (kaiguan==false)
        //{
        //    StartCoroutine(Test());
        //}


        //if (kaiguan == true)
        //{
        //    panduan();
        //}

    }

    public void starbuttion() {
        button03.SetActive(false);

        StartCoroutine(Test());

        text.text = "开始运行";
    }

    //在文本框显示文章内容
    void readBook(int hanghao, int liehao)
    {

        neirong = CSV.GetInstance().getString(hanghao, liehao);

        float time = CSV.GetInstance().getInt(hanghao, 6);

        print(time);

        new WaitForSeconds(time);

        text.text += neirong + "\n" + "\n";


        //huagan.value = 0;

    }

    //读表判断内容
    void panduan()
    {
        if (CSV.GetInstance().getString(hanghao, liehao) == "")
        {
            liehao = 1;

        }

        if (liehao == 2)
        {
            readBook(hanghao, 1);

            if (CSV.GetInstance().getString(hanghao, liehao) == "over")
            {
                GameOver();
                return;
            }

            anNiu(hanghao, liehao);

            return;
        }


        readBook(hanghao, liehao);

        huagan.value = 0;

        hanghao++;

        liehao++;
        print(CSV.GetInstance().m_arraydata.Count);
        if (hanghao >= CSV.GetInstance().m_arraydata.Count)
        {
            GameOver();
        }
    }

    //按钮显示，取得按钮文字，参数写死
    void anNiu(int hanghao, int liehao)
    {
        kaiguan = false;

        huagan.value = 0;

        button01.SetActive(true);

        button02.SetActive(true);

        buttiontext01.text = CSV.GetInstance().getString(hanghao, liehao); ;

        buttiontext02.text = CSV.GetInstance().getString(hanghao, liehao + 2); ;

    }

    //按钮1 写死参数
    public void bt01Onlick()
    {

        //文本框高度print(text.preferredHeight);

        // 文本框宽度print(text.preferredWidth);


        //取得按钮文字
        string temps = CSV.GetInstance().getString(hanghao, liehao);
        //取得文字宽度，字符串宽度
        double tempnum = (19 - temps.Length) * 0.5;
        //按钮文字输出到文本框
        text.text += jisuankongge(tempnum) +"<color=yellow>"+ temps +"</color>"+ "\n" + "\n";
        //取得跳转行号
        hanghao = CSV.GetInstance().getInt(hanghao, liehao + 1);

        //隐藏按钮
        button01.SetActive(false);
        button02.SetActive(false);
        huagan.value = 0;
        //打开开关
        kaiguan = true;
    }
    //按钮2 写死参数
    public void bt02Onlick()
    {

        string temps = CSV.GetInstance().getString(hanghao, liehao + 2);

        print(temps.Length);


        double tempnum = (19 - temps.Length) * 0.5;

        text.text += jisuankongge(tempnum) + temps + "\n" + "\n";

        hanghao = CSV.GetInstance().getInt(hanghao, liehao + 3);

        // print(hanghao);

        button01.SetActive(false);
        button02.SetActive(false);
        huagan.value = 0;
        kaiguan = true;
    }

    //按钮上的文字居中，按长度加全角空格居中
    string jisuankongge(double cahngdu)
    {
        //全角空格   "　"
        string tempt = "";
        for (int i = 0; i < cahngdu; i++)
        {
            tempt += "　";
        }

        return tempt;
    }

    //协程延迟秒数，代替update
    IEnumerator Test()
    {
        while (true)
        {


            if (kaiguan == true)
            {
                panduan();
            }

            yield return new WaitForSeconds(1.0f);//等待


        }

    }

    void GameOver()
    {
        kaiguan = false;
        text.text += "　　　　　　　　" + "<color=red>本章结束</color>" + "\n" + "\n";
        huagan.value = 0;

    }
}
