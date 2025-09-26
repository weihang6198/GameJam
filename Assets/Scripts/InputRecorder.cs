using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRecorder : MonoBehaviour
{
    private List<string> recordedKeyColors = new List<string>();

    // UIimage参照
    public Image upArrowImage;
    public Image downArrowImage;
    public Image leftArrowImage;
    public Image rightArrowImage;

    public Sprite KeyUp;
    public Sprite KeyDown;
    public Sprite KeyLeft;
    public Sprite KeyRight;

    public Transform UpPoint;
    public Transform DownPoint;
    public Transform LeftPoint;
    public Transform rightPoint;

    private Camera mainCamera;
    private int KeyCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        ClearInputHistory();
    }

    // Update is called once per frame
    void Update()
    {
        // 矢印キーを検知
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RecordInput("Red");
            SetKeySpriteImage(upArrowImage, UpPoint, KeyUp);
            KeyCount += 1;
            Debug.Log("KeyCount:" + KeyCount);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RecordInput("Green");
            SetKeySpriteImage(downArrowImage, DownPoint, KeyDown);
            KeyCount += 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RecordInput("Blue");
            SetKeySpriteImage(leftArrowImage, LeftPoint, KeyLeft);
            KeyCount += 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RecordInput("Yellow");
            SetKeySpriteImage(rightArrowImage, rightPoint, KeyRight);
            KeyCount += 1;
        }

        if(KeyCount >= 5)
        {
            HideAllImages();
        }

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
        if(upArrowImage != null) upArrowImage.enabled = false;
        if(downArrowImage != null) downArrowImage.enabled = false;
        if(leftArrowImage != null) leftArrowImage.enabled = false;
        if(rightArrowImage != null) rightArrowImage.enabled = false;

        KeyCount = 0;
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
    }
}
