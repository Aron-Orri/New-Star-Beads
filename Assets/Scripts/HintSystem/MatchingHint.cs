using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingHint : MonoBehaviour
{
    public float MaxTime = 60;
    public float CurrentTime;
    public bool TimerActive;
    public bool CorrectShape;
   

    [SerializeField] private MatchingManager matchingSystem;
    List<GameObject> buttonObjects;

   

    //Main plan as of right now is to attach this to each button and grab if its the correct one or not, then after a minute the button if correct will have an outline attached
    //If the player interacts with any button it will trigger an event that will reset the timer on all buttons. At least that's the plan

    // Start is called before the first frame update
    void Start()
    {
        TimerActive = true;
        CurrentTime = MaxTime;
        
        // The below two lines gives the error: NullReferenceException: Object reference not set to an instance of an object MatchingHint.Start()(at Assets / Scripts / HintSystem / MatchingHint.cs:21)
        //List<GameObject> somescript = transform.parent.gameObject.GetComponent<MatchingManager>().GetCorrectButtons();
        //Debug.Log(somescript);
        buttonObjects = matchingSystem.GetComponent<MatchingManager>().GetCorrectButtons();
        Debug.Log(buttonObjects);

    }
    
    void TimerRestart()
    {
        CurrentTime = MaxTime;
        Debug.Log(CurrentTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerActive == true)
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
            }
            else
            {
                foreach (var obj in buttonObjects)
                {
                    var outline = obj.AddComponent<UnityEngine.UI.Outline>();
                    outline.effectColor = Color.green;
                    outline.effectDistance = new Vector2(10, 10);
                }
                TimerActive = false;
                Debug.Log("TimerStopped");
            }
        }

    }
    
}
