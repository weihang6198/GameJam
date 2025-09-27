using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance; // �V���O���g��

    private void Awake()
    {
        // ���łɑ��݂���BGM������Δj��
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // �V�[�����ׂ��ł��j������Ȃ�

        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
