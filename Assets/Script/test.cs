using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

    public GameObject wordtext;

    public GameObject image;

    public GameObject buttontext;

    public GameObject kuang;

    Vector3 chushengdian = new Vector3(0,0,0);

    float Ynum;

    // Use this for initialization
    void Start()
    {
        ////高度及宽度
        //print("width:" + kuang.GetComponent<RectTransform>().sizeDelta.x.ToString());

        //print("height:" + kuang.GetComponent<RectTransform>().sizeDelta.y.ToString());

        ////kuang.GetComponent<RectTransform>().sizeDelta=new Vector2(184f,500f);

        ////坐标位置
        //print(wordtext.GetComponent<RectTransform>().localPosition.x.ToString());

        //print(wordtext.GetComponent<RectTransform>().localPosition.y.ToString());

        //print("wordtext height:" + wordtext.GetComponent<RectTransform>().sizeDelta.y.ToString());
        ////负数变为正数
        //float a = Mathf.Abs(wordtext.GetComponent<RectTransform>().localPosition.y);

       

        Ynum = wordtext.GetComponent<RectTransform>().sizeDelta.y;

        print(Ynum);

        Atest();
        
    }

    void Atest()
    {
        Transform p1 = GameObject.Find("Content").transform;
        for (int i = 0; i < 30; i++)
        {
            GameObject temp = Instantiate(wordtext, chushengdian, Quaternion.identity) as GameObject;
            //高度叠加为下移坐标
            Ynum += temp.GetComponent<RectTransform>().sizeDelta.y;

            Vector2 tempzb = new Vector3(0, -Ynum);

            kuang.GetComponent<RectTransform>().sizeDelta = new Vector2(184f, Ynum + 20);

            temp.transform.SetParent(p1);

            //RectTransform下POS X,Y坐标值
            temp.GetComponent<RectTransform>().anchoredPosition = tempzb;

            print(temp.GetComponent<RectTransform>().anchoredPosition.x);
        }
        

       



    }





    // Update is called once per frame
    void Update()
    {

    }
}
