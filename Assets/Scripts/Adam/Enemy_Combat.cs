using UnityEngine;
using UnityEngine.AI;
using System.Collections;

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
    public float GunDistance;
    private RaycastHit Hit;
    public LayerMask PlayerLayer;
    public LayerMask EnemyLayer;
    public LayerMask GunLayerDetection;
    public int Health;
    public GameObject Player;
    public Vector3 EyeLevel;
    public Vector3 PlayerEyeLevel;
    public bool IsAttacking;
    public NavMeshAgent Agent;
    public float CoverWaitTime;
    private bool PeakFunctionRunning = false;
    public GameObject Bullet;
    public GameObject BulletSpawnPoint;
    private float ShootDelay;
    public float AttackDistance;
    public GameObject NPCTextBox;
    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        ShootDelay = 1f;
    }
    void Update()
    {
        if (!IsAttacking)
        {
            if (Physics.Raycast(EyeLevel + transform.position, (Player.transform.position + PlayerEyeLevel) - (EyeLevel + transform.position), out Hit) && Hit.transform.gameObject.layer == LayerMask.NameToLayer("Cover") || Physics.Raycast(EyeLevel + transform.position, (Player.transform.position + PlayerEyeLevel) - (EyeLevel + transform.position), out Hit) && Hit.transform.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                CanSeePlayer = false;
            }

            else if (Physics.BoxCast(transform.position, BoxSize * 0.5f, transform.forward, out Hit, transform.rotation, Distance, PlayerLayer) && !NPCTextBox.activeSelf)
            {
                CanSeePlayer = true;
            }

            else if (Physics.BoxCast(LineOfSightPosition.transform.position, BoxSize * 0.5f, LineOfSightPosition.transform.forward, out Hit, LineOfSightPosition.transform.rotation, Distance, PlayerLayer) && !NPCTextBox.activeSelf)
            {
                CanSeePlayer = true;
            }

            else if (Physics.BoxCast(LineOfSightPosition2.transform.position, BoxSize * 0.5f, LineOfSightPosition2.transform.forward, out Hit, LineOfSightPosition2.transform.rotation, Distance, PlayerLayer) && !NPCTextBox.activeSelf)
            {
                CanSeePlayer = true;
            }

            else if (Physics.BoxCast(LineOfSightPosition3.transform.position, BoxSize * 0.5f, LineOfSightPosition3.transform.forward, out Hit, LineOfSightPosition3.transform.rotation, Distance, PlayerLayer) && !NPCTextBox.activeSelf)
            {
                CanSeePlayer = true;
            }

            else if (Physics.BoxCast(LineOfSightPosition4.transform.position, BoxSize * 0.5f, LineOfSightPosition4.transform.forward, out Hit, LineOfSightPosition4.transform.rotation, Distance, PlayerLayer) && !NPCTextBox.activeSelf)
            {
                CanSeePlayer = true;
            }

            else
            {
                CanSeePlayer = false;
            }
        }
        
        else
        {
            if (Physics.Raycast(EyeLevel + transform.position, (Player.transform.position + PlayerEyeLevel) - (EyeLevel + transform.position), out Hit) && Hit.transform.gameObject.layer == LayerMask.NameToLayer("Cover") || Physics.Raycast(EyeLevel + transform.position, (Player.transform.position + PlayerEyeLevel) - (EyeLevel + transform.position), out Hit) && Hit.transform.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                CanSeePlayer = false;
                GetComponent<Cover_Selector>().FindCover = true;
            }

            else if (Physics.Raycast(EyeLevel + transform.position, (Player.transform.position + PlayerEyeLevel) - (EyeLevel + transform.position)))
            {
                CanSeePlayer = true;
            }
        }

        if (CanSeePlayer && !NPCTextBox.activeSelf)
        {
            IsAttacking = true;
        }

        if (NPCTextBox.activeSelf)
        {
            IsAttacking = false;
        }

        if (GetComponent<Cover_Selector>().InCover && !PeakFunctionRunning)
        {
            StartCoroutine(Peak());
        }

        if (IsAttacking)
        {
            foreach (Collider Enemy in Player.GetComponent<Enemy_Detection>().AllEnemies)
            {
                if (Enemy != null && Vector3.Distance(Enemy.transform.position, Player.transform.position) < AttackDistance)
                {
                    Enemy.gameObject.GetComponent<EnemyCombat>().IsAttacking = true;
                }

                else
                {
                    if (Enemy != null)
                    {
                        Enemy.gameObject.GetComponent<EnemyCombat>().IsAttacking = false;
                        Enemy.gameObject.GetComponent<Cover_Selector>().InCover = false;
                        Enemy.gameObject.GetComponent<Cover_Selector>().FindCover = false;
                    }
                }
                
            }
            Shoot();
        }

        if (CanSeePlayer && IsAttacking)
        {
            transform.LookAt(Player.transform.position);
        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition.transform.position, LineOfSightPosition.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition2.transform.position, LineOfSightPosition2.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition3.transform.position, LineOfSightPosition3.transform.forward * Distance);
        Debug.DrawRay(LineOfSightPosition4.transform.position, LineOfSightPosition4.transform.forward * Distance);
    }

    private IEnumerator Peak()
    {
        PeakFunctionRunning = true;

        yield return new WaitForSeconds(CoverWaitTime);

        if (GetComponent<Cover_Selector>().InCover && Player.GetComponent<Enemy_Detection>().EnemiesInCover.Capacity > 0 && !Physics.SphereCast(transform.position, 2, Vector3.forward, out RaycastHit hit, 2, EnemyLayer))
        {
            if (GetComponent<Cover_Selector>().TargetCover.name == "Point1" || GetComponent<Cover_Selector>().TargetCover.name == "Point2")
            {
                Agent.destination = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(CoverWaitTime);
                Agent.destination = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            }

            else if (GetComponent<Cover_Selector>().TargetCover.name == "Point3" || GetComponent<Cover_Selector>().TargetCover.name == "Point4")
            {
                Agent.destination = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(CoverWaitTime);
                Agent.destination = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            }

            else if (GetComponent<Cover_Selector>().TargetCover.name == "Point5" || GetComponent<Cover_Selector>().TargetCover.name == "Point6")
            {
                Agent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
                yield return new WaitForSeconds(CoverWaitTime);
                Agent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
            }

            else if (GetComponent<Cover_Selector>().TargetCover.name == "Point7" || GetComponent<Cover_Selector>().TargetCover.name == "Point8")
            {
                Agent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
                yield return new WaitForSeconds(CoverWaitTime);
                Agent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
            }
        }
        PeakFunctionRunning = false;
    }

    private void Shoot()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 10f && CanSeePlayer)
        {
            GetComponent<Cover_Selector>().FindCover = false;
            Agent.ResetPath();

            if (GetComponent<Cover_Selector>().InCover)
            {
                GetComponent<Cover_Selector>().TargetCover.GetComponent<Occupied_Detection>().IsOccupied = false;
                GetComponent<Cover_Selector>().TargetCover = null;
            }
            
            GetComponent<Cover_Selector>().InCover = false;
        }

        if (CanSeePlayer && !GetComponent<Cover_Selector>().IsFunctionRunning)
        {
            if (ShootDelay <= 0f)
            {
                GameObject Instance = Instantiate(Bullet, BulletSpawnPoint.transform.position, transform.rotation);
                Instance.GetComponent<Enemy_Bullet>().DeathTimer = 5f;
                Instance.GetComponent<Enemy_Bullet>().Move = true;
                ShootDelay = 1f;
            }

            else
            {
                ShootDelay -= Time.deltaTime;
            }
        }

        if (!GetComponent<Cover_Selector>().FindCover && Vector3.Distance(transform.position, Player.transform.position) >= 10f)
        {
            Agent.destination = Player.transform.position;
        }
    }
}
