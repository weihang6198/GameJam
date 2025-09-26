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
        // 矢印キーを検知
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
    }
}
