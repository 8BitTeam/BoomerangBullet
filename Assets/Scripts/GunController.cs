using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    public int magazine = 1;

    private AudioSource explosionSound;
    private MainMovingController movingController;

    private GameObject bulletShoot;

    // Start is called before the first frame update
    void Start()
    {
        movingController = transform.parent.gameObject.GetComponent<MainMovingController>();
        explosionSound = GetComponent<AudioSource>();
        bulletShoot  = Instantiate<GameObject>(bullet, transform.position, Quaternion.identity);
        bulletShoot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (magazine > 0)
            {
                magazine--;
                bulletShoot.SetActive(true);
                bulletShoot.GetComponent<BulletController>().Shoot(movingController.GetFacingDirection(), gameObject);
                explosionSound.Play();
                
            }
        }
    }

}
