using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _playerRenderer;
    private int _widthScreen;
    private int _heightScreen;

    private Vector2 _positionHorizontal;
    private Vector2 _positionVertical;

    public float horizontalMove;
    public float verticalMove;

    private void Start()
    {
        _playerRenderer = gameObject.GetComponent<SpriteRenderer>();


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        _positionHorizontal = new Vector2(horizontalMove, 0) * _speed * Time.deltaTime;
        _positionVertical = new Vector2(0, verticalMove) * _speed * Time.deltaTime;

        PlayerControler();
    }

    private void PlayerControler()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            int middleWidthScreen = Screen.width / 2;

            if (Input.mousePosition.x <= middleWidthScreen)
            {
                transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Time.deltaTime);
                _playerRenderer.flipX = true;
            }
            else if (Input.mousePosition.x > middleWidthScreen)
            {
                transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Time.deltaTime);
                _playerRenderer.flipX = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(_positionVertical);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(_positionHorizontal);
                _playerRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(_positionVertical);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(_positionHorizontal);
                _playerRenderer.flipX = false;
            }
        }
    }
}
