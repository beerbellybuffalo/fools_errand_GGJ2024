using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitSwapper : MonoBehaviour
{
    // public PlayerInteract playerInteract;
    public GameObject Head;
    public GameObject Torso;
    public GameObject Pants;

    public void swapOutfit(Interactable inp)
    {
        if (inp.Slot == Interactable.SlotType.HEAD)
        {
            Head.GetComponent<SpriteRenderer>().sprite = inp.equippedSprite;
        }
        else if (inp.Slot == Interactable.SlotType.TORSO)
        {
            Torso.GetComponent<SpriteRenderer>().sprite = inp.equippedSprite;
        }
        else if (inp.Slot == Interactable.SlotType.PANTS)
        {
            Pants.GetComponent<SpriteRenderer>().sprite = inp.equippedSprite;
        }
    }
}
