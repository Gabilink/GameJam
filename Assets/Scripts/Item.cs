using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public string nombre;

    public int salud;
    public int escudo;
    public int ammo;
    public int granadas;
}