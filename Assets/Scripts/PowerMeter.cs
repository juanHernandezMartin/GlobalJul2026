using UnityEngine;

public class PowerMeter : MonoBehaviour
{
    public MeatBallLauncher launcher;

    public GameObject backGroundSprite;
    public GameObject powerSprite;

    public float minScale;
    private  float maxScale;
    public float minPosY;

    public void Start()
    {
        maxScale = powerSprite.transform.localScale.y;
    }

    public void Update()
    {
        if( launcher.isLaunching)
        {
            backGroundSprite.SetActive(true);
            powerSprite.SetActive(true);

            float fillMeter = launcher.currentForce / launcher.maxLaunchForce;
            Vector3 targetScale = powerSprite.transform.localScale;
            targetScale.y = fillMeter * maxScale;
            powerSprite.transform.localScale = targetScale;
        }
        else
        {
            backGroundSprite.SetActive(false);
            powerSprite.SetActive(false);
        }

        //powerSprite.transform
    }
}
