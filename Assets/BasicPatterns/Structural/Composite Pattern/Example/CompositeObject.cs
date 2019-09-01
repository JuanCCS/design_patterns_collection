using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Property
{
    public string Name;
    public float Value;
    public Property(string name, float value)
    {
        Name = name;
        Value = value;
    }
}

public class CompositeObject : MonoBehaviour
{   
    List<Property> properties;

    private void Awake()
    {
        properties = new List<Property>();
        properties.Add(new Property("Health", 50));
        properties.Add(new Property("Speed", 20));
        properties.Add(new Property("Luck", 30));
    }

    public float Sum(){
        float sum = 0;
        foreach(Property property in properties){
            sum += property.Value;
        }
        return sum;
    }
}


