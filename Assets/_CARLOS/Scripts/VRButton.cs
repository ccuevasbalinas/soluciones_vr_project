using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;

    public GameObject button;

    private bool _isPressed;

    public UnityEvent OnPress;
    public UnityEvent OnRelease;

    private void Awake()
    {
        _isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
        if(!_isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.04f, 0);
            OnPress.Invoke();
        }
    }

    private void OnEnable()
    {
        button.transform.localPosition = new Vector3(0, 0.05f, 0);
        _isPressed = false;
    }
}
