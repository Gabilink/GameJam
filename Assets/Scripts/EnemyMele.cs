using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMele : MonoBehaviour
{
    private GameControler gameMaster;

    [SerializeField] private int distanciaAtaque;
    private NavMeshAgent agente;
    private bool attacking;
    [SerializeField] private int ataque;

    private GameObject playerGO;
    private Player_Movement playerScr;

    private Rigidbody rb;

    public Animator animator;

    private void Start()
    {
        gameMaster = GameControler.GetInstance();

        agente = GetComponent<NavMeshAgent>();
        agente.stoppingDistance = distanciaAtaque;

        playerGO = GameObject.FindGameObjectWithTag("Player");

        playerScr = playerGO.GetComponent<Player_Movement>();

        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {


        if (Vector3.Distance(transform.position, playerGO.transform.position) <= distanciaAtaque)
        {
            agente.SetDestination(transform.position);
            if (!attacking)
            {
                animator.SetBool("Attacking", true);
                StartCoroutine(Atacar());
            }
        }
        else
        {
            agente.SetDestination(playerGO.transform.position);
        }

        //private void FixedUpdate()
        //{
        //    Vector3 vel = rb.linearVelocity;
        //    if (vel.magnitude!=0)
        //    {
        //        animator.SetBool("Walking", true);
        //    }
        //    if (vel.magnitude == 0)
        //    {
        //        animator.SetBool("Walking", false);
        //    }
        //}

        IEnumerator Atacar()
        {
            if (!attacking)
            {
                animator.SetBool("Dirty", true);
                attacking = true;
                yield return new WaitForSeconds(2f);
                playerScr.RecibirDano(ataque);
                attacking = false;
                animator.SetBool("Attacking", false);
            }
        }

    }
}