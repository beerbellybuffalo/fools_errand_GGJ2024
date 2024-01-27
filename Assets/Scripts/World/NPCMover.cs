
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{

    public bool isMoveLeft = false;
    public float moveSpeed = 1f;
    public GameObject chatBubblePrefab;
    public string dialogue = "aaaaaaaaaaaaaaaaa";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("collide");
        if (dialogue.Length <= 0) return;

        GameObject a = Instantiate(chatBubblePrefab, transform);
        a.GetComponent<ChatBubble>().StartChatBubble(dialogue);
    }

    
}
