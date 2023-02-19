using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TicTacToeGameManager : MonoBehaviour
{
    public static int Xcounter = 0;
    public static int Ocounter = 0;

    [SerializeField] private GameObject xtextObject;
    [SerializeField] private GameObject otextObject;
    public static TextMeshProUGUI Xtext;
    public static TextMeshProUGUI Otext;

    [SerializeField] private string sceneToTeleport;

    private void Start()
    {
        Xtext = xtextObject.GetComponent<TextMeshProUGUI>();
        Otext = otextObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {

        
    }

    public void TeleportToMainscene()
    {
      StartCoroutine(teleportCoroutine());
    }

    IEnumerator teleportCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneToTeleport);
    }
}
