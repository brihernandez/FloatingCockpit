using UnityEngine;

namespace FC
{
    /// <summary>
    /// Very simple camera that looks ahead into turns based on ShipInput.
    /// </summary>
    public class LookaheadCamera : MonoBehaviour
    {
        public ASF.ShipInput input;
        [Range(0f, 179f)] public float horizontalLook = 15f;
        [Range(0f, 179f)] public float verticalLook = 15f;

        private float horizontalAngle = 0f;
        private float verticalAngle = 0f;

        private void Update()
        {
            if (input == null)
                return;

            horizontalAngle = input.yaw * horizontalLook;
            verticalAngle = input.pitch * verticalLook;

            transform.localEulerAngles = new Vector3(verticalAngle, horizontalAngle, 0f);
        }
    }
}
