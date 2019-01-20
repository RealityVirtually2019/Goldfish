using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> claws = new List<GameObject>();
    public static GameManager instance = null;

    private GameObject bleedParticleGo;

	private void Awake()
	{
        if (instance == null) instance = this;
        else Destroy(gameObject);

        Init();
	}

    private void Init ()
    {
        bleedParticleGo = Resources.Load<GameObject>("ParticleSystem/Flare");
        StartCoroutine(GameDelay());
    }

    public void InstantiateParticles (GameObject playerObj)
	{

        GameObject referenceToParticlesInstantiated = Instantiate(bleedParticleGo);
        referenceToParticlesInstantiated.transform.position = playerObj.transform.position;
        ParticleSystem bleedParticles = referenceToParticlesInstantiated.GetComponent<ParticleSystem>();
        StartCoroutine(StopParticlesAfter3Seconds(bleedParticles));
	}

    IEnumerator StopParticlesAfter3Seconds(ParticleSystem particleSystem)
    {
        particleSystem.Play();
        yield return new WaitForSecondsRealtime(3);
        particleSystem.Stop();
        yield return new WaitForSecondsRealtime(3);
        Destroy(particleSystem.gameObject);
    }

    public void AddClaw (GameObject claw)
    {
        claws.Add(claw);
    }

    IEnumerator GameDelay ()
    {
        yield return new WaitForSecondsRealtime(15);
        AudioManager.instance.ChangeStateToFishbowl();
        ShowClaws();

    }

    private void ShowClaws ()
    {
        foreach (GameObject i in claws)
        {
            i.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
