using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Animator anim;

    private int enemyLife = 4;
    private bool sucio;
    private NavMeshAgent angente;

    private Transform playerPos;

    void Start()
    {

        //angente = GetComponent<NavMeshAgent>();
        //playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        //sucio = true;//esto se le pondra un if para cuando vea al jugador
        anim.SetBool("Dirty", true);
    }

    void Update()
    {
        //if(sucio)
        //{
        //    angente.SetDestination(playerPos.position);
        //}
    }
    public void Damage(int daño)
    {
        enemyLife -= daño;
        if(enemyLife<=0)
        {
            sucio = false;
            anim.SetBool("Dirty", false);
            Debug.Log("MUERTO CONO");
        }
    }
}