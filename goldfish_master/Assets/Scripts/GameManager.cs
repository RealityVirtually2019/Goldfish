using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private ParticleSystem bleedParticles;

	private void Awake()
	{
        if (instance == null) instance = this;
        else Destroy(gameObject);

        Init();
	}

    private void Init ()
    {
        bleedParticles = Resources.Load<ParticleSystem>("Particles/bleedParticles");
    }

    public void InstantiateParticles (GameObject objToInstantiate)
	{
        
	}
}
