using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    public BallFactory BallFactory;
    Dictionary<int, Ball> balls;

    // Start is called before the first frame update
    void Start()
    {
        var ballParams = new List<BallParams>()
        {
            new BallParams(1, Color.green),
            new BallParams(2, Color.red),
            new BallParams(1, Color.blue),
            new BallParams(4, Color.red)
        };

        balls = BallFactory.CreateBalls(ballParams.ToArray());
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad > 2.0f)
        {
            balls[0].transform.position += Vector3.up * Time.deltaTime;
        }
    }
}
