
using UnityEngine;
using UnityEngine.Events;

public class CircuitManager : MonoBehaviour
{
    public enum OutputState
    {
        High,
        Low,
        Floating,
        ShortCircuit
    }

    [Header("Transistors")]
    [SerializeField] private Transistor t1;
    [SerializeField] private Transistor t2;
    [SerializeField] private Transistor t3;
    [SerializeField] private Transistor t4;

    [Header("Inputs")]
    [SerializeField] private InputSwitch inputA;
    [SerializeField] private InputSwitch inputB;

    [Header("Output Indicator")]
    [SerializeField] private Renderer outputRenderer;
    [SerializeField] private Material highMaterial;
    [SerializeField] private Material lowMaterial;

    [Header("Puzzle Completion")]
    [SerializeField] private UnityEvent onPuzzleSolved;

    private bool puzzleSolved;

    public OutputState CurrentOutput { get; private set; }

    private bool Conducts(Transistor transistor, bool input)
    {
        if (transistor.transistorType == Transistor.TransistorType.NMOS)
            return input;

        return !input;
    }

    private OutputState CalculateOutput(bool a, bool b)
    {
        // Parallel pull-up network
        bool pullUp = Conducts(t1, a) || Conducts(t2, b);

        // Series pull-down network
        bool pullDown = Conducts(t3, a) && Conducts(t4, b);

        if (pullUp && pullDown)
            return OutputState.ShortCircuit;

        if (!pullUp && !pullDown)
            return OutputState.Floating;

        return pullUp ? OutputState.High : OutputState.Low;
    }

    private bool IsCorrectNand()
    {
        return CalculateOutput(false, false) == OutputState.High
            && CalculateOutput(false, true) == OutputState.High
            && CalculateOutput(true, false) == OutputState.High
            && CalculateOutput(true, true) == OutputState.Low;
    }

    private void Update()
    {
        CurrentOutput = CalculateOutput(inputA.IsOn, inputB.IsOn);

        if (outputRenderer != null)
        {
            outputRenderer.material =
                CurrentOutput == OutputState.High
                    ? highMaterial
                    : lowMaterial;
        }

        if (!puzzleSolved && IsCorrectNand())
        {
            puzzleSolved = true;
            Debug.Log("NAND circuit solved!");
            onPuzzleSolved?.Invoke();
        }
    }
}
