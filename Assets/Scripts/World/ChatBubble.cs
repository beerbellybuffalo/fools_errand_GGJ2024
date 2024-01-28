using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{

    public TextMeshPro textField;
    public float charDelay = 0.1f;
    public bool isRunning = false;

    public void StartChatBubble(string dialogue)
    {
        if (isRunning) return;
        isRunning = true;
        StartCoroutine(DisplayChatBubble(dialogue));
    }

    private IEnumerator DisplayChatBubble(string dialogue)
    {
        isRunning = true;
        string chat = "";
        foreach(char x in dialogue)
        {
            chat += x;
            yield return new WaitForSeconds(charDelay);
            textField.SetText(chat);
        }
        yield return new WaitForSeconds(1f);
        isRunning = false;
        Destroy(gameObject);
    }
}
