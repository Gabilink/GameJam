using UnityEngine;

public class PickUpItem : ObjetoInteractuable
{

    [SerializeField] private Item item;

    public override void Interactuar()
    {
        Debug.Log("Recoger" + item.nombre);

        // Aquí iría el código para recoger el objeto
        // destruir el objeto
    }
}