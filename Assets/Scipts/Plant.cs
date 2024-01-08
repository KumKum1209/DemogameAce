using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shoot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(bulletPrefab,shoot.position,shoot.rotation);
    }
}
