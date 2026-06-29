For part 3

* since the if statement is in update() its going to spawn the coin as long as the spacebar is pressed so I would add some kind of cool down on it to prevent multiples from spawning.

* No transform position is included for the coin in the statement so I would add that as well.

* Lastly I would change public gameobject to private to prevent other scripts in the project to changing it.


For Part 4

* I like to take the one script, one job approach for my projects so if something breaks I know exactly where to look.

* In accordance with part 2, I didn't limit the Interactable objects to the 3 cubes instead made it a public List so we can add as many objects as we want.

* The project is pretty simple with all the scripts are separate and have comments explaining basic job of functions

* Lastly, for improvements I would just add visual polish for it to look more appealing to increase retention, such as adding confetti when the answer is correct and a screenshake when wrong.

* right now the project works with limited gameobjects but if the project has more than 25 interactable objects it might get tedious to assign them in the inspector so I would like to add some form of auto detection for Interactables.