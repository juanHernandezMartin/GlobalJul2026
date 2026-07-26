using DG.Tweening;
using UnityEngine;

public class MeatBallLauncher : MonoBehaviour
{
    public GameObject meatBallPrefab;
    public float maxLaunchForce = 10f;
    public float timeToHoldButton = 2f;
    public float timeToSpin;
    public float maxAngle;
    public float elevation;

    [HideInInspector]
    public float currentForce = 0f;
    [HideInInspector]
    public bool isLaunching;
    private Vector3 startingRotation;

    private Tween rotateTween;

    public void Start()
    {
        startingRotation = transform.eulerAngles;
        rotateTween = transform.DOLocalRotate(new Vector3(0, maxAngle, 0), timeToSpin).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void Update()
    {
        if( Input.GetKeyUp(KeyCode.Space))
        {
            isLaunching = false;
            LaunchMeatBall(currentForce);
            currentForce = 0f;
            rotateTween.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //stop rotation and start increasing force
            rotateTween.Pause();
            StartPressingLaunchButton();
        }

        if( isLaunching )
        {
            currentForce += (maxLaunchForce / timeToHoldButton) * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0f, maxLaunchForce);
        }
    }


    public void StartPressingLaunchButton()
    {
        currentForce = 0f;
        isLaunching = true;
    }

    public void LaunchMeatBall(float force)
    {
        GameObject meatBall = Instantiate(meatBallPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = meatBall.GetComponent<Rigidbody>();
        Vector3 forceDirecction = -transform.forward * force;
        forceDirecction.y += elevation;
        rb.AddForce(forceDirecction * force, ForceMode.Impulse);
    }

}
