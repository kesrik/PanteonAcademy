using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float _cameraSpeed = 0.1f;
    [SerializeField] private Vector3 _dist;
    [SerializeField] private Transform _lookTarget;

    private void LateUpdate()
    {
        Vector3 dPos = _cameraTarget.position + _dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, _cameraSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(_lookTarget.position);
    }
}
