using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradePanelExitButtonuScripti : MonoBehaviour
{
    [SerializeField] GameObject upgradePaneli;

    public void exitFonk()
    {
        upgradePaneli.SetActive(false);

    }

}
