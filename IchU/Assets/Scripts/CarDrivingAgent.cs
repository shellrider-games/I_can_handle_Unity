using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarDrivingAgent : MonoBehaviour
{
    [SerializeField]
    private Transform point1;
    [SerializeField]
    private Transform point2;

    private bool _returnPath = false;

    private NavMeshAgent _agent;

    private ScanForPlayer _scanForPlayer;

    private IEnumerator _slowDown;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = point1.position;
        _scanForPlayer = GetComponent<ScanForPlayer>();
        _scanForPlayer.OnPlayerDetected += PlayerDetected;
        AkSoundEngine.PostEvent("engine_on", gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.1f)
        {
            if (!_returnPath)
            {
                _agent.destination = point2.position;
            }
            else
            {
                _agent.destination = point1.position;
            }

            _returnPath = !_returnPath;
        }
        AkSoundEngine.SetRTPCValue("car_speed", _agent.velocity.magnitude);
    }

    private void PlayerDetected()
    {
        _agent.speed = 14;
        if (_slowDown != null)
        {
            StopCoroutine(_slowDown);
        }
        _slowDown = SlowDown();
        StartCoroutine(_slowDown);
    }

    private IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(2);
        _agent.speed = 8;
    }
}
