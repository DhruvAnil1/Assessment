using UnityEngine;
using UnityEngine.InputSystem;        // Requires Input System package
 
/// Fires a raycast from the camera each frame.
/// On mouse-click, notifies GameManager which cube was hit.
public class RaycastSelector : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private float rayDistance = 20f;      // Max distance the ray travels
    [SerializeField] private LayerMask cubeLayer;          // Set to the layer your cubes are on
 
    private Camera _camera;
    private GameManager _gameManager;
 
    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _gameManager = FindObjectOfType<GameManager>();
    }
 
    private void Update()
    {
       
        if (Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame) return;
 
        
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = _camera.ScreenPointToRay(mousePos);
 
        // Fires the ray and checks if it hits anything on the cube layer
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, cubeLayer))
        {
            InteractableCube cube = hit.collider.GetComponent<InteractableCube>();
            if (cube != null)
                _gameManager.OnCubeSelected(cube);
        }
    }
}