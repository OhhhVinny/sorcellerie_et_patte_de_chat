using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // État des puzzles
    public bool Puzzle1Solved = false;
    public bool Puzzle2Solved = false;

private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameManager instance created");
    }
    else
    {
        Debug.LogWarning("Duplicate GameManager instance destroyed");
        Destroy(gameObject);
    }
}
}

