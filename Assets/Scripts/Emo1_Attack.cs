using UnityEngine;

public class Emo1_Attack : MonoBehaviour
{
    Player_Movement playerScript;
    Transform player;
    private bool attacking;
    private bool repetir;
    public float damage;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerScript = player.GetComponent<Player_Movement>();
        attacking = false;
    }
    public void ActivateHitbox()
    {      
        attacking = true;
    }
    public void DeactivateHitbox()
    {        
        attacking = false;
    }
    private void Update()
    {
        if(attacking && repetir)
        {
            if(Vector3.Distance(transform.position, player.position)<=3f)
            {
                playerScript.RecibirDano(damage);
                Debug.Log("golpe");
                repetir = false;
            }
        }
        if(!attacking && !repetir)
        {
            repetir = true;
        }
    }
}
