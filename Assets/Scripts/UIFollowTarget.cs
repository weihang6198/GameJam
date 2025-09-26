using UnityEngine;
using UnityEngine.UI;

public class UIFollowTarget : MonoBehaviour
{
    public Transform targetTransform;
    private Image uiImage;
    private Camera mainCamera;

    void Awake()
    {
        uiImage = GetComponent<Image>();
        if(uiImage == null)
        {
            enabled = false;
            return;
        }

        mainCamera = Camera.main;
        if(mainCamera == null)
        {
            enabled = false;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(targetTransform.position);

        uiImage.rectTransform.position = screenPos;

    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;
    }
}
