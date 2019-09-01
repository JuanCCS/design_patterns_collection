using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{

    public ChessTileFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<TileIndex, ChessTile> tiles = factory.CreateChessBoard(new ChessBoardParams(8, 8, 10));
    }
}
