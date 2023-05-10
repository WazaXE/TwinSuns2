using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialSlapper : MonoBehaviour, IDamageable
{

    [SerializeField] private Renderer renderer;
    [SerializeField] private float fadeTime = 1.0f;
    [SerializeField] private Transform cube;

    private Material material;
    private Coroutine fadeCoroutine;
    private bool goingUp;
    private float b = 1f;
    private Vector3 closedScale;
    private Vector3 openScale;
    private float startingEmissionIntensity = 0.0f;
    private float targetEmissionIntensity = 1.0f;

    [SerializeField] private ParticleSystem particle;






    private void Start()
    {
        // Get the material of the renderer attached to this GameObject
        material = renderer.material;

        // Set the starting emission intensity of the material
        material.SetColor("_EmissionColor", Color.white * startingEmissionIntensity);

        closedScale = cube.transform.localScale;
        openScale = new Vector3(closedScale.x, closedScale.y, 1.3f);
    }

    public void TakeDamage(int damage, DamageType dType = DamageType.Normal) //I detta fall ska den g� s�nder direkt �nd�
    {
        if (dType == DamageType.Fire)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }

            goingUp = true;

            // Set the emission intensity to the target value
            material.SetColor("_EmissionColor", Color.red * targetEmissionIntensity);

            particle.Play();

            // Start the coroutine to fade the emission intensity back to the starting value over time
            fadeCoroutine = StartCoroutine(FadeEmissionIntensity());
        }
    }

    private IEnumerator FadeEmissionIntensity()
    {
        // Calculate the rate at which to change the emission intensity per frame


        float fadeRate = (targetEmissionIntensity - startingEmissionIntensity) / fadeTime;


        // Gradually decrease the emission intensity of the material over time
        while (material.GetColor("_EmissionColor").r > startingEmissionIntensity)
        {
            if (b > 0f && goingUp == true)
            {
                //This code runs while it's lighting up
                b -= 0.1f;
                cube.transform.localScale = Vector3.Lerp(openScale, cube.transform.localScale, b);
                Debug.Log(cube.transform.localScale);
                Debug.Log(openScale);
            }
            else
            {
                //This code runs while it's fading



                goingUp = false;
                float newEmissionIntensity = material.GetColor("_EmissionColor").r - (fadeRate * Time.deltaTime);
                material.SetColor("_EmissionColor", Color.red * newEmissionIntensity);

                // Interpolate the scale of the cube between the up and down scales based on the emission intensity
                float t = (newEmissionIntensity - startingEmissionIntensity) / (targetEmissionIntensity - startingEmissionIntensity);
                cube.transform.localScale = Vector3.Lerp(closedScale, openScale, t);
                b = 1f;

            }
            yield return null;

        }
        particle.Stop();
        material.SetColor("_EmissionColor", Color.red * startingEmissionIntensity);
    }
}