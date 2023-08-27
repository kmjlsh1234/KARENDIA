using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
#if UNITY_ANDROID
using GooglePlayGames;
#elif UNITY_IOS
using UnityEngine.iOS;
using UnityEngine.SocialPlatforms.GameCenter;
#endif
public class PlayfabManager : SingletonBase<PlayfabManager>
{
    [SerializeField] private GameObject RegisterObj;
    public bool loadingComplete;
    private string playfabID;
    private string customId;
    private string displayName;

    public string EntityId { get; private set; }
    public string EntityType { get; private set; }
    protected override void Awake()
    {
        base.Awake();
    }

    void PlayfabLogin(string userId)
    {
        PlayFabSettings.TitleId = "D188E"; //카렌디아 플레이팹으로 설정
        var request = new LoginWithPlayFabRequest { Username = userId, Password = userId };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }
    void OnLoginSuccess(LoginResult result)
    {
        GetUserData(playfabID);
        Debug.Log("LoginSuccess");
        
        EntityId = result.EntityToken.Entity.Id;
        EntityType = result.EntityToken.Entity.Type;

        playfabID = result.PlayFabId;
        Debug.Log("PlayFab ID: " + playfabID);

        StartCoroutine(GotoMain());
        
    }

    IEnumerator GotoMain()
    {
        yield return YieldInstructionCache.WaitForSeconds(2.5f);
        LoadingManager.Instance.LoadingPanelActivate();
        SceneManager.LoadScene(1);
    }

    void OnLoginFailure(PlayFabError error)
    {
        RegisterObj.SetActive(true);
        Debug.Log("Login failed: " + error.GenerateErrorReport());
        LoadingManager.Instance.LoadingPanelActivate();
    }
    void GPGSLogin()
    {
        Social.localUser.Authenticate(
            (bool success) =>
            {
                if (success) {
                    customId = Social.localUser.id; PlayfabLogin(Social.localUser.id); }
                else { Debug.LogError("GPGS Login failed"); }
            });
    }

    void GameCenterLogin()
    {
        Social.localUser.Authenticate(
            (bool success) =>
            {
                if (success) { customId = Social.localUser.id; PlayfabLogin(Social.localUser.id); }
                else { Debug.LogError("GPGS Login failed"); }
            });
    }

    private void GetUserData(string myPlayFabId)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myPlayFabId,
            Keys = null
        },
        result =>
        {
            if (result.Data == null || !result.Data.ContainsKey("UserInfo"))
            {
                Debug.LogWarning("No UserData");
                loadingComplete = true;
            }
            else
            {
                Debug.LogWarning("UserData: " + result.Data["UserInfo"]);
                DataHandler.Instance.userData = JsonUtility.FromJson<UserData>(result.Data["UserInfo"].Value);
                loadingComplete = true;
            }
        },
        error =>
        {
            Debug.LogWarning("Got error retrieving user data:");
            Debug.LogWarning(error.GenerateErrorReport());
        });
    }

    public void SetUserData()
    {
        string stringData = JsonConvert.SerializeObject(DataHandler.Instance.userData, Formatting.Indented);

        // Deserialize the JSON into a dictionary
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("UserInfo", stringData);

        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = data
        },
        result =>
        {
            Debug.Log("Successfully updated user data");
        },
        error =>
        {
            Debug.Log("Got error setting user data");
            Debug.Log(error.GenerateErrorReport());
        });
    }

    public void SetDisplayID(string displayName)
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
            DisplayName = displayName
        },
        success => Debug.Log("Successfully updated user data"),
        failed => Debug.LogWarning("Set Displayname Failed")
        );
    }

    public void Register(string userName)
    {
        displayName = userName;
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
        {
            Username = customId,
            Password = customId,
            Email= userName + "@gmail.com",
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        for(int i=0; i<20; i++)
        {
            MapInfo newMap = new MapInfo();
            newMap.mapName = "스테이지" + (i+1).ToString();
            newMap.isClear = false;
            DataHandler.Instance.userData.mapInfo.Add(newMap);
        }
        SetDisplayID(displayName);
        DataHandler.Instance.userData.userName = displayName;
        DataHandler.Instance.userData.stamina = 100;
        SetUserData();
        PlayfabLogin(customId);
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.Log("Register Failure : " + error);
        LoadingManager.Instance.LoadingPanelActivate();
    }

    public void Login()
    {
        LoadingManager.Instance.LoadingPanelActivate();
#if UNITY_EDITOR
        customId = "custom00";
        PlayfabLogin(customId);
#elif UNITY_ANDROID
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        GPGSLogin();
#elif UNITY_IOS
        GameCenterLogin();
#endif 
    }
}
