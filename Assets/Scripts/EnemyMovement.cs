using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private int enemyLife = 4;
    private bool enemyMove;
    private NavMeshAgent angente;

    private Transform playerPos;

    void Start()
    {
        angente = GetComponent<NavMeshAgent>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        enemyMove = true;//esto se le pondra un if para cuando vea al jugador
    }

    void Update()
    {
        if(enemyMove)
        {
            angente.SetDestination(playerPos.position);
        }
    }
    public void Damage(int daño)
    {
        enemyLife -= daño;
        if(enemyLife<=0)
        {
            enemyMove = false;
        }
    }
}