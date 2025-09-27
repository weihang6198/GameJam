using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRecorder : MonoBehaviour
{
    //private List<string> recordedKeyColors = new List<string>();
    //record player input on color wall qte event
    public List<int> playerKeyInput = new List<int>();

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
            HandleInput(0, KeyUp);
        }
         else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandleInput(1, KeyRight);
        }
         else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HandleInput(2, KeyDown);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandleInput(3, KeyLeft);
        }
       

       
    }


    private void HandleInput(int playerInput, Sprite keySprite)
    {
        if (KeyCount >= KeyImages.Count)
        {
            ClearInputHistory();
        }

        RecordInput(playerInput);
        SetKeySpriteImage(KeyImages[KeyCount], keyPoints[KeyCount], keySprite);
        KeyCount++;
    }


    private void SetKeySpriteImage(Image image, Transform displayPoint, Sprite sprite)
    {
        if (image != null && displayPoint != null && mainCamera != null)
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
            if (img != null)
            {
                img.enabled = false;
            }
        }
    }

    private void RecordInput(int playerInput)
    {
        playerKeyInput.Add(playerInput);
        //Debug.Log("���͗����ɒǉ��F" + keyColor);
    }


    public List<int> GetRecordedInput()
    {
        return playerKeyInput;
    }


    public void ClearInputHistory()
    {
        playerKeyInput.Clear();
       
        HideAllImages();
        KeyCount = 0;
    }

public bool CompareInput(List<int> ColorWallIndices)
{
    // Print both lists before comparing
    Debug.Log("colorWallRandomIndices: " + string.Join(", ", ColorWallIndices));
    Debug.Log("playerList: " + string.Join(", ", playerKeyInput));

    // If lengths don't match, they can't be equal
    if (ColorWallIndices.Count != playerKeyInput.Count)
    {
        ClearInputHistory();
        Debug.Log("incorrect answer (length mismatch)");
        return false;
    }

    // Compare each element
    for (int i = 0; i < ColorWallIndices.Count; i++)
    {
        if (ColorWallIndices[i] != playerKeyInput[i])
        {
            Debug.Log("incorrect answer (element mismatch at index " + i + ")");
            ClearInputHistory();
            return false;
        }
    }

    // All elements matched
    ClearInputHistory();
    Debug.Log("correct answer");
    return true;
}
}

/*
todo 
make the atari hantei for the color wall system 

*/