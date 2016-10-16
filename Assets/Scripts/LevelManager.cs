using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//We want LevleManager to trigger the next level once Start is pressed
	//No need for start() and update()
	
	public void LoadLevel(string name){
		Debug.Log("Level load requested: " + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest() {
		Debug.Log("Quitting Game...");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.numberOfBricks <= 0) {
			LoadNextLevel();
		}
	}
}
