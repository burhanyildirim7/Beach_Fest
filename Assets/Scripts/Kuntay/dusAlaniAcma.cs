using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dusAlaniAcma : MonoBehaviour
{
    [SerializeField] Text bedelOdemeText;
    [SerializeField] GameObject acilacakObje, kapanacakObje, _acilacakCollider;
    [SerializeField] int dusNo = 0;
    int dus1Acik = 0, dus2Acik = 0, dus3Acik = 0, dus4Acik = 0, dus5Acik = 0, dus6Acik = 0;
    // Start is called before the first frame update
    void Start()
    {
        dus1Acik = PlayerPrefs.GetInt("dus1AcikMi");
        dus2Acik = PlayerPrefs.GetInt("dus2AcikMi");
        dus3Acik = PlayerPrefs.GetInt("dus3AcikMi");
        dus4Acik = PlayerPrefs.GetInt("dus4AcikMi");
        dus5Acik = PlayerPrefs.GetInt("dus5AcikMi");
        dus6Acik = PlayerPrefs.GetInt("dus6AcikMi");
        if (dus1Acik == 1 && dusNo == 1)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (dus2Acik == 1 && dusNo == 2)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (dus3Acik == 1 && dusNo == 3)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (dus4Acik == 1 && dusNo == 4)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (dus5Acik == 1 && dusNo == 5)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (dus6Acik == 1 && dusNo == 6)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (bedelOdemeText.text == "$0" && dus1Acik == 0 && dusNo == 1)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
            PlayerPrefs.SetInt("dus1AcikMi", 1);
        }
        else if (bedelOdemeText.text == "$0" && dus2Acik == 0 && dusNo == 2)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
            PlayerPrefs.SetInt("dus2AcikMi", 1);
        }
        else if (bedelOdemeText.text == "$0" && dus3Acik == 0 && dusNo == 3)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
            PlayerPrefs.SetInt("dus3AcikMi", 1);
        }
        else if (bedelOdemeText.text == "$0" && dus4Acik == 0 && dusNo == 4)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
            PlayerPrefs.SetInt("dus4AcikMi", 1);
        }
        else if (bedelOdemeText.text == "$0" && dus5Acik == 0 && dusNo == 5)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
            PlayerPrefs.SetInt("dus5AcikMi", 1);
        }
        else if (bedelOdemeText.text == "$0" && dus6Acik == 0 && dusNo == 6)
        {
            acilacakObje.SetActive(true);
            kapanacakObje.SetActive(false);
            _acilacakCollider.SetActive(true);
            transform.GetComponent<MeshRenderer>().enabled = false;
            PlayerPrefs.SetInt("dus6AcikMi", 1);
        }
        else
        {

        }
    }
}
