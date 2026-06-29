using System.Collections.Generic;
using UnityEngine;


/// Central coordinator. Picks the correct cube at startup and routes
public class GameManager : MonoBehaviour
{
    [Header("Cubes")]
    [SerializeField] private List<InteractableCube> cubeList;  // Drag all 3 cubes here

    [Header("Managers")]
    [SerializeField] private UIManager uiManager;
   

    private void Start()
    {
        PickCorrectCube();
        InitialiseAllCubes();
    }


  
    /// Randomly flags exactly one cube in the list as the correct answer.
  
    private void PickCorrectCube()
    {
        int correctIndex = Random.Range(0, cubeList.Count);

        for (int i = 0; i < cubeList.Count; i++)
            cubeList[i].isCorrect = (i == correctIndex);

        Debug.Log($"[GameManager] Correct cube index: {correctIndex}");
    }

    /// Tells each cube to cache its starting colour after CubeRandomiser has run.
    private void InitialiseAllCubes()
    {
        foreach (InteractableCube cube in cubeList)
            cube.Initialise();
    }


    /// Called when the player clicks on a cube.
    /// Routes to correct or wrong handling accordingly.
    public void OnCubeSelected(InteractableCube cube)
    {
        // Ignore if this cube has already been disabled
        if (!cube.CanInteract()) return;

        if (cube.isCorrect)
            HandleCorrect(cube);
        else
            HandleWrong(cube);
    }

    //Outcome handlers

    private void HandleCorrect(InteractableCube cube)
    {
        cube.OnCorrect();
        uiManager.ShowCorrect();
       
    }

    private void HandleWrong(InteractableCube cube)
    {
        cube.OnWrong();
        uiManager.ShowTryAgain();
      
    }
}
