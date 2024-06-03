using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SaveData : MonoBehaviour
{
    private string urlSave = "https://api.schematics-its.com/api/escapecard/savedata?id=" + DBManager.id;

    void Start()
    {
        if(DBManager.status == 0)
            StartCoroutine(PostData());
    }

    IEnumerator PostData()
    {
        while(DBManager.status == 0)
        {
            WWWForm form = new();
            form.AddField("team_name", DBManager.team_name);
            form.AddField("remaining_coin", DBManager.remaining_coins);
            form.AddField("remaining_time", (int)DBManager.remaining_hours);
            form.AddField("discard_card_count", DBManager.discardCardsCount);
            form.AddField("scores", DBManager.scores);
            form.AddField("map_id", DBManager.mapID);

            string ownedCards = "";

            for(int i = 0; i < DBManager.ownedCards.Count; i++)
            {
                ownedCards += DBManager.ownedCards[i];
                if (i < DBManager.ownedCards.Count - 1)
                    ownedCards += ",";
            }
            form.AddField("owned_card", ownedCards);

            using (UnityWebRequest webRequest = UnityWebRequest.Post(urlSave, form))
            {
                webRequest.method = "PATCH";
                webRequest.SetRequestHeader("Access-Control-Allow-Origin", "*");
                yield return webRequest.SendWebRequest();
                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    // Debug.Log("Error saving data");
                }
                else
                {
                    webRequest.Dispose();
                    yield return new WaitForSeconds(2);
                }
            }
        }
    }
}
