using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoLonely : MonoBehaviour {

    [SerializeField]
    bool isPetting = false;

    [SerializeField]
    int littleCut = 25;
    [SerializeField]
    int normalCut = 50;
    [SerializeField]
    int aggressiveCut = 75;
    
    [Task]
    public void LittleLonely() {

        if (Blackboard.GetLonely() < littleCut || Blackboard.GetLonely() > normalCut) {
            Task.current.Fail();
            return;
        }

        int rand = Mathf.FloorToInt(Random.Range(0, 3));

        switch(rand) {
            case 0:
                Debug.Log("Vito is looking at you expectantly.");
                break;
            case 1:
                Debug.Log("Vito lets out a low whine.");
                break;
            case 2:
                Debug.Log("Vito brushes against your legs.");
                break;
            default:
                Debug.Log("Vito stares at you with sentient eyes. He speaks with a voice that seems not of this earth, 'The statistical probability of this happening is 0, did you know that?' As you lower your self to your knees to worship this clearly divine being, he barks a single command. Pet me plz :P");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void Lonely() {

        if (Blackboard.GetLonely() < normalCut || Blackboard.GetLonely() > aggressiveCut) {
            Task.current.Fail();
            return;
        }

        int rand = Mathf.FloorToInt(Random.Range(0, 4));

        switch (rand) {
            case 0:
                Debug.Log("Vito watches you approach and starts wagging his tail.");
                break;
            case 1:
                Debug.Log("Vito whines as he paws at you.");
                break;
            case 2:
                Debug.Log("Vito jumps up on you.");
                break;
            default:
                Debug.Log("Vito gets excited when he sees you.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void AggressivelyLonely() {

        if (Blackboard.GetLonely() < aggressiveCut) {
            Task.current.Fail();
            return;
        }

        int rand = Mathf.FloorToInt(Random.Range(0, 4));

        switch (rand) {
            case 0:
                Debug.Log("Vito gives you the cutest puppy dog eyes you've ever seen, and hes in his 30's!");
                break;
            case 1:
                Debug.Log("Vito absolutely won't leave you alone.");
                break;
            case 2:
                Debug.Log("Vito lays right on top of your chest.");
                break;
            default:
                Debug.Log("Vito is ecstatic to be in your presence.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void CheckWantPet() {
        bool temp = Blackboard.GetLonely() > 25;
        if (temp) {

            int rand = Mathf.FloorToInt(Random.Range(0, 4));

            switch (rand) {
                case 0:
                    Debug.Log("Vito is loving his pets.");
                    break;
                case 1:
                    Debug.Log("Vito can't get enough of you.");
                    break;
                case 2:
                    Debug.Log("Vito's tail is wagging.");
                    break;
                default:
                    Debug.Log("Vito's never been happier.");
                    break;
            }

            Blackboard.DeltaLonely(-25);
        } else {
            Blackboard.SetLonely(0);
        }
        Task.current.Complete(temp);
    }

    [Task]
    public void StopPet() {

        isPetting = false;

        int rand = Mathf.FloorToInt(Random.Range(0, 2));

        switch (rand) {
            case 0:
                Debug.Log("Vito walks away.");
                break;
            case 1:
                Debug.Log("Vito runs into another room.");
                break;
            default:
                Debug.Log("Satisfied, Vito lays down next to you.");
                break;
        }

        Task.current.Succeed();
    }

    [Task]
    public void IsPetting() {
        Task.current.Complete(isPetting);
    }

}
