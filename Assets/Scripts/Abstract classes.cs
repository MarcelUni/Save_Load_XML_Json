using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExtensions;

public class Abstractclasses : MonoBehaviour
{
    void Start()
    {
        // This throws an error because it is abstract
        //AbstractClass abstractObject = new AbstractClass();

        // This does not since it is a child class, inheriting from the abstract class
        ChildClass childObject = new ChildClass();
        
    }
}

// This is the abstract class, we can not instantiate this class
public abstract class AbstractClass
{
    public virtual void AbstractMethod()
    {
        Debug.Log("Abstract class method");
    }

}

// This is the child class that inherits from the abstract class
public class ChildClass : AbstractClass
{
    public override void AbstractMethod()
    {
        Debug.Log("Child class method");
    }
}
