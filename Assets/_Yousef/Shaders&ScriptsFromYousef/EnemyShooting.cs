using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] float shotCoolDown = 1;
    [SerializeField] float bulletHeight = 0;
    [SerializeField] float howFurther = 0;
    
    float nextShot = 0;
    Vector3 shotPosition;

    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= nextShot)
        {
            nextShot = Time.time + shotCoolDown;
            shotPosition= transform.position;
            shotPosition.y = shotPosition.y + bulletHeight;
            shotPosition.x = shotPosition.x - 2.0f;
            shotPosition.z = shotPosition.z + howFurther;

            GameObject go = Instantiate(shot, shotPosition, transform.rotation);

            EnemyProjectile proj = go.GetComponent<EnemyProjectile>();
        }
        if (Input.GetMouseButton(2) && Time.time >= nextShot)
        {
            nextShot = Time.time + shotCoolDown;
            shotPosition = transform.position;
            shotPosition.y = shotPosition.y + bulletHeight;
            shotPosition.z = shotPosition.z + howFurther;

            GameObject go = Instantiate(shot, shotPosition, transform.rotation);

            EnemyProjectile proj = go.GetComponent<EnemyProjectile>();
        }
        if (Input.GetMouseButton(1) && Time.time >= nextShot)
        {
            nextShot = Time.time + shotCoolDown;
            shotPosition = transform.position;
            shotPosition.y = shotPosition.y + bulletHeight;
            shotPosition.x = shotPosition.x + 2.0f;
            shotPosition.z = shotPosition.z + howFurther;

            GameObject go = Instantiate(shot, shotPosition, transform.rotation);

            EnemyProjectile proj = go.GetComponent<EnemyProjectile>();
        }
    }
}
