using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintingDisposal : MonoBehaviour
{
    public bool haunted;
    public GameObject trash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == trash.GetComponent("CapsuleCollider"))
        {
            if (haunted) {
                Destroy(this);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
    }
}
