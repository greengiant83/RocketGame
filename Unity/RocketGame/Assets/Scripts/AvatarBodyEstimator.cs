using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarBodyEstimator : MonoBehaviour
{
    [SerializeField] private Transform Head;
    [SerializeField] private Vector3 HeadToBodyOffset;
    [SerializeField] private float SlerpAmount = 0.1f;

    void Update()
    {
        transform.localPosition = Head.localPosition + HeadToBodyOffset;

        var targetRot = Quaternion.Euler(0, Head.localRotation.eulerAngles.y, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, Time.deltaTime * SlerpAmount);
    }
}
