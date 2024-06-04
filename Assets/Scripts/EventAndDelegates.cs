using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventAndDelegates : MonoBehaviour
{
    public delegate void SpacePressed(); 
    public event SpacePressed OnSpacePressed;
    //public SpacePressed OnSpacePressed;

    void Start()
    {
        OnSpacePressed += WriteOne;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnSpacePressed != null)
            {
                OnSpacePressed();
            }
        }
    }
    private void WriteOne()
    {
        Debug.Log("One");
        OnSpacePressed -= WriteOne;
        OnSpacePressed += WriteTwo;
    }
    private void WriteTwo()
    {
        Debug.Log("Two");
        OnSpacePressed -= WriteTwo;
        OnSpacePressed += WriteThree;
    }
    private void WriteThree()
    {
        Debug.Log("Three");
        OnSpacePressed -= WriteThree;
        EventSubscriber eventSub = new EventSubscriber(this);
    }
}

public class EventSubscriber
{
    private EventAndDelegates eventAndDelegates;

    public EventSubscriber(EventAndDelegates eventAndDelegates)
    {
        this.eventAndDelegates = eventAndDelegates;
        
        this.eventAndDelegates.OnSpacePressed += WriteFour;
    }

    private void WriteFour()
    {
        Debug.Log("Four from other subscriber class");
        eventAndDelegates.OnSpacePressed -= WriteFour;
    }
}
