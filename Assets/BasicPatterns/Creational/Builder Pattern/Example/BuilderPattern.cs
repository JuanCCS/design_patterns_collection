using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Main Logic for Builder Pattern
/// </summary>
public class BuilderPattern : MonoBehaviour
{
    List<Type> builders = new List<Type>() { 
        typeof(TopBottomStructureBuilder), typeof(MiddleStructureBuilder) 
    };

    List<Structure> myStructures = new List<Structure>();

    private void Awake()
    {
        foreach(var structureType in builders)
        { 
            // Create a new instance of structure
            Structure structure = new Structure();

            // Fancy way of creating a builder using reflection
            StructureBuilder builder = (StructureBuilder)Activator.CreateInstance(structureType);

            builder.SetStructure(structure);

            // Fancy builder Syntax
            builder
                .BuildFirstFloor()
                .BuildSecondFloor()
                .BuildThirdFloor()
                .BuildFourthFloor();

            myStructures.Add(structure);
        }
    }

    float xDisplacement = 5;
    private void Start()
    {
        for(int i = 0; i < myStructures.Count; ++i)
        {
            foreach(KeyValuePair<int, bool> floor in myStructures[i].myFloors)
            {
                if (floor.Value)
                {
                    Vector3 xPosition = Vector3.right * xDisplacement * i;
                    Vector3 yPosition = Vector3.up * floor.Key;
                    GameObject
                        .CreatePrimitive(PrimitiveType.Cube)
                            .transform.position = (transform.position + xPosition + yPosition);
                }
            }
        }
    }
}

/// <summary>
/// The main class we want to override
/// </summary>
abstract class StructureBuilder
{
    protected Structure myStructure;

    /// <summary>
    /// We assign a Structure object we return in every method call
    /// </summary>
    /// <param name="structure">Structure.</param>
    public void SetStructure(Structure structure)
    {
        myStructure = structure;
    }

    /// <summary>
    /// Build the First Floor of the Object
    /// </summary>
    /// <returns> A reference to this object for prettier code.</returns>
    public virtual StructureBuilder BuildFirstFloor()
    {
        return this;
    }

    public virtual StructureBuilder BuildSecondFloor()
    {
        return this;
    }

    public virtual StructureBuilder BuildThirdFloor()
    {
        return this;
    }
    public virtual StructureBuilder BuildFourthFloor()
    {
        return this;
    }
}

class TopBottomStructureBuilder : StructureBuilder
{
    public override StructureBuilder BuildFirstFloor()
    {
        myStructure.myFloors.Add(0, true);
        return base.BuildFirstFloor();   
    }

    public override StructureBuilder BuildFourthFloor()
    {
        return base.BuildFourthFloor();
    }

    public override StructureBuilder BuildSecondFloor()
    { 
        return base.BuildSecondFloor();
    }

    public override StructureBuilder BuildThirdFloor()
    {
        myStructure.myFloors.Add(3, true);
        return base.BuildThirdFloor();
    }
}

class MiddleStructureBuilder : StructureBuilder
{
    public override StructureBuilder BuildFirstFloor()
    {
        return base.BuildFirstFloor();
    }

    public override StructureBuilder BuildFourthFloor()
    {
        myStructure.myFloors.Add(1, true);
        return base.BuildFourthFloor();
    }

    public override StructureBuilder BuildSecondFloor()
    {
        myStructure.myFloors.Add(2, true);
        return base.BuildSecondFloor();
    }

    public override StructureBuilder BuildThirdFloor()
    {
        return base.BuildThirdFloor();
    }
}

/// <summary>
/// Data Model for a Structure composed of Cubes in The Scene
/// </summary>
class Structure
{
    public Dictionary<int, bool> myFloors;
    public Structure()
    {
        myFloors = new Dictionary<int, bool>();
    }
}
