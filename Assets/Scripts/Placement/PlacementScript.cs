using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Transform endTransform;
    [SerializeField] float lerpDuration = 3f;
    private float elapsedTime;

    void Start()
    {
        elapsedTime = 0;
    }

    void Update()
    {
        if (!endTransform) return; // If the end transform hasn't been assigned skip the update function
        
        // Lerp the pendant to the location on the animal
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / lerpDuration;
        transform.SetPositionAndRotation(
            Vector3.Lerp(startPosition, endTransform.position, Mathf.SmoothStep(0, 1, percentageComplete)),
            Quaternion.Lerp(startRotation, endTransform.rotation, Mathf.SmoothStep(0, 1, percentageComplete))
            );

        if (elapsedTime > lerpDuration) // This locks the pendant location to the stuffed animal without parenting it
        {
            transform.parent = endTransform;
            endTransform = null;
        }
    }

    // This function sets the location that the pendant should move to
    public void MoveTo(Transform _endTransform)
    {
        if (_endTransform == null) Debug.LogError("Transform not set before calling MoveTo in PlacementScript.cs");
        elapsedTime = 0;

        endTransform = _endTransform;

        startPosition = transform.position;
        startRotation = transform.rotation;
    }
}
