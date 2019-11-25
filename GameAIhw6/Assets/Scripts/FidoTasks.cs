using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class FidoTasks : MonoBehaviour {

    // THIS SCRIPT WAS SOLELY FOR TESTING AND NO LONGER SERVES ANY PURPOSE

    [Task]
    public void PrintTest() {
        Debug.Log("test");
        Task.current.Succeed();
    }

    [Task]
    public void SetTest() {
        Debug.Log(Blackboard.GetTired());
    }

    [Task]
    public void yes() {
        Debug.Log("yes");
        Task.current.Succeed();
    }

    [Task]
    public void no() {
        Debug.Log("no");
        Task.current.Fail();
    }

    // Testing what would happen if you accidentally have sequential Task.current calls
    // Seems to stick with the last entered value (Ex. this prints all 3 and then fails)
    [Task]
    public void TestBreak() {
        Debug.Log("Start");
        Task.current.Fail();
        Debug.Log("Second");
        Task.current.Succeed();
        Debug.Log("Third");
        Task.current.Fail();
    }

}
