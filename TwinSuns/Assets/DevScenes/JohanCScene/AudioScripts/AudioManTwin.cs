using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FMOD.Studio;
using FMODUnity;

public class AudioManTwin : MonoBehaviour
{
    [Serializable]
    public class PlayerAudio
    {
        public EventReference playerFootstepEvent;
        private EventInstance playerFootstepInstance;

        public EventReference playerDamageEvent;
        private EventInstance playerDamageInstance;

        public EventReference playerMeleeEvent;
        private EventInstance playerMeleeInstance;

        public EventReference playerDeathEvent;
        private EventInstance playerDeathInstance;


        public EventReference playerJumpEvent;
        private EventInstance playerJumpInstance;

        public EventReference playerLandingEvent;
        private EventInstance playerLandingInstance;

        public EventReference playerRollEvent;
        private EventInstance playerRollInstance;

        public EventReference playerMeleeFireEvent;
        private EventInstance playerMeleeFireInstance;

        public EventReference playerFireballEvent;
        private EventInstance playerFireballInstance;

        public EventReference playerLadderClimbEvent;
        private EventInstance playerLadderClimbInstance;

        public void PlayerFootstepAudio(GameObject playerPlayer, string surface)
        {
            playerFootstepInstance = RuntimeManager.CreateInstance(playerFootstepEvent);

            RuntimeManager.AttachInstanceToGameObject(playerFootstepInstance, playerPlayer.transform,playerPlayer.GetComponent<Rigidbody>());
             switch (surface)
             {
                 case "Sand":
                     playerFootstepInstance.setParameterByName("Surface", 0f);
                     break;
                 case "Stone":
                     playerFootstepInstance.setParameterByName("Surface", 1f);
                     break;
                 case "Wood":
                     playerFootstepInstance.setParameterByName("Surface", 2f);
                     break;
                 case "Gravel":
                     playerFootstepInstance.setParameterByName("Surface", 3f);
                     break;
                case "Grass":
                    playerFootstepInstance.setParameterByName("Surface", 4f);
                    break;
                case "Water":
                    playerFootstepInstance.setParameterByName("Surface", 5f);
                    break;
                case "Snow":
                    playerFootstepInstance.setParameterByName("Surface", 6f);
                    break;
                case "Rock & Pebbles":
                    playerFootstepInstance.setParameterByName("Surface", 7f);
                    break;
            }

            playerFootstepInstance.start();

            playerFootstepInstance.release();
            Debug.Log("playerfootstep");


        }

        public void PlayerLandingAudio(GameObject playerPlayer)
        {

                playerLandingInstance = RuntimeManager.CreateInstance(playerLandingEvent);

                RuntimeManager.AttachInstanceToGameObject(playerLandingInstance, playerPlayer.transform,
                    playerPlayer.GetComponent<Rigidbody>());

                playerLandingInstance.start();

                playerLandingInstance.release(); 
        }

        public void PlayerLadderClimbAudio(GameObject playerPlayer)
        {

            playerLadderClimbInstance = RuntimeManager.CreateInstance(playerLadderClimbEvent);

            RuntimeManager.AttachInstanceToGameObject(playerLadderClimbInstance, playerPlayer.transform,
                playerPlayer.GetComponent<Rigidbody>());

            playerLadderClimbInstance.start();

            playerLadderClimbInstance.release();
        }


        public void PlayerFireballAudio(GameObject playerPlayer)
        {

            playerFireballInstance = RuntimeManager.CreateInstance(playerFireballEvent);

            RuntimeManager.AttachInstanceToGameObject(playerFireballInstance, playerPlayer.transform,
                playerPlayer.GetComponent<Rigidbody>());

            playerFireballInstance.start();

            playerFireballInstance.release();
        }

        public void PlayerRollAudio(GameObject playerPlayer)
        {

            playerRollInstance = RuntimeManager.CreateInstance(playerRollEvent);

            RuntimeManager.AttachInstanceToGameObject(playerRollInstance, playerPlayer.transform,
                playerPlayer.GetComponent<Rigidbody>());

            playerRollInstance.start();

            playerRollInstance.release();
        }



        public void PlayerJumpAudio(GameObject playerPlayer)
            {
                playerJumpInstance = RuntimeManager.CreateInstance(playerJumpEvent);

                RuntimeManager.AttachInstanceToGameObject(playerJumpInstance, playerPlayer.transform,
                    playerPlayer.GetComponent<Rigidbody>());

                playerJumpInstance.start();

                playerJumpInstance.release();
            }
       

