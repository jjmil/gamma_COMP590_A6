
using UnityEngine;

public class ExitDoorAnimator : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;

    public float openAngle = 90f;

    public void OpenDoors()
    {
        leftDoor.localRotation = Quaternion.Euler(
            0, -openAngle, 0);

        rightDoor.localRotation = Quaternion.Euler(
            0, openAngle, 0);
    }
}
