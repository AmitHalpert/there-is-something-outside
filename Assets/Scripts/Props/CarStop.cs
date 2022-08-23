using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarStop : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
            
        if (other.gameObject.tag == "InteractiveObject")
        {
            SceneManager.LoadScene("TheMarket", LoadSceneMode.Single);
        }
    }

}
