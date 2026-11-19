
using UnityEngine;

public class BroomSweeper : MonoBehaviour
{
    public SweepingPuzzleManager puzzleManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Splatter"))
        {
            Destroy(other.gameObject);
            puzzleManager.CleanSplatter();
        }
    }
}
