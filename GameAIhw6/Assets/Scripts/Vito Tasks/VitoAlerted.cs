using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoAlerted : MonoBehaviour {

    // 1440 seconds in a day

    int TOTALTIME = Blackboard.SecondsPerDay;
    int alertStates = 4;

    private UIControl controller;

    // TEMPORARY
    int time = 0;

    private void Update() {
        time = Clock.getTime();
    }

    private void Start()
    {
        controller = GameObject.Find("UIController").GetComponent<UIControl>();
    }

    [Task]
    public void Alert1() {
        if (time >= 0 && time <= (TOTALTIME / alertStates) * 1) {
            Task.current.Succeed();
            controller.Log("Vito is barking at something downstairs.");
        } else {
            Task.current.Fail();
        }
    }

    [Task]
    public void Alert2() {
        if (time > (TOTALTIME / alertStates) * 1 && time <= (TOTALTIME / alertStates) * 2) {
            Task.current.Succeed();
            controller.Log("Vito sprints to the door and starts barking aggressively.");
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void Alert3() {
        if (time > (TOTALTIME / alertStates) * 2 && time <= (TOTALTIME / alertStates) * 3) {
            Task.current.Succeed();
            controller.Log("Vito jumps up on the window and starts barking at something outside.");
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void Alert4() {
        if (time > (TOTALTIME / alertStates) * 3 && time <= (TOTALTIME / alertStates) * 4) {
            Task.current.Succeed();
            controller.Log("You wake up to Vito freaking out downstairs.");
        }
        else {
            Task.current.Fail();
        }
    }

    // Probably won't happen but also maybe saves us from having to fix a bug lol
    [Task]
    public void DefaultAlert() {
        controller.Log("Vito hears the sound of lazy programming and stares at you judgementally.");
        Task.current.Succeed();
    }

}