using UnityEngine;

public class Cuadros : MonoBehaviour
{
    public GameObject cuadro;
    public Material marcoLimpio;
    public Material cuadroLimpio;
    public ParticleSystem burbujas;
    private bool limpio;
    private void Start()
    {
        limpio = false;
    }
    public void Limpiar()
    {
        //Cambio de material y poner particulas
        if(!limpio)
        {
            gameObject.GetComponent<MeshRenderer>().material = marcoLimpio;
            cuadro.GetComponent<MeshRenderer>().material = cuadroLimpio;
            burbujas.Play();
            limpio = true;
        }        
    }
}
