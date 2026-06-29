using UnityEngine;



public class CubeRandomiser : MonoBehaviour
{
    // Cached reference to this cube's renderer
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        AssignRandomColour();
    }

   

    public void AssignRandomColour()
    {
        float hue = Random.value;                          
        Color colour = Color.HSVToRGB(hue, 1f, 1f);       
        _renderer.material.color = colour;
    }
    public void SetColour(Color colour)
    {
        _renderer.material.color = colour;
    }
}
