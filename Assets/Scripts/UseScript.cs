using UnityEngine;

public class UseScript : MonoBehaviour
{
    //Name this variable "ShowText" then drag the "ShowText" script into the variable through the inspector.
    public ShowTextScript textDisplayingScript;
    public ScreamerScript screamerScript;


    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientIntensity = 1f;

        textDisplayingScript.DisplayTextHereFor("Bon...j’aimerai voir son visage une dernière fois, elle doit être sous ces draps...", 10, 50, 10);
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

                    screamerScript.StartScreamer();

                    //Shows two lines of text at the bottom left of the screen (10 pixels from the left and 50 from the bottom).
                    //The text lasts for 5 seconds before it disappears.
                    textDisplayingScript.DisplayTextHereFor("Elle doit surement être dans les casiers, la dernière fois elle l’a sortie du n°9...", 10, 50, 10);
                }

                if (hit.transform.tag == "lockerInteraction")
                {
                    Debug.Log("Je suis lockerInteraction");
                }
            }
        }
    }
}
