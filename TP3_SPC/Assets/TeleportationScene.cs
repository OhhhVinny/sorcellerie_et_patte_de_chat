using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TeleportationScene : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "interieurExit"){
            SceneManager.LoadScene(1);
        }
        else if(other.tag == "exterieurExit"){
            SceneManager.LoadScene(2);
        }
        else if(other.tag == "vincentEnter"){
            SceneManager.LoadScene(4);
        }
        else if(other.tag == "jeremyEnter"){
            SceneManager.LoadScene(3);
        }

    }


}
