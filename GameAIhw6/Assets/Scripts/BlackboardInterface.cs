using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackboardInterface : MonoBehaviour {

    /* ABANDONED

    [SerializeField]
    int Lonely = 0;
    [SerializeField]
    int Hungry = 0;
    [SerializeField]
    int Tired = 0;
    [SerializeField]
    int GoOut = 0;

    int lonely = 0;
    int hungry = 0;
    int tired = 0;
    int goOut = 0;

    void Update() {

        if (Blackboard.lFlag) {
            Lonely = (int)Blackboard.GetLonely();
            lonely = (int)Blackboard.GetLonely();
            Blackboard.lFlag = false;
        }
        if (Blackboard.hFlag) {
            Hungry = (int)Blackboard.GetHungry();
            hungry = (int)Blackboard.GetHungry();
            Blackboard.hFlag = false;
        }
        if (Blackboard.gFlag) {
            GoOut = (int)Blackboard.GetGoOut();
            goOut = (int)Blackboard.GetGoOut();
            Blackboard.gFlag = false;
        }
        if (Blackboard.tFlag) {
            Tired = (int)Blackboard.GetTired();
            tired = (int)Blackboard.GetTired();
            Blackboard.tFlag = false;
        }

        if (Lonely != lonely) {
            lonely = Lonely;
            Blackboard.SetLonely(lonely);
        }
        if (Hungry != hungry) {
            hungry = Hungry;
            Blackboard.SetHungry(hungry);
        }
        if (Tired != tired) {
            tired = Tired;
            Blackboard.SetTired(tired);
        }
        if (GoOut != goOut) {
            goOut = GoOut;
            Blackboard.SetGoOut(goOut);
        } 
    } */

}
