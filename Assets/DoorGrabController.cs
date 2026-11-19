
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;

public class DoorGrabController : MonoBehaviour
{
    public GameManager gameManager;
    public HandGrabInteractable handGrabInteractable;
    public GameObject escapeMessage;
    public ExitDoorAnimator doorAnimator;

    private bool escaped = false;

    private void OnEnable()
    {
        if (handGrabInteractable != null)
            handGrabInteractable.WhenSelectingInteractorAdded.Action += OnGrabbed;
    }

    private void OnDisable()
    {
        if (handGrabInteractable != null)
            handGrabInteractable.WhenSelectingInteractorAdded.Action -= OnGrabbed;
    }

    private void OnGrabbed(HandGrabInteractor interactor)
    {
        if (escaped)
            return;

        Debug.Log("Door grabbed!");

        if (gameManager.completedPuzzles >= gameManager.totalPuzzles)
        {
            escaped = true;
            doorAnimator.OpenDoors();
            escapeMessage.SetActive(true);
            gameManager.ShowWinScreen();
        }
        else
        {
            Debug.Log("The exit is locked! Complete all puzzles first.");
        }
    }
}
