using UnityEngine;
using System.Collections;

public class Granada : MonoBehaviour
{

    [SerializeField] private float explosionRadius;
    [SerializeField] private int dano;


    void Start()
    {
        StartCoroutine(CuentaAtras());
    }

    IEnumerator CuentaAtras()
    {
        yield return new WaitForSeconds(3);
        Explotar();
    }

    void Explotar()
    {
        //Detectar enemigos en un area esferica

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider c in colliders)
        {
            if (c.CompareTag("Enemy"))
            {
                Debug.Log("Enemigo alcanzado");
                
            }
        }

        //Destruir la granada
        Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}