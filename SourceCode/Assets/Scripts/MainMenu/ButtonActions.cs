using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public Animator transitionAnim;
    AudioSource ButtonAd;
    // Start is called before the first frame update
    void Start()
    {
        ButtonAd = GameObject.Find("Button Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onClickStartButton()
    {
        StartCoroutine(LoadScene("SampleScene"));
        ButtonAd.Play();
        //SceneManager.LoadScene("GamePlay");
    }



    public void onClickInfoButton()
    {
        StartCoroutine(LoadScene("Info"));
        ButtonAd.Play();
    }


    public void onClickHelpButton()
    {
        StartCoroutine(LoadScene("Help"));
        ButtonAd.Play();
    }
    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
