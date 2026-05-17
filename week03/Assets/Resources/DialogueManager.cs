using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueLoader loader;
    public string eventName;

    [Tooltip("대사 사이 대기 시간 (초)")]
    public float delay = 1.5f;

    List<Dialogue> dialogueList;

    void Start()
    {
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        dialogueList = loader.GetDialogue(eventName);

        if (dialogueList == null) yield break;

        for (int i = 0; i < dialogueList.Count; i++)
        {
            string name = dialogueList[i].name;
            string text = dialogueList[i].text.Replace("\\n", "\n");
            Debug.Log(name + ": " + text);

            yield return new WaitForSeconds(delay);
        }

        Debug.Log("--- 대화 종료 ---");
    }
}