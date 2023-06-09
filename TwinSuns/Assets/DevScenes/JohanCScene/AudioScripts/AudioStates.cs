using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FMOD.Studio;
using FMODUnity;

public class AudioStates : MonoBehaviour
{
    public GameObject playerPlayer;         // Random Audio Players used for various situations.
    public GameObject cactiObject;
    public GameObject skeletonObject;

    public void FootstepAudioPlay()
    {
        RaycastHit hit;
        Physics.Raycast(playerPlayer.transform.position, Vector3.down, out hit, 7f);
        Debug.DrawRay(playerPlayer.transform.position, Vector3.down * 7f, Color.blue, 1f);
        //Debug.Log("We Hit: " + hit.collider.tag);
        audioManTwin.playerAudio.PlayerFootstepAudio(playerPlayer, hit.collider.tag);
    }

    public void LandingAudioPlay()
    {
        RaycastHit hit;
        Physics.Raycast(playerPlayer.transform.position, Vector3.down, out hit, 7f);
        Debug.DrawRay(playerPlayer.transform.position, Vector3.down * 7f, Color.blue, 1f);
        //Debug.Log("We Hit: " + hit.collider.tag);
        audioManTwin.playerAudio.PlayerLandingAudio(playerPlayer, hit.collider.tag);
    }

    public void JumpAudioPlay()
    {
        audioManTwin.playerAudio.PlayerJumpAudio(playerPlayer);
    }

    public void PlayerMeleePlay()
    {
        audioManTwin.playerAudio.PlayerMeleeAudio(playerPlayer);
    }

    public void PlayerDamagePlay()
    {
        audioManTwin.playerAudio.PlayerDamageAudio(playerPlayer);
    }

    public void PlayerClimbPlay()
    {
        audioManTwin.playerAudio.PlayerLadderClimbAudio(playerPlayer);
    }

    public void PlayerRollPlay()
    {
        audioManTwin.playerAudio.PlayerRollAudio(playerPlayer);
    }
    public void CactiAlertPlay()
    {
        audioManTwin.enemyCactiAudio.CactiAlertAudio(cactiObject);
    }

    public void CactiDeathPlay()
    {
        audioManTwin.enemyCactiAudio.CactiDeathAudio(cactiObject);
    }

    public void CactiDamagePlay()
    {
        audioManTwin.enemyCactiAudio.CactiDamageAudio(cactiObject);
    }

    public void CactiJumpPlay()
    {
        audioManTwin.enemyCactiAudio.CactiJumpAudio(cactiObject);
    }

    public void CactiLandPlay()
    {
        audioManTwin.enemyCactiAudio.CactiLandAudio(cactiObject);
    }
    public void PlankHitFire()
    {
     audioManTwin.interactablesAudio.BoardFireAudio(cactiObject);
    }
    public void PlankHit()
    {
       audioManTwin.interactablesAudio.BoardDodgeAudio(playerPlayer);
    }

    public void LargeMetallWall()
    {
        audioManTwin.interactablesAudio.MetallWallLargeAudio(this.gameObject);
    }

    public void SmallMetallWall()
    {
        audioManTwin.interactablesAudio.MetallWallSmallAudio(this.gameObject);
    }
    public void PlankBreak()
    {
        audioManTwin.interactablesAudio.BoardBreakAudio(playerPlayer);
    }

    public void PistonIn()
    {
        audioManTwin.interactablesAudio.PistonForwardAudio(this.gameObject);
    }

    public void PistonOut()
    {
        audioManTwin.interactablesAudio.PistonBackwardsAudio(this.gameObject);
    }

    public void SkeletonMelee()
    {
        audioManTwin.enemySkeletonAudio.SkeletonMeleeAudio(this.gameObject);
    }

    public void SkeletonFlying()
    {
        audioManTwin.enemySkeletonAudio.SkeletonFlyingAudio(this.gameObject);
    }

    public void PickUpItem()
    {
        audioManTwin.interactablesAudio.PickUpItemAudio(this.gameObject);
    }

    public void ButtonPress()
    {
        audioManTwin.interactablesAudio.ButtonPressAudio(this.gameObject);
    }

    public void PlayerCrawl()
    {
        audioManTwin.playerAudio.PlayerCrawlAudio(this.gameObject);
    }

    public void PlayerRollWalk()
    {
        audioManTwin.playerAudio.PlayerRollWalkAudio(this.gameObject);
    }

    public void PlayerDeath()
    {
        audioManTwin.playerAudio.PlayerDeathAudio(this.gameObject);
    }

    public void PlayerEquip()
    {
        audioManTwin.playerAudio.PlayerEquipAudio(this.gameObject);
    }

    public void PlayerDeequip()
    {
        audioManTwin.playerAudio.PlayerDeequipAudio(this.gameObject);
    }

    public void PlayerEnchant()
    {
        audioManTwin.interactablesAudio.SwordFiredAudio(this.gameObject);
    }

    public void PlayerSwordFireCelebrate()
    {
        audioManTwin.interactablesAudio.SwordFiredAudio(this.gameObject);
    }

    public void PlayerCrawl2()
    {
        audioManTwin.playerAudio.PlayerCrawl2Audio(this.gameObject);
    }








    public void CactiFootstepPlay()
    {
        RaycastHit hit;
        Physics.Raycast(cactiObject.transform.position, Vector3.down, out hit, 5f);
        Debug.DrawRay(cactiObject.transform.position, Vector3.down * 5f, Color.blue, 1f);
        audioManTwin.enemyCactiAudio.CactiFootstepAudio(cactiObject, hit.collider.tag);
    }

    public void SkeletonFootstepPlay()
    {
        RaycastHit hit;
        Physics.Raycast(skeletonObject.transform.position, Vector3.down, out hit, 5f);
        Debug.DrawRay(skeletonObject.transform.position, Vector3.down * 5f, Color.blue, 1f);
        audioManTwin.enemySkeletonAudio.SkeletonFootstepAudio(skeletonObject, hit.collider.tag);
    }


    // Start is called before the first frame update
    private void Awake()
    {
        audioManTwin = GameObject.Find("AudioManTwin").GetComponent<AudioManTwin>();
    }
    void Start()
    {
        audioManTwin = GameObject.Find("AudioManTwin").GetComponent<AudioManTwin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private AudioManTwin audioManTwin;
}
