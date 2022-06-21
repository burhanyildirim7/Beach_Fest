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
    public List<GameObject> _cantadakiIceCreamObjeleri = new List<GameObject>();
    public List<GameObject> _cantadakiDrinkObjeleri = new List<GameObject>();
    [Header("PlayerController Scripti")]
    [SerializeField] private PlayerController _playerController;
    [Header("Ice Cream Yonetme Objeler")]
    [SerializeField] private GameObject _iceCreamTepsi;
    public List<GameObject> _tepsidekiIceCreams = new List<GameObject>();
    [Header("Drink Yonetme Objeler")]
    [SerializeField] private GameObject _drinkTepsi;
    public List<GameObject> _tepsidekiDrinks = new List<GameObject>();

    public int _cantadakiObjeSayisi;

    public int _cantadakiStuffSayisi;

    public int _cantadakiIceCreamSayisi;

    public int _cantadakiDrinkSayisi;

    public int _stuffStackSiniri;

    public int _iceCreamStackSiniri;

    public int _drinkStackSiniri;

    void Start()
    {
        _cantadakiObjeSayisi = 0;
        _cantadakiStuffSayisi = 0;
        _cantadakiIceCreamSayisi = 0;
        _cantadakiDrinkSayisi = 0;
        _stuffStackSiniri = 4;
        _iceCreamStackSiniri = 1;
        _drinkStackSiniri = 1;

        _iceCreamTepsi.SetActive(false);
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

        /*
        if (_cantadakiIceCreamSayisi > 0)
        {
            _iceCreamTepsi.SetActive(true);
        }
        else
        {
            _iceCreamTepsi.SetActive(false);
        }
        */
    }

    public void StuffTopla(GameObject other)
    {
        if (_cantadakiIceCreamObjeleri.Count == 0 && _cantadakiDrinkObjeleri.Count == 0)
        {
            if (_cantadakiStuffObjeleri.Count < _stuffStackSiniri)
            {
                other.gameObject.transform.parent = _sirtCantasiObject.transform;
                _cantadakiObjeler.Add(other.gameObject);
                _cantadakiStuffObjeleri.Add(other.gameObject);

                int sira = _cantadakiObjeSayisi;
                //other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.2f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.2f));
                other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f);
                other.gameObject.transform.DOLocalRotate(new Vector3(90, 90, 0), 0.5f);
                _cantadakiStuffSayisi++;
                _cantadakiObjeSayisi++;
            }
            else
            {

            }
        }
        else
        {

        }

    }

    public void IceCreamTopla()
    {
        if (_cantadakiStuffObjeleri.Count == 0 && _cantadakiDrinkObjeleri.Count == 0)
        {
            if (_cantadakiIceCreamObjeleri.Count < _iceCreamStackSiniri)
            {
                for (int i = 0; i < _tepsidekiIceCreams.Count; i++)
                {
                    if (_tepsidekiIceCreams[i].activeSelf == false)
                    {
                        _tepsidekiIceCreams[i].SetActive(true);
                        //_cantadakiObjeler.Add(_tepsidekiIceCreams[i].gameObject);
                        _cantadakiIceCreamObjeleri.Add(_tepsidekiIceCreams[i].gameObject);
                        _cantadakiIceCreamSayisi++;
                        _cantadakiObjeSayisi++;
                        break;
                    }
                    else
                    {

                    }
                }


            }
            else
            {

            }
        }
        else
        {

        }

    }

    public void DrinkTopla()
    {
        if (_cantadakiStuffObjeleri.Count == 0 && _cantadakiIceCreamObjeleri.Count == 0)
        {
            if (_cantadakiDrinkObjeleri.Count < _drinkStackSiniri)
            {
                for (int i = 0; i < _tepsidekiDrinks.Count; i++)
                {
                    if (_tepsidekiDrinks[i].activeSelf == false)
                    {
                        _tepsidekiDrinks[i].SetActive(true);
                        //_cantadakiObjeler.Add(_tepsidekiDrinks[i].gameObject);
                        _cantadakiDrinkObjeleri.Add(_tepsidekiDrinks[i].gameObject);
                        _cantadakiDrinkSayisi++;
                        _cantadakiObjeSayisi++;
                        break;
                    }
                    else
                    {

                    }
                }


            }
            else
            {

            }
        }
        else
        {

        }

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
            _cantadakiStuffSayisi--;
            _cantadakiObjeSayisi--;
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    public void IceCreamCek()
    {
        if (_cantadakiIceCreamObjeleri.Count > 0)
        {
            int sira = _cantadakiIceCreamObjeleri.Count - 1;
            // _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.parent = null;
            //_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            // _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            //Destroy(_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject, 1f);
            _cantadakiIceCreamObjeleri[_cantadakiIceCreamObjeleri.Count - 1].SetActive(false);
            _cantadakiIceCreamObjeleri.RemoveAt(_cantadakiIceCreamObjeleri.Count - 1);
            //_cantadakiObjeler.RemoveAt(_cantadakiDrinkObjeleri.Count - 1);
            _cantadakiIceCreamSayisi--;
            _cantadakiObjeSayisi--;
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    public void DrinkCek()
    {
        if (_cantadakiDrinkObjeleri.Count > 0)
        {
            int sira = _cantadakiDrinkObjeleri.Count - 1;
            // _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.parent = null;
            //_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            // _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            //Destroy(_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject, 1f);
            _cantadakiDrinkObjeleri[_cantadakiDrinkObjeleri.Count - 1].SetActive(false);
            _cantadakiDrinkObjeleri.RemoveAt(_cantadakiDrinkObjeleri.Count - 1);
            //_cantadakiObjeler.RemoveAt(_cantadakiDrinkObjeleri.Count - 1);
            _cantadakiDrinkSayisi--;
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

        IceCreamCek();
        DrinkCek();
    }

    public void TepsiBosalt()
    {
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

        if (_cantadakiIceCreamSayisi > 0)
        {
            _iceCreamTepsi.SetActive(true);

        }
        else
        {
            _iceCreamTepsi.SetActive(false);

        }

        if (_cantadakiDrinkSayisi > 0)
        {
            _drinkTepsi.SetActive(true);

        }
        else
        {
            _drinkTepsi.SetActive(false);

        }

        if (_cantadakiObjeler.Count == 0)
        {
            if (_cantadakiIceCreamSayisi > 0 || _cantadakiDrinkSayisi > 0)
            {

                _playerController._elindeStaffVarMi = true;
            }
            else
            {

                _playerController._elindeStaffVarMi = false;
            }


        }
        else
        {

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
