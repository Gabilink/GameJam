using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMele : MonoBehaviour
{
    [SerializeField] private int distanciaAtaque;
    [SerializeField] private int dano;
    private NavMeshAgent agente;
    private bool attacking;
    public GameObject hitbox;

    private GameObject playerGO;
    private Player_Movement playerScr;

    public Animator anim;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.stoppingDistance = distanciaAtaque;

        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScr = playerGO.GetComponent<Player_Movement>();

        hitbox.SetActive(false);
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
            Debug.Log("ATAQUE");
            StartCoroutine(Atacar());
            anim.SetBool("Attacking", true);
        }
    }

    IEnumerator Atacar()
    {
        if (!attacking)
        {         
            attacking = true;
            yield return new WaitForSeconds(2f);          
            attacking = false;
            anim.SetBool("Attacking", false);
        }
    }
    public void ActivateHitbox(string a)
    {
        hitbox.SetActive(true);
        Debug.Log(a);
    }
    public void DeactivateHitbox()
    {
        hitbox.SetActive(false);
    }
}