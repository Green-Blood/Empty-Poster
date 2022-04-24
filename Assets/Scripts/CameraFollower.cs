using System.Collections;
using Cinemachine;
using Infrastructure;
using UnityEngine;

public sealed class CameraFollower : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera0;
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
        SwitchCameras(cinemachineCamera, cinemachineCamera2);
        yield return new WaitForSeconds(waitTime);
        SwitchCameras(cinemachineCamera2, cinemachineCamera);
        _stateMachine.NextState();
    }

    private void SwitchCameras(CinemachineVirtualCamera cameraToHide, CinemachineVirtualCamera cameraToShow)
    {
        cameraToHide.gameObject.SetActive(false);
        cameraToShow.gameObject.SetActive(true);
    }

    public void GameStart() => SwitchCameras(cinemachineCamera0, cinemachineCamera);
}