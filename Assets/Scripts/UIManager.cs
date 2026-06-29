using System.Collections;
using UnityEngine;
using UnityEngine.UI;



/// Owns and controls all on-screen UI elements.

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text feedbackText;            

    [Header("Timing")]
    [SerializeField] private float messageDisplayTime = 1.5f;

    private Coroutine _hideCoroutine;

    private void Start()
    {
        HideMessage();
    }

    
    /// Show the "Correct!" message. It stays until manually cleared or game ends.
    public void ShowCorrect()
    {
        StopAnyRunningHide();
        feedbackText.text = "Correct!";
        feedbackText.color = Color.green;
        feedbackText.gameObject.SetActive(true);

        // Auto-hide after a delay
        _hideCoroutine = StartCoroutine(HideAfterDelay(messageDisplayTime));
    }

   
    /// Show the "Try Again" message briefly.
    public void ShowTryAgain()
    {
        StopAnyRunningHide();
        feedbackText.text = "Try Again";
        feedbackText.color = Color.red;
        feedbackText.gameObject.SetActive(true);

        _hideCoroutine = StartCoroutine(HideAfterDelay(messageDisplayTime));
    }

    

    private void HideMessage()
    {
        feedbackText.gameObject.SetActive(false);
    }

    private void StopAnyRunningHide()
    {
        if (_hideCoroutine != null)
        {
            StopCoroutine(_hideCoroutine);
            _hideCoroutine = null;
        }
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HideMessage();
    }
}
