using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoGoOut : MonoBehaviour {

    [SerializeField]
    bool isGoOut = false;

    [SerializeField]
    int littleCut = 60;
    [SerializeField]
    int normalCut = 80;
    [SerializeField]
    int aggressiveCut = 90;

    private UIControl controller;

    private void Start()
    {
        controller = GameObject.Find("UIController").GetComponent<UIControl>();
    }

    [Task]
    public void LittleGoOut() {

        if (Blackboard.GetGoOut() < littleCut || Blackboard.GetGoOut() >= normalCut) {
            Task.current.Fail();
            return;
        }

        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        switch (rand) {
            case 0:
                controller.Log("Vito is scratching at the door.");
                break;
            case 1:
                controller.Log("Vito lets out a low whine at the door.");
                break;
            default:
                controller.Log("Vito sits at the door and watches you.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void GoOut() {

        if (Blackboard.GetGoOut() < normalCut || Blackboard.GetGoOut() >= aggressiveCut) {
            Task.current.Fail();
            return;
        }

        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        switch (rand) {
            case 0:
                controller.Log("Vito is scratching at the door quite a bit.");
                break;
            case 1:
                controller.Log("Vito is whining more than usual at the door.");
                break;
            default:
                controller.Log("Vito sits at the door and barks once to try and get your attention.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void AggressivelyGoOut() {

        if (Blackboard.GetGoOut() < aggressiveCut || Blackboard.GetGoOut() >= 100) {
            Task.current.Fail();
            return;
        }

        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        switch (rand) {
            case 0:
                controller.Log("Vito is starting to leave claw marks on the door.");
                break;
            case 1:
                controller.Log("Vito is whimpering at the door.");
                break;
            default:
                controller.Log("Vito barks aggressively at the door for your attention.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void GoOnFloor() {
        Blackboard.SetGoOut(0);

        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        switch (rand) {
            case 0:
                controller.Log("Vito leaves a fun surprise for you somewhere in the house.");
                break;
            case 1:
                controller.Log("A familiar odor wafts from the other room.");
                break;
            default:
                controller.Log("Vito makes eye contact as he takes a fat dump on your brand new timbs.");
                break;
        }

    }

    [Task]
    public void CheckNeedGoOut() {
        bool temp = Blackboard.GetGoOut() > 25;
        if (temp) {

            int rand = Mathf.FloorToInt(Random.Range(0, 5));

            switch (rand) {
                case 0:
                    controller.Log("Did this always take so long?");
                    break;
                case 1:
                    controller.Log("Nice weather we're having today...");
                    break;
                case 2:
                    controller.Log("Vito shows no sign of yielding.");
                    break;
                case 3:
                    controller.Log("Vito waddles after a passing dog before reaching the end of his leash and going back to his business.");
                    break;
                default:
                    controller.Log("Vito's eyes meet yours, it's awkward.");
                    break;
            }

            Blackboard.DeltaGoOut(-25);
        }
        else {
            Blackboard.SetGoOut(0);
        }
        Task.current.Complete(temp);
    }

    [Task]
    public void StopGoOut() {

        isGoOut = false;

        int rand = Mathf.FloorToInt(Random.Range(0, 2));

        switch (rand) {
            case 0:
                controller.Log("You and Vito walk home.");
                break;
            case 1:
                controller.Log("Vito takes you on a jog back home.");
                break;
            default:
                controller.Log("Vito takes you on many squirell chasing adventures before you return home.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void IsGoingOut() {
        Task.current.Complete(isGoOut);
    }

    [Task]
    public void GoToDoor() {
        int rand = Mathf.FloorToInt(Random.Range(0, 2));

        switch (rand) {
            case 0:
                controller.Log("Vito walks over to the door.");
                break;
            case 1:
                controller.Log("Vito gets up and goes to the door.");
                break;
            default:
                // Real shit do people know what a mudroom is around here? Like is this too ambiguious? Idk change it if you think it should be.
                controller.Log("Vito walks into the mudroom.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void NeedGoOut() {
        Task.current.Complete(Blackboard.GetGoOut() >= 50);
    }

}
