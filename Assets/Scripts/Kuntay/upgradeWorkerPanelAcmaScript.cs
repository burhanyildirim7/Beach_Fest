using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeWorkerPanelAcmaScript : MonoBehaviour
{
    [SerializeField] GameObject workerPaneli,playerPaneli;

    public void WorkerPanelFonk()
    {
        workerPaneli.SetActive(true);
        playerPaneli.SetActive(false);

    }
}
