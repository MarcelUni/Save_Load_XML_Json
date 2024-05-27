using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAMAInterfaces : MonoBehaviour, IMyInterface
{
    void Start()
    {
        MyMethod();
    }

    public void MyMethod()
    {
        Debug.Log("Interface method");
    }
}

public interface IMyInterface
{
    void MyMethod();
}
