using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoTests : MonoBehaviour {

    // TEMPORARY VALUES TO BE REPLACED WITH INTELLIGENT SELECTION METHODS
    [SerializeField]
    bool isTired = true;
    
    [SerializeField]
    bool isHungry = false;

    [SerializeField]
    bool isLonely = false;

    [SerializeField]
    bool isPlayful = false;

    [SerializeField]
    bool isNeedGoOut = false;

    [SerializeField]
    bool isAlerted = false;

    public State state = State.IDLE;

    public enum State {
        IDLE,
        TIRED,
        HUNGRY,
        LONELY,
        PLAYFUL,
        ALERTED,
        GOOUT
    }

    [Task]
    public void TestIsTired() {
        Task.current.Complete(state == State.TIRED);
    }

    [Task]
    public void TestIsHungry() {
        Task.current.Complete(state == State.HUNGRY);
    }

    [Task]
    public void TestIsLonely() {
        Task.current.Complete(state == State.LONELY);
    }

    [Task]
    public void TestIsPlayful() {
        Task.current.Complete(state == State.PLAYFUL);
    }

    [Task]
    public void TestIsNeedGoOut() {
        Task.current.Complete(state == State.GOOUT);
    }

    [Task]
    public void TestIsAlerted() {
        Task.current.Complete(state == State.ALERTED);
    }

}
