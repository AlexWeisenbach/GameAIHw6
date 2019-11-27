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
        Debug.Log("Vito lifts his head before getting up off of the " + spot);
        Task.current.Succeed();
    }

    [Task]
    public void Sleepy() {
        if (Blackboard.GetTired() < sleepyCut || Blackboard.GetTired() >= irritableCut) {
            Task.current.Fail();
            return;
        }
        Blackboard.irritated = false;
        Debug.Log("Vito looks sleepy");
        Task.current.Succeed();
    }

    [Task]
    public void Irritable() {
        if (Blackboard.GetTired() < irritableCut || Blackboard.GetTired() >= sleepCut) {
            Task.current.Fail();
            return;
        }
        Blackboard.irritated = true;
        Debug.Log("Vito seems drowsy, and easily provoked.");
        Task.current.Succeed();
    }

    [Task]
    public void Sleep() {
        if (Blackboard.GetTired() < sleepCut) {
            Task.current.Fail();
            return;
        }
        Blackboard.irritated = false;
        Debug.Log("Vito needs to sleep");
        Task.current.Succeed();
    }

    [Task]
    public void FindBed() {
        Debug.Log("Vito looks around for his bed");
        if (bedExists) {
            Debug.Log("Vito falls asleep in his bed!");
            Task.current.Succeed();
        } else {
            Debug.Log("Doesn't look like Vito has a bed...");
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
                Debug.Log("Vito curls up on the couch, leaving scratches when he does.");
                spot = "couch";
                break;
            case 1:
                Debug.Log("Vito falls asleep on the bed, making sure to roll around on the ground first.");
                spot = "bed";
                break;
            case 2:
                Debug.Log("Vito scratches at the rug before falling asleep on it.");
                spot = "rug";
                break;
            case 3:
                Debug.Log("Vito found a comfortable spot by the fireplace, and drifts off to sleep.");
                spot = "floor";
                break;
            default:
                Debug.Log("Vito passes out where he stands.");
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
        Debug.Log("Vito is sleeping soundly on the " + spot);
        Task.current.Succeed();
    }

    [Task]
    public void CanSleep() {
        Task.current.Complete(Blackboard.GetTired() >= sleepCut);
    }

}
