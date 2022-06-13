using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradePlayerPanelAcmaScript : MonoBehaviour
{
    [SerializeField] GameObject workerPaneli, playerPaneli;

    public void WorkerPanelFonk()
    {
        workerPaneli.SetActive(false);
        playerPaneli.SetActive(true);

    }
}
