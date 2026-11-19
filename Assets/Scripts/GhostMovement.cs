
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 0.3f;
    public float changeDirectionTime = 3f;
    public float movementRadius = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 direction;
    private float timer;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        startPosition = transform.position;
        ChooseDirection();

        AudioSource audio = GetComponent<AudioSource>();

        if (!audio.isPlaying)
        {
            audio.Play();
        }

    }

    void FixedUpdate()
    {
        // No moving while grabbed
        if (rb.isKinematic)
            return;

        timer -= Time.fixedDeltaTime;

        if (timer <= 0f ||
            Vector3.Distance(transform.position, startPosition) > movementRadius)
        {
            ChooseDirection();
        }

        Vector3 desiredVelocity = direction * speed;

        rb.linearVelocity = Vector3.Lerp(
            rb.linearVelocity,
            desiredVelocity,
            Time.fixedDeltaTime * 2f
        );
    }

    void ChooseDirection()
    {
        Vector3 randomPoint = startPosition +
            Random.insideUnitSphere * movementRadius;

        direction = (randomPoint - transform.position).normalized;
        timer = changeDirectionTime;
    }
}
