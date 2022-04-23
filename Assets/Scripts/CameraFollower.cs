using Cinemachine;
using UnityEngine;

public sealed class CameraFollower : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;

    public void Follow(Transform at)
    {
        cinemachineCamera.Follow = at;
    }
}
