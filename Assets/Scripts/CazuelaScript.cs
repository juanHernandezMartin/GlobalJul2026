using System.Collections.Generic;
using UnityEngine;

public class CazuelaScript : MonoBehaviour
{
    public List<GameObject> meatBallsInCazuela = new List<GameObject>();

    public void LaunchMeatBall()
    {
        if( meatBallsInCazuela.Count > 0 )
        {
            meatBallsInCazuela[0].SetActive(false);
            meatBallsInCazuela.Remove( meatBallsInCazuela[0] );
        }
    }
}
