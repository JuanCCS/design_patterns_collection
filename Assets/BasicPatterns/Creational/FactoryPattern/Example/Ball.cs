using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// Factory Method
    /// </summary>
    /// <returns> The initialized ball. </returns>
    /// <param name="ballPrototype">Ball prototype.</param>
    public static Ball Init(GameObject ballPrototype)
    {

        GameObject ball = Instantiate(ballPrototype);
        return ball.AddComponent<Ball>();
    }

    public Ball SetColor(Color color)
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Specular"));
        rend.material.color = color;
        return this;
    }

    public Ball SetSize(int size)
    {
        transform.localScale *= size;
        return this;
    }


    float xSeparation = 5;
    public Ball SetPosition(int position)
    {
        transform.position += Vector3.right * xSeparation * position;
        return this;
    }
}