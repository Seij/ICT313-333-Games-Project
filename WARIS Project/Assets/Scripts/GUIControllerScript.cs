using UnityEngine;
using System.Collections;

public class GUIControllerScript : MonoBehaviour {

	public CursorController cursorController;
	private Vector2 scrollPosition = Vector2.zero;
	private Vector2 scrollPosition2 = Vector2.zero;
	private string scrollText = "Sample scroll text";
	private bool showWindow;
	private int fontSize = 16;

	private Rect windowRect;
	private Rect windowRectDupe;
	private string windowLabel;
	private string windowText;
	private int windowIDnum;
	private bool windowExpandable;

	// Use this for initialization
	void Start () 
	{
		showWindow = true;
		SetupWindow (new Rect (20, 20, 200, 200), "New Test Window", "New test string\n next line of test", 0, true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnGUI()
	{
		GUI.depth = 2;

		GUI.skin.label.fontSize = fontSize;

		/*/Test Button
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
		//End Test Button*/
		Vector2 pos = cursorController.GetCursorPosition ();
		Vector2 dupePos = pos;
		dupePos.x += Screen.width / 2;
		//Test Scrollview
		var testWinRect = new Rect (100, 400, 200, 200);
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


		var testWinRectDupe = new Rect (testWinRect);
		testWinRectDupe.x += Screen.width/2;
		scrollPosition2 = GUI.BeginScrollView (testWinRectDupe, scrollPosition2, new Rect (0, 0, 190, 400));
		if(testWinRectDupe.Contains (dupePos)) //if cursor over window
		{
			if(Input.GetAxis ("Scroll Y") != 0)
			{
				if(Input.GetAxis ("Scroll Y") > 0 && scrollPosition2.y < 400)
					GUI.ScrollTo(new Rect(0, scrollPosition2.y + 5.0f, 200, 200));
				else if(Input.GetAxis ("Scroll Y") < 0 && scrollPosition2.y > 0)
					GUI.ScrollTo(new Rect(0, scrollPosition2.y - 10.0f, 200, 200));
			}
		}
		scrollText = GUI.TextArea (new Rect (0, 0, 200, 200), scrollText);
		GUI.EndScrollView ();
		//End Test Scrollview

		//Test Windows
		windowRectDupe = new Rect (windowRect);
		windowRectDupe.x += Screen.width / 2;

		if(showWindow)
		{
			//windowRect = new Rect(20, 200, 200, 200);
			windowRect = GUI.Window (windowIDnum, windowRect, WindowFunction, windowLabel);
			windowRectDupe = GUI.Window (windowIDnum + 1, windowRectDupe, WindowFunction, windowLabel);
		}
		else
		{
			//windowRect = new Rect();
		}
		//End Test Windows

	}

	void WindowFunction(int windowID)
	{
		GUI.Label (new Rect(20, 20, 100, 50), windowText);

		Vector2 pos = cursorController.GetCursorPosition ();

		if(windowExpandable)
		{
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
		}

		var testRect2 = new Rect (150, 0, 50, 50);
		GUI.Button (testRect2, "X");
		testRect2 = new Rect (testRect2.x + windowRect.x, testRect2.y + windowRect.y, testRect2.width, testRect2.height);
		if(testRect2.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
			showWindow = false;
	}

	/// <summary>
	/// Sets up the window.
	/// Sets private GUIControllerScript variables to those passed in
	/// </summary>
	/// <param name="window">Rect containing window size and position.</param>
	/// <param name="label">Label of the window.</param>
	/// <param name="text">Text to be written in the window.</param>
	/// <param name="windowID">Window ID number.</param>
	/// <param name="expandable">If set to <c>true</c> the window will have a button which when clicked will open a scroll window with more details.</param>
	public void SetupWindow(Rect window, string label, string text, int windowID, bool expandable/*, Building buildingDetails*/)
	{
		windowRect = new Rect (window);
		windowLabel = label;
		windowText = text;
		windowIDnum = windowID;
		windowExpandable = expandable;
	}
}
