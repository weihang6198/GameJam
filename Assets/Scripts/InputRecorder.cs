using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    private List<string> recordedKeyColors = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���L�[�����m
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RecordInput("Red");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RecordInput("Green");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RecordInput("Blue");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RecordInput("Yellow");
        }
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
    }
}
