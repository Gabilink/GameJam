using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour
{

    private Vector3 posicionCerrado;
    private Vector3 posicionAbierto;

    private bool abierta = false;

    private GameObject player;

    [SerializeField] private Vector3 posGizmos;
    [SerializeField] private float radio;

    void Start()
    {
        posicionCerrado = new Vector3(0.0f, 0.0f, 0.0f);
        posicionAbierto = new Vector3(0.0f, 0.0f, 90.0f);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Abrir()
    {
        transform.rotation = Quaternion.Euler(posicionAbierto);
    }

    void Cerrar()
    {
        transform.rotation = Quaternion.Euler(posicionCerrado);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (!abierta)
            {
                Abrir();
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(posGizmos, radio);
    }

}