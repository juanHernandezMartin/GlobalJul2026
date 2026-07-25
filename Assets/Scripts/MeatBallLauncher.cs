using DG.Tweening;
using UnityEngine;

public class MeatBallLauncher : MonoBehaviour
{
    public float timeToSpin;
    public float maxAngle;

    public void Start()
    {
        transform.DOLocalRotate(new Vector3(0, maxAngle, 0), timeToSpin).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

}
