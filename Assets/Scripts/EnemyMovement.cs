using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    public void SetWaveConfig(WaveConfig config)
    {
        this.waveConfig = config;
    }

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.Waypoints;
        transform.position = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex < waypoints.Count)
        {
            var frameSpeed = waveConfig.EnemyMoveSpeed * Time.deltaTime;
            var targetPos =  waypoints[waypointIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, frameSpeed);
            if (targetPos == transform.position)
                waypointIndex++;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
