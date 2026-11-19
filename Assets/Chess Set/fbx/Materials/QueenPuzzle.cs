
using UnityEngine;

public class QueenPuzzle : MonoBehaviour
{
    public Transform startingPosition;
    public Transform correctPosition;

    private bool puzzleSolved = false;

    void Start()
    {
        transform.position = startingPosition.position;
        transform.rotation = startingPosition.rotation;
    }

    public void OnQueenReleased()
    {
        if (puzzleSolved)
            return;

        float distance = Vector3.Distance(
            transform.position,
            correctPosition.position
        );

        if (distance < 0.3f)
        {
            transform.position = correctPosition.position;
            transform.rotation = correctPosition.rotation;

            puzzleSolved = true;

            Debug.Log("CHECKMATE! Puzzle Solved!");
        }
        else
        {
            transform.position = startingPosition.position;
            transform.rotation = startingPosition.rotation;
        }
    }
}
