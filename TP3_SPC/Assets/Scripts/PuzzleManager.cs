using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject radio;
    public AudioClip[] puzzleSounds;
    public AudioClip successSound;
    public AudioClip puzzleCompleteSound;
    public Transform teleportPoint;

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
        TeleportPlayer();
        puzzleStarted = false;
        canFindObject = false;
    }

    private void TeleportPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = teleportPoint.position;
        }
    }

    private void ResetRadioTrigger()
    {
        canTriggerRadio = true;
    }
}
