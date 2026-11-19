
using UnityEngine;

public class ChandelierController : MonoBehaviour
{
    [SerializeField] private Light[] lights;
    [SerializeField] private AudioSource audioSource;

    public void TurnOn()
    {
        foreach (Light light in lights)
        {
            if (light != null)
            {
                light.enabled = true;
            }
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
