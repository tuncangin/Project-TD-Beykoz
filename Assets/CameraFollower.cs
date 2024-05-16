using System;
using DG.Tweening;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform objectToFollow;

    private Vector3 offset;

    private void Start()
    {
        offset = objectToFollow.position - transform.position;
    }

    private void Update()
    {
        transform.DOMove(objectToFollow.position - offset, .2f);
    }
}
