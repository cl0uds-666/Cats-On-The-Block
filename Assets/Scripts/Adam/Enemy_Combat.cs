using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
public class EnemyCombat : MonoBehaviour
{
    public bool Attack;
    public bool CanSeePlayer;
    public Vector3 BoxSize;
    public Transform LineOfSightPosition;
    public Transform LineOfSightPosition2;
    public Transform LineOfSightPosition3;
    public Transform LineOfSightPosition4;
    public float Distance;
    private RaycastHit Hit;
    public LayerMask PlayerLayer;
    public int Health;
    public GameObject Player;
    public Vector3 EyeLevel;
    public Vector3 PlayerEyeLevel;
    void Update()
    {
        if (Physics.Raycast(EyeLevel + transform.position, (Player.transform.position + PlayerEyeLevel) - (EyeLevel + transform.position), out RaycastHit hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Cover"))
        {
            CanSeePlayer = false;
        }

        else if (Physics.BoxCast(transform.position, BoxSize * 0.5f, transform.forward, out Hit, transform.rotation, Distance, PlayerLayer))
        {
            print("see player");
            CanSeePlayer = true;
        }

        else if (Physics.BoxCast(LineOfSightPosition.transform.position, BoxSize * 0.5f, LineOfSightPosition.transform.forward, out Hit, LineOfSightPosition.transform.rotation, Distance, PlayerLayer))
        {
            print("see player");
            CanSeePlayer = true;
        }

        else if (Physics.BoxCast(LineOfSightPosition2.transform.position, BoxSize * 0.5f, LineOfSightPosition2.transform.forward, out Hit, LineOfSightPosition2.transform.rotation, Distance, PlayerLayer))
        {
            print("see player");
            CanSeePlayer = true;
        }

        else if (Physics.BoxCast(LineOfSightPosition3.transform.position, BoxSize * 0.5f, LineOfSightPosition3.transform.forward, out Hit, LineOfSightPosition3.transform.rotation, Distance, PlayerLayer))
        {
            print("see player");
            CanSeePlayer = true;
        }

        else if (Physics.BoxCast(LineOfSightPosition4.transform.position, BoxSize * 0.5f, LineOfSightPosition4.transform.forward, out Hit, LineOfSightPosition4.transform.rotation, Distance, PlayerLayer))
        {
            print("see player");
            CanSeePlayer = true;
        }

        else
        {
            print("no see");
            CanSeePlayer = false;
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition.transform.position, LineOfSightPosition.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition2.transform.position, LineOfSightPosition2.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition3.transform.position, LineOfSightPosition3.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition4.transform.position, LineOfSightPosition4.transform.forward * Distance);

        if (CanSeePlayer)
        {
            Debug.DrawRay(EyeLevel + transform.position, (Player.transform.position + PlayerEyeLevel) - (EyeLevel + transform.position));
        }
    }
}
