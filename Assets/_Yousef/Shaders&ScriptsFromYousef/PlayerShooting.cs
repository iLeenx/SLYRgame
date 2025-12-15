using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject playerShot;
    [SerializeField] float playerShotCoolDown = 1;
    [SerializeField] float shotHeight = 1;
    [SerializeField] float shotForward = 1;
    [SerializeField] float angularChange;
    [SerializeField]
    Image[] bullets;
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

            Quaternion shotRotation = Quaternion.Euler(transform.eulerAngles.x + angularChange, transform.eulerAngles.y, transform.eulerAngles.z);

            AudioManager.instance.playSFX("Gun");

            GameObject go = Instantiate(playerShot, shotPosition, shotRotation);

            PlayerProjectile proj = go.GetComponent<PlayerProjectile>();
            shotCount--;
            Color color = bullets[shotCount].color;
            color.a = 0.0f;
            bullets[shotCount].color = color;
            if(shotCount == 0)
            {
                hasGun = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (bullets[bullets.Length - 1].color.a != 1.0f)
        {
            if (other.CompareTag("Gun"))
            {
                Color color = bullets[shotCount].color;
                color.a = 1.0f;
                bullets[shotCount].color = color;
                shotCount = Mathf.Min(shotCount + 1, 5);
                hasGun = true;
            }
            if (other.CompareTag("BigGun"))
            {
                int addedBullets = shotCount;
                addedBullets = Mathf.Min(addedBullets + 3, bullets.Length);
                for (int i = shotCount; i < addedBullets; i++)
                {
                    Color color = bullets[i].color;
                    color.a = 1.0f;
                    bullets[i].color = color;
                }
                shotCount = addedBullets;
                hasGun = true;
            }
        }
    }
}
