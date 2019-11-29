using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoHungry : MonoBehaviour {
    [SerializeField]
    public int bowlFullness = 0;
    [SerializeField]
    int hungryCut = 30;

    private UIControl controller;

    private void Update() {
        if (Blackboard.fillFlag) {
            Blackboard.fillFlag = false;
            bowlFullness = 100;
        } else if (bowlFullness == 0) {
            Blackboard.EmptyBowl();
        }
    }

    private void Start()
    {
        controller = GameObject.Find("UIController").GetComponent<UIControl>();
    }

    [Task]
    public void GoToBowl() {
        controller.Log("Vito walks over to his bowl.");
        Task.current.Succeed();
    }

    [Task]
    public void CheckForFood() {
        Task.current.Complete(bowlFullness > 0);
    }

    [Task]
    public void EatFood() {

        controller.Log("Vito is eating his food.");

        if (Blackboard.GetHungry() > bowlFullness) {
            Blackboard.DeltaHungry(-bowlFullness);
            bowlFullness = 0;
        } else {
            bowlFullness -= (int)Blackboard.GetHungry();
            Blackboard.SetHungry(0);
        }

        Task.current.Succeed();
    }

    [Task]
    public void BegForFood() {
        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        if (Blackboard.GetHungry() > 100) {
            rand = 10;
        } else if (Blackboard.irritated) {
            rand = 2;
        }

        switch(rand) {
            case 0:
                controller.Log("Vito's empty food bowl bangs around in the next room.");
                break;
            case 1:
                controller.Log("A faint whimpering carries from Vito's feeding area.");
                break;
            case 2:
                controller.Log("A low growl eminates from a hungry Vito");
                break;
            default:
                controller.Log("Vito drops his empty food dish at your feet.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void CheckStillHungry() {
        Task.current.Complete(Blackboard.GetHungry() > 0 && Blackboard.GetHungry() > hungryCut);
    }

    [Task]
    public void StopEating() {
        controller.Log("Vito stops eating his food.");
        Task.current.Succeed();
    }

    [Task]
    public void IsEating() {
        Task.current.Complete(Blackboard.eating);
    }

}
