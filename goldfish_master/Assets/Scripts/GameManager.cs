using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}
