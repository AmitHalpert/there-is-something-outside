using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{


    private Animator doorAnim;
    private bool doorOpen = false;


    private void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {

        // checks if door is a scene portal (door without animations are portals)
        if(doorAnim == null)
        {
            SceneManager.LoadScene("TheRoad", LoadSceneMode.Single);
        }
        else
        {
            if (!doorOpen)
            {

                Debug.Log("OPEN");
                doorAnim.Play("DoorOpen", 0, 0.0f);
                doorOpen = true;

            }
            else
            {
                Debug.Log("DoorClose");
                doorAnim.Play("DoorClose", 0, 0.0f);
                doorOpen = false;
            }
        }
    }
}
