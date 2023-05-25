using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{

    public GameObject heartPrefab;

    public PlayerHealthManager playerHealth;

    List<HealthHeart> hearts = new List<HealthHeart>();

    private Animator anim;

    private void OnEnable()
    {
        //subscribe to event
        PlayerHealthManager.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        //Unsubscribe to event
        PlayerHealthManager.OnPlayerDamaged -= DrawHearts;
    }

    public void DrawHearts()
    {
        //Clear existing hearts
        ClearHearts();

        //Create empty hearts depending on max health
        for(int i = 0; i < playerHealth.maxHealth; i++)
        {
            CreateEmptyHeart();
        }

        //Update hearts to be full depending on current player health
        for(int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - i, 0, 1);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);

            if (i == playerHealth.health && i < playerHealth.maxHealth)
            {
                anim = hearts[i].GetComponent<Animator>();
                anim.SetBool("isHit", true);
            }

        }

    }

    private void ClearHearts()
    {
        //Clear all existing hearts and create a new list
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }



    private void CreateEmptyHeart()
    {
        //Create new empty heart
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        newHeart.transform.localScale = Vector3.one;

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();

        heartComponent.SetHeartImage(HeartStatus.Empty);

        //Add to list
        hearts.Add(heartComponent);
    }
}
