using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomizerScript : MonoBehaviour
{

    private StateMachine _stateMachine;

    [SerializeField] private Transform obstaclesTransform;
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

    public void Init(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _stateMachine.OnStateChanged += OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {
        if (state == GameState.Intro)
        {
            DestroyAllObstacles();
            Randomize();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        lastPosition = startPoint;

        Randomize();
    }
    public void DestroyAllObstacles()
    {
        foreach (Transform child in obstaclesTransform)
        {
            Destroy(child.gameObject);
        }
        
    }

    public void Randomize()
    {
        bool randomize = true;


        while (randomize)
        {
            int i = Random.Range(0, obstacles.Length);


            float positionX = Random.Range(lastPosition - maxDistance, Mathf.Min(lastPosition - currentMinDistance, lastPosition - minDistance));

            Transform nextObstacle = Instantiate(obstacles[i], obstaclesTransform);


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
