
using UnityEngine;
using TMPro;

public class Transistor : MonoBehaviour
{
    public enum TransistorType
    {
        NMOS,
        PMOS
    }

    public TransistorType transistorType = TransistorType.NMOS;

    public TextMeshPro typeLabel;
    public Renderer baseRenderer;

    public Material nmosMaterial;
    public Material pmosMaterial;

    private void Start()
    {
        UpdateAppearance();
    }

    private void OnMouseDown()
    {
        ToggleType();
    }

    public void ToggleType()
    {
        if (transistorType == TransistorType.NMOS)
        {
            transistorType = TransistorType.PMOS;
        }
        else
        {
            transistorType = TransistorType.NMOS;
        }

        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        bool isNMOS =
            transistorType == TransistorType.NMOS;

        if (typeLabel != null)
        {
            typeLabel.text = isNMOS ? "NMOS" : "PMOS";
        }

        if (baseRenderer != null)
        {
            baseRenderer.material =
                isNMOS ? nmosMaterial : pmosMaterial;
        }
    }
}
