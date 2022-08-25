using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool TakeKey() {
        Destroy(gameObject);

        return true;
    }



}
