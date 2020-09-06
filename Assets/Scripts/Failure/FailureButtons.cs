using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailureButtons : MonoBehaviour
{


    public Animator transitionAnim;
    GameObject Blocker;
    // Start is called before the first frame update
    void Start()
    {
        transitionAnim = GameObject.Find("OrangeCircle").GetComponent<Animator>();
        Blocker = GameObject.Find("WhiteBlocker");
        Blocker.GetComponent<Image>().enabled = false;
        BGMPlayer.stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onClickRestartButton()
    {
        StartCoroutine(LoadScene("GamePlay"));
    }


    public void OnClickHomeButton()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }


    IEnumerator LoadScene(string sceneName)
    {
        
        
        transitionAnim.SetTrigger("Echo");
        Blocker.GetComponent<Image>().enabled = true;

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

}
