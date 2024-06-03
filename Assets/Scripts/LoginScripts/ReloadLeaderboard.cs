using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class ReloadLeaderboard : MonoBehaviour
{
    private List<GameObject> rankList = new List<GameObject>();
    public GameObject leaderboardContainer;
    public GameObject rankTemplate;
    public GameObject teamRank;
    private string uri = "https://api.schematics-its.com/api/escapecard/leaderboard";
    public void ClickButton()
    {
        StartCoroutine(LeaderboardRequest());
    }

    IEnumerator LeaderboardRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    string rawResponse = webRequest.downloadHandler.text;
                    GameAPIDTO.bodyLdb response = JsonUtility.FromJson<GameAPIDTO.bodyLdb>(rawResponse);
                    foreach (GameAPIDTO.dataLdb data in response.data)
                    {
                        GameObject gameObject = null;
                        if (leaderboardContainer.transform.Find(data.team_name) == null)
                        {
                            gameObject = Instantiate(rankTemplate, leaderboardContainer.transform);
                            gameObject.name = data.team_name;
                            rankList.Add(gameObject);
                        }
                        else
                            gameObject = leaderboardContainer.transform.Find(data.team_name).gameObject;

                        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = data.team_name;
                        gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = data.scores.ToString();
                        if (DBManager.team_name == data.team_name)
                        {
                            teamRank.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = data.team_name;
                            teamRank.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = data.scores.ToString();
                        }
            }
            if (rankList.Count > 0)
            {
                rankList.Sort(delegate (GameObject a, GameObject b)
                {
                    return (int.Parse(a.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text).CompareTo
                    (int.Parse(b.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text)));
                });
                rankList.Reverse();
            }

            for (int i = 0; i < rankList.Count; i++)
            {
                rankList[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
                rankList[i].transform.SetSiblingIndex(i);
                if (DBManager.team_name == rankList[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text)
                    teamRank.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            }
        break;
            }
    }
    }
}
