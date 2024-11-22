using System;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scratch : MonoBehaviour
{
    public GameObject AttackBox;
    public bool CanScratch = true;
    public float MaxMeleeTimer;
    private float CurrentMeleeTimer;

    private void Start()
    {
        CurrentMeleeTimer = 0f;
    }

    private void Update()
    {
        if (Input.GetAxis("Xbox_RT") > 0 && CanScratch)
        {
            if (GetComponent<WeaponSwitching>().currentWeaponIndex == 0 && CurrentMeleeTimer <= 0f)
            {
                AttackBox.GetComponent<Player_melee>().Scratch = true;
                CurrentMeleeTimer = MaxMeleeTimer;
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
