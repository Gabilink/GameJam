using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour
{
    private Animator animator;
    private bool abierta = false;

    private GameObject player;

    [SerializeField] private Vector3 posGizmos;
    [SerializeField] private float radio;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Abrir()
    {
        animator.SetBool("abrir", true);
    }

    void Cerrar()
    {
        animator.SetBool("abrir", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Puerta OnTriggerEnter");
        if (other.gameObject == player)
        {
            Abrir();
            if (!abierta)
            {
                
                abierta = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            if (abierta)
            {
                Cerrar();
                abierta = false;
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(posGizmos, radio);
    //}

}