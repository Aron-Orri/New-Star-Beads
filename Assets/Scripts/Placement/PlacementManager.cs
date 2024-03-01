using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] Transform[] PendantLocations;
    private GameObject CurrentPendant;
    [SerializeField] GameObject PendantPrefab;
    [SerializeField] Transform PendantSpawnPoint;
    [SerializeField] GameObject EndScreen;

    private void Start()
    {
        CurrentPendant = Instantiate(PendantPrefab, PendantSpawnPoint.position, PendantSpawnPoint.rotation);
    }

    public void MovePendantToTransformIndex(int idx)
    {
        Debug.Log(PendantLocations[0]);
        CurrentPendant.GetComponent<PlacementScript>().MoveTo(PendantLocations[idx]);
        //gameObject.SetActive(false);
        //CreateNewPendant();
    }

    public void ConfirmPlacement()
    {
        EndScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CreateNewPendant()
    {
        CurrentPendant = Instantiate(PendantPrefab, PendantSpawnPoint.position, PendantSpawnPoint.rotation);
    }
}
