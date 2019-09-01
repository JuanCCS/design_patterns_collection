using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ChessBoardParams
{
    public int width;
    public int height;
    public int tileSize;
    public ChessBoardParams(int width, int height, int tileSize)
    {
        this.width = width;
        this.height = height;
        this.tileSize = tileSize;
    }
}

public struct TileIndex
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public TileIndex(int x, int y)
    {
        X = x;
        Y = y;
    }

}

/// <summary>
/// Creates a ChessBoard in the Center of the Scene with the given parameters
/// </summary>
public class ChessTileFactory : ScriptableObject
{
    public ChessTile tilePrototype;

    /// <summary>
    /// Creates a Chessboard with the specified tileSize, height and with
    /// </summary>
    /// <returns>The chess board.</returns>
    /// <param name="boardParams">Board parameters.</param>
    public Dictionary<TileIndex, ChessTile> CreateChessBoard(ChessBoardParams boardParams)
    {
        var chessBoard = new Dictionary<TileIndex, ChessTile>();
        for (int i = 0; i < boardParams.height; i++)
        {
            for(int j = 0; j < boardParams.width; j++)
            {
                ChessTile tile = ChessTile.Init(tilePrototype).SetPosition().SetColor();

                TileIndex index = new TileIndex(j, i);
                chessBoard.Add(index, tile);
            }
        }
        return chessBoard;
    }
}
