﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;



    void Start ()
    {
        target = Waypoints.points[0];
    }

    void Update ()
    {
      
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
            GetNextWayPoint();
        }

    }

    void GetNextWayPoint()
    {
        if ( wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }

    }
}
