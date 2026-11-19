
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPuzzles = 4;
    public int completedPuzzles = 0;

    public TMP_Text scoreText;

    private HashSet<string> completedPuzzleIDs = new HashSet<string>();

    public void CompletePuzzle(string puzzleID)
    {
        // Prevent a puzzle from counting more than once
        if (!completedPuzzleIDs.Add(puzzleID))
            return;

        completedPuzzles++;

        Debug.Log("Puzzles completed: " + completedPuzzles);

        if (completedPuzzles >= totalPuzzles)
        {
            scoreText.text = "TASKS\nCOMPLETED\n\n4 / 4\n\nYOU WIN!";
        }
        else
        {
            scoreText.text = "TASKS\nCOMPLETED\n\n"
                + completedPuzzles + " / " + totalPuzzles
                + "\n\nEXIT LOCKED";
        }
    }

    private void Start()
    {
        scoreText.text = "TASKS\nCOMPLETED\n\n0 / "
            + totalPuzzles + "\n\nEXIT LOCKED";
    }
}
