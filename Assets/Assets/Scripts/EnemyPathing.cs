﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveconfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveconfig.getWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void setWaveConfig(WaveConfig waveConfigSet)
    {
        this.waveconfig = waveConfigSet;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveconfig.getMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards
                (transform.position,
                    targetPosition,
                    movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
