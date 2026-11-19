
using UnityEngine;

public class GhostDisposal : MonoBehaviour
{
    public GameObject trash;

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == trash.GetComponent("CapsuleCollider"))
        {
            Destroy(gameObject);
        }
    }
}
