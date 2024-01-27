using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public Transform SpawnPos;
    public Transform RightSpawnPos;
    public Transform LeftSpawnPos;



    public void EnterCenter()
    {
        PlayerInteract.instance.gameObject.transform.position = SpawnPos.transform.position;
    }

    public void EnterLeft()
    {
        PlayerInteract.instance.gameObject.transform.position = LeftSpawnPos.transform.position;

    }

    public void EnterRight()
    {
        PlayerInteract.instance.gameObject.transform.position = RightSpawnPos.transform.position;

    }


}
