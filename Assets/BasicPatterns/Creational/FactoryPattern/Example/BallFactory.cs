using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BallParams
{
    public int m_size;
    public Color m_color;

    public BallParams(int size, Color color)
    {
        m_size = size;
        m_color = color;
    }
}

/// <summary>
/// Instantiates Ball given certain parameters
/// </summary>
[CreateAssetMenu(menuName = "Factory/BallFactory")]
public class BallFactory : ScriptableObject
{
    public GameObject ballPrototype;

    /// <summary>
    /// Creates balls and gives a way to access them
    /// </summary>
    /// <returns>The balls.</returns>
    /// <param name="ballParams">Board parameters.</param>
    public Dictionary<int, Ball> CreateBalls(BallParams[] ballParams)
    {
        var balls = new Dictionary<int, Ball>();

        for(int i = 0; i < ballParams.Length; i++)
        {
            BallParams currentParams = ballParams[i];
            Ball ball = Ball.Init(ballPrototype)
                .SetSize(currentParams.m_size)
                .SetColor(currentParams.m_color)
                .SetPosition(i);
            balls.Add(i, ball);
        }

        return balls;
    }
}
