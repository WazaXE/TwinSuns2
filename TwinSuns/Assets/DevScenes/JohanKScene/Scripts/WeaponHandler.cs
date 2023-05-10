using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    GameObject weaponHolder;
    [SerializeField]
    GameObject weaponPrefab;

    GameObject currentWeaponInHand;
    MeleeWeapon currentW;

    public bool canUseFire = true,canUseWater = false,canUseWind = false,canUseEarth = false;

    private void Start()
    {
        //currentWeaponInHand = Instantiate(weapon)

    }

    public void DrawWeapon()
    {
        if (currentWeaponInHand != null) return;
        currentWeaponInHand = Instantiate(weaponPrefab, weaponHolder.transform);
        currentW = currentWeaponInHand.GetComponent<MeleeWeapon>();
    }
    public void SheathWeapon()
    {
        Destroy(currentWeaponInHand);
    }

    public void StartWeaponAttack() //kallas från animatorn
    {
        //currentWeaponInHand.GetComponent<MeleeWeapon>().StartDealDamage();
        currentW.StartDealDamage();
    }

    public void StopWeaponAttack() //kallas från animatorn
    {
        //currentWeaponInHand.GetComponent<MeleeWeapon>().StopDealDamage();
        currentW.StopDealDamage();
    }

    public void EnchantWeapon(float duration, DamageType enchantType = DamageType.Fire)
    {
        switch (enchantType) //Kolla för att se om typen som försöker enchantas faktiskt kan, ananrs return(händer ingenting)
        {
            case DamageType.Fire:
                if (!canUseFire) return; 
                break;
            case DamageType.Water:
                if (!canUseWater) return;
                break;
            case DamageType.Earth:
                if (!canUseEarth) return;
                break;
            case DamageType.Wind:
                if (!canUseWind) return;
                break;
            default:
                break;
        }

        currentW.EnchantWeapon(duration, enchantType);

    }

}
