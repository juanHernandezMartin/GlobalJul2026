using UnityEngine;

public class BackGroundAudio : MonoBehaviour
{
    public static BackGroundAudio Instance;

    private void Awake()
    {
        // Si ya existe otro, este se destruye
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
