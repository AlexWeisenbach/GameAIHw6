using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoTired : MonoBehaviour {

    int sleepyCut = 25;
    int irritableCut = 50;
    int sleepCut = 75;

    enum State {
        SLEEPY,
        IRRITABLE,
        SLEEP
    }


    /*
    [Task]
    public void TestTired(int t) {
        if (t == (int)State.SLEEPY) {

            if (Blackboard.GetTired() < sleepyCut) {
                Task.current.Fail();
            } else {
                Task.current.Succeed();
            }
            return;

        } else if (t == (int)State.IRRITABLE) {

            if (Blackboard.GetTired() < irritableCut) {
                Task.current.Fail();
            }
            else {
                Task.current.Succeed();
            }
            return;

        } else {

            if (Blackboard.GetTired() < sleepCut) {
                Task.current.Fail();
            }
            else {
                Task.current.Succeed();
            }
            return;

        }
    } */

    [Task]
    public void Sleepy() {
        if (Blackboard.GetTired() < sleepyCut || Blackboard.GetTired() >= irritableCut) {
            Task.current.Fail();
            return;
        }
        Debug.Log("Vito is sleepy");
        Task.current.Succeed();
    }

    [Task]
    public void Irritable() {
        if (Blackboard.GetTired() < irritableCut || Blackboard.GetTired() >= sleepCut) {
            Task.current.Fail();
            return;
        }
        Debug.Log("Vito is irritable");
        Task.current.Succeed();
    }

    [Task]
    public void Sleep() {
        if (Blackboard.GetTired() < sleepCut) {
            Task.current.Fail();
            return;
        }
        Debug.Log("Vito needs sleep");
        Task.current.Succeed();
    }

}
