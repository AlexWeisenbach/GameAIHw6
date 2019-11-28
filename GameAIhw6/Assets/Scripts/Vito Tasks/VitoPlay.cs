using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoPlay : MonoBehaviour {

    [SerializeField]
    int playCut = 75;
    [SerializeField]
    int patience = 3;

    int currPatience = 0;

    private void Start() {
        currPatience = patience;
    }

    [Task]
    public void CheckIfThrown() {
        Task.current.Complete(Blackboard.thrown);
    }

    [Task]
    public void WantToPlay() {
        Task.current.Complete(Blackboard.GetLonely() >= playCut);
    }

    [Task]
    public void Playing() {
        Task.current.Complete(Blackboard.playing);
    }

    [Task]
    public void WantContinuePlay() {
        Task.current.Complete(!(Blackboard.GetLonely() >= 0) && currPatience >= 0);
    }

    [Task]
    public void HasPatience() {
        Task.current.Complete(currPatience >= 0);
    }

    [Task]
    public void WaitForThrow() {
        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        if (!Blackboard.thrown) {
            switch (rand) {
                case 0:
                    Debug.Log("Vito wags his tail expectantly.");
                    break;
                case 1:
                    Debug.Log("Vito looks up at you and waits for the throw.");
                    break;
                case 2:
                    Debug.Log("Vito runs in circles as he waits for you to throw the stick.");
                    break;
                default:
                    Debug.Log("Vito sits patiently at your feet.");
                    break;
            }
            currPatience -= 1;
        } else {
            currPatience = patience;
        }

        Task.current.Complete(Blackboard.thrown);
    }

    [Task]
    public void GetReadyToPlay() {
        int rand = Mathf.FloorToInt(Random.Range(0, 2));

        switch (rand) {
            case 0:
                Debug.Log("Vito and you head outside to play fetch.");
                break;
            case 1:
                Debug.Log("Vito can hardly contain his excitement as you two walk towards the door.");
                break;
            default:
                Debug.Log("Vito is so excited he tries to open the door before you get there. (It doesn't work)");
                break;
        }

        Blackboard.playing = true;
        currPatience = patience;
        Task.current.Succeed();
    }

    [Task]
    public void GetStick() {
        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        switch (rand) {
            case 0:
                Debug.Log("Vito races to where the stick fell.");
                break;
            case 1:
                Debug.Log("Vito struggles to carry the stick back before deciding to just drag it back by one end.");
                break;
            case 2:
                Debug.Log("Vito misses the stick on the first pass, but eventually finds it.");
                break;
            default:
                Debug.Log("Vito sits patiently at your feet before realizing that you don't have the stick and races to get it.");
                break;
        }

        rand = Mathf.FloorToInt(Random.Range(10, 25));
        Blackboard.DeltaLonely(-rand);

        if (Blackboard.GetLonely() < 0) {
            Blackboard.SetLonely(0);
        }

        Blackboard.thrown = false;

        Task.current.Succeed();
    }

    [Task]
    public void BringStickBack() {
        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        switch (rand) {
            case 0:
                Debug.Log("Vito races back to you and drops the stick at your feet.");
                break;
            case 1:
                Debug.Log("Vito drops the stick a few times before eventually dropping it of with you.");
                break;
            case 2:
                Debug.Log("Vito almost trips running back to give you the stick, but eventually makes it.");
                break;
            default:
                Debug.Log("Vito sits patiently at your feet, until you realize he somehow got the stick to you without you noticing.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void StopFetch() {

        if (!Blackboard.playing) {
            Task.current.Succeed();
            return;
        }

        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        switch (rand) {
            case 0:
                Debug.Log("Vito seems ready to go inside.");
                break;
            case 1:
                Debug.Log("Vito drops the stick and wanders to the door.");
                break;
            case 2:
                Debug.Log("Vito doesn't seem interested in fetch anymore.");
                break;
            default:
                Debug.Log("Vito wanders to the door and paws at the bottom.");
                break;
        }

        Blackboard.playing = false;
        Task.current.Succeed();
    }

}
