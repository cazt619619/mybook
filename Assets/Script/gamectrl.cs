using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class gamectrl : MonoBehaviour
{

    public GameObject wordtext;

    public GameObject image;

    public GameObject buttontext;

    public GameObject kuang;

    public GameObject button04;

    Vector3 chushengdian = new Vector3(0, 0, 0);

    public GameObject husantext;

    float Ynum;

    float jichu;
    /// <summary>
    /// 原来的参数
    /// </summary>
    /// 
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

    

    // Use this for initialization
    void Start()
    {
        string FileName = "mybook2.csv";

        CSV.GetInstance().readtest(FileName);
        //CSV.GetInstance().loadFile(Application.streamingAssetsPath, "/mybook2.csv");

        ///基准高度
        GameObject temp = Instantiate(wordtext, chushengdian, Quaternion.identity) as GameObject;
        temp.GetComponent<Text>().text = "你好！";
        jichu = temp.GetComponent<Text>().preferredHeight;
        Destroy(temp);

       // print(jichu);
    }


    public void starbuttion()
    {
        button03.SetActive(false);
        //开启线程计时
       // float time = CSV.GetInstance().getInt(hanghao, 6);

        StartCoroutine(Test());

        // text.text = "开始运行";
    }

    //协程延迟秒数，代替update
    IEnumerator Test()
    {
        while (true)
        {
            if (kaiguan == true)
            {
                print("huagan = " + huagan.value);
                panduan();

                
            }
           
            yield return new WaitForSeconds(CSV.GetInstance().getInt(hanghao, 6));//等待时间
            //print("husanhusan");

            
        }
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
            wrtieBook(hanghao, 1);

            if (CSV.GetInstance().getString(hanghao, liehao) == "over")
            {
                GameOver();
                return;
            }

            anNiu(hanghao, liehao);

            return;
        }


        wrtieBook(hanghao, liehao);

        huagan.value = 0;

        hanghao++;

        liehao++;

        //print(CSV.GetInstance().m_arraydata.Count);

        if (hanghao >= CSV.GetInstance().m_arraydata.Count)
        {
            GameOver();
        }
    }

    //在文本框显示文章内容
    void wrtieBook(int hanghao, int liehao)
    {
        //引用内容
        neirong = CSV.GetInstance().getString(hanghao, liehao)+"\n";
        //找到目录
        Transform p1 = GameObject.Find("Content").transform;
        //实列化text
        GameObject temp = Instantiate(wordtext, chushengdian, Quaternion.identity) as GameObject;
        //放入内容
        temp.GetComponent<Text>().text = neirong;

        // print(temp.GetComponent<Text>().preferredHeight);

        //高度叠加为下移坐标
        Ynum += temp.GetComponent<Text>().preferredHeight;
        //print(Ynum);
        //POSx，y坐标赋值
        Vector2 tempzb = new Vector3(330, -Ynum);
        //下拉框高度增加
        kuang.GetComponent<RectTransform>().sizeDelta = new Vector2(184f, Ynum + 20);
        //放入目标下
        temp.transform.SetParent(p1);

       
        temp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        //判断文本框几行
        if (temp.GetComponent<Text>().preferredHeight > jichu)
        {
            //ynum-(hight/14-1)*14/2计算等差高度
            tempzb = new Vector3(330, -(Ynum - (temp.GetComponent<Text>().preferredHeight / jichu - 1) * jichu / 2), 0);
            temp.GetComponent<RectTransform>().anchoredPosition = tempzb;
        }
        else
        {
            //RectTransform下POS X,Y坐标值
            temp.GetComponent<RectTransform>().anchoredPosition = tempzb;
        }

        huagan.value = 0;
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
        //取得按钮文字
        string temps = CSV.GetInstance().getString(hanghao, liehao);

        //按钮文字输出到文本框
        //text.text += jisuankongge(tempnum) + "<color=yellow>" + temps + "</color>" + "\n" + "\n";
        buttonWriteText(temps);

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

        buttonWriteText(temps);

        hanghao = CSV.GetInstance().getInt(hanghao, liehao + 3);

        // print(hanghao);

        button01.SetActive(false);
        button02.SetActive(false);
        huagan.value = 0;
        kaiguan = true;
    }
    void buttonWriteText(string temp)
    {
        Transform p1 = GameObject.Find("Content").transform;
        //实例化线条
        GameObject writeimage = Instantiate(image, chushengdian, Quaternion.identity) as GameObject;

        Ynum += writeimage.GetComponent<RectTransform>().sizeDelta.y;

        //print("高度"+writeimage.GetComponent<Text>().preferredHeight);

      //  print(Ynum);

        Vector2 tempzb = new Vector3(330, -Ynum);

        writeimage.transform.SetParent(p1);

        writeimage.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        writeimage.GetComponent<RectTransform>().anchoredPosition = tempzb;

        //实列化text
        GameObject writetext = Instantiate(buttontext, chushengdian, Quaternion.identity) as GameObject;
        //放入内容
        writetext.GetComponent<Text>().text = temp;

        Ynum += writetext.GetComponent<Text>().preferredHeight;

        tempzb = new Vector3(330, -Ynum);

        kuang.GetComponent<RectTransform>().sizeDelta = new Vector2(184f, Ynum + 20);

        writetext.transform.SetParent(p1);

        writetext.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        if (writetext.GetComponent<Text>().preferredHeight > jichu)
        {

            tempzb = new Vector3(330, -(Ynum - (writetext.GetComponent<Text>().preferredHeight / jichu - 1) * jichu / 2), 0);
            writetext.GetComponent<RectTransform>().anchoredPosition = tempzb;
        }
        else
        {
            writetext.GetComponent<RectTransform>().anchoredPosition = tempzb;
        }

        //实例化线条
        GameObject writeimagedown = Instantiate(image, chushengdian, Quaternion.identity) as GameObject;

        Ynum += writeimage.GetComponent<RectTransform>().sizeDelta.y;

        tempzb = new Vector3(330, -Ynum );

        writeimagedown.transform.SetParent(p1);

        writeimagedown.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        writeimagedown.GetComponent<RectTransform>().anchoredPosition = tempzb;


    }
    
    void GameOver()
    {
        kaiguan = false;
        string over = "<color=red>" + "Game Over" + "</color>";
        buttonWriteText(over);
        button04.SetActive(true);

        huagan.value = 0;

    }

    public void Restbutton()
    {
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
}
