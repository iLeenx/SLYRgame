using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] float shotCoolDown = 1;
    [SerializeField] float bigShotCoolDown = 1;
    [SerializeField] float bulletHeight = 0;
    [SerializeField] float howFurther = 0;
    
    private float nextShot = 0;
    private float bigShot = 0;
    private Vector3 shotPosition;
    private Vector3 bigShotPosition;

    void Update()
    {
        if (Input.GetButtonDown("EnemyShoot1") && Time.time >= nextShot)
        {
            nextShot = Time.time + shotCoolDown;
            shotPosition = transform.position;
            shotPosition.y = shotPosition.y + bulletHeight;
            shotPosition.z = shotPosition.z + howFurther;

            GameObject go = Instantiate(shot, shotPosition, transform.rotation);

            EnemyProjectile proj = go.GetComponent<EnemyProjectile>();
        }
        shootInAllDir();
    }
    void shootInAllDir()
    {
        if (Input.GetButtonDown("EnemyShoot2") && Time.time >= bigShot)
        {
            bigShot = Time.time + bigShotCoolDown;
            
            bigShotPosition = transform.position;
            bigShotPosition.y = bigShotPosition.y + bulletHeight;
            bigShotPosition.z = bigShotPosition.z + howFurther;

            GameObject go = Instantiate(shot, bigShotPosition, transform.rotation);

            bigShotPosition = transform.position;
            bigShotPosition.y = bigShotPosition.y + bulletHeight;
            bigShotPosition.x = bigShotPosition.x + 2.0f;
            bigShotPosition.z = bigShotPosition.z + howFurther;

            GameObject go1 = Instantiate(shot, bigShotPosition, transform.rotation);

            bigShotPosition = transform.position;
            bigShotPosition.y = bigShotPosition.y + bulletHeight;
            bigShotPosition.x = bigShotPosition.x - 2.0f;
            bigShotPosition.z = bigShotPosition.z + howFurther;

            GameObject go2 = Instantiate(shot, bigShotPosition, transform.rotation);

            EnemyProjectile proj = go.GetComponent<EnemyProjectile>();
            EnemyProjectile proj1 = go1.GetComponent<EnemyProjectile>();
            EnemyProjectile proj2 = go2.GetComponent<EnemyProjectile>();
        }
    }
}
