using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour
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

                if (hit.transform.tag == "bouton1")
                {
                    Debug.Log("Je suis bouton1");
                    hit.transform.gameObject.SetActive(false);
                    GameObject activeB2 = GameObject.FindWithTag("bouton2");
                    activeB2.SetActive(true);
                }
                else if(hit.transform.tag == "bouton2")
                {
                    Debug.Log("Je suis bouton2");
                    hit.transform.gameObject.SetActive(false);
                    GameObject activeB3 = GameObject.FindWithTag("bouton3");
                    activeB3.SetActive(true);
                }
               
            }
        }
    }
}
