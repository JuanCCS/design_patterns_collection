using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Builds a chess tile on the board
/// </summary>
public class ChessTile : MonoBehaviour
{
    public static ChessTile Init(ChessTile tilePrototype)
    {
        return Instantiate(tilePrototype);
    }

    public ChessTile SetPosition()
    {
        return this;
    }

    public ChessTile SetColor()
    {
        return this;
    }
}

