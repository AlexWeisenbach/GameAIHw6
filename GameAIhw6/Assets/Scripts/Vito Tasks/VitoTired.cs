using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoTired : MonoBehaviour {

    [SerializeField]
    bool bedExists = false;

    [SerializeField]
    int sleepyCut = 25;
    [SerializeField]
    int irritableCut = 50;
    [SerializeField]
    int sleepCut = 75;

    private UIControl controller;

    private void Start()
    {
        controller = GameObject.Find("UIController").GetComponent<UIControl>();
        Blackboard.SCut = sleepyCut;
    }

    string spot = "bed";

    enum State {
        SLEEPY,
        IRRITABLE,
        SLEEP
    }

    public int GetSleepyCut() {
        return sleepyCut;
    }

    [Task]
    public void WakeUp() {
        controller.Log("Vito lifts his head before getting up off of the " + spot);
        Task.current.Succeed();
    }

    [Task]
    public void Sleepy() {
        if (Blackboard.GetTired() < sleepyCut || Blackboard.GetTired() >= irritableCut) {
            Task.current.Fail();
            return;
        }
        Blackboard.irritated = false;
        controller.Log("Vito looks sleepy");
        Task.current.Succeed();
    }

    [Task]
    public void Irritable() {
        if (Blackboard.GetTired() < irritableCut || Blackboard.GetTired() >= sleepCut) {
            Task.current.Fail();
            return;
        }
        Blackboard.irritated = true;
        controller.Log("Vito seems drowsy, and easily provoked.");
        Task.current.Succeed();
    }

    [Task]
    public void Sleep() {
        if (Blackboard.GetTired() < sleepCut) {
            Task.current.Fail();
            return;
        }
        Blackboard.irritated = false;
        controller.Log("Vito needs to sleep");
        Task.current.Succeed();
    }

    [Task]
    public void FindBed() {
        controller.Log("Vito looks around for his bed");
        if (bedExists) {
            controller.Log("Vito falls asleep in his bed!");
            Task.current.Succeed();
        } else {
            controller.Log("Doesn't look like Vito has a bed...");
            Task.current.Fail();
        }
    }

    [Task]
    public void FindSpot() {
       int rand = (int)Mathf.Floor(Random.Range(0, 4));

        if (Blackboard.GetTired() > 100) {
            rand = 10;
        }

       switch (rand) {
            case 0:
                controller.Log("Vito curls up on the couch, leaving scratches when he does.");
                spot = "couch";
                break;
            case 1:
                controller.Log("Vito falls asleep on the bed, making sure to roll around on the ground first.");
                spot = "bed";
                break;
            case 2:
                controller.Log("Vito scratches at the rug before falling asleep on it.");
                spot = "rug";
                break;
            case 3:
                controller.Log("Vito found a comfortable spot by the fireplace, and drifts off to sleep.");
                spot = "floor";
                break;
            default:
                controller.Log("Vito passes out where he stands.");
                spot = "floor";
                break;
       }
        Task.current.Succeed();
    }

    [Task]
    public void IsSleeping() {
        Task.current.Complete(Blackboard.asleep);
    }

    [Task]
    public void FallAsleep() {
        Blackboard.asleep = true;
        controller.Log("Vito is sleeping soundly on the " + spot);
        Task.current.Succeed();
    }

    [Task]
    public void CanSleep() {
        Task.current.Complete(Blackboard.GetTired() >= sleepCut && (Blackboard.leftAlone || Blackboard.GetTired() >= 100));
    }

    [Task]
    public void AlertWakeUp() {
        int rand = (int)Mathf.Floor(Random.Range(0, 3));

        switch (rand) {
            case 0:
                controller.Log("Vito wakes up and jumps up off the " + spot + ".");
                break;
            case 1:
                controller.Log("Vito lifts his head off the " + spot + " and listens carefully.");
                break;
            case 2:
                controller.Log("Vito jumps to his feet.");
                break;
            default:
                controller.Log("Vito raises his head in curiousity.");
                break;
        }
        Task.current.Succeed();
    }

}
