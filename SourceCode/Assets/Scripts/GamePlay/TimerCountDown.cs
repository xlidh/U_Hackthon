using System;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimerCountDown : MonoBehaviour
{
    public float totalTime = 30.0f;
    float currentTime;
    public Animator transitionAnim;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreScheme.isGamePaused)
        {
            return;
        }
        currentTime -= Time.deltaTime;
        if (currentTime>10)
        {
            GetComponent<TextMeshProUGUI>().text = Math.Round(currentTime, 0).ToString() + " s";
        }
        else if (currentTime>0)
        {
            GetComponent<TextMeshProUGUI>().text = Math.Round(currentTime, 1).ToString() + " s";
        }
        else
        {
            ScoreScheme.isGamePaused = true;
            if (ScoreScheme.score >= 0 && ScoreScheme.score <= 20)
            {
                //白色
                StartCoroutine(LoadScene("Success1"));
            }
            else if (ScoreScheme.score > 20 && ScoreScheme.score <= 40)
            {
                //粉色
                StartCoroutine(LoadScene("success2"));
            }
            else
            {
                //无
                StartCoroutine(LoadScene("success3"));
            } //Game over
        }
    }
    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
