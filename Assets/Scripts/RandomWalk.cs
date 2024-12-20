using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]

public class RandomWalk : MonoBehaviour
{
    public float _Range = 25.0f;
    public float detRange;

    NavMeshAgent _Agent;

    public Transform zombie;
    public Transform player;

    public GameObject deathScreen;

    void Start()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // && AND
        // || OR

        //If AI is still moving
        if (_Agent.pathPending || !_Agent.isOnNavMesh || _Agent.remainingDistance > 0.1f)
        {
            //Exit function (update) here
            return;
        }

        //Choose a random point
        Vector3 randomPosition = _Range * Random.insideUnitCircle;
        randomPosition = new Vector3(randomPosition.x, 0, randomPosition.y);
        _Agent.destination = transform.position + randomPosition;

        if (Vector3.Distance(zombie.position, player.position) < detRange)
        {
            _Agent.destination = player.position;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Time.timeScale = 0;

        deathScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("AHHH");
        Time.timeScale = 1;
    }
}