using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public GameObject correctObject; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Radio"))
            {
                puzzleManager.PlayCurrentSound();
            }
            else
            {
                puzzleManager.CheckObject(gameObject, correctObject);
            }
        }
    }
}
