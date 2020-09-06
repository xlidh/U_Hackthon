using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class sample_count : MonoBehaviour
{
    const KeyCode KeyP1Up = KeyCode.A;
    const KeyCode KeyP1Down = KeyCode.S;
    const KeyCode KeyP2Up = KeyCode.K;
    const KeyCode KeyP2Down = KeyCode.J;
    public Sprite SpriteP1Up;
    public Sprite SpriteP1Down;
    public Sprite SpriteP2Up;
    public Sprite SpriteP2Down;
    public Sprite SpriteSuccess;
    public Sprite SpriteStop;
    GameObject P1;
    GameObject P2;
    public GameObject Text_count;

    bool isP1Down = false;
    bool isP2Down = false;
    bool stop = false;
    float punishTime = 0.0f;
    //public Animator transitionAnim;

    AudioSource ad;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        P1 = GameObject.Find("Player1");
        P2 = GameObject.Find("Player1-1");
        Text_count = GameObject.Find("Text_count");
        P2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        P1.GetComponent<SpriteRenderer>().sortingOrder = 1;
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        punishTime -= Time.deltaTime;
        if (punishTime > 0) {; }//正在接受惩罚
        //倒计时归零
        else
        {
            if (stop)
            {
                P1.GetComponent<SpriteRenderer>().sprite = SpriteP1Down;
                P2.GetComponent<SpriteRenderer>().sprite = SpriteP2Up;
                stop = false;//解除
            }

            punishTime = 0;//惩罚结束
            if (Input.GetKeyDown(KeyP1Up) && isP1Down)
            {
                P1.GetComponent<SpriteRenderer>().sprite = SpriteP1Up;
                isP1Down = false;
            }
            else if (Input.GetKeyDown(KeyP1Down) && !isP1Down)
            {
                ad.Play();
                // TODO : Check fail
                if (isP2Down)
                {
                    Punish(2);
                    P1.GetComponent<SpriteRenderer>().sprite = SpriteStop;
                    P2.GetComponent<SpriteRenderer>().sprite = null;
                    isP1Down = true;
                    isP2Down = false;
                    UnityEngine.Debug.Log(isP1Down);
                    UnityEngine.Debug.Log(isP2Down);
                    stop = true;
                }
                else
                {
                    P1.GetComponent<SpriteRenderer>().sprite = SpriteP1Down;
                    isP1Down = true;
                    P2.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    P1.GetComponent<SpriteRenderer>().sortingOrder = 1;

                    //Scoring

                    count = count + 1;
                }
            }

            // P2 
            if (Input.GetKeyDown(KeyP2Up) && isP2Down)
            {
                
                UnityEngine.Debug.Log("P1 get up");
                P2.GetComponent<SpriteRenderer>().sprite = SpriteP2Up;
                isP2Down = false;
            }
            else if (Input.GetKeyDown(KeyP2Down) && !isP2Down)
            {
                ad.Play();
                // TODO : Check fail
                if (isP1Down)
                {
                    Punish(2);
                    P1.GetComponent<SpriteRenderer>().sprite = SpriteStop;
                    P2.GetComponent<SpriteRenderer>().sprite = null;
                    isP1Down = true;
                    isP2Down = false;
                    UnityEngine.Debug.Log(isP1Down);
                    UnityEngine.Debug.Log(isP2Down);
                    stop = true;
                }
                else
                {
                    P2.GetComponent<SpriteRenderer>().sprite = SpriteP2Down;
                    isP2Down = true;
                    P1.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    P2.GetComponent<SpriteRenderer>().sortingOrder = 1;


                    count = count + 1;
                }
            }



            //Update score 
            Text_count.GetComponent<Text>().text = count.ToString();

            //胜利条件
            if (count >= 30)
            {
                count = 30;
                P1.GetComponent<SpriteRenderer>().sprite = SpriteSuccess;
                P2.GetComponent<SpriteRenderer>().sprite = null;
                
                //进入下一关
            }
            


        }
    }
    void Punish(float t)
    {
        punishTime = t;
    }

}
