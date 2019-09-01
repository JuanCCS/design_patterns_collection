using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveCube : MonoBehaviour
{
    public GameEvent myEvent;

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        myEvent.Raise();
    }
}
