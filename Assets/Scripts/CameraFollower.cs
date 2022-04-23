using System.Collections;
using Cinemachine;
using Infrastructure;
using UnityEngine;

public sealed class CameraFollower : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera2;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private float delayTime = 2.5f;


    private StateMachine _stateMachine;

    public void Init(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _stateMachine.OnStateChanged += OnStateChanged;
    }


    private void OnStateChanged(GameState newState)
    {
        if (newState == GameState.Transition)
        {
            StartCoroutine(FollowForTime());
        }
    }

    private IEnumerator FollowForTime()
    {
        yield return new WaitForSeconds(delayTime);
        cinemachineCamera.gameObject.SetActive(false);
        cinemachineCamera2.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        cinemachineCamera2.gameObject.SetActive(false);
        cinemachineCamera.gameObject.SetActive(true);
        _stateMachine.NextState();
    }
}