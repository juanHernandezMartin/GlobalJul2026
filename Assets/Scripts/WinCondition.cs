using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winButton;
    public List<PlatoScript> platos;

    public void Update()
    {
        int platesActive = 0;

        for( int currPlate = 0; currPlate < platos.Count; currPlate++ )
        {
            if( platos[currPlate].isPlatoActive)
            {
                platesActive++;
            }
        }

        if( platesActive == platos.Count )
        {
            winButton.SetActive(true);
        }
    }
}
