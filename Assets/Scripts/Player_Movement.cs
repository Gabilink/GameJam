using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private GameControler gameMaster;

    private CharacterController playerController;
    public float playerSpeed = 10f;
    private float vSpeed = 0;
    private float gravity = 9.8f;

    public float sensitivityMouse = 10f;
    public Transform playerBody;
    public Transform cameraBody;
    float xRotation = 0f;

    private float life = 100;
    public float GetLife() { return life; }
    public void SetLife(float _life) { life = _life; }

    private bool alive;

    private int escudo;
    public int GetEscudo() { return escudo; }
    public void SetEscudo(int _escudo) { escudo = _escudo; }

    private int ammo;
    public int GetAmmo() { return ammo; }
    public void SetAmmo(int _ammo)
    {
        ammo = _ammo;
        disparosScr.StartCoroutine(disparosScr.Recargar());
    }

    private int granadas = 0;
    public int GetGranadas() { return granadas; }
    public void SetGranadas(int _granadas) { granadas = _granadas; }
    [SerializeField] private GameObject granada;

    private Player_Shoot disparosScr;

    private AudioSource sonido;
    [SerializeField] private AudioClip[] sufrir;
    [SerializeField] private AudioClip recibirImpacto;
    [SerializeField] private AudioClip lanzar;


    void Start()
    {
        gameMaster = GameControler.GetInstance();
        sonido = GetComponent<AudioSource>();
        disparosScr = GetComponent<Player_Shoot>();
        alive = true;
        playerController = GetComponent<CharacterController>();
        LockCursor();
    }
    void Update()
    {
        if(!gameMaster.GetGamePause())
        {
            if (alive)
            {
                PlayerMove();
                PlayerRotate();
            }
            Vector3 vel = transform.forward * Input.GetAxis("Vertical") * playerSpeed;
            vSpeed -= gravity * Time.deltaTime;
            vel.y = vSpeed; // include vertical speed in vel
                            // convert vel to displacement and Move the character:
            playerController.Move(vel * Time.deltaTime);

            ammo = disparosScr.GetAmmo();

            if (Input.GetKeyDown(KeyCode.E))
            {
                LanzarGrana();
            }
        }
        
    }
    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        playerController.Move(move * playerSpeed * Time.deltaTime);
    }
    void LockCursor()
    {
        if(gameMaster.GetGamePause() == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
    void PlayerRotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // vertical rotation
        cameraBody.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // horizontal rotation 
        playerBody.Rotate(Vector3.up * mouseX);
    }
    //PARA RECIBIR DAMAGE
    public void RecibirDano(float d)
    {
        sonido.clip = recibirImpacto;
        sonido.Play();
        life -= d;
        if (life <= 0)
        {
            sonido.clip = sufrir[Random.Range(0, sufrir.Length)];
            sonido.Play();
            alive = false;
            gameMaster.SetGameOver(true);
        }
    }

    void LanzarGrana()
    {
        if (granadas > 0)
        {
            sonido.clip = lanzar;
            sonido.Play();
            granadas--;
            Instantiate(granada, transform.position + transform.forward, Quaternion.identity);
        }
    }
}
