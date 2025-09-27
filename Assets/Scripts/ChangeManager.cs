using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeManager : MonoBehaviour
{
    [SerializeField] string[] order = { "Title", "Rule", "Game", "Result" };

    private static ChangeManager instance;
    public bool resultOrder = false; 

    void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        bool PressSpaceKey = Input.GetKeyDown(KeyCode.Space);

        if(PressSpaceKey)
        {
            ChangeScene();
        }

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex == 2 && resultOrder) 
        {
            SceneManager.LoadScene(3);
            resultOrder = false;
        }
    }

    void ChangeScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
            nextIndex = 0; // loop back to first scene (optional)

        if (currentIndex == 2) return;

        SceneManager.LoadScene(nextIndex);

    }
}

