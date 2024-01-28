using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public List<Interactable> equipped;
    private OutfitSwapper outfitSwapper;
    private Interactable interactable;
    public GameObject chatBubble;

    private bool isDogInteractionComplete = false;
    private bool isDoorInteractionComplete = false;

    void Start()
    {
        if (instance == null) instance = this;
        outfitSwapper = gameObject.transform.parent.GetComponent<OutfitSwapper>();
    }

    public string DogWantBurgerText = "Dis not Borgor :(";
    public string MissingKeyText = "Perhaps I need a key...";

    public static PlayerInteract instance;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("TriggerEnter");
        Interactable a = collision.gameObject.GetComponent<Interactable>();
        if (a == null) return;
        this.interactable = a;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Interactable a = collision.gameObject.GetComponent<Interactable>();
        if (a == null) return;
        if (interactable == a)
        {
            interactable = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            OnInteractKeyPressed();
        }
    }

    private void OnInteractKeyPressed()
    {
        if (interactable == null) return;
        bool isSlotEmpty = true;
        for (int i = 0; i < equipped.Count; i++)
        {
            if (equipped[i].Slot == interactable.Slot)
            {
                isSlotEmpty = false;

                SwapInteractable(equipped[i], interactable);

                return;
            }
        }
        if (isSlotEmpty)
        {
            EquipInteractable(interactable);
        }
    }

    private void SwapInteractable(Interactable oldInteractable, Interactable newInteractable)
    {
        //Dog Interaction
        if (newInteractable.prefabName == "Dog" && !isDogInteractionComplete)
        {

            Interactable burger = null;
            foreach (Interactable c in equipped)
            {
                if (c.prefabName == "Burger")
                {
                    burger = c;
                }
            }


            if (burger == null)
            {
                GameObject obj = Instantiate(chatBubble, newInteractable.transform);
                ChatBubble bubble = obj.GetComponent<ChatBubble>();
                bubble.StartChatBubble(DogWantBurgerText);
                return;
            }
            else
            {
                isDogInteractionComplete = true;
                equipped.Remove(burger);
                EquipInteractable(interactable);
                return;
            }

        }
        //Door Interaction
        if (newInteractable.prefabName == "Door" && !isDoorInteractionComplete)
        {


            Interactable key = null;
            foreach (Interactable c in equipped)
            {
                if (c.prefabName == "Key")
                {
                    key = c;
                }
            }

            if (key == null)
            {
                GameObject obj = Instantiate(chatBubble, transform);
                ChatBubble bubble = obj.GetComponent<ChatBubble>();
                bubble.StartChatBubble(MissingKeyText);
                return;
            }
            else
            {
                isDoorInteractionComplete = true;
                equipped.Remove(oldInteractable);
                EquipInteractable(interactable);
                return;
            }



        }

        DropInteractable(oldInteractable);
        equipped.Remove(oldInteractable);
        EquipInteractable(interactable);
    }


    private void DropInteractable(Interactable input)
    {

        //GameObject a = Instantiate(input.prefab, WorldManager.CurrentWorld.transform);
        GameObject a = Instantiate(input.prefab, transform.position,transform.rotation);
        a.transform.localScale = a.transform.lossyScale;//new Vector3(,1,1f);

        a.SetActive(true);
        Destroy(input.gameObject);
    }

    private void EquipInteractable(Interactable inp)
    {
        inp.gameObject.transform.SetParent(transform, false);
        equipped.Add(inp);

        outfitSwapper.swapOutfit(inp);

        inp.gameObject.SetActive(false);
    }
}
