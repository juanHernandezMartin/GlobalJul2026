using UnityEngine;

public class TableScript : MonoBehaviour
{
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public GameObject smashedMeatBallPrefab;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MeatBall"))
        {
            Destroy(other.gameObject);
            Vector3 impactPosition = other.ClosestPoint(transform.position);
            impactPosition.y += 0.1f;
            Instantiate(smashedMeatBallPrefab, impactPosition, Quaternion.identity);
            audioSource.Play();
        }
        
    }
}
