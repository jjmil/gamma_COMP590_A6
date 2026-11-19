
using UnityEngine;

public class GhostDisposal : MonoBehaviour
{
    public GameObject trash;
    public GameManager gameManager;

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == trash.GetComponent("CapsuleCollider"))
        {
            gameManager.CompletePuzzle("Ghost");
            Destroy(gameObject);
        }
    }
}
