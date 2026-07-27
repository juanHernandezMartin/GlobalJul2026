using DG.Tweening;
using TMPro;
using UnityEngine;

public class MeatBallLauncher : MonoBehaviour
{
    public GameObject ganarGameobject;
    public GameObject perderGameObject;

    public int numMeatballs;
    public GameObject meatBallPrefab;
    public float minLaunchForce = 0f;
    public float maxLaunchForce = 4f;
    public float timeToHoldButton = 2f;
    public float timeToSpin;
    public float maxAngle;
    public float elevation;
    public TextMeshProUGUI meatBallText;
    public CazuelaScript cazuela;

    [HideInInspector]
    public float currentForce = 0f;
    [HideInInspector]
    public bool isLaunching;
    private Vector3 startingRotation;


    private Tween rotateTween;

    public void Start()
    {
        meatBallText.text = numMeatballs.ToString();
        startingRotation = transform.eulerAngles;
        rotateTween = transform.DOLocalRotate(new Vector3(0, maxAngle, 0), timeToSpin).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            if (numMeatballs > 0)
            {
                cazuela.LaunchMeatBall();
                numMeatballs--;
                meatBallText.text = numMeatballs.ToString();
                isLaunching = false;
                LaunchMeatBall(currentForce);
                currentForce = minLaunchForce;
                rotateTween.Play();

                if( numMeatballs == 0)
                {
                    Invoke("Perder", 2);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (numMeatballs > 0)
            {
                //stop rotation and start increasing force
                rotateTween.Pause();
                StartPressingLaunchButton();
            }
        }

        if (isLaunching)
        {
            currentForce += (maxLaunchForce / timeToHoldButton) * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0f, maxLaunchForce);
        }
    }


    public void StartPressingLaunchButton()
    {
        currentForce = minLaunchForce;
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

    public void Perder()
    {
        if( !ganarGameobject.activeSelf)
        {
            perderGameObject.SetActive(true);
        }
    }

}
