using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LogoutScript : MonoBehaviour
{
    private string url = "https://api.schematics-its.com/api/escapecard/logout";
    // Start is called before the first frame update
    public void CallLogout()
    {
        StartCoroutine(Logout());
    }
    IEnumerator Logout()
    {
        WWWForm form = new();
        url = url + "?id=" + DBManager.id;

        // TL DR, make a new form and use the post method to send info
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            webRequest.SetRequestHeader("Access-Control-Allow-Origin", "*");
            yield return webRequest.SendWebRequest();
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
            }
            else
            {
                DBManager.Logout();
                //Check the state if user is logged in or not
                webRequest.Dispose();
                yield return null;

            }
            if (!DBManager.LoggedIn)
            {
                SceneManager.LoadScene("Login Scene");
            }
        }
    }
}
