using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] WaveConfig _waveConfig;
    List<Transform> _waypoints;
    [SerializeField] float _moveSpeed = 2f;

    int _waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _waypoints = _waveConfig.Waypoints;
        transform.position = _waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_waypointIndex < _waypoints.Count)
        {
            var frameSpeed = _moveSpeed * Time.deltaTime;
            var targetPos =  _waypoints[_waypointIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, frameSpeed);
            if (targetPos == transform.position)
                _waypointIndex++;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
