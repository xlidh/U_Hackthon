using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpHome : MonoBehaviour
{
    public Animator transitionAnim;
    GameObject Blocker;
    AudioSource ButtonAd;
    // Start is called before the first frame update
    void Start()
    {
        transitionAnim = GameObject.Find("GreenCircle").GetComponent<Animator>();
        Blocker = GameObject.Find("WhiteBlocker");
        Blocker.GetComponent<Image>().enabled = false;
        ButtonAd = GameObject.Find("Button Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onCiickHomeButton()
    {
        StartCoroutine(LoadScene("MainMenu"));
        ButtonAd.Play();
    }


    IEnumerator LoadScene(string sceneName)
    {


        transitionAnim.SetTrigger("Echo");
        Blocker.GetComponent<Image>().enabled = true;

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
