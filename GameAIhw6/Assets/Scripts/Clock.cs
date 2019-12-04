using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    public static int startOfDay = 420;

    static int daysPast = 0;
    static int time = 420;
    static float accTime = 420;
    float tempTime = 0;

    // Start is called before the first frame update
    void Start() {
        time = startOfDay;
        accTime = startOfDay;
    }

    // Update is called once per frame
    void Update() {
        tempTime += Time.deltaTime;

        if (tempTime >= 1) {
            time++;
            if (time > Blackboard.SecondsPerDay) {
                daysPast++;
                time -= Blackboard.SecondsPerDay;
            }
            tempTime -= 1;
        }

        accTime = time + tempTime;
    }

    public static int getTime() {
        return time;
    }

    public static int getDays() {
        return daysPast;
    }

    public static void AdvanceTime(int t) {
        time += t;
    }

    public static float GetATime() {
        return accTime;
    }

    public static void addDay() {
        daysPast++;
    }
}
