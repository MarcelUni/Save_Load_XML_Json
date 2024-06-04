using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shop<string> itemShop = new Shop<string>();

        Shop<float> floatShop = new Shop<float>();

        floatShop.AddItem(5.5f);
        Debug.Log("Items for sale: " + itemShop.inventory.Count);
    }

    // Update is called once per frame
    void Update()
    {
        float five = 5;
        GenericMethod(five);
        
        string blob = "Blob";
        GenericMethod(blob);
    }
    
    public void GenericMethod<T>(T item)
    {
        Debug.Log(item);
    }


}

public class Shop<T>
{
    public List<T> inventory = new List<T>();

    public void AddItem(T item)
    {
        inventory.Add(item);
    }
}