using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintingDisposal : MonoBehaviour
{
    public bool haunted;
    public GameObject trash;
    public GameObject ghost;
    public GameManager gameManager;

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
                ghost.SetActive(true);
                gameManager.CompletePuzzle("PaintDisposal");
                Destroy(gameObject);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
    }
}
