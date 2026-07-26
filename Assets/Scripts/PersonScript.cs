using DG.Tweening;
using UnityEngine;

public class PersonScript : MonoBehaviour
{
    [SerializeField] float angle = 5f;
    [SerializeField] float duration = 2f;

    float current;

    void Start()
    {

        //randomice duration & angle
        duration = duration / 2 + Random.value * duration;
        angle = angle / 2 + Random.value* angle;

        DOTween.To(
            () => current,
            x =>
            {
                float delta = x - current;
                current = x;
                transform.Rotate(Vector3.forward, delta, Space.Self);
            },
            angle,
            duration
        )
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.InOutSine);
    }
}