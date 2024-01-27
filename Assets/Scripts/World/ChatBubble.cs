using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{

    public TextMeshPro textField;
    public float charDelay = 0.1f;


    public void StartChatBubble(string dialogue)
    {
        StartCoroutine(DisplayChatBubble(dialogue));
    }

    private IEnumerator DisplayChatBubble(string dialogue)
    {
        string chat = "";
        foreach(char x in dialogue)
        {
            chat += x;
            yield return new WaitForSeconds(charDelay);
            textField.SetText(chat);
        }


        Destroy(gameObject, 1f);
    }
}
