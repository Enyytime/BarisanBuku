using System.Collections.Generic;

public static class DBManager
{
    public static string team_name = "Solo";
    public static string id;
    public static int remaining_coins = 500;
    public static float remaining_hours = 7200;
    public static int discardCardsCount = 0;
    public static int scores = 0;
    public static int mapID = 0; //change this value if you want to change between map :D

    // public static List<string> ownedCards = new List<string>(new string[] { "5", "P", "9", "28", "14", "35" });
    // public static List<string> ownedCards = new List<string>(new string[] { "Y", "31", "52", "38", "25"});
    // public static List<string> ownedCards = new List<string>(new string[] { "G", "66", "21" });
    // public static List<string> ownedCards = new List<string>(new string[] { "H", "20", "24", "32" });
    // public static List<string> ownedCards = new List<string>(new string[] { "34", "47", "154", "68", "69" });
    // public static List<string> ownedCards = new List<string>(new string[] {  "1", "82", "10", "23", "43", "22", "61" });
    // public static List<string> ownedCards = new List<string>(new string[] {  "99","101","76","42","56","62","73" });
    //main is down here
    public static List<string> ownedCards = new List<string>(new string[] { "5", "P", "9", "28", "14", "35" });

    //This one is for tutorial
    // public static List<string> ownedCards = new List<string>(new string[] { "74", "26", "54" });

    public static bool isTutorial = false;
    public static int status;

    public static bool LoggedIn => team_name != null;
    public static void Logout() => team_name = null;
}
