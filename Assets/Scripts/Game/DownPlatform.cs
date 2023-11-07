using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Gold")
        {
            Destroy(collision.gameObject);
            _gameManager.lives--;
            if (_gameManager.lives <= 0)
                _gameManager.GameOver();
        }
            
    }
}
