using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedParticleInstantiation : MonoBehaviour
{
    public GameObject particleSystemToInstantiate;
    private GameObject instantiatedObj;

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "MainCamera")
        {
            instantiatedObj = Instantiate(particleSystemToInstantiate, gameObject.transform);
            instantiatedObj.GetComponent<ParticleSystem>().Play();
            StartCoroutine(StopParticlesAfter3Seconds(instantiatedObj));
        }

	}

    IEnumerator StopParticlesAfter3Seconds (GameObject obj)
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("Particle system stops");
        instantiatedObj.GetComponent<ParticleSystem>().Stop();
    }
}
