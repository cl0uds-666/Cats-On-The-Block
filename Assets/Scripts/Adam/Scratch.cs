using UnityEngine;
public class Scratch : MonoBehaviour
{
    public GameObject AttackBox;
    public bool CanScratch = true;
    public float MaxMeleeTimer;
    public float CurrentMeleeTimer;

    private void Start()
    {
        CurrentMeleeTimer = 0f;
    }

    private void Update()
    {
        if (Input.GetAxis("Xbox_RT") > 0 && CanScratch || Input.GetKeyDown(KeyCode.Mouse0) && CanScratch)
        {
            if (GetComponent<WeaponSwitching>().currentWeaponIndex == 0 && CurrentMeleeTimer <= 0f)
            {
                AttackBox.GetComponent<Player_melee>().Scratch = true;
                CurrentMeleeTimer = MaxMeleeTimer;
                if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
                {
                    GetComponent<Animator>().SetInteger("MainState", 2);
                }
            }
        }

        else if (Input.GetAxis("Xbox_RT") <= 0)
        {
            CanScratch = true;
        }

        if (CurrentMeleeTimer > 0f)
        {
            CurrentMeleeTimer -= Time.deltaTime;
        }
    }
}
