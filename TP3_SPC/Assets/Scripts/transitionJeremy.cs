using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class transitionJeremy : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(3);
    }
}