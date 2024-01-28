using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    public string connection = "";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(connection == "cityLeft")
        {
            WorldManager.instance.CityLeft();
        }
        else if (connection == "cityRight")
        {
            WorldManager.instance.CityRight();
        }
        else if (connection == "gardenRight")
        {
            WorldManager.instance.GardenRight();
        }
        else if(connection == "gardenLeft")
        {
            WorldManager.instance.GardenLeft();
        }


    }
}
