using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRecorder : MonoBehaviour
{
    private List<string> recordedKeyColors = new List<string>();

    // UIimage�Q��
    public List<Image> KeyImages = new List<Image>();

    public Sprite KeyUp;
    public Sprite KeyDown;
    public Sprite KeyLeft;
    public Sprite KeyRight;

    public List<Transform> keyPoints = new List<Transform>(); 

    private Camera mainCamera;
    private int KeyCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        ClearInputHistory();
        HideAllImages();
    }

    // Update is called once per frame
    void Update()
    {
        // ���L�[�����m
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HandleInput("Red", KeyUp);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HandleInput("Green", KeyDown);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandleInput("Blue", KeyLeft);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandleInput("Yellow", KeyRight);
        }
    }

  
    private void HandleInput(string KeyColor, Sprite keySprite)
    {
        if(KeyCount >= KeyImages.Count)
        {
            ClearInputHistory();
        }

        RecordInput(KeyColor);
        SetKeySpriteImage(KeyImages[KeyCount], keyPoints[KeyCount], keySprite);
        KeyCount++;
    }

    
    private void SetKeySpriteImage(Image image, Transform displayPoint, Sprite sprite)
    {
        if(image != null && displayPoint != null && mainCamera != null)
        {
          
            Vector3 screenPos = mainCamera.WorldToScreenPoint(displayPoint.position);
            image.rectTransform.position = screenPos;
            image.sprite = sprite;
            image.enabled = true;
        }
    }

       private void HideAllImages()
    {
        foreach (Image img in KeyImages)
        {
            if(img != null)
            {
                img.enabled = false;
            }
        }
    }

      private void RecordInput(string keyColor)
    {
        recordedKeyColors.Add(keyColor);
        Debug.Log("���͗����ɒǉ��F" + keyColor);
    }

   
    public List<string> GetRecordedInput()
    {
        return recordedKeyColors;
    }

  
    public void ClearInputHistory()
    {
        recordedKeyColors.Clear();
        Debug.Log("���͗������N���A���܂���");
        HideAllImages();
        KeyCount = 0;
    }
}

/*
todo 
make the atari hantei for the color wall system 

*/