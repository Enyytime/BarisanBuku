using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAPIDTO : MonoBehaviour
{
    [System.Serializable]
    public class body
    {
        public bool success;
        public string message;
        public data data;
    }

    [System.Serializable]
    public class data
    {
        public string id;
        public string team_name;
        public int remaining_coin;
        public int remaining_time;
        public int scores;
        public int map_id;
        public string owned_card;
        public int discard_card_count;
        public int status;
    }

    [System.Serializable]
    public class bodyLdb
    {
        public bool success;
        public string message;
        public dataLdb[] data;
    }

    [System.Serializable]
    public class dataLdb
    {
        public string team_name;
        public int scores;

    }

    public class bodyCountStatus
    {
        public bool success;
        public string message;
        public dataCountStatus data;
    }

    [System.Serializable]
    public class dataCountStatus
    {
        public int win;
        public int lose;
        public int playing;
    }
}
