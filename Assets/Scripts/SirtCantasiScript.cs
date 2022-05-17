using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SirtCantasiScript : MonoBehaviour
{
    [Header("Objeler Toplandiğinda Parent Atanacak Obje")]
    public GameObject _sirtCantasiObject;
    [Header("Objelerin Yerlesecegi Transform Listesi")]
    public List<Transform> _yerlesmeNoktalari = new List<Transform>();
    [Header("Cantada Bulunan Objelerin Tamami")]
    public List<GameObject> _cantadakiObjeler = new List<GameObject>();
    [Header("Cantada Bulunan Saman Objeleri")]
    public List<GameObject> _cantadakiSamanObjeleri = new List<GameObject>();

    private int _cantadakiObjeSayisi;

    void Start()
    {
        _cantadakiObjeSayisi = 0;
    }

    private void FixedUpdate()
    {
        CantayiDüzenle();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SamanBalyasi")
        {
            if (_cantadakiObjeler.Count < _yerlesmeNoktalari.Count)
            {
                other.gameObject.transform.parent = _sirtCantasiObject.transform;
                _cantadakiObjeler.Add(other.gameObject);
                _cantadakiSamanObjeleri.Add(other.gameObject);
                other.gameObject.tag = "ToplanmisSamanBalyasi";

                int sira = _cantadakiObjeSayisi;
                other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.5f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f));
                other.gameObject.transform.DOLocalRotate(Vector3.zero, 1);
                _cantadakiObjeSayisi++;

                if (GameObject.FindGameObjectWithTag("Ambar") != null)
                {
                    AmbarSpawnScript _ambarSpawnScript = GameObject.FindGameObjectWithTag("Ambar").GetComponent<AmbarSpawnScript>();

                    if (_ambarSpawnScript._ambarUrunSayisi > 0)
                    {
                        _ambarSpawnScript._ambarUrunSayisi--;
                    }
                    else
                    {

                    }
                }
                else
                {

                }



            }
            else
            {

            }


            //Debug.Log("Saman Balyasi Alindi");
        }
    }

    public void SamanCek(Transform malKabulNoktasi)
    {
        if (_cantadakiSamanObjeleri.Count > 0)
        {
            int sira = _cantadakiSamanObjeleri.Count - 1;
            _cantadakiSamanObjeleri[_cantadakiSamanObjeleri.Count - 1].gameObject.transform.parent = null;
            _cantadakiSamanObjeleri[_cantadakiSamanObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiSamanObjeleri[_cantadakiSamanObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _cantadakiSamanObjeleri.RemoveAt(_cantadakiSamanObjeleri.Count - 1);
            _cantadakiObjeSayisi--;

        }
        else
        {

        }
    }

    private void CantayiDüzenle()
    {
        for (int i = 0; i < _cantadakiObjeler.Count; i++)
        {
            if (_cantadakiObjeler[i] == null)
            {
                _cantadakiObjeler.RemoveAt(i);
            }
            else
            {

            }
        }

    }

    public void SirtCantasiLevelStart()
    {
        int cantadakiobjesayi = _cantadakiObjeler.Count;
        for (int i = 0; i < cantadakiobjesayi; i++)
        {
            Destroy(_cantadakiObjeler[0].gameObject);
            _cantadakiObjeler.RemoveAt(0);

        }

        int cantadakisamanobjesayi = _cantadakiSamanObjeleri.Count;
        for (int i = 0; i < cantadakisamanobjesayi; i++)
        {
            Destroy(_cantadakiSamanObjeleri[0].gameObject);
            _cantadakiSamanObjeleri.RemoveAt(0);

        }

        _cantadakiObjeSayisi = 0;
    }
}
