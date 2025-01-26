using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Player_Shoot : MonoBehaviour
{
    private GameControler gameMaster;

    public int damage = 1;
    public float maxDistance = 50f;
    private Ray ray;
    public int numDeArmas = 1;
    public LayerMask layersToHit;

    private int ammo;
    public int GetAmmo() { return ammo; }
    private bool recargando = false;

    public ParticleSystem burbujas;
    public ParticleSystem agua;

    private AudioSource sonido;
    [SerializeField] private AudioClip recargarClip;
    [SerializeField] private AudioClip disparoClip;

    //PROVISIONAL
    public float timeBtwShot = 1;  
    private float timeOfLastShot;

    private void Start()
    {
        gameMaster = GameControler.GetInstance();
        ammo = 10;
        sonido = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameMaster.GetGamePause())
        {

            if (ammo > 0)
            {
                if (Input.GetButtonDown("Fire1") && !recargando)
                {
                    if (Time.time - timeOfLastShot >= timeBtwShot)
                    {
                        Shoot();
                        timeOfLastShot = Time.time;
                        ammo--;
                    }
                }
            }
            else
            {
                StartCoroutine(Recargar());
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Recargar());
            }
        }
    }

    //PARA LA ANIMACION DE DISPARO

    //LA ANIMACION DE DISPARO ACABA CON UN EVENTO QUE ACTIVA LA DE RECARGA LA CUAL TAMBIEN TENDRA UN EVENTO QUE PERMITIRA VOLVER A DISPARAR
    void Shoot()
    {
        sonido.clip = disparoClip;
        sonido.Play();

        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.Log("BANG");
        burbujas.Play();
        agua.Play();
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
        //Debug.Log(hit.collider.gameObject.name + " fue herido");
    }

    public IEnumerator Recargar()
    {
        recargando = true;
        sonido.clip = recargarClip;
        sonido.Play();
        //poner animacion
        yield return new WaitForSeconds(2);
        ammo = 10;
        recargando = false;
    }
}
