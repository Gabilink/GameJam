using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent angente;

    private Transform playerPos;

    void Start()
    {
        angente = GetComponent<NavMeshAgent>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        angente.SetDestination(playerPos.position);
    }

}