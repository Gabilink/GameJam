using UnityEngine;

public class PickUpItem : ObjetoInteractuable
{

    [SerializeField] private Item item;

    public override void Interactuar()
    {
        Debug.Log("Recoger" + item.nombre);

        // Aqu� ir�a el c�digo para recoger el objeto
        // destruir el objeto
    }
}