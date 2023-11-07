using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private string keyPlayer = "Nickname";
    private string keyScore = "Score";
    private string KeyLevelId = "LevelId";
    private string KeyLevelName = "LevelName";

    public void SaveLeader(List<PlayerData> data)
    {
        PlayerData currentPlayer = GetCurrentPlayer();
        for (int i = 0; i < data.Count; i++)
        {
            if ((data[i].score < currentPlayer.score && data[i].levelId <= currentPlayer.levelId) || 
                data[i].levelId < currentPlayer.levelId || (data[i].nickname == "None" && data[i].score == 0))
            {
                PlayerPrefs.SetString(keyPlayer + (i + 1), currentPlayer.nickname);
                PlayerPrefs.SetInt(keyScore + (i + 1), currentPlayer.score);
                PlayerPrefs.SetString(KeyLevelName + (i + 1), currentPlayer.levelName);
                PlayerPrefs.SetInt(KeyLevelId + (i + 1), currentPlayer.levelId);
                break;
            }
        }
    }
    
    public void SavePlayer()
    {
        PlayerPrefs.SetString(keyPlayer, GetCurrentPlayer().nickname);
        PlayerPrefs.SetInt(keyScore, GetCurrentPlayer().score);
    }
    public PlayerData GetCurrentPlayer()
    {
        PlayerData data = new PlayerData() { nickname = _gameManager.nickname, score = _gameManager.score, levelId = _gameManager.hardLevel, levelName = _gameManager.hardLevelName };
        return data;
    }
}
public class PlayerData
{
    public string nickname;
    public int score;
    public int levelId;
    public string levelName;
}
