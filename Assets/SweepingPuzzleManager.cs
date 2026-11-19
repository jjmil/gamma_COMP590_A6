
using UnityEngine;

public class SweepingPuzzleManager : MonoBehaviour
{
    public int remainingSplatters = 3;
    public GameManager gameManager;

    public void CleanSplatter()
    {
        if (remainingSplatters <= 0)
            return;

        remainingSplatters--;

        Debug.Log("Splatters remaining: " + remainingSplatters);

        if (remainingSplatters == 0)
        {
            Debug.Log("PUZZLE COMPLETE!");
            gameManager.CompletePuzzle("Sweeping");
        }
    }
}
