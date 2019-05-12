using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;


    void Start()
    {
        target = Waypoint3.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (Player.GameOn == 1)
        {
            if (wavepointIndex == Waypoint3.points.Length - 1)
            {
                wavepointIndex = -1;
            }
            wavepointIndex++;
            target = Waypoint3.points[wavepointIndex];
        }
    }
}
