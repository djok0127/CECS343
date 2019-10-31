using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject vortexPrefab;
    public GameObject slashPrefab;
    public RectTransform canvasTransform;
    private Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //CombatTextManager.Instance.CreateText(transform.position,"Fire!",Color.red, canvasTransform,new Vector3(0f,1f,0f));
            Shoot();
            SoundManager.PlaySound("fire");
            //player.TakeDamage(500f);

        }
        if (Input.GetKeyDown(KeyCode.F)&&player.MyMana==player.maxMana)
        {
            player.MyMana = -50f;
            Vortex();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Slash();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void Vortex()
    {
        Instantiate(vortexPrefab, firePoint.position, firePoint.rotation);
    }
    void Slash()
    {
        Instantiate(slashPrefab, firePoint.position, firePoint.rotation);
    }
}
