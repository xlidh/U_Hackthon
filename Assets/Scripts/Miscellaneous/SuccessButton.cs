using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessButton : MonoBehaviour
{


    public Animator transitionAnim;
    AudioSource ButtonAd;
    // Start is called before the first frame update
    void Start()
    {
        transitionAnim = GameObject.Find("Animation").GetComponent<Animator>();
        ButtonAd = GameObject.Find("Button Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void onClickRestartButton()
    {
        StartCoroutine(LoadScene("GamePlay"));
        ButtonAd.Play();
    }


    public void OnClickHomeButton()
    {
        StartCoroutine(LoadScene("MainMenu"));
        ButtonAd.Play();
    }


    IEnumerator LoadScene(string sceneName)
    {


        transitionAnim.SetTrigger("end");

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

}
