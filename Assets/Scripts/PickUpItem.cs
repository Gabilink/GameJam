using UnityEngine;

public class PickUpItem : ObjetoInteractuable
{

    [SerializeField] private Item item;

    public override void Interactuar()
    {
        Debug.Log("Recoger" + item.nombre);

        // Aquí iría el código para recoger el objeto
        //comprobar cantidad de salur, escudo, ammo, granadas
        //si no está al tope se suma y se destruye el objeto.
        //si está al tope sale un mensaje en pantalla y no se hace nada


        Destroy(gameObject);
    }
}