using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventExample : MonoBehaviour
{
    [System.Serializable]
    public class TestEvent : UnityEvent<string> { }
    public TestEvent testEvent;

    public delegate int DelegateExample(int a, string s);
    public event DelegateExample GenericEventExample;

    public event Action<int, string> ActionEventExample; //using System library is needed for Action type events

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            testEvent.Invoke("Unity Event Message");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GenericEventExample != null)
            {
                GenericEventExample(7, "Cristiano Ronaldo");
            }
            else
            {
                Debug.Log("No listeners found for out event");
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (ActionEventExample != null)
            {
                ActionEventExample(10, "Leo Messi");
            }
            else
            {
                Debug.Log("No listeners found for this event");
            }
        }
    }
}
