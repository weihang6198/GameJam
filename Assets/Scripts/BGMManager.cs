using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying) 
        {
            audio.Play();
        }
    }
}
