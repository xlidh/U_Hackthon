using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
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
    public void onClickNextButton()
    {
        ButtonAd.Play();
        StartCoroutine(LoadScene("GamePlay"));
        UnityEngine.Debug.Log("On Click");
    }
    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
