using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public enum SlotType
    {
          HEAD,
          TORSO,
          PANTS
    }

    public SlotType Slot;

    public GameObject prefab;


}
