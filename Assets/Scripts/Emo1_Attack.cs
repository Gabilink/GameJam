using UnityEngine;

public class Emo1_Attack : MonoBehaviour
{
    public GameObject hitbox;
    public void ActivateHitbox()
    {
        hitbox.SetActive(true);
    }
    public void DeactivateHitbox()
    {
        hitbox.SetActive(false);
    }
}
