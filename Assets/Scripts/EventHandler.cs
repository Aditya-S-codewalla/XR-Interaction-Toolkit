using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    UnityEventExample refereceUnityEventExample;

    private void Awake()
    {
        refereceUnityEventExample = FindObjectOfType<UnityEventExample>();

        refereceUnityEventExample.testEvent.AddListener(UnityEventHandlerSetWithScript);

        refereceUnityEventExample.testEvent.AddListener((string message) =>
        {
            Debug.Log("Unity event message added via inline lambda function:" + message);
        });
    }

    private void OnEnable()
    {
        refereceUnityEventExample.GenericEventExample += EventHandler_GenericEventExample;

        refereceUnityEventExample.ActionEventExample += EventHandler_ActionEventExample;
    }

    private void EventHandler_ActionEventExample(int arg1, string arg2)
    {
        Debug.Log("The Best footballer in the world is:" + arg1.ToString() + arg2);
    }

    private int EventHandler_GenericEventExample(int a, string s)
    {
        Debug.Log("The best footballer in the world is:" + s + a.ToString());
        return a;
    }

    public void UnityEventHandler(string message) //this method is set via the inspector for our unity event
    {
        Debug.Log("Dynamic unity event message from listener added via inspector:" + message);
    }

    private void UnityEventHandlerSetWithScript(string message)
    {
        Debug.Log("Dynamic unity event message from listener added via script:" + message);
    }

    private void OnDisable()
    {
        refereceUnityEventExample.GenericEventExample -= EventHandler_GenericEventExample;

        refereceUnityEventExample.ActionEventExample -= EventHandler_ActionEventExample;
    }


}
