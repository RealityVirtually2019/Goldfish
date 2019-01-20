using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedParticleInstantiation : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
        Debug.Log("Triggered");
        if (other.gameObject.tag == "PlayerCollision")
        {
            GameManager.instance.InstantiateParticles(gameObject);

        }

	}




}
