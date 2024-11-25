using UnityEngine;

public class MeleeInput : MonoBehaviour
{
    public GameObject AttackBox;
    private void OnShoot()
    {
        AttackBox.GetComponent<Player_melee>().Scratch = true;
    }
}
