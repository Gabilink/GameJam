using UnityEditor.Build;
using UnityEngine;

public class PickUpItem : ObjetoInteractuable
{

    [SerializeField] private Item item;

    public override void Interactuar()
    {
        Debug.Log("Recoger" + item.nombre);

        playerScr.SetLife(item.salud);
        playerScr.SetEscudo(item.escudo);
        playerScr.SetAmmo(item.ammo);
        playerScr.SetGranadas(item.granadas);

        Destroy(gameObject);
    }
}