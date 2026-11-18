
using UnityEngine;

public class InputSwitch : MonoBehaviour
{
    [SerializeField] private bool isOn = false;
    [SerializeField] private Renderer terminalRenderer;
    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;

    public bool IsOn => isOn;

    private void Start()
    {
        UpdateAppearance();
    }

    private void OnMouseDown()
    {
        isOn = !isOn;
        UpdateAppearance();

        Debug.Log(gameObject.name + ": " + (isOn ? "1" : "0"));
    }

    private void UpdateAppearance()
    {
        if (terminalRenderer != null)
        {
            terminalRenderer.material = isOn ? onMaterial : offMaterial;
        }
    }
}
