using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMele : MonoBehaviour
{
    [SerializeField] private int distanciaAtaque;
    private NavMeshAgent agente;
    private bool attacking;

    private GameObject playerGO;
    private Player_Movement playerScr;

    private Rigidbody rb;

    public Animator animator;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.stoppingDistance = distanciaAtaque;

        playerGO = GameObject.FindGameObjectWithTag("Player");

        playerScr = playerGO.GetComponent<Player_Movement>();

        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (animator.GetBool("Dirty"))
        {
            if (Vector3.Distance(transform.position, playerGO.transform.position) >= distanciaAtaque)
            {
                agente.SetDestination(playerGO.transform.position);
            }
            else
            {
                agente.SetDestination(transform.position);
                StartCoroutine(Atacar());
                animator.SetBool("Attacking", true);
            }
        }
                     
    }
    private void FixedUpdate()
    {
        Vector3 vel = rb.linearVelocity;
        if (vel.magnitude!=0)
        {
            animator.SetBool("Walking", true);
        }
        if (vel.magnitude == 0)
        {
            animator.SetBool("Walking", false);
        }
    }

    IEnumerator Atacar()
    {
        if (!attacking)
        {
            animator.SetBool("Dirty", true);
            attacking = true;
            yield return new WaitForSeconds(2f);          
            attacking = false;
            animator.SetBool("Attacking", false);
        }
    }

}