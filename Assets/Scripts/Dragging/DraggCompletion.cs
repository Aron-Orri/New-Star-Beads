using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggCompletion : MonoBehaviour
{
    public Image[] areas;
    private int completedAreas = 0;
    public GameObject draggingSystem;
    public GameObject pendantSystem;

    private void Update()
    {
        if (completedAreas == areas.Length)
        {
            draggingSystem.SetActive(false);
            pendantSystem.SetActive(true);
        }
    }

    public void areaCompleted()
    {
        completedAreas++;
    }
}
