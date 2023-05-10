using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGround : MonoBehaviour
{
    [SerializeField]
    private GameObject destroyedGroundPrefab;
    [SerializeField]
    private float shrinkDelay = 2f;
    [SerializeField]
    private float fragScaleFactor = 1f;

    public Quaternion spawnRotation;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BreakGround();
        }
    }

    private void BreakGround()
    {
        if (destroyedGroundPrefab == null) return;

        GameObject fractObj = Instantiate(destroyedGroundPrefab, transform.position, spawnRotation);

        FracturedObject fo = fractObj.GetComponent<FracturedObject>();
        fo.Break(shrinkDelay, fragScaleFactor);

        //foreach (Transform t in fractObj.transform)
        //{
        //    //StartCoroutine(t.GetComponent<Debris>().Shrink(shrinkDelay,fragScaleFactor)); //G�r att starta h�rifr�n, men n�r man tar bort detta objekt s� slutar coroutinen k�ra
        //    t.GetComponent<Debris>().StartShrink(shrinkDelay,fragScaleFactor);
        //}


        Destroy(this.gameObject);
    }
}
