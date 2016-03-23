using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, locks_0, cell_mirror, sheets_1, locks_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.cell)			    state_cell(); 
		else if (myState == States.sheets_0)    state_sheets_0(); 
		else if (myState == States.locks_0)     state_locks_0(); 
		else if (myState == States.mirror)      state_mirror();
		else if (myState == States.cell_mirror) state_cell_mirror();
		else if (myState == States.locks_1)     state_locks_1();
		else if (myState == States.sheets_1)    state_sheets_1();
		else if (myState == States.freedom) 	state_freedom();
	}

	void state_cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press a letter below to view the object:"+
					"\n\tS = sheets\n\tM = mirror\n\tL = lock";
		if (Input.GetKeyDown(KeyCode.S)) 	   myState = States.sheets_0;
		else if (Input.GetKeyDown (KeyCode.M)) myState = States.mirror;
		else if (Input.GetKeyDown (KeyCode.L)) myState = States.locks_0;
	}
	
	void state_sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " + 
					"I guess!\n\n" + 
					"Press R to return to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) myState = States.cell;
	}
	
	void state_sheets_1() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
			"time somebody changed them. The pleasures of prison life " + 
				"I guess!\n\n" + 
				"Press R to return to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) myState = States.cell_mirror;
	}
	
	void state_locks_0() {
		text.text = "You try to open the lock, but it's... Locked. Surprising." +
					"There must be a key laying around somewhere!\n\n" +
					"Press R to return to roaming your cell";
		if (Input.GetKeyDown (KeyCode.R)) myState = States.cell;
	}
	
	void state_mirror() {
		text.text = "You look around the mirror and found a key laying behind " +
					"it!\n\n" + 
					"Press a letter below to perform the action:" +
					"\n\tT = take the key and return to your cell" +
					"\n\tR = return to your cell";
		if (Input.GetKeyDown (KeyCode.T))      myState = States.cell_mirror;
		else if (Input.GetKeyDown (KeyCode.R)) myState = States.cell;
	}
	
	void state_cell_mirror() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press a letter below to view the object:"+
					"\n\tS = sheets\n\tL = lock";
		if (Input.GetKeyDown(KeyCode.S))       myState = States.sheets_1;
		else if (Input.GetKeyDown (KeyCode.L)) myState = States.locks_1;
	}
	
	void state_locks_1() {
		text.text = "You used the key you found behind the mirror and unlocked the " +
					"door!\n\n" +
					"Press a letter below to perform the action:" +
					"\n\tO = open the door and leave the cell" +
					"\n\tR = return to your cell";
		if (Input.GetKeyDown (KeyCode.O)) 	   myState = States.freedom;
		else if (Input.GetKeyDown (KeyCode.R)) myState = States.cell_mirror;	
	}
	
	void state_freedom() {
		text.text = "You are free!" +
					"\n\n\tPress P to play again\n\tPress Q to quit";
		if (Input.GetKeyDown(KeyCode.P)) 	   myState = States.cell;
		else if (Input.GetKeyDown (KeyCode.Q)) Application.Quit ();
	}
}