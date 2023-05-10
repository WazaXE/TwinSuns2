using System.Collections;
using UnityEngine;

public class Debris : MonoBehaviour
{

    public void StartShrink(float delay, float fragScaleFactor)
    {
        StartCoroutine(Shrink(delay,fragScaleFactor));
    }

    IEnumerator Shrink(float delay, float fragScaleFactor)
    {
        yield return new WaitForSeconds(delay);

        Vector3 newScale = transform.localScale;

        while (newScale.x > 0)
        {
            newScale -= new Vector3(fragScaleFactor, fragScaleFactor, fragScaleFactor);

            transform.localScale = newScale;
            yield return new WaitForSeconds (0.05f);
        }
        Destroy(transform.parent.gameObject); //Förstör parent, så borde alla försvinna
    }
   
}
