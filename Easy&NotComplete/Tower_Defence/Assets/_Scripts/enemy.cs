using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            getNextWaypoint();
        }

    }

    void getNextWaypoint()
    {
        if(wavepointIndex>= waypoints.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }
}
