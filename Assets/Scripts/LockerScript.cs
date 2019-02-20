using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            print("up arrow key is held down");
        }

        if (Input.GetKey("down"))
        {
            print("down arrow key is held down");
        }
    }
}
