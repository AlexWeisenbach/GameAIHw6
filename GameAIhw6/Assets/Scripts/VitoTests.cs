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

    [Task]
    public void TestIsTired() {
        if (isTired) {
            Task.current.Succeed();
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void TestIsHungry() {
        if (isHungry) {
            Task.current.Succeed();
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void TestIsLonely() {
        if (isLonely) {
            Task.current.Succeed();
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void TestIsPlayful() {
        if (isPlayful) {
            Task.current.Succeed();
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void TestIsNeedGoOut() {
        if (isNeedGoOut) {
            Task.current.Succeed();
        }
        else {
            Task.current.Fail();
        }
    }

    [Task]
    public void TestIsAlerted() {
        if (isAlerted) {
            Task.current.Succeed();
        }
        else {
            Task.current.Fail();
        }
    }

}
