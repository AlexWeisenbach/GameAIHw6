using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIControl : MonoBehaviour
{
    public Text textbox;
    public Text clock;
    public Text readout;
    public ScrollRect scroll;
    private string displayedText = "";
    private bool readoutVisible = false;
    //public Blackboard blackboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool timeChange = false;
        if(Input.GetKeyDown("f"))
        {
            Blackboard.FillBowl();
            Log("You fill Vito's bowl with dog food.");
            
        }
        else if (Input.GetKeyDown("t"))
        {
            //Figure out how a treat should change blackboard values
            Log("You give Vito a tasty treat.");
            
        }
        else if (Input.GetKeyDown("k"))
        {
            Blackboard.thrown = true;
            Log("You throw a stick for Vito.");
            
        }
        else if (Input.GetKeyDown("p"))
        {
            Blackboard.DeltaLonely(-10);
            if (Blackboard.GetLonely() > 0) {
                Blackboard.SetLonely(0);
            }
            Log("You pet Vito.");
            
        }
        else if (Input.GetKeyDown("b"))
        {
            Log("You rub Vito's belly.");
            
        }
        else if (Input.GetKeyDown("w"))
        {
            Log("You and Vito go for a walk");
            
        }
        else if (Input.GetKeyDown("l"))
        {
            Log("You give Vito some time to himself.");
            
        }
        else if (Input.GetKeyDown("g"))
        {
            Log("You go to work, the grind never stops.");
            
        }
        else if (Input.GetKeyDown("a"))
        {
            Log("You get home from work");
            
        }
        else if (Input.GetKeyDown("i"))
        {
            Log("15 minutes passes");
            Clock.AdvanceTime(15);
            timeChange = true;
            
        }
        else if (Input.GetKeyDown("h"))
        {
            Log("An hour passes.");
            Clock.AdvanceTime(60);
            timeChange = true;
            
        }
        else if (Input.GetKeyDown("d"))
        {
            Log("A new day begins.");
            timeChange = true;
            
        }
        else if (Input.GetKeyDown("s"))
        {
            Log("Vito hears a mysterious noise!");
            
        }
        else if(Input.GetKeyDown("1"))
        {
            readoutVisible = !readoutVisible;
        }

        float hours = Clock.getTime() / 60;
        float minutes = Clock.getTime() % 60;
        clock.text = hours.ToString("00") + ":" + minutes.ToString("00");

        
        if(readoutVisible)
        {
            readout.gameObject.GetComponentInParent<CanvasRenderer>().gameObject.transform.localScale = new Vector3(1, 1, 1);
            readout.text = "Lonely: " + Blackboard.GetLonely() + "\nHungry: " + Blackboard.GetHungry() + "\nTired: " + Blackboard.GetTired() + "\nGo out:" + Blackboard.GetGoOut();
        }
        else
        {
            readout.gameObject.GetComponentInParent<CanvasRenderer>().gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        
    }

    public void Log(string line)
    {
        if (displayedText == "")
            displayedText = line;
        else
            displayedText = displayedText + "\n" + line;
        textbox.text = displayedText;
        StartCoroutine(ScrollToBottom());
    }

    IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        scroll.normalizedPosition = new Vector2(0, 0);
    }
}
