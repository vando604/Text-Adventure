using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0,
                          corridor_1, corridor_2, corridor_3, stairs_0, stairs_1, stairs_2, closet_door,
                          in_closet, floor, courtyard
                        };
    private States currentState;

	// Use this for initialization
	void Start () {
        currentState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
        if      (currentState == States.cell)           { state_cell();        }
        else if (currentState == States.sheets_0)       { state_sheets_0();    }
        else if (currentState == States.sheets_1)       { state_sheets_1();    }
        else if (currentState == States.lock_0)         { state_lock_0();      }
        else if (currentState == States.lock_1)         { state_lock_1();      }
        else if (currentState == States.mirror)         { state_mirror();      }
        else if (currentState == States.cell_mirror)    { state_cell_mirror(); }
        else if (currentState == States.corridor_0)     { state_corridor_0();  }
        else if (currentState == States.corridor_1)     { state_corridor_1();  }
        else if (currentState == States.corridor_2)     { state_corridor_2();  }
        else if (currentState == States.corridor_3)     { state_corridor_3();  }
        else if (currentState == States.stairs_0)       { state_stairs_0();    }
        else if (currentState == States.stairs_1)       { state_stairs_1();    }
        else if (currentState == States.stairs_2)       { state_stairs_2();    }
        else if (currentState == States.closet_door)    { state_closet_door(); }
        else if (currentState == States.in_closet)      { state_in_closet(); }
        else if (currentState == States.floor)          { state_floor();       }
        else if (currentState == States.courtyard)      { state_courtyard();   }

    }

    void state_cell()
    {
        text.text = "You are currently trapped in a prison cell." +
                    "There are some dirty sheets on the bed, a mirror on the wall " +
                    "and the door is locked from the outside.\n\n" +
                    "Press S to view the Sheets\n" +
                    "M to view the Mirror\n" +
                    "L to view the Lock";
        if      (Input.GetKeyDown(KeyCode.S))           { currentState = States.sheets_0; }
        else if (Input.GetKeyDown(KeyCode.M))           { currentState = States.mirror; }
        else if (Input.GetKeyDown(KeyCode.L))           { currentState = States.lock_0; }
    }

    void state_sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
                    "time someone changed them\n\n" +
                    "Press R to Return to cell";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.cell; }
    }

    void state_sheets_1()
    {
        text.text = "Holding a mirror in your hands does not make the sheets look any better.\n\n" +
                    "Press R to Return to cell";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.cell_mirror; }
    }

    void state_mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to Take the mirror\n" +
                    "R to Return to cell";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.cell; }
        else if (Input.GetKeyDown(KeyCode.T))           { currentState = States.cell_mirror ; }
    }

    void state_cell_mirror()
    {
        text.text = "You are still in your cell, and you STILL want to escape! There are " +
                    "some dirty sheets on the bed, a mark where the mirror was, " +
                    "and that pesky door is still there, and firmly locked!\n\n" +
                    "Press S to view Sheets\n" + 
                    "L to view Lock";

        if      (Input.GetKeyDown(KeyCode.S))           { currentState = States.sheets_1; }
        if      (Input.GetKeyDown(KeyCode.L))           { currentState = States.lock_1; }
    }

    void state_lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to Return to roaming your cell";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.cell; }
    }

    void state_lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it round " +
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons. You press the dirty buttons, and hear a click.\n\n" +
                    "Press O to Open\n" +
                    "R to Return to your cell";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.O))           { currentState = States.corridor_0; }
    }

    void state_corridor_0()
    {
        text.text = "You have escaped the prison cell, but you're not out of the clear just yet." +
                    "You are in the corridor, there's a closet and some stairs leading up to the " +
                    "courtyard.  There also seems to be a shining object lying on the floor\n\n" +
                    "Press C to view the Closet\n" +
                    "F to inspect the Floor\n" +
                    "S to go up the Stairs";
        if      (Input.GetKeyDown(KeyCode.C))           { currentState = States.closet_door; }
        else if (Input.GetKeyDown(KeyCode.F))           { currentState = States.floor; }
        else if (Input.GetKeyDown(KeyCode.S))           { currentState = States.stairs_0; }
    }

    void state_closet_door()
    {
        text.text = "You are looking at a closet door, unfortunately it's locked. " +
                    "Maybe you could find something around to unlock it?\n\n" +
                    "Press R to Return to the corridor";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.corridor_0; }
    }

    void state_stairs_0()
    {
        text.text = "You start walking up the stairs towards the outside light. " +
                    "You realise it's not break time, and you'll be caught immediately.\n\n" +
                    "Press R to Return to the corridor.";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.corridor_0; }
    }

    void state_floor()
    {
        text.text = "Searching around on the dirty floor, you find a hairpin.\n\n" +
                    "Press R to stand up\n" +
                    "H to take the Hairpin.";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.corridor_0; }
        else if (Input.GetKeyDown(KeyCode.H))           { currentState = States.corridor_1; }
    }

    void state_corridor_1()
    {
        text.text = "Still in the corridor. Floor is still dirty. Hairclip in hand. " +
                    "Now what? You wonder if that lock on the closet could be opened " +
                    "by the hairpin.\n\n" +
                    "P to Pick the lock\n" +
                    "S to climb the stairs";
        if      (Input.GetKeyDown(KeyCode.P))           { currentState = States.in_closet; }
        else if (Input.GetKeyDown(KeyCode.S))           { currentState = States.stairs_1; }
    }

    void state_stairs_1()
    {
        text.text = "Unfortunately having a puny hairclip hasn't given you the " +
                    "confidence to walk out into a courtyard surrounded by armed guards.\n\n" +
                    "Press R to Retreat down the stairs";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.corridor_1; }
    }

    void state_in_closet()
    {
        text.text = "Inside the closet you see a cleaner's uniform that looks about your size!\n\n" +
                    "Press D to wear the uniform\n\n" +
                    "R to Return to the corridor";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.corridor_2; }
        else if (Input.GetKeyDown(KeyCode.D))           { currentState = States.corridor_3; }
    }

    void state_corridor_2()
    {
        text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
                    "Press C to revisit the Closet\n" +
                    "S to climb the stairs";
        if      (Input.GetKeyDown(KeyCode.C))           { currentState = States.in_closet; }
        else if (Input.GetKeyDown(KeyCode.S))           { currentState = States.stairs_2; }
    }

    void state_stairs_2()
    {
        text.text = "Even with a bent hairclip, you still cannot muster the courage to " +
                    "climb up the stairs to your death!\n\n" +
                    "Press R to Return to the corridor";
        if      (Input.GetKeyDown(KeyCode.R))           { currentState = States.corridor_2; }
    }

    void state_corridor_3()
    {
        text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
                    "You strongly consider the run for freedom.\n\n" +
                    "Press S to take the Stairs to freedom\n" +
                    "U to Undress";
        if      (Input.GetKeyDown(KeyCode.S))           { currentState = States.courtyard; }
        else if (Input.GetKeyDown(KeyCode.U))           { currentState = States.in_closet; }
    }

    void state_courtyard()
    {
        text.text = "You walk through the courtyard dressed as a cleaner. " +
                    "The guard tips his hat at you as you waltz past, claiming " +
                    "your freedom. You heart races as you walk into the sunset.\n\n" +
                    "Congratulations, you have escaped the prison!";
    }
}
