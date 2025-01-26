using UnityEngine;

public class Emo2_Attack : MonoBehaviour
{
    //FALTA RB PARA EL WALKING
    public GameObject monsterLata;
    public GameObject puntoSalida;
    private Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        
    }
    public void LanzarMonster()
    {
        Vector3 relativePos = target.position - transform.position;
        Instantiate(monsterLata, puntoSalida.transform.position, Quaternion.LookRotation(relativePos, Vector3.up));
    }
    public void ReiniciarAtaque()
    {

    }
}
