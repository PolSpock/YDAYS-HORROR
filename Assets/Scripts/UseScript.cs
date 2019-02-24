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
            if (Physics.Raycast(ray, out hit, 1f))
            {
                Debug.Log("touché");
                Debug.Log(hit.transform.gameObject);

               if (hit.transform.tag == "bedInteraction")
               {
                    Debug.Log("Je suis bedInteraction");
               }
            }
        }
    }
}
