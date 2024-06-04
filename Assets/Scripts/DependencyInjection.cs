using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyInjection : MonoBehaviour
{
    // Denpendency Injection, class is "injected" into method as parameter
    public void Inject(InjectionClass injection)
    {
        Debug.Log("Health: " + injection.health);
        Debug.Log("Damage: " + injection.damage);
        Debug.Log("Speed: " + injection.speed);
    }


    // Dependency on instance of class, NOT dependency injection since its using a class directly
    public InjectionClass ic;
    public void Inject()
    {
        Debug.Log("Health: " + ic.health);
        Debug.Log("Damage: " + ic.damage);
        Debug.Log("Speed: " + ic.speed);
    }
}

public class InjectionClass
{
    public float health;
    public float damage;
    public float speed;
}

