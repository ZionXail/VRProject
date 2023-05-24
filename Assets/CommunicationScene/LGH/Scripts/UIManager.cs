using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject guiScreen;
    public GameObject memberScreen;

    public Button registerFormButton;
    public Button loginFormButton;
    public Button memberFormButton;

    public GameObject memberForm;
    public GameObject registerForm;
    public GameObject loginForm;

    public Button login_registerFormButton;
    public Button register_loginFormButton;

    public Button registerButton;
    public Button loginButton;

    public InputField registerIDIF;
    public InputField registerPwIF;
    public InputField registerPwCIF;
    public InputField registerNnIF;

    public InputField loginIDIF;
    public InputField loginPwIF;

    public Text nickname;

    public Button logoutButton;

    public Button gameStartButton;

    public Text registerIDText;
    public Text registerPwText;
    public Text registerPwCText;
    public Text registerNnText;

    public Text loginIDText;
    public Text loginPwText;

    public Text serverConnectText;
    public Button offlineButton;

    [System.Obsolete]
    void Start()
    {
        registerFormButton.onClick.AddListener(OnRegisterFormButtonAct);
        loginFormButton.onClick.AddListener(OnLoginFormButtonAct);
        memberFormButton.onClick.AddListener(OnMemberFormButtonAct);
        login_registerFormButton.onClick.AddListener(OnRegisterFormButtonAct);
        register_loginFormButton.onClick.AddListener(OnLoginFormButtonAct);

        registerButton.onClick.AddListener(OnRegisterButtonClicked);
        loginButton.onClick.AddListener(OnLoginButtonClicked);

        logoutButton.onClick.AddListener(OnLogoutButtonClicked);

        gameStartButton.onClick.AddListener(OnGameStartButtonAct);

        offlineButton.onClick.AddListener(OnGameStartButtonAct);
    }

    void OnRegisterFormButtonAct()
    {
        memberFormButton.gameObject.SetActive(true);
        memberForm.SetActive(false);
        registerForm.SetActive(true);
        loginForm.SetActive(false);
    }

    void OnLoginFormButtonAct()
    {
        memberFormButton.gameObject.SetActive(true);
        memberForm.SetActive(false);
        registerForm.SetActive(false);
        loginForm.SetActive(true);
    }

    void OnMemberFormButtonAct()
    {
        memberFormButton.gameObject.SetActive(false);
        memberForm.SetActive(true);
        registerForm.SetActive(false);
        loginForm.SetActive(false);
    }

    void OnGameStartButtonAct()
    {
        SceneManager.LoadScene("Hospital/Scenes/ShowCase 1");
    }

    /**
     * SM 으로 연동 하는 부분     
     */

    [System.Obsolete]
    void OnRegisterButtonClicked()
    {
        string id = registerIDIF.text;
        string pw = registerPwIF.text;
        string pwC = registerPwCIF.text;
        string nn = registerNnIF.text;

        GameManager.GM.SM.RegisterAct(id, pw, pwC, nn);
    }

    [System.Obsolete]
    void OnLoginButtonClicked()
    {
        string id = loginIDIF.text;
        string pw = loginPwIF.text;

        GameManager.GM.SM.LoginAct(id, pw);
    }

    [System.Obsolete]
    void OnLogoutButtonClicked()
    {
        GameManager.GM.SM.LogoutAct();
    }

    /**
     * SM 에게 연동 되는 부분     
     */

    public void ServerConnection(string sCT, bool network)
    {
        bool isOpen;
        isOpen = network;
        serverConnectText.text = sCT;
        
        if (isOpen == true)
        {
            // offlineButton.gameObject.SetActive(false);
        }
        else if (isOpen == false)
        {
            // offlineButton.gameObject.SetActive(true);
        }
    }

    public void RegisterSuccess()
    {
        OnLoginFormButtonAct();
    }

    public void LoginSuccess()
    {
        guiScreen.SetActive(false);
        memberScreen.SetActive(true);
    }

    public void MemberNickname(string nn)
    {
        nickname.text = nn;
    }

    public void LogoutSuccess()
    {
        guiScreen.SetActive(true);
        memberScreen.SetActive(false);

        loginIDIF.text = null;
        loginPwIF.text = null;
    }

    public void RegisterIDText(string rIT)
    {
        registerIDText.text = rIT;
    }

    public void RegisterPwText(string rPT)
    {
        registerPwText.text = rPT;
    }

    public void RegisterPwCText(string rPCT)
    {
        registerPwCText.text = rPCT;
    }
    public void RegisterNnText(string rNT)
    {
        registerNnText.text = rNT;
    }

    public void LoginIDText(string lIT)
    {
        loginIDText.text = lIT;
    }

    public void LoginPwText(string lPT)
    {
        loginPwText.text = lPT;
    }

    public void RegisterTextNull()
    {
        registerIDText.text = "";
        registerPwText.text = "";
        registerNnText.text = "";
    }

    public void RegisterConfirmTextNull()
    {
        registerPwCText.text = "";
    }

    public void LoginTextNull()
    {
        loginIDText.text = "";
        loginPwText.text = "";
    }
}