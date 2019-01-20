using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance = null;

    private uint bankID;

	private void Awake()
	{
        if (AudioManager.instance == null) instance = this;
        else Destroy(gameObject);

        InitializeAudio();
	}

	private void InitializeAudio()
	{
        AkSoundEngine.LoadBank("MX", AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
        AkSoundEngine.LoadBank("SFX", AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
        StartMusic();
        StartAmbiance();
        AkSoundEngine.RenderAudio();
	}

    //public void RegisterListener (GameObject listener)
    //{
    //    AkSoundEngine.RegisterGameObj(listener, "Main Listener");
    //    AkSoundEngine.SetDefaultListeners(listener, 1);
    //}

    public void StartAmbiance()
    {
        AkSoundEngine.PostEvent("Play_Goldfish_sfx_underwaterAmb", gameObject);
    }
    public void StartPeopleAmbiance (GameObject peopleGO)
    {
        AkSoundEngine.PostEvent("Goldfish_sfx_peopleAmbiance", peopleGO);
        AkSoundEngine.PostEvent("Goldfish_sfx_peopleAmbiance_2D", gameObject);
        AkSoundEngine.RenderAudio();
    }

    public void StartBubbles (GameObject bubbleObj)
    {
        AkSoundEngine.PostEvent("Goldfish_sfx_startBubbles", bubbleObj);
        AkSoundEngine.RenderAudio();
    }

    public void CatSound (GameObject catGO)
    {
        AkSoundEngine.PostEvent("Goldfish_sfx_catMiaow", catGO);
        AkSoundEngine.RenderAudio();
    }
    public void CatFrollement (GameObject catGO)
    {
        AkSoundEngine.PostEvent("Goldfish_sfx_catFrollement", catGO);
        AkSoundEngine.RenderAudio();
    }



    //MX Related Stuff
    public void StartMusic()
    {
        AkSoundEngine.PostEvent("Play_Goldfish_MX", gameObject);
        ChangeStateToHouse();
        //AkSoundEngine.RenderAudio();
    }

    public void ChangeStateToHouse ()
    {
        AkSoundEngine.SetState("Goldfish_mx_states", "Goldfish_mx_states_house");
        AkSoundEngine.RenderAudio();
    }
    public void ChangeStateToCat()
    {
        AkSoundEngine.SetState("Goldfish_mx_states", "Goldfish_mx_states_cat");
        AkSoundEngine.RenderAudio();
    }
    public void ChangeStateToFishbowl()
    {
        AkSoundEngine.SetState("Goldfish_mx_states", "Goldfish_mx_states_fishBowl");
        AkSoundEngine.RenderAudio();
    }

    public void UpdateCatTension (float tensionPercentage)
    {
        AkSoundEngine.SetRTPCValue("Goldfish_rtpc_catTension", tensionPercentage);
        AkSoundEngine.RenderAudio();
    }

}
