using UnityEngine;

public class PowerMeter : MonoBehaviour
{
    public MeatBallLauncher launcher;

    public GameObject backGroundSprite;
    public GameObject powerSprite;

    private  float maxScale;
    private float minPosY;

    public void Start()
    {
        maxScale = powerSprite.transform.localScale.y;
        minPosY = transform.localPosition.y;
    }

    public void Update()
    {
        if( launcher.isLaunching)
        {
            backGroundSprite.SetActive(true);
            powerSprite.SetActive(true);

            

            float fillMeter = (launcher.currentForce - launcher.minLaunchForce) / (launcher.maxLaunchForce - launcher.minLaunchForce);
            Vector3 targetScale = powerSprite.transform.localScale;
            targetScale.y = fillMeter * maxScale;
            powerSprite.transform.localScale = targetScale;

            Vector3 targetPosition = powerSprite.transform.localPosition;
            float targety = -minPosY + fillMeter * minPosY;
            targetPosition.y = targety;
            powerSprite.transform.localPosition = targetPosition;
        }
        else
        {
            backGroundSprite.SetActive(false);
            powerSprite.SetActive(false);
        }

        //powerSprite.transform
    }
}
