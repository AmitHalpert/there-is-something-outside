using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{

    private float rayLength = 0.7f;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private DoorController raycastedObj;

    [SerializeField] private KeyCode InteractKey = KeyCode.E;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool DoOnce;
    private bool TakenMainDoorKey = false;

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            raycastedObj = hit.collider.gameObject.GetComponent<DoorController>();
            switch (hit.collider.tag)
            {
                
                case "MainDoor":
                    Debug.Log("Found MainDoor");
                    if (TakenMainDoorKey)
                    {
                        crosshairChange(true);
                        if (Input.GetKeyDown(InteractKey))
                        {
                            SceneManager.LoadScene("TheRoad", LoadSceneMode.Single);
                        }
                    }
                    break;

                case "Door":
                    
                    if (!DoOnce)
                    {
                        crosshairChange(true);
                    }
                    isCrosshairActive = true;
                    DoOnce = true;

                    if (Input.GetKeyDown(InteractKey))
                    {
                        raycastedObj.PlayAnimation();
                    }
                    break;

                case "Key":
                    
                    if (Input.GetKeyDown(InteractKey))
                    {
                        TakenMainDoorKey = raycastedObj.TakeKey();
                    }

                    break;

            }

        }
        else
        {
            if (isCrosshairActive)
            {
                crosshairChange(false);
                DoOnce = false;
            }
        }
    }

    void crosshairChange(bool on)
    {
        if (on && !DoOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }

    }

}