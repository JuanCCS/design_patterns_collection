using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Handles Creation and maintenance of a grid of cubes
/// </summary>
public class CubeGrid : MonoBehaviour
{
    int numberOfColumns = 8;
    int numberOfRows = 8;
    int cubeSeparation = 4;

    Dictionary<int, GameObject> cubes = new Dictionary<int, GameObject>();
    Dictionary<int, Color> startColors = new Dictionary<int, Color>();

    private void Awake()
    {

        for(int i = 0; i < 64; i++)
        {
            int z = (i / numberOfRows) * cubeSeparation;
            int x = i % numberOfColumns * cubeSeparation;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.right * x + Vector3.back * z;
            cube.transform.parent = this.transform;
            cubes.Add(i, cube);
            startColors.Add(i, cube.GetComponent<Renderer>().material.color);
        }
    }

    private void Start()
    {
        GridStates states = new GridStates(startColors);
        var firstCommand = new CubeCommand(0, 60, Color.red);
        var secondCommand = new CubeCommand(0, 36, Color.green);
        var thirdCommand = new CubeCommand(24, 48, Color.blue);
        var fourthCommand = new CubeCommand(12, 15, Color.yellow);
        firstCommand.Do(states);
        secondCommand.Do(states);
        thirdCommand.Do(states);
        fourthCommand.Do(states);
        states.Render(cubes);
    }

}

public class GridStates
{
    public CubeGridMemento currentState;

    public GridStates(Dictionary<int, Color> startColors)
    {
        currentState = new CubeGridMemento(startColors);
    }

    public void Render(Dictionary<int, GameObject> cubes)
    {
        foreach(KeyValuePair<int, Color> cubeData in currentState.colors)
        {
            Renderer renderer = cubes[cubeData.Key].GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Specular"));
            renderer.material.color = cubeData.Value;
        }
    }
}

public class CubeGridMemento
{
    public Dictionary<int, Color> colors;

    /// <summary>
    /// Constructor that takes a dictionary as parameter
    /// </summary>
    /// <param name="colors">Colors.</param>
    public CubeGridMemento(Dictionary<int, Color> colors)
    {
        this.colors = colors;
    }

    /// <summary>
    /// Copy Constructor
    /// </summary>
    /// <param name="memento">Memento.</param>
    public CubeGridMemento(CubeGridMemento memento)
    {
        colors = memento.colors.ToDictionary(entry => entry.Key, entry => entry.Value);
    }
}

public class CubeCommand
{
    CubeGridMemento startMemento;
    int myStart = 0;
    int myEnd = 0;
    Color myColor;

    public CubeCommand(int rangeStart, int rangeEnd, Color newColor)
    {
        myStart = rangeStart;
        myEnd = rangeEnd;
        myColor = newColor;
    }

    // Let's Modify the colors in a Range
    public void Do(GridStates states)
    {
        startMemento = new CubeGridMemento(states.currentState);

        for (int i = myStart; i < myEnd; i++)
        {
            states.currentState.colors[i] = myColor;
            Debug.Log(myColor);
        }
    }

    // Let's return the colors to the state they were before us
    public void Undo(GridStates states)
    {
        for (int i = myStart; i < myEnd; i++)
        {
            states.currentState.colors[i] = startMemento.colors[i];
        }
    }
}