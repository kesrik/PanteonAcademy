using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _xSpeed;
    [SerializeField] private float _limitX;

    private Animator _playerAnimator;
    private float _touchXDelta;
    private float _newX;

    private void Awake()
    {
        _playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            _touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else
        {
            _touchXDelta = 0;
        }
        _newX = transform.position.x + _xSpeed * _touchXDelta * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_limitX, _limitX);

        Vector3 newPosition = new Vector3(_newX, transform.position.y, transform.position.z + _runSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    public void StopMoving()
    {
        _runSpeed = 0;
    }

    public void ChangeAnimation(bool hasWon)
    {
        transform.Rotate(transform.rotation.x, 180f, transform.rotation.z, Space.Self);
        
        if (hasWon)
            _playerAnimator.SetBool("Win", true);
        else
            _playerAnimator.SetBool("Lose", true);
    }
}
