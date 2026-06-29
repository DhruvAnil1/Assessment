using System.Collections;
using UnityEngine;


/// Handles the state and feedback for a single interactable cube.
[RequireComponent(typeof(CubeRandomiser))]
public class InteractableCube : MonoBehaviour
{
    [Header("Flash Settings")]
    [SerializeField] private float flashDuration = 0.3f;   

    // Public flag read by GameManager to determine the correct answer
    [HideInInspector] public bool isCorrect;

    // Internal state
    private bool _isDisabled;                             
    private CubeRandomiser _randomiser;
    private Color _originalColour;

    private void Awake()
    {
        _randomiser = GetComponent<CubeRandomiser>();
    }

   
    /// Called by GameManager after colours are set, so we can cache the starting colour.
    public void Initialise()
    {
        _originalColour = GetComponent<Renderer>().material.color;
        _isDisabled = false;
    }

   
    /// Returns false if this cube should no longer accept interactions.
    public bool CanInteract() => !_isDisabled;

    //Correct behaviour

    /// Turn white and lock out further interaction.
    public void OnCorrect()
    {
        _isDisabled = true;
        _randomiser.SetColour(Color.white);
    }

    //Wrong behaviour 

    /// Briefly flash red, then revert to the original colour.
    public void OnWrong()
    {
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        _randomiser.SetColour(Color.red);
        yield return new WaitForSeconds(flashDuration);
        _randomiser.SetColour(_originalColour);            // Restore original colour
    }
}
