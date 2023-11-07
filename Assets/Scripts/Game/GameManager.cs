using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _nicknameText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _gamePrototype;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _texts;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private GameObject _nicknamePanel;
    [SerializeField] private InputField _nicknameInput;
    [SerializeField] private SaveManager _saveManager;
    [SerializeField] private LeaderBoard _leaderBoard;
    private Spawner _spawner;

    public string nickname;
    public int score;
    public int hardLevel = 0;
    public string hardLevelName = "Легко";
    public int lives = 3;

    private GameObject game;
    private void Start()
    {
        _gameOverPanel.SetActive(false);
    }
    public void DifficultyChange(int id, string name)
    {
        hardLevel = id;
        hardLevelName = name;
        
    }
    public void AcceptNicknameClick()
    {
        nickname = _nicknameInput.text;
        _gameScreen.SetActive(true);
        _texts.SetActive(true);
        _menuScreen.SetActive(false);
        game = Instantiate(_gamePrototype, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        _spawner = FindAnyObjectByType<Spawner>();
        float difficulty = hardLevel + 1;
        _spawner.timeBetweenSpawn = 3.5f / difficulty;
        TextsUpdate();
        _nicknamePanel.SetActive(false);
    }
    public void Restart()
    {
        _gameOverPanel.SetActive(false);
        game = Instantiate(_gamePrototype, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        float difficulty = hardLevel + 1;
        _spawner = FindAnyObjectByType<Spawner>();
        _spawner.timeBetweenSpawn = 3.5f / difficulty;
    }
    public void TextsUpdate()
    {
        _scoreText.text = "Очки:" + score.ToString();
        _nicknameText.text = nickname.ToString();
    }
    public void ShowGame()
    {
        _nicknamePanel.SetActive(true);
        _gameScreen.SetActive(true);
        _menuScreen.SetActive(false);
    }
    public void HideGame()
    {
        _gameScreen.SetActive(false);
        _gameOverPanel.SetActive(false);
        _menuScreen.SetActive(true);
    }
    public void GameOver()
    {
        _saveManager.SaveLeader(_leaderBoard.GetLeaders());
        lives = 3;
        score = 0;
        _spawner = null;
        Destroy(game);
        _gameOverPanel.SetActive(true);
    }
    
}
