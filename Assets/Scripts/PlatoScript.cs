using UnityEngine;

public class PlatoScript : MonoBehaviour
{
    private bool isPlatoActive = false;
    public GameObject emptyPlate;
    public GameObject fullPlate;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MeatBall") && !isPlatoActive)
        {
            isPlatoActive = true;
            fullPlate.SetActive(true);
            emptyPlate.SetActive(false);
            Destroy(other.gameObject);
            audioSource.Play();
        }
        else if(other.gameObject.CompareTag("MeatBall") && isPlatoActive)
        {
            Destroy(other.gameObject);
            audioSource.Play();
        }
    }
}
