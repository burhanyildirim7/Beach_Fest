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
    public List<GameObject> _cantadakiStuffSemsiyeObjeleri = new List<GameObject>();
    public List<GameObject> _cantadakiStuffPaletObjeleri = new List<GameObject>();
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
    [Header("Can Simidi Yonetme Objeler")]
    public GameObject _canSimidi;

    [Header("Kontrol Amacli")]
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

        _canSimidi.SetActive(false);

        _iceCreamTepsi.SetActive(false);
        _drinkTepsi.SetActive(false);

        PlayerCapacityGuncelle();
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

    public void PlayerCapacityGuncelle()
    {
        if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 0)
        {
            _stuffStackSiniri = 4;
            _iceCreamStackSiniri = 1;
            _drinkStackSiniri = 1;
        }
        else if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 1)
        {
            _stuffStackSiniri = 6;
            _iceCreamStackSiniri = 2;
            _drinkStackSiniri = 2;
        }
        else if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 2)
        {
            _stuffStackSiniri = 8;
            _iceCreamStackSiniri = 3;
            _drinkStackSiniri = 3;
        }
        else
        {

        }
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
                //other.gameObject.transform.DOLocalJump(_yerlesmeNoktalari[sira].localPosition, 1, 1, 0.5f);
                other.gameObject.transform.DOLocalRotate(new Vector3(90, 90, 0), 0.5f);
                _cantadakiStuffSayisi++;
                _cantadakiObjeSayisi++;

                MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            }
            else
            {

            }
        }
        else
        {

        }

    }

    public void StuffSemsiyeTopla(GameObject other)
    {
        if (_cantadakiIceCreamObjeleri.Count == 0 && _cantadakiDrinkObjeleri.Count == 0)
        {
            if (_cantadakiStuffObjeleri.Count < _stuffStackSiniri)
            {
                other.gameObject.transform.parent = _sirtCantasiObject.transform;
                _cantadakiObjeler.Add(other.gameObject);
                //_cantadakiStuffObjeleri.Add(other.gameObject);
                _cantadakiStuffSemsiyeObjeleri.Add(other.gameObject);

                int sira = _cantadakiObjeSayisi;
                //other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.2f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.2f));
                other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f);
                //other.gameObject.transform.DOLocalJump(_yerlesmeNoktalari[sira].localPosition, 1, 1, 0.5f);
                other.gameObject.transform.DOLocalRotate(new Vector3(90, 90, 0), 0.5f);
                _cantadakiStuffSayisi++;
                _cantadakiObjeSayisi++;

                MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            }
            else
            {

            }
        }
        else
        {

        }

    }

    public void StuffPaletTopla(GameObject other)
    {
        if (_cantadakiIceCreamObjeleri.Count == 0 && _cantadakiDrinkObjeleri.Count == 0)
        {
            if (_cantadakiStuffObjeleri.Count < _stuffStackSiniri)
            {
                other.gameObject.transform.parent = _sirtCantasiObject.transform;
                _cantadakiObjeler.Add(other.gameObject);
                //_cantadakiStuffObjeleri.Add(other.gameObject);
                _cantadakiStuffPaletObjeleri.Add(other.gameObject);

                int sira = _cantadakiObjeSayisi;
                //other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.2f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.2f));
                other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f);
                //other.gameObject.transform.DOLocalJump(_yerlesmeNoktalari[sira].localPosition, 1, 1, 0.5f);
                other.gameObject.transform.DOLocalRotate(new Vector3(90, 90, 0), 0.5f);
                _cantadakiStuffSayisi++;
                _cantadakiObjeSayisi++;

                MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
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

                        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
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

                        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
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

    public void CanSimidiTopla()
    {

        _canSimidi.SetActive(true);

        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

    }



    public void StuffCek(Transform malKabulNoktasi)
    {
        if (_cantadakiStuffObjeleri.Count > 0)
        {
            int sira = _cantadakiStuffObjeleri.Count - 1;
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.parent = null;
            //_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOJump(malKabulNoktasi.position, 3, 1, 0.5f);
            _cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            //Destroy(_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject, 1f);
            _cantadakiStuffObjeleri.RemoveAt(_cantadakiStuffObjeleri.Count - 1);
            _cantadakiStuffSayisi--;
            _cantadakiObjeSayisi--;

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    public void StuffSemsiyeCek(Transform malKabulNoktasi)
    {
        if (_cantadakiStuffSemsiyeObjeleri.Count > 0)
        {
            int sira = _cantadakiStuffSemsiyeObjeleri.Count - 1;
            _cantadakiStuffSemsiyeObjeleri[_cantadakiStuffSemsiyeObjeleri.Count - 1].gameObject.transform.parent = null;
            //_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiStuffSemsiyeObjeleri[_cantadakiStuffSemsiyeObjeleri.Count - 1].gameObject.transform.DOJump(malKabulNoktasi.position, 3, 1, 0.5f);
            _cantadakiStuffSemsiyeObjeleri[_cantadakiStuffSemsiyeObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            //Destroy(_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject, 1f);
            _cantadakiStuffSemsiyeObjeleri.RemoveAt(_cantadakiStuffSemsiyeObjeleri.Count - 1);
            _cantadakiStuffSayisi--;
            _cantadakiObjeSayisi--;

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    public void StuffPaletCek(Transform malKabulNoktasi)
    {
        if (_cantadakiStuffPaletObjeleri.Count > 0)
        {
            int sira = _cantadakiStuffPaletObjeleri.Count - 1;
            _cantadakiStuffPaletObjeleri[_cantadakiStuffPaletObjeleri.Count - 1].gameObject.transform.parent = null;
            //_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiStuffPaletObjeleri[_cantadakiStuffPaletObjeleri.Count - 1].gameObject.transform.DOJump(malKabulNoktasi.position, 3, 1, 0.5f);
            _cantadakiStuffPaletObjeleri[_cantadakiStuffPaletObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            //Destroy(_cantadakiStuffObjeleri[_cantadakiStuffObjeleri.Count - 1].gameObject, 1f);
            _cantadakiStuffPaletObjeleri.RemoveAt(_cantadakiStuffPaletObjeleri.Count - 1);
            _cantadakiStuffSayisi--;
            _cantadakiObjeSayisi--;

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
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

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
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

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    public void CanSimidiCek()
    {
        _canSimidi.SetActive(false);

        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
    }


    public void CopKutusunaAt(Transform malKabulNoktasi)
    {
        StuffCek(malKabulNoktasi);
        StuffSemsiyeCek(malKabulNoktasi);
        StuffPaletCek(malKabulNoktasi);

        IceCreamCek();
        DrinkCek();
        CanSimidiCek();

        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
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

        if (_cantadakiIceCreamObjeleri.Count > 0)
        {
            _iceCreamTepsi.SetActive(true);

        }
        else
        {
            _iceCreamTepsi.SetActive(false);

        }

        if (_cantadakiDrinkObjeleri.Count > 0)
        {
            _drinkTepsi.SetActive(true);

        }
        else
        {
            _drinkTepsi.SetActive(false);

        }

        if (_cantadakiObjeler.Count == 0)
        {
            if (_cantadakiIceCreamObjeleri.Count > 0 || _cantadakiDrinkObjeleri.Count > 0)
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

        int cantadakidrinkobjesayi = _cantadakiDrinkObjeleri.Count;
        for (int i = 0; i < cantadakidrinkobjesayi; i++)
        {
            _cantadakiDrinkObjeleri[0].gameObject.SetActive(false);
            _cantadakiDrinkObjeleri.RemoveAt(0);

        }

        int cantadakiicecreamobjesayi = _cantadakiIceCreamObjeleri.Count;
        for (int i = 0; i < cantadakiicecreamobjesayi; i++)
        {
            _cantadakiIceCreamObjeleri[0].gameObject.SetActive(false);
            _cantadakiIceCreamObjeleri.RemoveAt(0);

        }


        _cantadakiObjeSayisi = 0;
    }
}