        public void PlayerDamageAudio(GameObject playerPlayer)
        {
            if (playerDamageEvent.IsNull)
            {
                Debug.Log("FMOD filepath for PlayerDamageEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                playerDamageInstance = RuntimeManager.CreateInstance(playerDamageEvent);
                RuntimeManager.AttachInstanceToGameObject(playerDamageInstance, playerPlayer.transform,
                    playerPlayer.GetComponent<Rigidbody>());

                playerDamageInstance.start();

                playerDamageInstance.release();

                //   Debug.Log("playerdamageaudio");
            }
        }

        public void PlayerMeleeAudio(GameObject playerPlayer)
        {
            if (playerMeleeEvent.IsNull)
            {
                Debug.Log("FMOD filepath for PlayerMeleeEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                playerMeleeInstance = RuntimeManager.CreateInstance(playerMeleeEvent);

                RuntimeManager.AttachInstanceToGameObject(playerMeleeInstance, playerPlayer.transform,
                    playerPlayer.GetComponent<Rigidbody>());

                playerMeleeInstance.start();

                playerMeleeInstance.release();
                //     Debug.Log("playermelee");
            }
        }

        public void PlayerMeleeFireAudio(GameObject playerPlayer)
        {
            if (playerMeleeFireEvent.IsNull)
            {
                Debug.Log("FMOD filepath for PlayerMeleeFireEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                playerMeleeFireInstance = RuntimeManager.CreateInstance(playerMeleeFireEvent);

                RuntimeManager.AttachInstanceToGameObject(playerMeleeFireInstance, playerPlayer.transform,
                    playerPlayer.GetComponent<Rigidbody>());

                playerMeleeFireInstance.start();

                playerMeleeFireInstance.release();
                //     Debug.Log("playermeleefire");
            }
        }
        public void PlayerDeathAudio(GameObject playerPlayer)
        {
            if (playerDeathEvent.IsNull)
            {
                Debug.Log("FMOD filepath for PlayerShootingEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                playerDeathInstance = RuntimeManager.CreateInstance(playerDeathEvent);

                RuntimeManager.AttachInstanceToGameObject(playerDeathInstance, playerPlayer.transform,
                    playerPlayer.GetComponent<Rigidbody>());

                playerDeathInstance.start();

                playerDeathInstance.release();


            }
        }



       

    }
        [Serializable]
        public class InteractablesAudio
    {

        public EventReference pickupItemEvent;
        public EventInstance pickupItemInstance;

        public EventReference CoinEvent;
        public EventInstance CoinInstance;

        public EventReference cactusDestroyedEvent;
        public EventInstance cactusDestroyedInstance;

        public EventReference buildingEvent;
        public EventInstance buildingInstance;

        public EventReference boardBreakEvent;
        public EventInstance boardBreakInstance;

        public EventReference boardDodgeEvent;
        public EventInstance boardDodgeInstance;

        public EventReference boardFireEvent;
        public EventInstance boardFireInstance;

        public EventReference lightTempleEvent;
        public EventInstance lightTempleInstance;

        public EventReference swordFiredEvent;
        public EventInstance swordFiredInstance;

        public EventReference CheckpointEvent;
        public EventInstance CheckpointInstance;

        public EventReference metallWallLargeEvent;
        public EventInstance metallWallLargeInstance;

        public EventReference metallWallSmallEvent;
        public EventInstance metallWallSmallInstance;

        public EventReference wallThrowerEvent;
        public EventInstance wallThrowerInstance;

        public EventReference pistonForwardEvent;
        public EventInstance pistonForwardInstance;

        public EventReference pistonBackwardsEvent;
        public EventInstance pistonBackwardsInstance;

        public EventReference ladderEnableEvent;
        public EventInstance ladderEnableInstance;



        public void BoardBreakAudio(GameObject boardbreakObject)
        {
            if (boardBreakEvent.IsNull)
            {
                Debug.Log("FMOD filepath for boardbreak is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                boardBreakInstance = RuntimeManager.CreateInstance(boardBreakEvent);

                RuntimeManager.AttachInstanceToGameObject(boardBreakInstance, boardbreakObject.transform,
                    boardbreakObject.GetComponent<Rigidbody>());

                boardBreakInstance.start();
                boardBreakInstance.release();
                Debug.Log("boardbreak");
            }
        }

        public void LadderEnableAudio(GameObject ladderEnableObject)
        {
            if (ladderEnableEvent.IsNull)
            {
                Debug.Log("FMOD filepath for ladderEnable is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                ladderEnableInstance = RuntimeManager.CreateInstance(ladderEnableEvent);

                RuntimeManager.AttachInstanceToGameObject(ladderEnableInstance, ladderEnableObject.transform,
                    ladderEnableObject.GetComponent<Rigidbody>());

                ladderEnableInstance.start();
                ladderEnableInstance.release();
                Debug.Log("ladderEnable");
            }
        }

        public void WallThrowerAudio(GameObject wallThrowerObject)
        {
            if (wallThrowerEvent.IsNull)
            {
                Debug.Log("FMOD filepath for wallThrower is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                wallThrowerInstance = RuntimeManager.CreateInstance(wallThrowerEvent);

                RuntimeManager.AttachInstanceToGameObject(wallThrowerInstance, wallThrowerObject.transform,
                    wallThrowerObject.GetComponent<Rigidbody>());

                wallThrowerInstance.start();
                wallThrowerInstance.release();
                Debug.Log("wallThrower");
            }
        }

        public void PistonForwardAudio(GameObject pistonForwardObject)
        {
            if (pistonForwardEvent.IsNull)
            {
                Debug.Log("FMOD filepath for pistonForward is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                pistonForwardInstance = RuntimeManager.CreateInstance(pistonForwardEvent);

                RuntimeManager.AttachInstanceToGameObject(pistonForwardInstance, pistonForwardObject.transform,
                    pistonForwardObject.GetComponent<Rigidbody>());

                pistonForwardInstance.start();
                pistonForwardInstance.release();
                Debug.Log("pistonForward");
            }
        }

        public void PistonBackwardsAudio(GameObject pistonBackwardsObject)
        {
            if (pistonBackwardsEvent.IsNull)
            {
                Debug.Log("FMOD filepath for pistonBackwards is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                pistonBackwardsInstance = RuntimeManager.CreateInstance(pistonBackwardsEvent);

                RuntimeManager.AttachInstanceToGameObject(pistonBackwardsInstance, pistonBackwardsObject.transform,
                    pistonBackwardsObject.GetComponent<Rigidbody>());

                pistonBackwardsInstance.start();
                pistonBackwardsInstance.release();
                Debug.Log("pistonBackwards");
            }
        }

        public void BoardDodgeAudio(GameObject boarddodgeObject)
        {
            if (boardDodgeEvent.IsNull)
            {
                Debug.Log("FMOD filepath for boardDodgeis missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                boardDodgeInstance = RuntimeManager.CreateInstance(boardDodgeEvent);

                RuntimeManager.AttachInstanceToGameObject(boardDodgeInstance, boarddodgeObject.transform,
                    boarddodgeObject.GetComponent<Rigidbody>());

                boardDodgeInstance.start();
                boardDodgeInstance.release();
                Debug.Log("boardDodge");
            }
        }

        public void BoardFireAudio(GameObject boardfireObject)
        {
            if (boardFireEvent.IsNull)
            {
                Debug.Log("FMOD filepath for boardFireis missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                boardFireInstance = RuntimeManager.CreateInstance(boardFireEvent);

                RuntimeManager.AttachInstanceToGameObject(boardFireInstance, boardfireObject.transform,
                    boardfireObject.GetComponent<Rigidbody>());

                boardFireInstance.start();
                boardFireInstance.release();
                Debug.Log("boardFire");
            }
        }

        public void MetallWallLargeAudio(GameObject metallWallLargeObject)
        {
            if (metallWallLargeEvent.IsNull)
            {
                Debug.Log("FMOD filepath formetallWallLarge is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                metallWallLargeInstance = RuntimeManager.CreateInstance(metallWallLargeEvent);

                RuntimeManager.AttachInstanceToGameObject(metallWallLargeInstance, metallWallLargeObject.transform,
                    metallWallLargeObject.GetComponent<Rigidbody>());

                metallWallLargeInstance.start();
                metallWallLargeInstance.release();
                Debug.Log("metallWallLarge");
            }
        }

        public void MetallWallSmallAudio(GameObject metallWallSmallObject)
        {
            if (metallWallSmallEvent.IsNull)
            {
                Debug.Log("FMOD filepath metallWallSmall is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                metallWallSmallInstance = RuntimeManager.CreateInstance(metallWallSmallEvent);

                RuntimeManager.AttachInstanceToGameObject(metallWallSmallInstance, metallWallSmallObject.transform,
                    metallWallSmallObject.GetComponent<Rigidbody>());

                metallWallSmallInstance.start();
                metallWallSmallInstance.release();
                Debug.Log("metallSmallsmall");
            }
        }

        public void SwordFiredAudio(GameObject swordfiredObject)
        {
            if (swordFiredEvent.IsNull)
            {
                Debug.Log("FMOD filepath for swordFired is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                swordFiredInstance = RuntimeManager.CreateInstance(swordFiredEvent);

                RuntimeManager.AttachInstanceToGameObject(swordFiredInstance, swordfiredObject.transform,
                    swordfiredObject.GetComponent<Rigidbody>());

                swordFiredInstance.start();
                swordFiredInstance.release();
                Debug.Log("swordFired");
            }
        }

        public void LightTempleAudio(GameObject lighttempleObject)
        {
            if (lightTempleEvent.IsNull)
            {
                Debug.Log("FMOD filepath for lightTemple is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                lightTempleInstance = RuntimeManager.CreateInstance(lightTempleEvent);

                RuntimeManager.AttachInstanceToGameObject(boardBreakInstance, lighttempleObject.transform,
                    lighttempleObject.GetComponent<Rigidbody>());

                lightTempleInstance.start();
                lightTempleInstance.release();
                Debug.Log("lightTemple");
            }
        }
        public void CactusDestroyedAudio() // Tror inte Gameobject behövs, för vi kan inte AttachInstanceToGameObject ändå      mvh Johan
        {
            if (cactusDestroyedEvent.IsNull)
            {
                Debug.Log("FMOD filepath for cactusDestroyedEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                cactusDestroyedInstance = RuntimeManager.CreateInstance(cactusDestroyedEvent);

                /*
                RuntimeManager.AttachInstanceToGameObject(cactusDestroyedInstance, cactusObject.transform,
                    cactusObject.GetComponent<Rigidbody>());
                */

                cactusDestroyedInstance.start();
                cactusDestroyedInstance.release();
                Debug.Log("cactusDestroyed");
            }
        }
        public void PickUpItemAudio(GameObject pickUpitemObject)
        {
            if (pickupItemEvent.IsNull)
            {
                Debug.Log("FMOD filepath for PickupItem is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                pickupItemInstance = RuntimeManager.CreateInstance(pickupItemEvent);

                RuntimeManager.AttachInstanceToGameObject(pickupItemInstance, pickUpitemObject.transform,
                    pickUpitemObject.GetComponent<Rigidbody>());

                pickupItemInstance.start();
                pickupItemInstance.release();
                Debug.Log("pickupItem");
            }
        }

        public void CoinAudio(GameObject coinObject)
        {
            if (CoinEvent.IsNull)
            {
                Debug.Log("FMOD filepath for coin is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                CoinInstance = RuntimeManager.CreateInstance(CoinEvent);

                RuntimeManager.AttachInstanceToGameObject(CoinInstance, coinObject.transform,
                    coinObject.GetComponent<Rigidbody>());

                CoinInstance.start();
                CoinInstance.release();
                Debug.Log("coin");
            }
        }

        public void CheckpointAudio(GameObject checkpointObject)
        {
            if (CheckpointEvent.IsNull)
            {
                Debug.Log("FMOD filepath for Checkpoint is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                CheckpointInstance = RuntimeManager.CreateInstance(CheckpointEvent);

                RuntimeManager.AttachInstanceToGameObject(CheckpointInstance, checkpointObject.transform,
                    checkpointObject.GetComponent<Rigidbody>());

                CheckpointInstance.start();
                CheckpointInstance.release();
                Debug.Log("Checkpoint");
            }
        }

        public void BuildingAudio(GameObject buldingObject) // Tror inte Gameobject behövs, för vi kan inte AttachInstanceToGameObject ändå      mvh Johan
        {
            if (buildingEvent.IsNull)
            {
                Debug.Log("FMOD filepath for buildingEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                buildingInstance = RuntimeManager.CreateInstance(buildingEvent);


                buildingInstance.start();
                buildingInstance.release();
                Debug.Log("building");
            }
        }
    }
    [Serializable]
    public class MenuAudio
    {
        public EventReference menuHoverEvent;
        public EventInstance menuHoverInstance;

        public EventReference menuPressEvent;
        public EventInstance menuPressInstance;


        public void MenuHoverAudio(GameObject menuhoverObject)
        {
            if (menuHoverEvent.IsNull)
            {
                Debug.Log("FMOD filepath for MenuHoverEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                menuHoverInstance = RuntimeManager.CreateInstance(menuHoverEvent);

                RuntimeManager.AttachInstanceToGameObject(menuHoverInstance, menuhoverObject.transform,
                    menuhoverObject.GetComponent<Rigidbody>());

                menuHoverInstance.start();

                menuHoverInstance.release();
                Debug.Log("menuhover");
            }
        }
        // N�r man trycker i huvudmenyn eller i ammo menyn
        public void MenuPressAudio(GameObject menupressObject)
        {
            if (menuPressEvent.IsNull)
            {
                Debug.Log("FMOD filepath for MenuPressEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                menuPressInstance = RuntimeManager.CreateInstance(menuPressEvent);

                RuntimeManager.AttachInstanceToGameObject(menuPressInstance, menupressObject.transform,
                    menupressObject.GetComponent<Rigidbody>());

                menuPressInstance.start();

                menuPressInstance.release();
                Debug.Log("menupress");
            }
        }
    }
    [Serializable]
    public class ObjectAudio
    {
        public EventReference weedThumbleEvent;
        public EventInstance weedThumbleInstance;

        public EventReference scrollUnfoldingEvent;
        public EventInstance scrollUnfoldingInstance;

        public EventReference scrollFoldingEvent;
        public EventInstance scrollFoldingInstance;

        public EventReference bookOpenEvent;
        public EventInstance bookOpenInstance;

        public EventReference bookClosingEvent;
        public EventInstance bookClosingInstance;

        public EventReference buttonPressEvent;
        public EventInstance buttonPressInstance;





        public void WeedThumbleAudio(GameObject weedThumbleObject)
        {
            if (weedThumbleEvent.IsNull)
            {
                Debug.Log("FMOD filepath for WeedThumbleEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                weedThumbleInstance = RuntimeManager.CreateInstance(weedThumbleEvent);

                RuntimeManager.AttachInstanceToGameObject(weedThumbleInstance, weedThumbleObject.transform,
                    weedThumbleObject.GetComponent<Rigidbody>());

                weedThumbleInstance.start();

                weedThumbleInstance.release();
                Debug.Log("weedtumble");
            }
        }

        public void ScrollUnfoldingAudio(GameObject scrollUnfoldingObject)
        {
            if (scrollUnfoldingEvent.IsNull)
            {
                Debug.Log("FMOD filepath for scrollUnfolding is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                scrollUnfoldingInstance = RuntimeManager.CreateInstance(scrollUnfoldingEvent);

                RuntimeManager.AttachInstanceToGameObject(scrollUnfoldingInstance, scrollUnfoldingObject.transform,
                    scrollUnfoldingObject.GetComponent<Rigidbody>());

                scrollUnfoldingInstance.start();

                scrollUnfoldingInstance.release();
                Debug.Log("scrollUnfolding");
            }
        }

        public void ScrollFoldingAudio(GameObject scrollFoldingObject)
        {
            if (scrollFoldingEvent.IsNull)
            {
                Debug.Log("FMOD filepath for scrollFolding is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                scrollFoldingInstance = RuntimeManager.CreateInstance(scrollFoldingEvent);

                RuntimeManager.AttachInstanceToGameObject(scrollFoldingInstance, scrollFoldingObject.transform,
                    scrollFoldingObject.GetComponent<Rigidbody>());

                scrollFoldingInstance.start();

                scrollFoldingInstance.release();
                Debug.Log("scrollFolding");
            }
        }

        public void BookOpenAudio(GameObject bookOpenObject)
        {
            if (bookOpenEvent.IsNull)
            {
                Debug.Log("FMOD filepath for bookOpen is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                bookOpenInstance = RuntimeManager.CreateInstance(bookOpenEvent);

                RuntimeManager.AttachInstanceToGameObject(bookOpenInstance, bookOpenObject.transform,
                    bookOpenObject.GetComponent<Rigidbody>());

                bookOpenInstance.start();

                bookOpenInstance.release();
                Debug.Log("bookOpen");
            }
        }

        public void BookClosingAudio(GameObject bookClosingObject)
        {
            if (bookClosingEvent.IsNull)
            {
                Debug.Log("FMOD filepath for bookClosing is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                bookClosingInstance = RuntimeManager.CreateInstance(bookClosingEvent);

                RuntimeManager.AttachInstanceToGameObject(bookClosingInstance, bookClosingObject.transform,
                    bookClosingObject.GetComponent<Rigidbody>());

                bookClosingInstance.start();

                bookClosingInstance.release();
                Debug.Log("bookClosing");
            }
        }

        public void ButtonPressAudio(GameObject buttonPressObject)
        {
            if (buttonPressEvent.IsNull)
            {
                Debug.Log("FMOD filepath for buttonPress is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                buttonPressInstance = RuntimeManager.CreateInstance(buttonPressEvent);

                RuntimeManager.AttachInstanceToGameObject(buttonPressInstance, buttonPressObject.transform,
                    buttonPressObject.GetComponent<Rigidbody>());

                buttonPressInstance.start();

                buttonPressInstance.release();
                Debug.Log("buttonPress");
            }
        }
    }

    [Serializable]
    public class EnemyCactiAudio
    {
        public EventReference cactiAlertEvent;
        public EventInstance cactiAlertInstance;

        public EventReference cactiDeathEvent;
        public EventInstance cactiDeathInstance;

        public EventReference cactiDamageEvent;
        public EventInstance cactiDamageInstance;

        public EventReference cactiFootstepEvent;
        public EventInstance cactiFootstepInstance;

        public EventReference cactiJumpEvent;
        public EventInstance cactiJumpInstance;

        public EventReference cactiLandEvent;
        public EventInstance cactiLandInstance;

        public EventReference cactiBlinkEvent;
        public EventInstance cactiBlinkInstance;

        public EventReference cactiLookEvent;
        public EventInstance cactiLookInstance;

        public void CactiAlertAudio(GameObject cactiAlertObject)
        {
            if (cactiAlertEvent.IsNull)
            {
                Debug.Log("FMOD filepath for CactiAlertEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                cactiAlertInstance = RuntimeManager.CreateInstance(cactiAlertEvent);

                RuntimeManager.AttachInstanceToGameObject(cactiAlertInstance, cactiAlertObject.transform,
                    cactiAlertObject.GetComponent<Rigidbody>());

                cactiAlertInstance.start();

                cactiAlertInstance.release();
                Debug.Log("cactialert");
            }
        }

        public void CactiBlinkAudio(GameObject cactiBlinkObject)
        {
            if (cactiBlinkEvent.IsNull)
            {
                Debug.Log("FMOD filepath for cactiBlinkEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                cactiBlinkInstance = RuntimeManager.CreateInstance(cactiBlinkEvent);

                RuntimeManager.AttachInstanceToGameObject(cactiBlinkInstance, cactiBlinkObject.transform,
                    cactiBlinkObject.GetComponent<Rigidbody>());

                cactiBlinkInstance.start();

                cactiBlinkInstance.release();
                Debug.Log("cactiBlink");
            }
        }

        public void CactiLookAudio(GameObject cactiLookObject)
        {
            if (cactiBlinkEvent.IsNull)
            {
                Debug.Log("FMOD filepath for cactiBlinkEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                cactiLookInstance = RuntimeManager.CreateInstance(cactiLookEvent);

                RuntimeManager.AttachInstanceToGameObject(cactiBlinkInstance, cactiLookObject.transform,
                    cactiLookObject.GetComponent<Rigidbody>());

                cactiLookInstance.start();

                cactiLookInstance.release();
                Debug.Log("Look");
            }
        }

        public void CactiDeathAudio(GameObject cactiDeathObject)
        {
            if (cactiDeathEvent.IsNull)
            {
                Debug.Log("FMOD filepath for CactiDeathEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                cactiDeathInstance = RuntimeManager.CreateInstance(cactiDeathEvent);

                RuntimeManager.AttachInstanceToGameObject(cactiDeathInstance, cactiDeathObject.transform,
                    cactiDeathObject.GetComponent<Rigidbody>());

                cactiDeathInstance.start();

                cactiDeathInstance.release();
                Debug.Log("cactideath");
            }
        }

        public void CactiDamageAudio(GameObject cactiDamageObject)
        {
            if (cactiDamageEvent.IsNull)
            {
                Debug.Log("FMOD filepath for CactiDamageEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                cactiDamageInstance = RuntimeManager.CreateInstance(cactiDamageEvent);

                RuntimeManager.AttachInstanceToGameObject(cactiDamageInstance, cactiDamageObject.transform,
                    cactiDamageObject.GetComponent<Rigidbody>());

                cactiDamageInstance.start();

                cactiDamageInstance.release();
                Debug.Log("cactidamage");
            }
        }

        public void CactiFootstepAudio(GameObject cactiFootstepObject, string surface)
        {
            cactiFootstepInstance = RuntimeManager.CreateInstance(cactiFootstepEvent);

            RuntimeManager.AttachInstanceToGameObject(cactiFootstepInstance, cactiFootstepObject.transform, cactiFootstepObject.GetComponent<Rigidbody>());
            switch (surface)
            {
                case "Sand":
                    cactiFootstepInstance.setParameterByName("Surface", 0f);
                    break;
                case "Stone":
                    cactiFootstepInstance.setParameterByName("Surface", 1f);
                    break;
                case "Wood":
                    cactiFootstepInstance.setParameterByName("Surface", 2f);
                    break;
                case "Gravel":
                    cactiFootstepInstance.setParameterByName("Surface", 3f);
                    break;
                case "Grass":
                    cactiFootstepInstance.setParameterByName("Surface", 4f);
                    break;
                case "Water":
                    cactiFootstepInstance.setParameterByName("Surface", 5f);
                    break;
                case "Snow":
                    cactiFootstepInstance.setParameterByName("Surface", 6f);
                    break;
            }

            cactiFootstepInstance.start();

            cactiFootstepInstance.release();
            Debug.Log("cactifootstep");


        }

        public void CactiJumpAudio(GameObject cactiJumpObject)
        {
            if (cactiJumpEvent.IsNull)
            {
                Debug.Log("FMOD filepath for CactiJumpEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                cactiJumpInstance = RuntimeManager.CreateInstance(cactiJumpEvent);

                RuntimeManager.AttachInstanceToGameObject(cactiJumpInstance, cactiJumpObject.transform,
                    cactiJumpObject.GetComponent<Rigidbody>());

                cactiJumpInstance.start();

                cactiJumpInstance.release();
                Debug.Log("cactijump");
            }
        }

        public void CactiLandAudio(GameObject cactiLandObject)
        {
            if (cactiLandEvent.IsNull)
            {
                Debug.Log("FMOD filepath for CactiLandEvent is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                cactiLandInstance = RuntimeManager.CreateInstance(cactiLandEvent);

                RuntimeManager.AttachInstanceToGameObject(cactiLandInstance, cactiLandObject.transform,
                    cactiLandObject.GetComponent<Rigidbody>());

                cactiLandInstance.start();

                cactiLandInstance.release();
                Debug.Log("cactiLand");
            }
        }
    }

    [Serializable]
        public class EnemySkeletonAudio
        {
            public EventReference skeletonDeathEvent;
            public EventInstance skeletonDeathInstance;

            public EventReference skeletonMeleeEvent;
            public EventInstance skeletonMeleeInstance;

            public EventReference skeletonFootstepEvent;
            public EventInstance skeletonFootstepInstance;

            public EventReference skeletonDamagedEvent;
            public EventInstance skeletonDamagedInstance;

            public EventReference skeletonShieldBreakEvent;
            public EventInstance skeletonShieldBreakInstance;

            public EventReference skeletonShieldBlockEvent;
            public EventInstance skeletonShieldBlockInstance;

                public void SkeletonDeathAudio(GameObject skeletonDeathObject)
                {
                    if (skeletonDeathEvent.IsNull)
                    {
                        Debug.Log("FMOD filepath for skeletonDeathEvent is missing, ask Johan to set it up at audiomanager.");
                    }
                    else
                    {
                    skeletonDeathInstance = RuntimeManager.CreateInstance(skeletonDeathEvent);

                        RuntimeManager.AttachInstanceToGameObject(skeletonDeathInstance, skeletonDeathObject.transform,
                            skeletonDeathObject.GetComponent<Rigidbody>());

                    skeletonDeathInstance.start();

                    skeletonDeathInstance.release();
                        Debug.Log("skeletonDeath");
                    }
                }

            public void SkeletonMeleeAudio(GameObject skeletonMeleeObject)
            {
                if (skeletonMeleeEvent.IsNull)
                {
                    Debug.Log("FMOD filepath for skeletonMeleeEvent is missing, ask Johan to set it up at audiomanager.");
                }
                else
                {
                    skeletonMeleeInstance = RuntimeManager.CreateInstance(skeletonMeleeEvent);

                    RuntimeManager.AttachInstanceToGameObject(skeletonMeleeInstance, skeletonMeleeObject.transform,
                        skeletonMeleeObject.GetComponent<Rigidbody>());

                    skeletonMeleeInstance.start();

                    skeletonMeleeInstance.release();
                    Debug.Log("skeletonMelee");
                }
            }

            public void SkeletonFootstepAudio(GameObject skeletonFootstepObject, string surface)
            {
                skeletonFootstepInstance = RuntimeManager.CreateInstance(skeletonFootstepEvent);

                RuntimeManager.AttachInstanceToGameObject(skeletonFootstepInstance, skeletonFootstepObject.transform, skeletonFootstepObject.GetComponent<Rigidbody>());
                switch (surface)
                {
                    case "Temple":
                        skeletonFootstepInstance.setParameterByName("Surface", 0f);
                        break;
                }

                skeletonFootstepInstance.start();

                skeletonFootstepInstance.release();
                Debug.Log("skeletonFootstep");


            }

            public void SkeletonDamagedAudio(GameObject skeletonDamagedObject)
            {
                if (skeletonDamagedEvent.IsNull)
                {
                    Debug.Log("FMOD filepath for skeletonDamagedEvent is missing, ask Johan to set it up at audiomanager.");
                }
                else
                {
                    skeletonDamagedInstance = RuntimeManager.CreateInstance(skeletonDamagedEvent);

                    RuntimeManager.AttachInstanceToGameObject(skeletonDamagedInstance, skeletonDamagedObject.transform,
                        skeletonDamagedObject.GetComponent<Rigidbody>());

                    skeletonDamagedInstance.start();

                    skeletonDamagedInstance.release();
                    Debug.Log("skeletonDamaged");
                }
            }

            public void SkeletonShieldBreakAudio(GameObject skeletonShieldBreakObject)
            {
                if (skeletonShieldBreakEvent.IsNull)
                {
                    Debug.Log("FMOD filepath for skeletonShieldBreak is missing, ask Johan to set it up at audiomanager.");
                }
                else
                {
                    skeletonShieldBreakInstance = RuntimeManager.CreateInstance(skeletonShieldBreakEvent);

                 RuntimeManager.AttachInstanceToGameObject(skeletonShieldBreakInstance, skeletonShieldBreakObject.transform,
                    skeletonShieldBreakObject.GetComponent<Rigidbody>());

                 skeletonShieldBreakInstance.start();

                    skeletonShieldBreakInstance.release();
                    Debug.Log("skeletonShieldBreak");
                }
            }

            public void SkeletonShieldBlockAudio(GameObject skeletonShieldBlockObject)
            {
                if (skeletonShieldBlockEvent.IsNull)
                {
                    Debug.Log("FMOD filepath for skeletonShieldBlock is missing, ask Johan to set it up at audiomanager.");
                }
                else
                {
                    skeletonShieldBlockInstance = RuntimeManager.CreateInstance(skeletonShieldBlockEvent);

                    RuntimeManager.AttachInstanceToGameObject(skeletonShieldBlockInstance, skeletonShieldBlockObject.transform,
                    skeletonShieldBlockObject.GetComponent<Rigidbody>());

                    skeletonShieldBlockInstance.start();

                    skeletonShieldBlockInstance.release();
                    Debug.Log("skeletonShieldBlock");
                }
            }
        }

    [Serializable]
    public class GolemBossAudio
    {
        public EventReference golemThrowerEvent;
        public EventInstance golemThrowerInstance;

        public EventReference golemEntryEvent;
        public EventInstance golemEntryInstance;

        public void GolemThrowerAudio(GameObject golemThrowerObject)
        {
            if (golemThrowerEvent.IsNull)
            {
                Debug.Log("FMOD filepath for golemthrower is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                golemThrowerInstance = RuntimeManager.CreateInstance(golemThrowerEvent);

                RuntimeManager.AttachInstanceToGameObject(golemThrowerInstance, golemThrowerObject.transform,
                golemThrowerObject.GetComponent<Rigidbody>());

                golemThrowerInstance.start();

                golemThrowerInstance.release();
                Debug.Log("golemThrower");
            }
        }

        public void GolemEntryAudio(GameObject golemEntryObject)
        {
            if (golemEntryEvent.IsNull)
            {
                Debug.Log("FMOD filepath for golemEntry is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                golemEntryInstance = RuntimeManager.CreateInstance(golemEntryEvent);

                RuntimeManager.AttachInstanceToGameObject(golemEntryInstance, golemEntryObject.transform,
                golemEntryObject.GetComponent<Rigidbody>());

                golemEntryInstance.start();

                golemEntryInstance.release();
                Debug.Log("Entry");
            }
        }
    }
    [Serializable]
        public class AmbianceAudio
        {
            public EventReference templeFiresEvent;
            public EventInstance templeFiresInstance;

            public void TempleFiresAudio(GameObject templeFiresObject)
            {
                if (templeFiresEvent.IsNull)
                {
                    Debug.Log("FMOD filepath for templeFires is missing, ask Johan to set it up at audiomanager.");
                }
                else
                {
                    templeFiresInstance = RuntimeManager.CreateInstance(templeFiresEvent);

                    RuntimeManager.AttachInstanceToGameObject(templeFiresInstance, templeFiresObject.transform,
                    templeFiresObject.GetComponent<Rigidbody>());

                    templeFiresInstance.start();

                    templeFiresInstance.release();
                    Debug.Log("templeFires");
                }
            }
        }

    [Serializable]
    public class MusicAudio
    {
        public EventReference tutorialMusicEvent;
        public EventInstance tutorialMusicInstance;

        public EventReference menuThemeSongEvent;
        private EventInstance menuThemeSongInstance;

        public ScriptableValueHandler scriptableValueHandler;
        public void TutorialMusicEventAudio(GameObject tutorialMusicObject)
        {


            if (tutorialMusicEvent.IsNull)
            {
                Debug.Log("FMOD filepath for tutorialMusic is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {

                tutorialMusicInstance = RuntimeManager.CreateInstance(tutorialMusicEvent);


                RuntimeManager.AttachInstanceToGameObject(tutorialMusicInstance, tutorialMusicObject.transform,
                tutorialMusicObject.GetComponent<Rigidbody>());

                tutorialMusicInstance.start();

                tutorialMusicInstance.release();
                Debug.Log("tutorialMusic");
            }
        }
        public void MenuThemeSongAudio(GameObject menuMusicObject)
        {
            if (menuThemeSongEvent.IsNull)
            {
                Debug.Log("FMOD filepath for tutorialMusic is missing, ask Johan to set it up at audiomanager.");
            }
            else
            {
                menuThemeSongInstance = RuntimeManager.CreateInstance(menuThemeSongEvent);

                RuntimeManager.AttachInstanceToGameObject(menuThemeSongInstance, menuMusicObject.transform,
                menuMusicObject.GetComponent<Rigidbody>());

                menuThemeSongInstance.start();

                menuThemeSongInstance.release();
                Debug.Log("menuThemeMusic");
            }
        }

        public void GameStart()
        {
            menuThemeSongInstance.setParameterByName("Startgame", 1);
        }

        public void AdjustTutorialMusicParameter()
        {
            tutorialMusicInstance.setParameterByName("Intro", 1);
        }


    }


    


        public PlayerAudio playerAudio;
        public InteractablesAudio interactablesAudio;
        public MenuAudio menuAudio;
        public ObjectAudio objectAudio;
        public EnemyCactiAudio enemyCactiAudio;
        public EnemySkeletonAudio enemySkeletonAudio;
        public GolemBossAudio golemThrowerAudio;
        public AmbianceAudio ambianceAudio;
        public MusicAudio musicAudio;


}



// Start is called before the first frame update
//void Start()
//  {

//     }

// Update is called once per frame
//  void Update()
//  {

//  }
//  }
