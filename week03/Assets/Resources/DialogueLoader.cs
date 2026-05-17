using UnityEngine;
using System.Collections.Generic; 

public class DialogueLoader : MonoBehaviour
{
    public Dictionary<string, List<Dialogue>> dialogueDict = new Dictionary<string, List<Dialogue>>();
    
    void Awake()
    {
        LoadCSV(); 
    }

   void LoadCSV() 
{
    TextAsset csv = Resources.Load<TextAsset>("dialogue"); 
    
    if (csv == null)
    {
        Debug.LogError("CSV 파일을 찾을 수 없습니다!");
        return;
    }

    // Windows CSV의 \r\n 줄바꿈 처리
    string[] lines = csv.text.Split(new char[]{'\n', '\r'}, System.StringSplitOptions.RemoveEmptyEntries);
    
    string currentEvent = "";
    List<Dialogue> currentList = null;

    for (int i = 1; i < lines.Length; i++) 
    {
        if (string.IsNullOrWhiteSpace(lines[i])) continue; 

        // 쉼표 기준으로 최대 3개 열만 분리 (대사 안에 쉼표 있어도 안전)
        string[] row = lines[i].Split(new char[]{','}, 3);
        
        string eventName = row[0].Trim();
        string name = row.Length > 1 ? row[1].Trim() : "";
        string text = row.Length > 2 ? row[2].Trim() : "";

        if (eventName == "end") 
        {
            if (currentEvent != "" && currentList != null) 
            {
                dialogueDict[currentEvent] = currentList;
                Debug.Log($"저장 완료: [{currentEvent}] - {currentList.Count}줄");
            }
            currentEvent = ""; 
            currentList = null;
        }
        else if (eventName != "")
        {
            // 새 이벤트 시작
            currentEvent = eventName;
            currentList = new List<Dialogue>();
            
            // 같은 줄에 대사도 있으면 바로 추가
            if (text != "")
                currentList.Add(new Dialogue(name, text));
        }
        else if (currentList != null && text != "") 
        {
            // eventName이 비어있는 일반 대사 행
            currentList.Add(new Dialogue(name, text));
        }
    }
}
    public List<Dialogue> GetDialogue(string eventName)
    {
        return dialogueDict[eventName];
    }
}