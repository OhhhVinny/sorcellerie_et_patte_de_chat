using UnityEngine;

public class mainInterieur : MonoBehaviour
{
    // Lumières pour Puzzle1
    public Light puzzle1Light1;
    public Light puzzle1Light2;

    // Lumières pour Puzzle2
    public Light puzzle2Light1;
    public Light puzzle2Light2;

    private void Start()
    {
        // Active les lumières liées au Puzzle1
        if (GameManager.Instance.Puzzle1Solved)
        {
            puzzle1Light1.enabled = true;
            puzzle1Light2.enabled = true;
        }

        // Active les lumières liées au Puzzle2
        if (GameManager.Instance.Puzzle2Solved)
        {
            puzzle2Light1.enabled = true;
            puzzle2Light2.enabled = true;
        }

        if(GameManager.Instance.Puzzle1Solved && GameManager.Instance.Puzzle2Solved){
            
        }
    }
}
