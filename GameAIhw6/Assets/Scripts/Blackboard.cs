﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour {

    static float tired = 0;
    public static bool leftAlone = false;
    public static bool asleep = false;
    public static bool irritated = false;
    public static int SCut = 25;

    static float hungry = 0;
    public static bool eating = false;
    public static int HCut = 30;

    static float lonely = 0;
    public static bool thrown = false;
    public static bool playing = false;
    public static int LLCut = 25;
    public static int PCut = 75;

    static float goOut = 0;
    public static int GOCut = 60;
    public static bool isGoOut = false;

    public static int bowlFull = 0;
    public static bool fillFlag = false;

    public static bool HeardNoise = false;

    public static int SecondsPerDay = 1440;


    /* ABANDONED
    public static bool tFlag = false;
    public static bool hFlag = false;
    public static bool gFlag = false;
    public static bool lFlag = false; */

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

    public static float GetGoOut() {
        return goOut;
    }

    public static void SetGoOut(float f) {
        goOut = f;
    }

    public static void DeltaGoOut(float f) {
        goOut += f;
    }

    public static void FillBowl()
    {
        bowlFull = 100;
    }

    public static void EmptyBowl()
    {
        bowlFull = 0;
    }


}
