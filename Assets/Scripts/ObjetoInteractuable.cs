using UnityEngine;

public class ObjetoInteractuable : MonoBehaviour
{
    [SerializeField] private float radio;
    private SphereCollider hitbox;

    private bool playerEnRango;
    private GameObject player;
    private Player_Movement playerScr;

    private void Start()
    {
        hitbox = GetComponent<SphereCollider>();
        hitbox.radius = radio;
        player = GameObject.FindWithTag("Player");
    }

    public virtual void Interactuar()
    {
        Debug.Log("Interactuar con objeto");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interactuar();
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);
    }



}