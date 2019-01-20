using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawner : MonoBehaviour
{
    private GameObject managersGO; 
    // Start is called before the first frame update
    void Start()
    {
        if (AudioManager.instance == null)
        {
            managersGO = Resources.Load<GameObject>("Managers");
            Instantiate(managersGO);
        }
        Destroy(gameObject);
    }
}
