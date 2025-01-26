using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Animator anim;

    private int enemyLife = 3;
    //private bool sucio;
    private NavMeshAgent angente;

    private Transform playerPos;

    public Emo1_Attack emo1;

    public Emo2_Attack emo2;

    public ParticleSystem limpio;

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
        if(emo1!=null)
        {
            if (!anim.GetBool("Attacking"))
            {
                emo1.DeactivateHitbox();
            }
        }
        //if (emo2 != null)
        //{
        //    if (!anim.GetBool("Attacking"))
        //    {
        //        //emo2.DeactivateHitbox();
        //    }
        //}

    }
    void LateUpdate()
    {
        //transform.rotation = Camera.main.transform.rotation;
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
    }
    public void Damage(int dano)
    {
        enemyLife -= dano;
        if(enemyLife<=0)
        {
            //sucio = false;
            limpio.Play();
            anim.SetBool("Dirty", false);
            //Debug.Log("MUERTO CONO");
            if (emo1 != null)
            {
                emo1.DeactivateHitbox();
            }
        }
    }
}