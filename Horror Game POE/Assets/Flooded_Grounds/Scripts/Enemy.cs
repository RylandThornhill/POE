using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent Monster;

    public GameObject Player;

    public float MonsterDistanceRun = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Monster = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //Run towards player

        if (distance < MonsterDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            Monster.SetDestination(newPos);
        }
    }
}
