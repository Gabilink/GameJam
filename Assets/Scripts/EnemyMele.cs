using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMele : MonoBehaviour
{
    [SerializeField] private int distanciaAtaque;
    [SerializeField] private int dano;
    private NavMeshAgent agente;

    private GameObject playerGO;
    

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.stoppingDistance = distanciaAtaque;
    }
}