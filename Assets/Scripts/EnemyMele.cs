using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMele : MonoBehaviour
{
    [SerializeField] private int distanciaAtaque;
    [SerializeField] private int dano;
    private NavMeshAgent agente;

    private GameObject playerGO;
    private Player_Movement playerScr;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.stoppingDistance = distanciaAtaque;

        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScr = playerGO.GetComponent<Player_Movement>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, playerGO.transform.position) >= distanciaAtaque)
        {
            agente.SetDestination(playerGO.transform.position);
        }
        else
        {
            agente.SetDestination(transform.position);
            StartCoroutine(Atacar());
        }
    }

    IEnumerator Atacar()
    {
        yield return new WaitForSeconds(1);
    }
}