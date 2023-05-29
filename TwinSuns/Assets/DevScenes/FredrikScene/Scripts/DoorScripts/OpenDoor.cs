using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public bool buttonOnePressed;
    public bool buttonTwoPressed;

    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (buttonOnePressed && buttonTwoPressed)
        {
            anim.SetBool("isOpen", true);
        }
    }

}
