using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeManager : MonoBehaviour
{
    [SerializeField] string[] order = { "Title", "Rule", "Game", "Result" };

    public int currentSceneIndex = 0;
    private static ChangeManager instance;

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
            Debug.Log(order[currentSceneIndex]);
            Invoke(nameof(ChangeScene), 0.5f);
        }
    }

    void ChangeScene()
    {
        if (order.Length == 0) return;

        string nextScene = order[currentSceneIndex];
        Debug.Log("ÉVÅ[Éì: " + nextScene);

        SceneManager.LoadScene(order[currentSceneIndex]);

        currentSceneIndex = (currentSceneIndex + 1) % order.Length;
    }
}

