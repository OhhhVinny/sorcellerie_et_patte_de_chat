using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ColliderPuzzleReussis : MonoBehaviour
{
    public int puzzleID; // Assigne 1 pour Puzzle1, 2 pour Puzzle2 dans l'Inspector.

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger Entered by: {other.name}");

        if (other.CompareTag("Player"))
        {
            Debug.Log($"Puzzle ID: {puzzleID}");

            if (puzzleID == 1 && GameManager.Instance.Puzzle1Solved == false)
            {
                GameManager.Instance.Puzzle1Solved = true;
                            
                    Debug.Log("Puzzle1Solved state set to true in GameManager");
                    SceneManager.LoadScene("mainInterieur");

            }

            else if (puzzleID == 2 && GameManager.Instance.Puzzle2Solved)
            {
                Debug.Log("Puzzle 2 solved, loading mainInterieur");
                SceneManager.LoadScene("mainInterieur");
            }
        }
    }

}

