using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    private General _general;
    private MasterInput _masterInput;
    private PlayerController _player;

    private void Awake()
    {
        _masterInput = new();
        _masterInput.Player.Return.performed += _ => ReturnToPrevious();
        _masterInput.UI.Return.performed += _ => ReturnToPrevious();
    }

    private void Start()
    {
        _general = GameObject.FindGameObjectWithTag("General").GetComponent<General>();
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>() != null)
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        else
        {
            _player = null;
        }
    }

    private void OnEnable()
    {
        _masterInput.Enable();
        // ToDo: consider another scenes like Game End and High Scores.
        if (SceneManager.GetActiveScene().name != "Level")
        {
            _masterInput.UI.Enable();
            _masterInput.Player.Disable();
        }
        else
        {
            _masterInput.UI.Disable();
            _masterInput.Player.Enable();
        }
    }

    private void OnDisable()
    {
        _masterInput.Disable();
    }

    private void Update()
    {
        if (Mathf.Abs(_masterInput.Player.Move.ReadValue<float>()) > 0.05f)
        {
            PlayerMove(_masterInput.Player.Move.ReadValue<float>());
        }
        else
        {
            PlayerMove(0);
        }
    }

    private void PlayerMove(float move)
    {
        _player.Move(move);
    }

    private void ReturnToPrevious()
    {
        if (_masterInput.Player.enabled)
        {
            _masterInput.UI.Enable();
            _masterInput.Player.Disable();
            _general.PauseGame();
        }
        else if (_masterInput.UI.enabled)
        {
            _masterInput.UI.Disable();
            _masterInput.Player.Enable();
            _general.BackToGame();
        }
    }

    // ToDo: maybe we need an option to switch between reload options.
    public void ReloadInput()
    {
        _masterInput.UI.Disable();
        _masterInput.Player.Enable();
    }
}
