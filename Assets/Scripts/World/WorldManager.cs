using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{

    public GameObject City;
    public GameObject Garden;
    public int timeLeft = 60;

    public static GameObject CurrentWorld;
    public Image clock;

    public static WorldManager instance;

    private void Start()
    {
        if (instance == null) instance = this;
        StartTimer();
        CurrentWorld = City;
    }
    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    public IEnumerator TimerCoroutine()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft -= 1;
            clock.fillAmount = timeLeft / 60f;
        }
        OnTimerExpire();
        yield return null;

    }

    public void OnTimerExpire()
    {
        if (PlayerHasInteractable("Dog"))
        {
            print("woof");
        }
    }

    public bool PlayerHasInteractable(string interactableName)
    {
        foreach (Interactable a in PlayerInteract.instance.equipped)
        {
            if (a.prefabName == interactableName)
                return true;
        }
        return false;
    }

    public void CityLeft()
    {
       
        foreach (Transform child in PlayerInteract.instance.transform.parent)
        {
            child.transform.position += new Vector3(-9, 0, 0);
        }
        City.SetActive(true);
        Garden.SetActive(false);
        CurrentWorld = City;
    }

    public void CityRight()
    {
        foreach (Transform child in PlayerInteract.instance.transform.parent)
        {
            child.transform.position += new Vector3(9, 0, 0);
        }
        City.SetActive(true);
        Garden.SetActive(false);
        CurrentWorld = City;
    }

    public void GardenLeft()
    {
        foreach (Transform child in PlayerInteract.instance.transform.parent)
        {
            child.transform.position += new Vector3(-9, 0, 0);
        }
        City.SetActive(false);
        Garden.SetActive(true);
        CurrentWorld = Garden;
    }
    public void GardenRight()
    {
        foreach (Transform child in PlayerInteract.instance.transform.parent)
        {
            child.transform.position += new Vector3(9, 0, 0);
        }
        City.SetActive(false);
        Garden.SetActive(true);
        CurrentWorld = Garden;
    }
}
