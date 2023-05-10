using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour //Vill kanske i framtiden ha en basklass f�r vapen, med generella funktioner som StartDealDamage osv
{
    [SerializeField]
    private int damage = 1;

    bool canDealDamage;

    List<GameObject> hasDealtDamage  = new List<GameObject>();

    [SerializeField]
    [Tooltip("Skall vara triggers")]
    List<Collider> weaponColliders = new List<Collider>();

    private DamageType damageType = DamageType.Normal;

    [SerializeField] ParticleSystem slashpSystem; //ser ltie wack ut, testar att aktivera/deaktivera gameobject ist�llet
    //[SerializeField] GameObject slashTrailObject;
    [SerializeField] GameObject fireEffect;


    private void Start()
    {
        canDealDamage = false;

        fireEffect.SetActive(false);
        //slashTrailObject.SetActive(false);
        slashpSystem.Stop();
    }

    public void StartDealDamage() //Skall kallas av weaponHandler, som i sin tur kallas fr�n animatorn
    {
        canDealDamage = true;
        hasDealtDamage.Clear();

        foreach (Collider coll in weaponColliders)
        {
            coll.enabled = true;
        }

        //slashTrailObject.SetActive(true);
        slashpSystem.Play();

    }
    public void StopDealDamage() //Skall kallas av weaponHandler, som i sin tur kallas fr�n animatorn
    {
        canDealDamage = false;

        foreach (Collider coll in weaponColliders)
        {
            coll.enabled = false;
        }
        //slashTrailObject.SetActive(false);
        slashpSystem.Stop();
    }


    public void EnchantWeapon(float duration, DamageType enchantType = DamageType.Fire)
    {
        damageType = enchantType;

        fireEffect.SetActive(true);

        StartCoroutine(DisenchantAfterSeconds(duration));

    }

    private IEnumerator DisenchantAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        damageType = DamageType.Normal;

        fireEffect.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) //Min egentliga damageFunktion
    {
        if (!canDealDamage) return;

        if (!hasDealtDamage.Contains(other.gameObject)) //Kolla ifall objektet �r i listan
        {
            hasDealtDamage.Add(other.gameObject); //L�gg till i listan s� den inte kan skadas igen

            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {

                damageable.TakeDamage(damage, damageType); 
            }
        }

        

    }
}
