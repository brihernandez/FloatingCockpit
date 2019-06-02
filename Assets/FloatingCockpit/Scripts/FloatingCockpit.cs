using UnityEngine;

namespace FC
{
    /// <summary>
    /// Disocnnects and keeps a cockpit in sync with the model as it flies around. This
    /// can be useful to extend the range at which floating point precision becomes a
    /// problem. Cockpits in particular are sensitive to floating point errors because
    /// they have a lot of small fiddly bits compared to a much larger aircraft.
    /// 
    /// This script assumes that it's put onto a cockpit object.
    /// </summary>
    public class FloatingCockpit : MonoBehaviour
    {
        [Tooltip("Transform of the reference camera in the aircraft. Used to rotate the camera to match.")]
        [SerializeField] private Transform sourceCamera = null;

        [Tooltip("Transform of the aircraft that this cockpit belongs to. Used to rotate the cockpit to match.")]
        [SerializeField] private Transform sourceAircraft = null;

        [Tooltip("Camera in the cockpit.")]
        [SerializeField] private Camera cockpitCamera = null;

        private void Awake()
        {
            // Must be unparented so that it can sit comfortably at the origin where there's
            // no floating point errors to worry about.
            transform.SetParent(null);
            transform.position = Vector3.zero;

            // Tell the developer that these are required. It shouldn't crash without these,
            // but the script definitely won't work correctly.
            if (sourceCamera == null)
                Debug.LogError(name + ": FloatingCockpit - Missing source camera reference!");
            if (sourceAircraft == null)
                Debug.LogError(name + ": FloatingCockpit - Missing source aircraft reference!");
            if (cockpitCamera == null)
                Debug.LogError(name + ": FloatingCockpit - Missing cockpit camera reference!");
        }

        private void Update()
        {
            if (sourceAircraft != null)
                transform.rotation = sourceAircraft.rotation;

            if (sourceCamera != null && cockpitCamera != null)
                cockpitCamera.transform.rotation = sourceCamera.rotation;
        }
    }
}
