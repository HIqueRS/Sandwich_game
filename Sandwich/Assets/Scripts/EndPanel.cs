using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ScoreText;


    private void OnEnable()
    {
        GameManager.EndGame += TurnOnChild;
    }
    private void OnDisable()
    {
        GameManager.EndGame -= TurnOnChild;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TurnOnChild()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }


    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
