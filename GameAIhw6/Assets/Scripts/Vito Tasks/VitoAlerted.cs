using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoAlerted : MonoBehaviour {

    // 1440 seconds in a day

    int TOTALTIME = 1440;
    int alertStates = 4;

    // TEMPORARY
    int time = 0;

    [Task]
    public void Alert1() {
        if (time >= 0 && time <= (TOTALTIME / alertStates) * 1) {
            Task.current.Succeed();
            Debug.Log("Vito is barking at something downstairs.");
        } else {
            Task.current.Fail();
        }
    }

    [Task]
    public void Alert2() {
        if (time > (TOTALTIME / alertStates) * 1 && time <= (TOTALTIME / alertStates) * 2) {
            Task.current.Succeed();
            Debug.Log("Vito sprints to the door and starts barking aggressively.");
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void Alert3() {
        if (time > (TOTALTIME / alertStates) * 2 && time <= (TOTALTIME / alertStates) * 3) {
            Task.current.Succeed();
            Debug.Log("Vito jumps up on the window and starts barking at something outside.");
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void Alert4() {
        if (time > (TOTALTIME / alertStates) * 3 && time <= (TOTALTIME / alertStates) * 4) {
            Task.current.Succeed();
            Debug.Log("You wake up to Vito freaking out downstairs.");
        }
        else {
            Task.current.Fail();
        }
    }

    // Probably won't happen but also maybe saves us from having to fix a bug lol
    [Task]
    public void DefaultAlert() {
        Debug.Log("Vito hears the sound of lazy programming and stares at you judgementally.");
        Task.current.Succeed();
    }

}