using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{


    private Animator doorAnim;
    private bool doorOpen = false;


    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            SceneManager.LoadScene("TheRoad", LoadSceneMode.Single);
            doorOpen = true;
        }
        else
        {
            doorOpen = false;
        }
    }

}
