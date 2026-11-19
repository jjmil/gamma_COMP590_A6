
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPuzzles = 4;
    public int completedPuzzles = 0;
    public TMP_Text scoreText;

    public float timeLimit = 600f;
    private float timeRemaining;
    private bool gameStarted = false;
    private bool gameOver = false;

    private HashSet<string> completedPuzzleIDs = new HashSet<string>();

    private void Start()
    {
        timeRemaining = timeLimit;
        gameStarted = true;
        UpdateScoreboard();
    }

    private void Update()
    {
        if (!gameStarted || gameOver)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            gameOver = true;

            scoreText.text = "TIME'S UP!\n\nYOU LOST!";
            Debug.Log("TIME'S UP! YOU LOST!");

            Invoke(nameof(RestartGame), 5f);
            return;
        }

        UpdateScoreboard();
    }

    public void CompletePuzzle(string puzzleID)
    {
        if (!gameStarted || gameOver)
            return;

        if (!completedPuzzleIDs.Add(puzzleID))
            return;

        completedPuzzles++;

        Debug.Log("Puzzles completed: " + completedPuzzles);

        UpdateScoreboard();
    }

    private void UpdateScoreboard()
    {
        string exitStatus = completedPuzzles >= totalPuzzles
            ? "EXIT UNLOCKED"
            : "EXIT LOCKED";

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        string timer = minutes.ToString("00") + ":"
            + seconds.ToString("00");

        scoreText.text = "TASKS COMPLETED\n"
            + completedPuzzles + " / " + totalPuzzles
            + "\n\nTIME REMAINING\n" + timer
            + "\n\n" + exitStatus;
    }

    public void ShowWinScreen()
    {
        if (!gameStarted || gameOver ||
            completedPuzzles < totalPuzzles)
            return;

        gameOver = true;

        scoreText.text = "YOU ESCAPED!\n\nYOU WIN!";

        Debug.Log("YOU ESCAPED! YOU WIN!");
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
