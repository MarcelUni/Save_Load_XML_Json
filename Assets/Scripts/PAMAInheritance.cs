using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAMAInheritance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BaseClass baseObject = new BaseClass();
        ChildClass1 child1Object = new ChildClass1();
        ChildClass2 child2Object = new ChildClass2();

        baseObject.ExampleMethod();  // Outputs: "Base class method""
        child1Object.ExampleMethod(); // Outputs: "Base class method""
        child2Object.ExampleMethod(); // Outputs: "Child class 2 method"
    }
}
class BaseClass
{   
    public virtual void ExampleMethod()
    {
        // This is the base class method
        Debug.Log("Base class method");
    }
}
class ChildClass1 : BaseClass
{
    // This class does not override the base class method
}
class ChildClass2 : BaseClass
{
    public override void ExampleMethod()
    {
        // This is the method that is overrriding the base class method
        Debug.Log("Child class 2 method");
        base.ExampleMethod();
    }
}

