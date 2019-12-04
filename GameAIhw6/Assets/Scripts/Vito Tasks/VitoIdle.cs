using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class VitoIdle : MonoBehaviour {

    [SerializeField]
    float THourL = 14;
    [SerializeField]
    float THourH = 18;
    [SerializeField]
    float HHourL = 14;
    [SerializeField]
    float HHourH = 18;
    [SerializeField]
    float LHourL = 14;
    [SerializeField]
    float LHourH = 18;
    [SerializeField]
    float GHourL = 14;
    [SerializeField]
    float GHourH = 18;

    public bool isTired = false;
    int tUp = 0;
    public bool isHungry = false;
    int hUp = 0;
    public bool isLonely = false;
    int lUp = 0;
    public bool isPlayful = false;
    public bool isGoOut = false;
    int gUp = 0;
    public bool isAlerted = false;

    private UIControl controller;

    float TCurrTime = 0;
    float TUpTime = 0;
    float HCurrTime = 0;
    float HUpTime = 0;
    float LCurrTime = 0;
    float LUpTime = 0;
    float GCurrTime = 0;
    float GUpTime = 0;

    float tTime = 0;
    float hTime = 0;
    float lTime = 0;
    float gTime = 0;

    int day = 0;

    // Start is called before the first frame update
    void Start() {
        controller = GameObject.Find("UIController").GetComponent<UIControl>();
        TCurrTime = Clock.startOfDay;
        TUpTime = Clock.startOfDay;
        HCurrTime = Clock.startOfDay;
        HUpTime = Clock.startOfDay;
        LCurrTime = Clock.startOfDay;
        LUpTime = Clock.startOfDay;
        GCurrTime = Clock.startOfDay;
        GUpTime = Clock.startOfDay;
    }

    // Update is called once per frame
    void Update() {

        if (day != Clock.getDays()) {
            ShuffleHours();
            day = Clock.getDays();
        }

        if (Blackboard.GetLonely() >= Blackboard.LLCut) {
            isLonely = true;
        } else {
            isLonely = false;
        }

        if (Blackboard.GetHungry() >= Blackboard.HCut) {
            isHungry = true;
        } else {
            isHungry = false;
        }

        if (Blackboard.GetTired() >= Blackboard.SCut) {
            isTired = true;
        } else {
            isTired = false;
        }

        if (Blackboard.GetGoOut() >= Blackboard.GOCut) {
            isGoOut = true;
        } else {
            isGoOut = false;
        }

        if (Blackboard.HeardNoise) {
            isAlerted = true;
        }

        if (Blackboard.GetLonely() >= Blackboard.PCut) {
            isPlayful = true;
        }

        TUpTime = getTime();
        HUpTime = getTime();
        LUpTime = getTime();
        GUpTime = getTime();

        //Debug.Log("TCurr: " + TCurrTime + " TUp: " + TUpTime + " -: " + (TCurrTime - TUpTime) + " c: " + calcStep(16));
        if (TUpTime - TCurrTime >= calcStep(16)) {
            TCurrTime += calcStep(16);
            Blackboard.DeltaTired(1);
        }

        if (HUpTime - HCurrTime >= calcStep(6)) {
            HCurrTime += calcStep(6);
            Blackboard.DeltaHungry(1);
        }

        if (LUpTime - LCurrTime >= calcStep(8)) {
            LCurrTime += calcStep(8);
            Blackboard.DeltaLonely(1);
        }

        if (GUpTime - GCurrTime >= calcStep(7)) {
            GCurrTime += calcStep(7);
            Blackboard.DeltaGoOut(1);
        }

    }

    void ShuffleHours() {
        tTime = Mathf.FloorToInt(Random.Range(THourL, THourH));
        hTime = Mathf.FloorToInt(Random.Range(HHourL, HHourH));
        lTime = Mathf.FloorToInt(Random.Range(LHourL, LHourH));
        gTime = Mathf.FloorToInt(Random.Range(GHourL, GHourH));
    }

    int getTime() {
        return Clock.getDays() * Blackboard.SecondsPerDay + Clock.getTime();
    }

    float calcStep(int HoursToFill) {
        return HoursToFill * 60 * .01f;
    }

    [Task]
    public void TestIsTired() {
        Task.current.Complete(isTired);
    }

    [Task]
    public void TestIsHungry() {
        Task.current.Complete(isHungry);
    }

    [Task]
    public void TestIsLonely() {
        Task.current.Complete(isLonely && !(isPlayful && Blackboard.playing));
    }

    [Task]
    public void TestIsPlayful() {
        Task.current.Complete(isPlayful);
    }

    [Task]
    public void TestIsNeedGoOut() {
        Task.current.Complete(isGoOut || Blackboard.isGoOut);
    }

    [Task]
    public void TestIsAlerted() {
        Task.current.Complete(isAlerted);
    }

    [Task]
    public void LoafAround() {
        controller.Log("Vito is loafing around!");
        Task.current.Succeed();
    }

    [Task]
    public void CheckBusy() {
        Task.current.Complete(Blackboard.asleep || Blackboard.isGoOut || Blackboard.playing);
    }

    [Task]
    public void PlayCheck() {
        Task.current.Complete(Blackboard.asleep || Blackboard.isGoOut);
    }

}
