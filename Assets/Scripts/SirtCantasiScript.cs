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
    [Header("Cantada Bulunan Obje Cesitleri")]
    public List<GameObject> _cantadakiStuffObjeleri = new List<GameObject>();
    [Header("PlayerController Scripti")]
    [SerializeField] private PlayerController _playerController;

    [HideInInspector] public int _cantadakiObjeSayisi;

    [HideInInspector] public int _stuffStackSiniri;

    void Start()
    {
        _cantadakiObjeSayisi = 0;
        _stuffStackSiniri = 4;
    }

    private void FixedUpdate()
    {
        if (_cantadakiObjeler.Count > 0)
        {
            _playerController._elindeStaffVarMi = true;
        }
        else
        {
            _playerController._elindeStaffVarMi = false;
        }

        CantayiDüzenle();
        CantayiHizala();
    }

    public void StuffTopla(GameObject other)
    {
        if (_cantadakiObjeler.Count < _stuffStackSiniri)
        {
            other.gameObject.transform.parent = _sirtCantasiObject.transform;
            _cantadakiObjeler.Add(other.gameObject);
            _cantadakiStuffObjeleri.Add(other.gameObject);

            int sira = _cantadakiObjeSayisi;
            //other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.2f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.2f));
            other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f);
            other.gameObject.transform.DOLocalRotate(new Vector3(90, 90, 0), 0.5f);
            _cantadakiObjeSayisi++;
        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {


    }

    public void StuffCek(Transform malKabulNoktasi)
    {
        if (_cantadakiStuffObjeleri.Count > 0)
        {
            int sira = _cantadakiStuffObjeleri.Count - 1;
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.parent = null;
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            //Destroy(_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject, 1f);
            _cantadakiStuffObjeleri.RemoveAt(_cantadakiStuffObjeleri.Count - 1);
            _cantadakiObjeSayisi--;
            //CantayiDüzenle();

        }
        else
        {

        }
    }


    public void CopKutusunaAt(Transform malKabulNoktasi)
    {
        StuffCek(malKabulNoktasi);
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

    private void CantayiHizala()
    {
        for (int i = 0; i < _sirtCantasiObject.transform.childCount; i++)
        {
            _sirtCantasiObject.transform.GetChild(i).transform.position = _yerlesmeNoktalari[i].transform.position;
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

        int cantadakistuffobjesayi = _cantadakiStuffObjeleri.Count;
        for (int i = 0; i < cantadakistuffobjesayi; i++)
        {
            Destroy(_cantadakiStuffObjeleri[0].gameObject);
            _cantadakiStuffObjeleri.RemoveAt(0);

        }


        _cantadakiObjeSayisi = 0;
    }
}
