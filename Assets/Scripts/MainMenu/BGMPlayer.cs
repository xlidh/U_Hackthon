using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    
    public static bool stop = false;

    private static BGMPlayer instance = null;
    private AudioSource ad;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        ad = GetComponent<AudioSource>();
        ad.Play();
    }

    // Update is called once per frame
    
    void Update()
    {
        if(stop && ad.isPlaying)
        {
            Debug.Log("Beed Stopped");
            ad.Stop();
        }
        else if(!stop && !ad.isPlaying)
        {
            ad.Play();
        }
        
    }
    
}
