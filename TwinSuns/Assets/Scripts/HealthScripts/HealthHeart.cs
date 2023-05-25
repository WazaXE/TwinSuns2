using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{

    public Sprite fullHeart, emptyHeart;

    Image heartImage;

    private Animator anim;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
        anim = gameObject.GetComponent<Animator>();
    }


    public void SetHeartImage(HeartStatus status)
    {
        //Switch for different heartstatus, can add halfheart if needed
        switch(status)
        {
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                anim.SetBool("isHit", false);
                break;
        }
    }

}

//Enum for differnt status of heart, possible to expand to halfheart
public enum HeartStatus
{
    Empty = 0,
    Full = 1
}