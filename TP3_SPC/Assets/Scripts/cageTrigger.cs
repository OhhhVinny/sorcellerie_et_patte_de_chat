using UnityEngine;

public class cageTrigger : MonoBehaviour
{
    public Animator cage; // L'Animator contenant l'animation leverCage

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le joueur et si les deux puzzles sont résolus
        if (other.CompareTag("Player") && GameManager.Instance.Puzzle1Solved && GameManager.Instance.Puzzle2Solved)
        {
            // Déclenche l'animation leverCage
            cage.Play("leverCage"); // Jouer l'animation directement
        }
    }
}
