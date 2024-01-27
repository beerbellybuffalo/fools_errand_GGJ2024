using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public List<GameObject> Levels;
    public int timeLeft = 60;

    public static World CurrentWorld;

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


}
