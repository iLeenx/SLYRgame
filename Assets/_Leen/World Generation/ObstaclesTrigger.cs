using UnityEngine;

public class ObstaclesTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player got hit , - HP");
            Destroy(gameObject);
        }
    }



    //private Collider obstacleCollider;
    //private Renderer obstacleRenderer;

    //private void Start()
    //{
    //    // Get parent (Rock)
    //    Transform obstacle = transform.parent;

    //    obstacleCollider = obstacle.GetComponent<Collider>();
    //    obstacleRenderer = obstacle.GetComponent<Renderer>();
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        // Disable collider
    //        if (obstacleCollider != null)
    //            obstacleCollider.enabled = false;
    //        Debug.Log("desable collider");

    //        // Make 50% transparent
    //        if (obstacleRenderer != null)
    //        {
    //            Material mat = obstacleRenderer.material;
    //            Color color = mat.color;
    //            color.a = 0.5f;
    //            mat.color = color;

    //            // Enable transparency for Standard Shader
    //            mat.SetFloat("_Mode", 2);
    //            mat.EnableKeyword("_ALPHABLEND_ON");
    //            mat.renderQueue = 3000;

    //            Debug.Log("material change");
    //        }
    //    }
    //}

    
}
