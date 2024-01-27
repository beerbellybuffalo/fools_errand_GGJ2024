
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    public bool canMove = true;
    float moveSpeed = 0;
    public GameObject chatBubblePrefab;
    public string dialogue = "";

    private void Awake()
    {
        moveSpeed = Random.Range(0.5f, 1f) * (Random.Range(0, 2) == 0 ? 1 : -1);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != PlayerInteract.instance.gameObject) return;
        if (dialogue.Length <= 0) return;

        GameObject a = Instantiate(chatBubblePrefab, transform);
        a.GetComponent<ChatBubble>().StartChatBubble(dialogue);
    }

    public void Update()
    {
        if (!canMove) return;

        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -11)
        {
            transform.position = new Vector3(10, transform.position.y, 0);
        }
        else if (transform.position.x > 11)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);
        }
    }


}
