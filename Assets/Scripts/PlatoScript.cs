using UnityEngine;

public class PlatoScript : MonoBehaviour
{
    private bool isPlatoActive = false;
    public GameObject emptyPlate;
    public GameObject fullPlate;


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MeatBall") && !isPlatoActive)
        {
            isPlatoActive = true;
            fullPlate.SetActive(true);
            emptyPlate.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
