using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject playerShot;
    [SerializeField] float playerShotCoolDown = 1;
    [SerializeField] float shotHeight = 1;
    [SerializeField] float shotForward = 1;
    [SerializeField] AudioClip playerGunSound;
    
    private float nextShot = 0;
    private Vector3 shotPosition;
    private int shotCount = 0;
    private bool hasGun = false;

    void Update()
    {
        if (Input.GetButtonDown("One") && Time.time >= nextShot && hasGun)
        {
            nextShot = Time.time + playerShotCoolDown;
            shotPosition = transform.position;
            shotPosition.y = shotPosition.y + shotHeight;
            shotPosition.z = shotPosition.z + shotForward;

            AudioSource.PlayClipAtPoint(playerGunSound, transform.position);
            GameObject go = Instantiate(playerShot, shotPosition, transform.rotation);

            PlayerProjectile proj = go.GetComponent<PlayerProjectile>();
            shotCount--;
            if(shotCount == 0)
            {
                hasGun = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            shotCount = Mathf.Min(shotCount + 1, 5);
            hasGun = true;
        }
        if (other.CompareTag("BigGun"))
        {
            shotCount = Mathf.Min(shotCount + 3, 5);
            hasGun = true;
        }
    }
}
