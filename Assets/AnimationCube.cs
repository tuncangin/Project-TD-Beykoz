using System;
using DG.Tweening;
using UnityEngine;

public class AnimationCube : MonoBehaviour
{
    public AnimationCurve myEaseCurve;
    private void Start()
    {
        CubeRotationLoop();
    }

    private void CubeRotationLoop()
    {
        gameObject.transform.DOLocalRotate(new Vector3(0, 90, 0), 1).SetLoops(-1,LoopType.Yoyo).SetEase(myEaseCurve);
    }
    
}
