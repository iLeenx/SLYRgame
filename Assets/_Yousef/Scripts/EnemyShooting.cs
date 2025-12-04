using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] float shotCoolDown = 1;

    float nextShot = 0;

    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= nextShot)
        {
            nextShot = Time.time + shotCoolDown;
            GameObject go = Instantiate(shot, transform.position, transform.rotation);

            EnemyProjectile proj = go.GetComponent<EnemyProjectile>();
        }
    }
}
