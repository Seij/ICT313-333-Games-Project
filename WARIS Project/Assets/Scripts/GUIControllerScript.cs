using UnityEngine;
using System.Collections;

public class GUIControllerScript : MonoBehaviour {

	public CursorController cursorController;
	private Vector2 scrollPosition = Vector2.zero;
	private string scrollText = "Sample scroll text";
	private Rect windowRect = new Rect(20, 200, 200, 200);
	private Rect windowRect2 = new Rect(220, 200, 200, 200);
	private bool showWindow;

	// Use this for initialization
	void Start () 
	{
		showWindow = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnGUI()
	{
		GUI.depth = 2;

		//Test Button
		var testRect = new Rect (100, 100, 100, 100);
		GUI.Button (testRect, "Sphere Right");
		Vector2 pos = cursorController.GetCursorPosition ();
		if(testRect.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
		{
			GameObject temp = GameObject.Find ("TestSphere");
			Vector3 vec = temp.transform.position;
			vec.x += 0.1f;
			temp.transform.position = vec;
		}
		//End Test Button

		//Test Scrollview
		var testWinRect = new Rect (600, 150, 200, 200);
		scrollPosition = GUI.BeginScrollView (testWinRect, scrollPosition, new Rect (0, 0, 190, 400));
		if(testWinRect.Contains (pos)) //if cursor over window
		{
			if(Input.GetAxis ("Scroll Y") != 0)
			{
				if(Input.GetAxis ("Scroll Y") > 0 && scrollPosition.y < 400)
					GUI.ScrollTo(new Rect(0, scrollPosition.y + 5.0f, 200, 200));
				else if(Input.GetAxis ("Scroll Y") < 0 && scrollPosition.y > 0)
					GUI.ScrollTo(new Rect(0, scrollPosition.y - 10.0f, 200, 200));
			}
		}
		scrollText = GUI.TextArea (new Rect (0, 0, 200, 200), scrollText);
		GUI.EndScrollView ();
		//End Test Scrollview

		//Test Windows
		if(showWindow)
			windowRect = GUI.Window (0, windowRect, WindowFunction1, "TestWindow");
		windowRect2 = GUI.Window (1, windowRect2, WindowFunction2, "TestWindow2");
		//End Test Windows

	}

	void WindowFunction1(int windowID)
	{
		GUI.Label (new Rect(20, 20, 100, 50), "Test text test text test text test text test text");
		//GUI.DragWindow (new Rect (0, 0, 200, 10));

		Vector2 pos = cursorController.GetCursorPosition ();

		var testRect = new Rect (10, 70, 100, 100);
		GUI.Button(testRect, "Sphere Left");
		testRect = new Rect (testRect.x + windowRect.x, testRect.y + windowRect.y, testRect.width, testRect.height); 
		if(testRect.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
		{
			GameObject temp = GameObject.Find ("TestSphere");
			Vector3 vec = temp.transform.position;
			vec.x -= 0.1f;
			temp.transform.position = vec;
		}

		var testRect2 = new Rect (150, 0, 50, 50);
		GUI.Button (testRect2, "X");
		testRect2 = new Rect (testRect2.x + windowRect.x, testRect2.y + windowRect.y, testRect2.width, testRect2.height);
		if(testRect2.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
			showWindow = false;
	}
	
	void WindowFunction2(int windowID)
	{
		GUI.Label (new Rect(20, 20, 100, 50), "Test text test text test text test text test text");
		//GUI.DragWindow (new Rect (0, 0, 200, 10));

		Vector2 pos = cursorController.GetCursorPosition ();
		
		var testRect = new Rect (10, 70, 100, 100);
		GUI.Button (testRect, "Hello World!");
		testRect = new Rect (testRect.x + windowRect2.x, testRect.y + windowRect2.y, testRect.width, testRect.height); 
		if(testRect.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
			showWindow = true;

		var testRect2 = new Rect (150, 0, 50, 50);
		GUI.Button (testRect2, "X");
		testRect2 = new Rect (testRect2.x + windowRect2.x, testRect2.y + windowRect2.y, testRect2.width, testRect2.height);
		if(testRect2.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
			showWindow = false;
	}
}
