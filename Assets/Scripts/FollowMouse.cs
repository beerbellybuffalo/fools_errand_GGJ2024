using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z.
        transform.position = mouseWorldPos;
// transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
