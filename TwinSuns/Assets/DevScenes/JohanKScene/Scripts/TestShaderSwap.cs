using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShaderSwap : MonoBehaviour
{
    [SerializeField]
    private Material nMaterial;
    [SerializeField]
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Material originalMaterial;

    void Start()
    {
        //rend = GetComponent<Renderer>();
        originalMaterial = skinnedMeshRenderer.material;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ChangeToNewMaterial(nMaterial);
        }
    }

    void ChangeToNewMaterial(Material newMaterial)
    {
        skinnedMeshRenderer.material = newMaterial;
        Invoke("ChangeToOriginalMaterial", 1f);
    }

    void ChangeToOriginalMaterial()
    {
        skinnedMeshRenderer.material = originalMaterial;
    }
}
