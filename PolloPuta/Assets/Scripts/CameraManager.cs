using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera idleCamera;
    [SerializeField] private CinemachineVirtualCamera followCamera;

    private void Awake()
    {
        SwitchToIdleCamera();
    }

    public void SwitchToIdleCamera()
    {
        idleCamera.enabled = true;
        followCamera.enabled = false;
    }

    public void SwitchToFollowCamera(Transform followTransform)
    {
        followCamera.Follow = followTransform;

        followCamera.enabled = true;
        idleCamera.enabled = true;
    }
}
