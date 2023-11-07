using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _leadersMenu;
    [SerializeField] private LeaderBoard _leaderBoard;
    [SerializeField] private Text _leadersText;
    private List<string> difficultyNamings = new List<string>() { "Легко", "Средне", "Сложно" };
    private void Awake()
    {
        _leadersMenu.SetActive(false);
        _settingsMenu.SetActive(false);
        _gameManager.HideGame();

        

    }
    public void SelectDifficulty(int level)
    {
        _gameManager.hardLevel = level;
        _gameManager.hardLevelName = difficultyNamings[level];
    }
    public void ShowMain()
    {
        _settingsMenu.SetActive(false);
        _leadersMenu.SetActive(false);
        _mainMenu.SetActive(true);
        _leadersText.text = "Лидеры\n";
    }
    public void ShowSettings()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }
    public void ShowLeaders()
    {
        _mainMenu.SetActive(false);
        _leadersMenu.SetActive(true);

        List<PlayerData> leaders = _leaderBoard.GetLeaders();
        for (int i = 0; i < leaders.Count; i++)
        {
            _leadersText.text += $"{i + 1}. {leaders[i].nickname} {leaders[i].score} {leaders[i].levelName}\n";
        }
    }
    public void NewGameClick()
    {
        _gameManager.ShowGame();
    }
}
