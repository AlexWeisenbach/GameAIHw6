using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    static int time = 0;
    float tempTime = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        tempTime += Time.deltaTime;

        if (tempTime >= 1) {
            time++;
            if (time > Blackboard.SecondsPerDay) {
                time = 0;
            }
            tempTime -= 1;
        }
    }

    public static int getTime() {
        return time;
    }

    public static void AdvanceTime(int t) {
        time += t;
    }

}
