using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;
public class LoginScript : MonoBehaviour
{

    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button loginButton;
    [SerializeField] private TextMeshProUGUI warningMessage;
    // private string urlLogin = "https://api.schematics-its.com/api/escapecard/login";

    private void Start()
    {
        warningMessage.gameObject.SetActive(false);
    }

    // public void CallLogin()
    // {
    //     StartCoroutine(Login());
    // }

    public void Login()
    {
        string username = usernameField.text.Trim().ToLower();
        string password = passwordField.text;

        if (username == "" || password == "")
        {
            warningMessage.text = $"Login Failed!";
            warningMessage.gameObject.SetActive(true);
            Debug.Log("Something was not filled out!");
        }
        else
        {
            SceneManager.LoadScene(1);
        }

        // WWWForm form = new();
        // form.AddField("team_name", usernameField.text);
        // form.AddField("password", passwordField.text);

        // // TL DR, make a new form and use the post method to send info
        // using (UnityWebRequest webRequest = UnityWebRequest.Post(urlLogin, form))
        // {
        //     webRequest.SetRequestHeader("Access-Control-Allow-Origin", "*");
        //     yield return webRequest.SendWebRequest();
        //     if (webRequest.result == UnityWebRequest.Result.Success)
        //     {
        //         string rawResponse = webRequest.downloadHandler.text;
        //         GameAPIDTO.body response = JsonUtility.FromJson<GameAPIDTO.body>(rawResponse);

        //         DBManager.team_name = response.data.team_name;
        //         DBManager.id = response.data.id;
        //         DBManager.discardCardsCount = response.data.discard_card_count;
        //         DBManager.remaining_hours = response.data.remaining_time;
        //         DBManager.remaining_coins = response.data.remaining_coin;
        //         DBManager.scores = response.data.scores;
        //         string[] cards = response.data.owned_card.Split(",");

        //         DBManager.ownedCards = new List<string>();
        //         foreach (string card in cards) {
        //             DBManager.ownedCards.Add(card);
        //         }
        //         DBManager.mapID = response.data.map_id;
        //         DBManager.isTutorial = true;
        //         DBManager.status = response.data.status;

        //         if (DBManager.LoggedIn)
        //         {
        //             SceneManager.LoadScene("Main Menu");
        //         }
        //         webRequest.Dispose();
        //         yield return null;
        //     }
        //     else
        //     {
        //         warningMessage.text = $"Login Failed";
        //         warningMessage.gameObject.SetActive(true);
        //     }
        // }
    }
}
