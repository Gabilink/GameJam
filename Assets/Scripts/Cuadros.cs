using UnityEngine;

public class Cuadros : MonoBehaviour
{
    public Material cuadroSucio;
    public Material cuadroLimpio;
    public ParticleSystem burbujas;
    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = cuadroSucio;
    }
    public void Limpiar()
    {
        //Cambio de material y poner particulas
        gameObject.GetComponent<MeshRenderer>().material = cuadroLimpio;
        burbujas.Play();
    }
}
