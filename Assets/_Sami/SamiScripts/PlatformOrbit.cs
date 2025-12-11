using UnityEngine;

public class PlatformOrbit : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform platformCenter;
    public float radiusX = 10f;  // Horizontal radius (around left-right)
    public float radiusZ = 20f;  // Forward radius (around front-back)
    public float orbitSpeed = 20f;

    [Header("Floating")]
    public float floatHeight = 1f;
    public float floatSpeed = 2f;
    private float floatTimer;

    [Header("Self Rotation")]
    public bool rotateSelf = true;
    public float selfRotationSpeed = 90f;

    private float angle = 0f;

    void Update()
    {
        if (platformCenter == null) return;

        // ORBIT ANGLE UPDATE
        angle += orbitSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;

        // ELLIPTICAL PATH AROUND THE PLATFORM
        float x = Mathf.Cos(rad) * radiusX;
        float z = Mathf.Sin(rad) * radiusZ;

        Vector3 orbitPos = new Vector3(
            platformCenter.position.x + x,
            transform.position.y,
            platformCenter.position.z + z
        );

        // FLOATING ON Y
        floatTimer += Time.deltaTime * floatSpeed;
        float yOffset = Mathf.Sin(floatTimer) * floatHeight;
        orbitPos.y = platformCenter.position.y + yOffset;

        // APPLY POSITION
        transform.position = orbitPos;

        // SELF ROTATION
        if (rotateSelf)
            transform.Rotate(Vector3.up * selfRotationSpeed * Time.deltaTime);
    }
}
