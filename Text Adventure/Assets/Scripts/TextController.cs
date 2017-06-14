using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { cell, mirror, sheets_0, lock_0, cell_mirror,
        sheets_1, lock_1, freedom};
    private States currentState;
	// Use this for initialization
	void Start () {
        currentState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentState == States.cell)            { state_cell(); }
        else if(currentState == States.sheets_0)    { state_sheets_0(); }
        else if (currentState == States.sheets_1) { state_sheets_1(); }
        else if (currentState == States.lock_0) { state_lock_0(); }
        else if (currentState == States.lock_1) { state_lock_1(); }
        else if (currentState == States.mirror) { state_mirror(); }
        else if (currentState == States.cell_mirror) { state_cell_mirror(); }
        else if (currentState == States.freedom) { state_freedom(); }

    }

    
    void state_cell()
    {
        text.text = "You are currently trapped in a prison cell." +
                    "There are some dirty sheets on the bed, a mirror on the wall " +
                    "and the door is locked from the outside.\n\n" +
                    "Press S to view the Sheets\n" +
                    "M to view the Mirror\n" +
                    "L to view the Lock\n";
        if(Input.GetKeyDown(KeyCode.S))         {currentState = States.sheets_0;}
        else if (Input.GetKeyDown(KeyCode.M))   { currentState = States.mirror; }
        else if (Input.GetKeyDown(KeyCode.L))   { currentState = States.lock_0; }
    }

    void state_sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
                    "time someone changed them\n\n" +
                    "Press R to Return to cell";
        if (Input.GetKeyDown(KeyCode.R))        {currentState = States.cell;}
    }

    void state_sheets_1()
    {
        text.text = "Holding a mirror in your hands does not make the sheets look any better.\n\n" +
                    "Press R to Return to cell";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.cell_mirror; }
    }

    void state_mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to Take the mirror, or R to Return to cell";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.cell; }
        else if (Input.GetKeyDown(KeyCode.T)) { currentState = States.cell_mirror ; }
    }

    void state_cell_mirror()
    {
        text.text = "You are still in your cell, and you STILL want to escape! There are " +
                    "some dirty sheets on the bed, a mark where the mirror was, " +
                    "and that pesky door is still there, and firmly locked!\n\n" +
                    "Press S to view Sheets" +                     "L to view Lock";
        if (Input.GetKeyDown(KeyCode.S)) { currentState = States.sheets_1; }
        if (Input.GetKeyDown(KeyCode.L)) { currentState = States.lock_1; }
    }

    void state_lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.cell; }
    }

    void state_lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it round " +
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons. You press the dirty buttons, and hear a click.\n\n" +
                    "Press O to Open" +
                    "R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.O)) { currentState = States.freedom; }
    }

    void state_freedom()
    {
        text.text = "Congratulations, you have escaped the prison.";
    }
}
