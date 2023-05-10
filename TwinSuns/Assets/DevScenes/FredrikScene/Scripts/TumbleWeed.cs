using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]


public class TumbleWeed : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private ParticleSystem particle;

    //Choose random direction
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = 0;
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Start first coroutine
        StartCoroutine(ChooseDirection());
    }


    IEnumerator ChooseDirection()
    {
        //Set float value to how long between the tumbleweed switches direction
        yield return new WaitForSeconds(5f);

        rb.velocity = RandomVector(-10f, 10f);

        particle.Play();

        //Repeat forever
        StartCoroutine(ChooseDirection());
    }

}
