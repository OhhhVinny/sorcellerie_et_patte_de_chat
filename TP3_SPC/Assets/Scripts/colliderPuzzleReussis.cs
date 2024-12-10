using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ColliderPuzzleReussis : MonoBehaviour
{
    public int puzzleID; // Assigne 1 pour Puzzle1, 2 pour Puzzle2 dans l'Inspector.

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le joueur qui entre dans le collider
        if (other.CompareTag("Player"))
        {
            if (puzzleID == 1 && GameManager.Instance.Puzzle1Solved)
            {
                SceneManager.LoadScene("mainInterieur");
            }
            else if (puzzleID == 2 && GameManager.Instance.Puzzle2Solved)
            {
                SceneManager.LoadScene("mainInterieur");
            }
        }
    }
}

