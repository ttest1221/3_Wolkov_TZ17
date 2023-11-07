using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject[] _positions;
    private GameManager _gameManager;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    private bool onLeft = false;
    private bool onTop = true;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            if(onLeft == true)
                _transform.position = _positions[0].transform.position;
            else
                _transform.position = _positions[2].transform.position;
            onTop = true;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (onLeft == true)
                _transform.position = _positions[1].transform.position;
            else
                _transform.position = _positions[3].transform.position;
            onTop = false;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (onTop == true)
                _transform.position = _positions[2].transform.position;
            else
                _transform.position = _positions[3].transform.position;
            if(onLeft == true)
            {
                onLeft = false;
                _spriteRenderer.flipX = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (onTop == true)
                _transform.position = _positions[0].transform.position;
            else
                _transform.position = _positions[1].transform.position;
            if (onLeft == false)
            {
                onLeft = true;
                _spriteRenderer.flipX = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Gold")
        {
            Destroy(collision.gameObject);
            _gameManager.score += Random.Range(50, 100);
            _gameManager.TextsUpdate();
        }
            
    }
}
