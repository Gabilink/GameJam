using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public int damage = 1;
    public float maxDistance = 50f;
    private Ray ray;
    public int numDeArmas = 1;
    public LayerMask layersToHit;

    public ParticleSystem burbujas;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) { Shoot(); }
    }
    void Shoot()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.Log("BANG");
        burbujas.Play();
        CheckCollider();
    }
    void CheckCollider()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance/*layersToHit*/) && hit.collider.gameObject.tag=="Enemy")
        {
            //Debug.DrawRay(ray.origin, ray.direction * maxDistance);
            EnemyMovement enemyScript = hit.transform.GetComponent<EnemyMovement>();
            if(enemyScript!=null)
            {
                enemyScript.Damage(damage);
            }
            else
            {
                Debug.Log("No se encontro el script enemigo");
            }
            Debug.Log(hit.collider.gameObject.name + " fue herido");
        }
        if (Physics.Raycast(ray, out RaycastHit golpe, maxDistance/*layersToHit*/) && hit.collider.gameObject.tag == "Painting")
        {
            Cuadros cuadros = hit.transform.GetComponent<Cuadros>();
            cuadros.Limpiar();
        }
    }
}
