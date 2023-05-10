using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public GameObject fireballPrefab;

    public BossSwitches switch1;
    public BossSwitches switch2;
    public BossSwitches switch3;

    private bool hit = false;

    public GameObject breakableGround1;
    public GameObject breakableGround2;


    public float fireballLifetime = 3f;

    public float fireballSpeed = 15f;
    private float timeSinceLastFireball;



    public Transform launchPoint; // the set point to launch the player towards
    public float launchSpeed; // the force at which to launch the player

    public CharacterController characterController;



    private Vector3 lastPlayerPosition;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      timeSinceLastFireball += Time.deltaTime;

    if (timeSinceLastFireball >= 2f)
    {
        ShootFireball(lastPlayerPosition);
        lastPlayerPosition = player.transform.position;
        timeSinceLastFireball = 0f;
      }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        Vector3 launchDirection = (launchPoint.position - transform.position).normalized;
        characterController.Move(launchDirection * launchSpeed * Time.deltaTime);
        switch1.TorchHit();
        switch2.TorchHit();
        switch3.TorchHit();
        if (hit == false)
        {
        breakableGround1.SetActive(false);
        hit = true;
      } else if (hit == true){
          breakableGround2.SetActive(false);
        }

        }
    }


    public void ShootFireball(Vector3 targetPosition)
{
    GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
    fireball.transform.LookAt(targetPosition);
    Rigidbody rb = fireball.GetComponent<Rigidbody>();
    rb.velocity = fireball.transform.forward * fireballSpeed;

    // Destroy the fireball after the specified lifetime
    Destroy(fireball, fireballLifetime);
}
}
