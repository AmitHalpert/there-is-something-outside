using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseMainDoor : MonoBehaviour
{


    private bool doorOpen = false;

    void Update()
    {

        if (doorOpen)
        {
            Debug.Log("IsOpenPanelActive");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("opened door");
                SceneManager.LoadScene("TheRoad", LoadSceneMode.Single);
            }
        }

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Enter");
            doorOpen = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Exit");
            doorOpen = false;
        }
    }
   
}
