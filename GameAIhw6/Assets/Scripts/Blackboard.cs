using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour {

    static float tired = 99;
    bool asleep = false;

    static float hungry = 0;
    bool eating = false;

    static float lonely = 0;
    static float playful = 0;
    static float goOut = 0;
    static float alerted = 0;

    public static float GetTired() {
        return tired;
    }
}
