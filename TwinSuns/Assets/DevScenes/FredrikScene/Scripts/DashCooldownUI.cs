using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DashCooldownUI : MonoBehaviour
{
    private Image cooldownImage;
    private Color originalColor;

    private Coroutine lerpCoroutine;

    private void Awake()
    {
        cooldownImage = GetComponent<Image>();
        originalColor = cooldownImage.color;
    }

    public void StartLerpAlpha(float dashCooldown)
    {
        if (lerpCoroutine != null)
            StopCoroutine(lerpCoroutine);

        lerpCoroutine = StartCoroutine(LerpAlpha(dashCooldown));
    }

    private IEnumerator LerpAlpha(float dashCooldown)
    {
        float timer = 0f;
        Color targetColor = originalColor;
        targetColor.a = 0.2f;

        while (timer < dashCooldown)
        {
            float alpha = Mathf.Lerp(0.2f, 1f, timer / dashCooldown);

            Color currentColor = originalColor;
            currentColor.a = alpha;
            cooldownImage.color = currentColor;

            timer += Time.deltaTime;
            yield return null;
        }

        cooldownImage.color = originalColor;
    }
}