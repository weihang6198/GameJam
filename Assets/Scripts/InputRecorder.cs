using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRecorder : MonoBehaviour
{
    private List<string> recordedKeyColors = new List<string>();

    // UIimage�Q��
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
        // ���L�[�����m
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

    // UI��ύX���郁�\�b�h
    private void SetKeySpriteImage(Image image, Transform displayPoint, Sprite sprite)
    {
        if(image != null && displayPoint != null && mainCamera != null)
        {
            // ���[���h���W���X�N���[�����W�ɕϊ�����UI�̈ʒu�����߂�
            Vector3 screenPos = mainCamera.WorldToScreenPoint(displayPoint.position);
            image.rectTransform.position = screenPos;
            image.sprite = sprite;
            image.enabled = true;
        }
    }

    // �摜���\���ɂ���
    private void HideAllImages()
    {
        if(upArrowImage != null) upArrowImage.enabled = false;
        if(downArrowImage != null) downArrowImage.enabled = false;
        if(leftArrowImage != null) leftArrowImage.enabled = false;
        if(rightArrowImage != null) rightArrowImage.enabled = false;

        KeyCount = 0;
    }

    // ���͏������X�g�ɋL��
    private void RecordInput(string keyColor)
    {
        recordedKeyColors.Add(keyColor);
        Debug.Log("���͗����ɒǉ��F" + keyColor);
    }

    // �L�^���ꂽ������Ԃ�
    public List<string> GetRecordedInput()
    {
        return recordedKeyColors;
    }

    // �������N���A���郁�\�b�h
    public void ClearInputHistory()
    {
        recordedKeyColors.Clear();
        Debug.Log("���͗������N���A���܂���");
        HideAllImages();
    }
}
