using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;








public class BG_Animation : MonoBehaviour
{

    public GameObject Cloud_1;
    public GameObject Cloud_2;
    public float SceneLeftBoundary = -10.0f;
    public float SceneRightBoundary = 10.0f;
    public float SceneUpperBoundary = 5.0f;
    public float SceneLowerBoundary = -5.0f;
    public static float FlyingMinSpeed = 2.0f;
    public static float FlyingMaxSpeed = 3.0f;
    private float timeCountDown = 0;


    private class FlyingCloud 
    {
        GameObject obj;
        Vector3 speed;
        public FlyingCloud(GameObject o)
        {
            obj = o;
            speed = new Vector3(Random.Range(FlyingMinSpeed, FlyingMaxSpeed) * Time.deltaTime, 0, 0);
        }
        public GameObject getBody()
        {
            return obj;
        }
        public Vector3 getSpeed()
        {
            return speed;
        }
        
    }



    private List<GameObject> candidateList = new List<GameObject>(); // Just a list of template
    private List<FlyingCloud> currentClouds = new List<FlyingCloud>(); // Flying cloud
    // Start is called before the first frame update
    void Start()
    {
        BGMPlayer.stop = false;
        candidateList.Add(Cloud_1);
        candidateList.Add(Cloud_2);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCountDown<=0)
        {
            int rIndex = Random.Range(0, candidateList.Count);
            Vector3 pos = new Vector3(SceneLeftBoundary, Random.Range(SceneLowerBoundary, SceneUpperBoundary), 0.0f);
            GameObject cloudTemplate = Instantiate(candidateList[rIndex], pos,  new Quaternion(0,0,0,0));
            cloudTemplate.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(1, 4);
            currentClouds.Add(new FlyingCloud(cloudTemplate));
            //Debug.Log("Creaint a cloud at : " + pos.ToString());
            timeCountDown = Random.Range(2, 5);

        }
        else { 
            foreach (FlyingCloud cloud in currentClouds.ToList())    //Use ToList() Method to avoid undefined behaviour of removing element while iterating
            {
                cloud.getBody().transform.Translate(cloud.getSpeed());
                if (cloud.getBody().transform.position.x > SceneRightBoundary)
                {
                    currentClouds.Remove(cloud);
                    Destroy(cloud.getBody());
                }
                    
            }
            timeCountDown -= Time.deltaTime;
        }
    }
}
