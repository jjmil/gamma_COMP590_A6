using UnityEngine;

public class ShowDimensions : MonoBehaviour
{
    void Start()
    {
        Debug.Log("ShowDimensions script is running!");

        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0)
        {
            Debug.LogWarning("No renderers found!");
            return;
        }

        Bounds bounds = renderers[0].bounds;

        foreach (Renderer r in renderers)
            bounds.Encapsulate(r.bounds);

        Debug.Log("Floor dimensions (X, Y, Z): " + bounds.size);
    }
}