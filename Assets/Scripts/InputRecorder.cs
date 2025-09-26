using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRecorder : MonoBehaviour
{
    private List<string> recordedKeyColors = new List<string>();

    // UIimage参照
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
        // 矢印キーを検知
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

    // 入力処理を管理するメソッド
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

    // UIを変更するメソッド
    private void SetKeySpriteImage(Image image, Transform displayPoint, Sprite sprite)
    {
        if(image != null && displayPoint != null && mainCamera != null)
        {
            // ワールド座標をスクリーン座標に変換してUIの位置を決める
            Vector3 screenPos = mainCamera.WorldToScreenPoint(displayPoint.position);
            image.rectTransform.position = screenPos;
            image.sprite = sprite;
            image.enabled = true;
        }
    }

    // 画像を非表示にする
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

    // 入力情報をリストに記憶
    private void RecordInput(string keyColor)
    {
        recordedKeyColors.Add(keyColor);
        Debug.Log("入力履歴に追加：" + keyColor);
    }

    // 記録された履歴を返す
    public List<string> GetRecordedInput()
    {
        return recordedKeyColors;
    }

    // 履歴をクリアするメソッド
    public void ClearInputHistory()
    {
        recordedKeyColors.Clear();
        Debug.Log("入力履歴をクリアしました");
        HideAllImages();
        KeyCount = 0;
    }
}
