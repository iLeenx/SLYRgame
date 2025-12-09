using UnityEngine;

namespace Benjathemaker
{
    public class SimpleGemsAnim : MonoBehaviour
    {
        [Header("Rotation")]
        public bool isRotating = false;
        public bool rotateX = false;
        public bool rotateY = false;
        public bool rotateZ = false;
        public float rotationSpeed = 90f;

        [Header("Floating")]
        public bool isFloating = false;
        public bool useEasingForFloating = false;
        public float floatHeight = 1f;
        public float floatSpeed = 1f;
        private float floatTimer;
        private float initialY;

        [Header("Scaling")]
        public bool isScaling = false;
        public bool useEasingForScaling = false;
        public float scaleLerpSpeed = 1f;
        private float scaleTimer;
        private Vector3 startScale;
        public Vector3 endScale;

        [Header("Sliding Movement")]
        public bool isSliding = true;
        public float slideSpeed = 2f; // movement toward negative Z

        [Header("Lifetime (despawn)")]
        public float lifeTime = 5f;  // item will despawn after this time
        private float lifeTimer = 0f;

        void Start()
        {
            initialY = transform.position.y;

            // Initialize scaling system
            startScale = transform.localScale;

            // If endScale is zero, ignore and keep original
            if (endScale == Vector3.zero)
                endScale = startScale;
        }

        void Update()
        {
            // ----------------------------
            // ROTATION
            // ----------------------------
            if (isRotating)
            {
                Vector3 rot = new Vector3(
                    rotateX ? 1 : 0,
                    rotateY ? 1 : 0,
                    rotateZ ? 1 : 0
                );
                transform.Rotate(rot * rotationSpeed * Time.deltaTime);
            }

            // ----------------------------
            // FLOATING (affects Y only)
            // ----------------------------
            float newY = transform.position.y;

            if (isFloating)
            {
                floatTimer += Time.deltaTime * floatSpeed;
                float t = Mathf.PingPong(floatTimer, 1f);

                if (useEasingForFloating)
                    t = EaseInOutQuad(t);

                newY = initialY + t * floatHeight;
            }

            // ----------------------------
            // SLIDING (affects Z only)
            // ----------------------------
            float newZ = transform.position.z;

            if (isSliding)
                newZ -= slideSpeed * Time.deltaTime;

            // Apply new position (X stays unchanged)
            transform.position = new Vector3(
                transform.position.x,
                newY,
                newZ
            );

            // ----------------------------
            // SCALING
            // ----------------------------
            if (isScaling)
            {
                scaleTimer += Time.deltaTime * scaleLerpSpeed;
                float t = Mathf.PingPong(scaleTimer, 1f);

                if (useEasingForScaling)
                    t = EaseInOutQuad(t);

                transform.localScale = Vector3.Lerp(startScale, endScale, t);
            }

            // ----------------------------
            // LIFETIME (despawn)
            // ----------------------------
            lifeTimer += Time.deltaTime;
            if (lifeTimer >= lifeTime)
            {
                Destroy(gameObject);
            }
        }

        float EaseInOutQuad(float t)
        {
            return t < 0.5f ? 2 * t * t :
                   1 - Mathf.Pow(-2 * t + 2, 2) / 2;
        }
    }
}
