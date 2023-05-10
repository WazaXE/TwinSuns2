using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAttackRange))]
public class CactiAttack : MonoBehaviour
{
    private Animator cactiAnimator;

    private NavMeshAgent agent;
    private EnemyAttackRange enemyAttackRange;

    public GameObject cactiGameObj;
    private Rigidbody rb;

    public GameObject player;

    public float chargeTime = 1f;
    public float landTime = 1f;
    public float jumpForce = 2f;
    [Tooltip("while charging a jump against player")] public float turnSpeed = 0.01f;
    private float timeCount;
    
    [Range (0, 90)] public int jumpAngle = 45;
    [SerializeField] private bool isGrounded = true;
    private bool isJumping;
    private bool isAttacking = false;
    private bool isTurning;
    void Start()
    {
        cactiAnimator = GetComponent<Animator>();
        enemyAttackRange = GetComponent<EnemyAttackRange>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        cactiAnimator.SetFloat("Vertical", rb.velocity.y);
        timeCount += Time.deltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        if (enemyAttackRange.isInRange && !isAttacking)
        {
            StartCoroutine(ChargeRoutine());
        }
        if (isTurning)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, timeCount * turnSpeed);
        }
    }

    private IEnumerator ChargeRoutine()
    {
        Time.timeScale = 0.1f;
        isAttacking = true;
        isTurning = true;

        cactiAnimator.SetTrigger("Attack");

        yield return new WaitForSeconds(chargeTime);
        Jump();
        isTurning = false;
    }

    private IEnumerator LandingRoutine()
    {
        yield return new WaitForSeconds(landTime);
        if (isGrounded)
        {
            if (agent.enabled)
            {
                agent.Warp(transform.position);
                agent.updatePosition = true;
                agent.updateRotation = true;
                agent.isStopped = false;
            }
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        isJumping = false;
        isAttacking = false;
        Time.timeScale = 1f;
    }

    void Jump()
    {
        if (!isGrounded || isJumping)
        {
            return;
        }

        float radian = Mathf.Deg2Rad * jumpAngle;
        Vector3 jumpAngleVector = new Vector3(0, Mathf.Sin(radian), Mathf.Cos(radian));

        isGrounded = false;
        cactiAnimator.SetBool("Grounded", false);
        if (agent.enabled)
        {
            agent.updatePosition = false;
            agent.updateRotation = false;
            agent.isStopped = true;
        }

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddRelativeForce(jumpAngleVector * jumpForce, ForceMode.Impulse);
        

        isJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" && isJumping)
        {
            isGrounded = true;
            cactiAnimator.SetBool("Grounded", true);
            StartCoroutine(LandingRoutine());
        }
    }
}
