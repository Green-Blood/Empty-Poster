using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{

    //The point at which objects may beginn to appear
    public float startPoint;

    //The point at which objects may not appear anymore
    public float endPoint;


    //Min Distance between objects
    public float minDistance;

    //Max Distance between objects
    public float maxDistance;


    private int obstacleCnt;

    private float currentMinDistance;

    private float lastPosition;

    public Transform[] obstacles;

    public int maxNumberOfObstacles;

    // Start is called before the first frame update
    void Start()
    {

        lastPosition = startPoint;

        Randomize();
    }

    public void DestroyAllObstacles()
    {
       GameObject[] allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        for(int i = 0; i< allObstacles.Length; i++)
        {
            Destroy(allObstacles[i]);
        }
    }

    public void Randomize()
    {
        bool randomize = true;


        while (randomize)
        {
            int i = Random.Range(0, obstacles.Length);


            float positionX = Random.Range(Mathf.Min(lastPosition - currentMinDistance, lastPosition - minDistance), lastPosition - maxDistance);

            Transform nextObstacle = Instantiate(obstacles[i]);


            nextObstacle.position = new Vector2(positionX, nextObstacle.GetComponent<MinDistanceScript>().positionY);

            currentMinDistance = nextObstacle.GetComponent<MinDistanceScript>().minDistance;

            obstacleCnt++;

            lastPosition = positionX;

            if(obstacleCnt == maxNumberOfObstacles || positionX <= endPoint)
            {
                randomize = false;
            }

            
        }

    }
}
