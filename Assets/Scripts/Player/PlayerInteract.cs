using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public List<Interactable> equipped;
    private Interactable interactable;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("TriggerEnter");
        Interactable a = collision.gameObject.GetComponent<Interactable>();
        if (a == null) return;
        this.interactable = a ;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Interactable a = collision.gameObject.GetComponent<Interactable>();
        if (a == null) return;
        if(interactable == a)
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
        for(int i = 0; i < equipped.Count; i++)
        {
            if(equipped[i].Slot == interactable.Slot)
            {
                isSlotEmpty = false;
                DropInteractable(equipped[i]);
                equipped.Remove(equipped[i]);

                EquipInteractable(interactable);
                return;
            }
        }
        if (isSlotEmpty)
        {
            EquipInteractable(interactable);
        }
    }

    private void DropInteractable(Interactable input)
    {   
        
        GameObject a = Instantiate(input.prefab, transform.position, transform.rotation);
        a.SetActive(true);
        Destroy(input.gameObject);
    }

    private void EquipInteractable(Interactable inp)
    {
        inp.gameObject.transform.parent = transform;
        equipped.Add(inp);

        inp.gameObject.SetActive(false);
    }
}
