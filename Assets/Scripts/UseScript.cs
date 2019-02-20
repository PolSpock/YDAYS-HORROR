using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("zizi");
                Debug.Log(hit.transform.gameObject);
                // the object identified by hit.transform was clicked
                // do whatever you want
            }
        }
    }
}
