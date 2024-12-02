using UnityEngine;
using UnityEngine.UI; // Si tu utilises un UI classique
using TMPro; // Si tu utilises TextMeshPro

public class cageTrigger : MonoBehaviour
{
    public Animator cage; // L'Animator contenant l'animation leverCage
    public GameObject textBubble; // Référence à la bulle de texte (UI Text ou TextMeshPro)
    public AudioSource audioSource; // Référence à l'AudioSource pour jouer le son witch
    public AudioSource meow; // Référence à l'AudioSource pour jouer le son chat

    private void Start()
    {
        // Assure que la bulle de texte est cachée au départ
        textBubble.SetActive(false);

        // Si tu as déjà attaché les AudioSources via l'Inspector, tu n'as pas besoin de GetComponent ici.
        // Si tu veux les récupérer dans le code, fais-le de manière appropriée.

        // Si les AudioSource ne sont pas assignés via l'Inspector, on les récupère.
        if (audioSource == null)
            audioSource = GetComponents<AudioSource>()[0];  // Récupère le premier AudioSource
        if (meow == null)
            meow = GetComponents<AudioSource>()[1];  // Récupère le deuxième AudioSource

        audioSource.volume = 0.7f;

        // Ne joue pas le son au démarrage de la scène
        if (audioSource != null && meow != null)
        {
            audioSource.Stop();  // Assure que le son ne se joue pas à l'initialisation
            meow.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le joueur et si les deux puzzles sont résolus
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.Puzzle1Solved && GameManager.Instance.Puzzle2Solved)
            {
                // Si les puzzles sont résolus, lance l'animation
                cage.Play("leverCage");
                PlayMeow();  // Joue le son du chat en même temps
            }
            else
            {
                // Si les puzzles ne sont pas résolus, affiche la bulle de texte
                ShowTextBubble(true);
                PlaySound();  // Joue le son associé à la bulle
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Masque la bulle de texte lorsque le joueur sort du collider
        if (other.CompareTag("Player"))
        {
            ShowTextBubble(false);
        }
    }

    // Fonction pour afficher ou cacher la bulle de texte
    private void ShowTextBubble(bool show)
    {
        // Active ou désactive la bulle de texte
        textBubble.SetActive(show);
    }

    // Fonction pour jouer le son
    private void PlaySound()
    {
        if (audioSource != null)
        {
            // Joue le son de la bulle
            audioSource.Play();
        }
    }

    // Fonction pour jouer le son du chat
    private void PlayMeow()
    {
        if (meow != null)
        {
            // Joue le son du chat
            meow.Play();
        }
    }
}
