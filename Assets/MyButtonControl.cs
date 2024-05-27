using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButtonControl : MonoBehaviour {
	Canvas exitCanvas;
	// Use this for initialization
	void Start () {
		exitCanvas = GameObject.Find ("Quit_Canvas").GetComponent<Canvas>();
		exitCanvas.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowExitCanvas()
	{
		exitCanvas.enabled = true;
	}

	public void HideExitCanvas()
	{
		exitCanvas.enabled = false;
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync ("test_nevigate_maze06_UI");
	}
	public void ExitProgram()
	{
		Application.Quit ();
	}

	public void RetryWinCanvas()
	{
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync ("test_nevigate_maze06_UI");
	}

}
