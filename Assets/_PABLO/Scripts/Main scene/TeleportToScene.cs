using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToScene : MonoBehaviour
{
    [SerializeField] private string _scene;

    void OnTriggerEnter(Collider other)
    {
        // It is needed to check if the triggerer object is a player in order to be teleported to this scene.
        if (other.CompareTag("Player")) SceneManager.LoadScene(_scene); 
    }
}
