using Cinemachine;
using UnityEngine;

public sealed class CameraFollower : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;

    public void FollowAndLookAt(Transform at)
    {
        cinemachineCamera.Follow = at;
        cinemachineCamera.LookAt = at;
    }
}
