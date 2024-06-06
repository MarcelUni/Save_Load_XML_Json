using System.Collections;
using System.Collections.Generic;
using MyExtensions;
using UnityEngine;


public class ClassExtensions : MonoBehaviour
{
    private Vector3 vector = new Vector3(1, 2, 3);
    // Start is called before the first frame update
    void Start()
    {
        vector.DebugVector();
    }

}


// Creating the namespace for the extension method
namespace MyExtensions
{
    // Creating the extension method for the Vector3 class
    public static class Vector3Extensions
    {   
        // This is the extension method
        public static void DebugVector(this Vector3 vector)
        {
            Debug.Log("x: " + vector.x + " y: " + vector.y + " z: " + vector.z);
        }
    }
}


