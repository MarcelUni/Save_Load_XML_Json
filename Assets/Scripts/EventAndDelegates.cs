using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventAndDelegates : MonoBehaviour
{
    public delegate void SpacePressed(); 
    //public SpacePressed OnSpacePressed;
    public event SpacePressed OnSpacePressed;

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
    }
}
