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
            // Met à jour l'état du puzzle dans le GameManager
            if (puzzleID == 1) GameManager.Instance.Puzzle1Solved = true;
            else if (puzzleID == 2) GameManager.Instance.Puzzle2Solved = true;

            // Retourne à la scène principale
            SceneManager.LoadScene("mainInterieur");
        }
    }

}

