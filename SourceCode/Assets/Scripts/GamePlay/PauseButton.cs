using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Sprite clickToPause;
    public Sprite clickToResume;
    int temp1;
    int temp2;
    AudioSource ButtonAd;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("ShadowMask").GetComponent<Image>().enabled = false;
        BGMPlayer.stop = false;
        ButtonAd = GameObject.Find("Button Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCLickPauseButton()
    {
        ButtonAd.Play();

        if (!ScoreScheme.isGamePaused)
        {
            ScoreScheme.isGamePaused = true;
            GetComponent<Image>().sprite = clickToResume;
            GameObject.Find("ShadowMask").GetComponent<Image>().enabled = true;
            temp1 = GameObject.Find("Player1").GetComponent<SpriteRenderer>().sortingOrder;
            temp2 = GameObject.Find("Player2").GetComponent<SpriteRenderer>().sortingOrder;

            GameObject.Find("Player1").GetComponent<SpriteRenderer>().sortingOrder = 0;
            GameObject.Find("Player2").GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            ScoreScheme.isGamePaused = false;
            GetComponent<Image>().sprite = clickToPause;
            GameObject.Find("ShadowMask").GetComponent<Image>().enabled = false;
            GameObject.Find("Player1").GetComponent<SpriteRenderer>().sortingOrder = temp1;
            GameObject.Find("Player2").GetComponent<SpriteRenderer>().sortingOrder = temp2;
        }
    }
}
