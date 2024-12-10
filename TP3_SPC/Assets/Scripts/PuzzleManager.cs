using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject radio;
    public AudioClip[] puzzleSounds;
    public AudioClip successSound;
    public AudioClip puzzleCompleteSound;

    private AudioSource audioSource;
    private int currentSoundIndex = 0;
    private bool puzzleStarted = false;
    private bool canFindObject = false;
    private bool canTriggerRadio = true; 
    public float radioTriggerCooldown = 2f; 

    void Start()
    {
        audioSource = radio.GetComponent<AudioSource>();
    }

    public void StartPuzzle()
    {
        if (!puzzleStarted && canTriggerRadio)
        {
            puzzleStarted = true;
            PlayCurrentSound();
        }
    }

    public void PlayCurrentSound()
    {
        if (currentSoundIndex < puzzleSounds.Length && canTriggerRadio)
        {
            canTriggerRadio = false;
            audioSource.PlayOneShot(puzzleSounds[currentSoundIndex]);
            canFindObject = true;
            Invoke(nameof(ResetRadioTrigger), radioTriggerCooldown);
        }
    }

    public void CheckObject(GameObject triggeredObject, GameObject correctObject)
    {
        if (!canFindObject)
        {
            Debug.Log("Return to the radio to play the next sound.");
            return;
        }

        if (triggeredObject == correctObject)
        {
            audioSource.PlayOneShot(successSound);
            currentSoundIndex++;

            if (currentSoundIndex < puzzleSounds.Length)
            {
                Debug.Log("Return to the radio for the next sound.");
                canFindObject = false;
            }
            else
            {
                CompletePuzzle();
            }
        }
        else
        {
            Debug.Log("Wrong object! Try again.");
        }
    }

    private void CompletePuzzle()
    {
        Debug.Log("Puzzle Complete!");
        audioSource.PlayOneShot(puzzleCompleteSound);
        puzzleStarted = false;
        canFindObject = false;

// Marque le puzzle 2 comme résolu dans le GameManager
        GameManager.Instance.Puzzle2Solved = true;
    }


    private void ResetRadioTrigger()
    {
        canTriggerRadio = true;
    }
}
