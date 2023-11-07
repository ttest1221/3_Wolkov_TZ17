using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private string keyPlayer = "Nickname";
    private string keyScore = "Score";
    private string KeyLevelId = "LevelId";
    private string KeyLevelName = "LevelName";
    public List<PlayerData> GetLeaders()
    {
        List<PlayerData> list = new List<PlayerData>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new PlayerData()
            {
                nickname = PlayerPrefs.GetString(keyPlayer + (i + 1), "None"),
                score = PlayerPrefs.GetInt(keyScore + (i + 1), 0),
                levelId = PlayerPrefs.GetInt(KeyLevelId + (i + 1), 0),
                levelName = PlayerPrefs.GetString(KeyLevelName + (i + 1), "Легкий"),
            });
        }
        return list;
    }
}
