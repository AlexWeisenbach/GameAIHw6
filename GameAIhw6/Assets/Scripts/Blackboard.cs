using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour {

    static float tired = 0;
    public static bool asleep = false;
    public static bool irritated = false;

    static float hungry = 0;

    static float lonely = 0;
    static float playful = 0;
    static float goOut = 0;
    static float alerted = 0;

    public static bool Irritable() {
        return irritated;
    }

    // This is gross...
    public static float GetTired() {
        return tired;
    }

    public static void SetTired(float f) {
        tired = f;
    }

    // Delta just means it will change the value rather than set it
    public static void DeltaTired(float f) {
        tired += f;
    }

    public static float GetHungry() {
        return hungry;
    }

    public static void SetHungry(float f) {
        hungry = f;
    }

    public static void DeltaHungry(float f) {
        hungry += f;
    }

    public static float GetLonely() {
        return lonely;
    }

    public static void SetLonely(float f) {
        lonely = f;
    }

    public static void DeltaLonely(float f) {
        lonely += f;
    }

    public static float GetPlayful() {
        return playful;
    }

    public static void SetPlayful(float f) {
        playful = f;
    }

    public static void DeltaPlayful(float f) {
        playful += f;
    }

    public static float GetGoOut() {
        return goOut;
    }

    public static void SetGoOut(float f) {
        goOut = f;
    }

    public static void DeltaGoOut(float f) {
        goOut += f;
    }

    public static float GetAlerted() {
        return alerted;
    }

    public static void SetAlerted(float f) {
        alerted = f;
    }

    public static void DeltaAlerted(float f) {
        alerted += f;
    }

}
