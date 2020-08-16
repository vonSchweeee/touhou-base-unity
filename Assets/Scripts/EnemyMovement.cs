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
        Debug.Log("Wave config setted");
        this.waveConfig = config;
    }

    IEnumerator Start()
    {
        while (waveConfig == null)
        {
            yield return new WaitForEndOfFrame();
        }
        if (waveConfig != null) 
        {
            waypoints = waveConfig.Waypoints;
            transform.position = waypoints[0].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waveConfig != null)
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
}
