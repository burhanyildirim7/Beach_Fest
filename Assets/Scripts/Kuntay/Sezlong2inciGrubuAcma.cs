using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sezlong2inciGrubuAcma : MonoBehaviour
{
    [SerializeField] Text bedelText;
    [SerializeField] GameObject acilacakSezlongGrubu;
    bool isOpen=0;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = PlayerPrefs.GetInt("2inciSezlongAcikMi");
    }

    // Update is called once per frame
    void Update()
    {
        if (bedelText.text=="$0"||isOpen==1)
        {
            acilacakSezlongGrubu.SetActive(true);
        }
    }
}
