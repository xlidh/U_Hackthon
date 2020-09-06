using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScheme : MonoBehaviour
{
    // Start is called before the first frame update


    const KeyCode KeyP1Up = KeyCode.A;
    const KeyCode KeyP1Down = KeyCode.S;
    const KeyCode KeyP2Up = KeyCode.K;
    const KeyCode KeyP2Down = KeyCode.J;
    public Sprite SpriteP1Up;
    public Sprite SpriteP1Down;
    public Sprite SpriteP2Up;
    public Sprite SpriteP2Down;
    public Sprite SpriteInjury;
    public Sprite SpritePat;
    GameObject P1;
    GameObject P2;
    public GameObject ScoreText;

    bool isP1Down = false;
    bool isP2Down = false;

    bool isSoft = false;
    bool isWet = false;

    public static float score = 0.0f;
    float punishTime = 0.0f;
    
    public static bool isGamePaused = false;
    bool recoverHand = false;


    public AudioSource ad1;
    public AudioSource ad2;

    void Start()
    {
        score = 0.0f;
        isGamePaused = false;
        P1 = GameObject.Find("Player1");
        P2 = GameObject.Find("Player2");
        ScoreText = GameObject.Find("ScoreText");
        P2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        P1.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }


    // Update is called once per frame
    void Update()
    {
        if (isGamePaused)
        {
            return;
        }
        punishTime -= Time.deltaTime;
        if(punishTime > 0)
        {
            ;
        }
        else
        {
            if(recoverHand)
            {
                P1.GetComponent<SpriteRenderer>().sprite = SpriteP1Down;
                P2.GetComponent<SpriteRenderer>().sprite = SpriteP2Up;
                recoverHand = false;
            }
            punishTime = 0;
            
        
            // P1 State Update, 锤子手
            if (Input.GetKeyDown(KeyP1Up) && isP1Down)
            {
                P1.GetComponent<SpriteRenderer>().sprite = SpriteP1Up;
                isP1Down = false;
            }
            else if (Input.GetKeyDown(KeyP1Down) && !isP1Down)
            {
                ad1.Play();
                // TODO : Check fail
                if (isP2Down)
                {
                    //
                    P2.GetComponent<SpriteRenderer>().sprite = null;
                    P1.GetComponent<SpriteRenderer>().sprite = SpriteInjury;
                    StartCoroutine(FailGame());
                    // TODO LoadFailScene
                }
                else
                {
                    P1.GetComponent<SpriteRenderer>().sprite = SpriteP1Down;
                    isP1Down = true;
                    P2.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    P1.GetComponent<SpriteRenderer>().sortingOrder = 1;

                    //Scoring

                    score += 0.5f + 1.5f * (isWet ? 1 : 0);
                    isWet = false;
                    isSoft = true;
                }
            }

            // P2 State Update，洒水车
            if (Input.GetKeyDown(KeyP2Up) && isP2Down)
            {
                P2.GetComponent<SpriteRenderer>().sprite = SpriteP2Up;
                isP2Down = false;
            }
            else if (Input.GetKeyDown(KeyP2Down) && !isP2Down)
            {
                ad2.Play();
                // TODO : Check fail
                if (isP1Down)
                {

                    Punish(1);
                    P1.GetComponent<SpriteRenderer>().sprite = null;
                    P2.GetComponent<SpriteRenderer>().sprite = SpritePat;
                    isP1Down = true;
                    isP2Down = false;
                    recoverHand = true;
                }
                else
                {
                    P2.GetComponent<SpriteRenderer>().sprite = SpriteP2Down;
                    isP2Down = true;
                    P1.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    P2.GetComponent<SpriteRenderer>().sortingOrder = 1;


                    score += 0.5f + 1.5f * (isSoft ? 1 : 0);
                    isSoft = false;
                    isWet = true;
                }
            }



            //Update score 
            ScoreText.GetComponent<Text>().text = score.ToString();
        
        }
        

    }

    IEnumerator FailGame()
    {
        isGamePaused = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Failure");
    }
    void Resume()
    {

    }
    void Punish(float t)
    {
        punishTime = t;
    }
}
