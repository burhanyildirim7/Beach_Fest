using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance; // Singleton yapisi icin gerekli ornek

    public GameObject TapToStartPanel, GamePanel, _upgradePanel;
    public Text gamePlayScoreText, tapToStartScoreText;

    [Header("UPGRADE EKRANI")]
    [Header("Player")]
    [SerializeField] private Text _playerSpeedPriceText;
    [SerializeField] private Slider _playerSpeedSlider;
    [SerializeField] private Button _playerSpeedButton;
    [SerializeField] private Text _playerCapacityPriceText;
    [SerializeField] private Slider _playerCapacitySlider;
    [SerializeField] private Button _playerCapacityButton;

    private bool _upgradeScreenAcik;

    // singleton yapisi burada kuruluyor.
    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
    }

    private void Start()
    {
        StartUI();

        _upgradeScreenAcik = false;
    }

    // Oyun ilk acildiginda calisacak olan ui fonksiyonu. 
    public void StartUI()
    {
        ActivateTapToStartScreen();
    }

    private void FixedUpdate()
    {
        if (_upgradeScreenAcik)
        {
            UpgradeScreenOpen();
        }
        else
        {

        }
    }

    /// <summary>
    /// Level numarasini ui kisminda degistirmek icin fonksiyon. Parametre olarak level numarasi aliyor.
    /// </summary>
    /// <param name="levelNo">UI ekranina yazilmak istenen Level numaras?</param>


    // TAPTOSTART TUSUNA BASILDISINDA  --- GIRIS EKRANINDA VE LEVEL BASLARINDA
    public void TapToStartButtonClick()
    {

        GameController.instance.isContinue = true;
        //PlayerController.instance.SetArmForGaming();
        TapToStartPanel.SetActive(false);
        GamePanel.SetActive(true);
        //SetLevelText(LevelController.instance.totalLevelNo);
        SetGamePlayScoreText();

    }

    // RESTART TUSUNA BASILDISINDA  --- LOOSE EKRANINDA
    public void RestartButtonClick()
    {
        GamePanel.SetActive(false);
        //LoosePanel.SetActive(false);
        TapToStartPanel.SetActive(true);
        LevelController.instance.RestartLevelEvents();
        SetTapToStartScoreText();
    }


    // NEXT LEVEL TUSUNA BASILDIGINDA... WIN EKRANINDAKI BUTON
    public void NextLevelButtonClick()
    {
        SetTapToStartScoreText();
        TapToStartPanel.SetActive(true);
        //WinPanel.SetActive(false);
        GamePanel.SetActive(false);
        LevelController.instance.NextLevelEvents();
        //StartCoroutine(StartScreenCoinEffect());
    }


    /// <summary>
    /// Bu fonksiyon gameplay ekranindaki score textini gunceller.
    /// </summary>
    public void SetGamePlayScoreText()
    {
        gamePlayScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }


    /// <summary>
    /// Bu fonksiyon totalScore un yazilmasi gereken textleri gunceller.
    /// </summary>
    public void SetTapToStartScoreText()
    {
        tapToStartScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }

    /// <summary>
    /// Bu fonksiyon winscreen de ge?erli level scoreunun yazildigi texti gunceller.
    /// </summary>
    public void WinScreenScore()
    {
        //winScreenScoreText.text = GameController.instance.score.ToString();
    }

    /// <summary>
    /// Bu fonksiyon totalElmas sayilarinin yazildigi textleri gunceller.
    /// </summary>
    public void SetTotalElmasText()
    {
        //totalElmasText.text = PlayerPrefs.GetInt("totalElmas").ToString();
    }

    /// <summary>
    /// Bu fonksiyon winscreen ekranini acar.
    /// </summary>
    public void ActivateWinScreen()
    {
        GamePanel.SetActive(false);
        //StartCoroutine(WinScreenDelay());
    }

    /// <summary>
    /// Bu fonksiyon loose secreeni acar. 
    /// </summary>
    public void ActivateLooseScreen()
    {
        GamePanel.SetActive(false);
        //LoosePanel.SetActive(true);
    }


    /// <summary>
    /// Bu fonksiyon gamescreeni acar.
    /// </summary>
    public void ActivateGameScreen()
    {
        GamePanel.SetActive(true);
        TapToStartPanel.SetActive(false);
        SetGamePlayScoreText();
    }

    /// <summary>
    /// Bu fonksiyon taptostartscreen i acar.
    /// </summary>
    public void ActivateTapToStartScreen()
    {
        TapToStartPanel.SetActive(true);
        //WinPanel.SetActive(false);
        //LoosePanel.SetActive(false);
        GamePanel.SetActive(false);
        tapToStartScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }

    public void UpgradeCanvasAc()
    {
        //GamePanel.SetActive(false);
        _upgradePanel.SetActive(true);
        _upgradeScreenAcik = true;
    }

    public void UpgradeCanvasKapat()
    {
        _upgradePanel.SetActive(false);
        _upgradeScreenAcik = false;
        //GamePanel.SetActive(true);

    }


    //------------------UPGRADE EKRANI----------------------------------------------------

    private void UpgradeScreenOpen()
    {

        //-------PLAYER SPEED--------

        if (PlayerPrefs.GetInt("PlayerSpeedLevel") == 0)
        {
            _playerSpeedPriceText.text = "$1000";
            _playerSpeedSlider.value = 1;

            if (PlayerPrefs.GetInt("Money") < 1000)
            {
                _playerSpeedButton.interactable = false;
            }
            else
            {
                _playerSpeedButton.interactable = true;
            }
        }
        else if (PlayerPrefs.GetInt("PlayerSpeedLevel") == 1)
        {
            _playerSpeedPriceText.text = "$2000";
            _playerSpeedSlider.value = 2;

            if (PlayerPrefs.GetInt("Money") < 2000)
            {
                _playerSpeedButton.interactable = false;
            }
            else
            {
                _playerSpeedButton.interactable = true;
            }
        }
        else if (PlayerPrefs.GetInt("PlayerSpeedLevel") == 2)
        {
            _playerSpeedPriceText.text = "MAX LEVEL";
            _playerSpeedSlider.value = 3;


            _playerSpeedButton.interactable = false;

        }
        else
        {

        }

        //-------PLAYER CAPACITY--------

        if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 0)
        {
            _playerCapacityPriceText.text = "$1000";
            _playerCapacitySlider.value = 1;

            if (PlayerPrefs.GetInt("Money") < 1000)
            {
                _playerCapacityButton.interactable = false;
            }
            else
            {
                _playerCapacityButton.interactable = true;
            }
        }
        else if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 1)
        {
            _playerCapacityPriceText.text = "$2000";
            _playerCapacitySlider.value = 2;

            if (PlayerPrefs.GetInt("Money") < 2000)
            {
                _playerCapacityButton.interactable = false;
            }
            else
            {
                _playerCapacityButton.interactable = true;
            }
        }
        else if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 2)
        {
            _playerCapacityPriceText.text = "MAX LEVEL";
            _playerCapacitySlider.value = 3;


            _playerCapacityButton.interactable = false;

        }
        else
        {

        }
    }

    public void PlayerSpeedButton()
    {
        if (PlayerPrefs.GetInt("PlayerSpeedLevel") == 0)
        {

            if (PlayerPrefs.GetInt("Money") < 1000)
            {
                _playerSpeedButton.interactable = false;
            }
            else
            {
                _playerSpeedButton.interactable = true;
                PlayerPrefs.SetInt("PlayerSpeedLevel", 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>().PlayerSpeedGuncelle();
            }
        }
        else if (PlayerPrefs.GetInt("PlayerSpeedLevel") == 1)
        {


            if (PlayerPrefs.GetInt("Money") < 2000)
            {
                _playerSpeedButton.interactable = false;
            }
            else
            {
                _playerSpeedButton.interactable = true;
                PlayerPrefs.SetInt("PlayerSpeedLevel", 2);
                GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>().PlayerSpeedGuncelle();
            }
        }
        else
        {

        }
    }


    public void PlayerCapacityButton()
    {
        if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 0)
        {

            if (PlayerPrefs.GetInt("Money") < 1000)
            {
                _playerCapacityButton.interactable = false;
            }
            else
            {
                _playerCapacityButton.interactable = true;
                PlayerPrefs.SetInt("PlayerCapacityLevel", 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<SirtCantasiScript>().PlayerCapacityGuncelle();
            }
        }
        else if (PlayerPrefs.GetInt("PlayerCapacityLevel") == 1)
        {


            if (PlayerPrefs.GetInt("Money") < 2000)
            {
                _playerCapacityButton.interactable = false;
            }
            else
            {
                _playerCapacityButton.interactable = true;
                PlayerPrefs.SetInt("PlayerCapacityLevel", 2);
                GameObject.FindGameObjectWithTag("Player").GetComponent<SirtCantasiScript>().PlayerCapacityGuncelle();
            }
        }
        else
        {

        }
    }

}
