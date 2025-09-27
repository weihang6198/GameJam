using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance; // シングルトン

    private void Awake()
    {
        // すでに存在するBGMがあれば破棄
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // シーンを跨いでも破棄されない

        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
