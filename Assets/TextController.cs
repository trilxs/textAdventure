using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {
		cell, mirror, sheets_0, locks_0, cell_mirror, sheets_1, locks_1, 
		freedom, corridor_0, stairs_0, floor, closet_door
		};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if      (myState == States.cell)	    cell(); 
		else if (myState == States.sheets_0)    sheets_0(); 
		else if (myState == States.locks_0)     locks_0(); 
		else if (myState == States.mirror)      mirror();
		else if (myState == States.cell_mirror) cell_mirror();
		else if (myState == States.locks_1)     locks_1();
		else if (myState == States.sheets_1)    sheets_1();
		else if (myState == States.corridor_0)  corridor_0();
		else if (myState == States.stairs_0)    stairs_0();
		else if (myState == States.closet_door) closet_door();
		else if (myState == States.floor)       floor();
		else if (myState == States.freedom) 	freedom();
	}

//PART I

	void cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press a letter below to view the object:"+
					"\n\tS = sheets\n\tM = mirror\n\tL = lock";
		if      (Input.GetKeyDown(KeyCode.S))  myState = States.sheets_0;
		else if (Input.GetKeyDown (KeyCode.M)) myState = States.mirror;
		else if (Input.GetKeyDown (KeyCode.L)) myState = States.locks_0;
	}
	
	void sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " + 
					"I guess!\n\n" + 
					"Press R to return to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) myState = States.cell;
	}
	
	void sheets_1() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " + 
					"I guess!\n\n" + 
					"Press R to return to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) myState = States.cell_mirror;
	}
	
	void locks_0() {
		text.text = "You try to open the lock, but it's... Locked. Surprising." +
					"There must be a key laying around somewhere!\n\n" +
					"Press R to return to roaming your cell";
		if (Input.GetKeyDown (KeyCode.R)) myState = States.cell;
	}
	
	void mirror() {
		text.text = "You look around the mirror and found a key laying behind " +
					"it!\n\n" + 
					"Press a letter below to perform the action:" +
					"\n\tT = take the key and return to your cell" +
					"\n\tR = return to your cell";
		if 		(Input.GetKeyDown (KeyCode.T)) myState = States.cell_mirror;
		else if (Input.GetKeyDown (KeyCode.R)) myState = States.cell;
	}
	
	void cell_mirror() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press a letter below to view the object:"+
					"\n\tS = sheets\n\tL = lock";
		if 		(Input.GetKeyDown(KeyCode.S))  myState = States.sheets_1;
		else if (Input.GetKeyDown (KeyCode.L)) myState = States.locks_1;
	}
	
	void locks_1() {
		text.text = "You used the key you found behind the mirror and unlocked the " +
					"door!\n\n" +
					"Press a letter below to perform the action:" +
					"\n\tO = open the door and leave the cell" +
					"\n\tR = return to your cell";
		if 		(Input.GetKeyDown (KeyCode.O)) myState = States.corridor_0;
		else if (Input.GetKeyDown (KeyCode.R)) myState = States.cell_mirror;	
	}
	
//PART II
	
	void corridor_0() {
		text.text = "You are in a corridor. There's no going back.\n\n" +
					"Press a letter below to perform the action:" +
					"\n\tS = check out the stairs" +
					"\n\tF = check the floor" +
					"\n\tC = check the closet door";
		if 		(Input.GetKeyDown (KeyCode.S)) myState = States.stairs_0;
		else if (Input.GetKeyDown (KeyCode.F)) myState = States.floor;
		else if (Input.GetKeyDown (KeyCode.C)) myState = States.closet_door;
	}
	
	void stairs_0() {
		text.text = "Looks too dangerous to go out-- look at the guards!\n\n" + 
					"Press R to return to roaming the corridor";
		if (Input.GetKeyDown(KeyCode.R)) myState = States.corridor_0;
	}
	
	void closet_door() {
		text.text = "The closet's locked!\n\n" + 
					"Press R to return to roaming the corridor";
		if (Input.GetKeyDown(KeyCode.R)) myState = States.corridor_0;
	}
	
	void floor() {
		text.text = "You found a centimeter long hole... Could be big " +
					"enough to fit through and escape!\n\n" +
					"Press a letter below to perform the action:" +
					"\n\tG = go through the hole.. Or try to" +
					"\n\tR = return to corridor";
		if 		(Input.GetKeyDown (KeyCode.R)) myState = States.corridor_0;
		else if (Input.GetKeyDown (KeyCode.G)) myState = States.freedom;
	}
	void freedom() {
		text.text = "You fit through the hole... What are you...?!" +
					"\n*ahem* Anyways, congratulations! You escaped!" +
					"\n\n\tPress P to play again\n\tPress Q to quit";
		if 		(Input.GetKeyDown (KeyCode.P)) myState = States.cell;
		else if (Input.GetKeyDown (KeyCode.Q)) Application.Quit();
	}
}