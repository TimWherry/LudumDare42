using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_LoseCondition : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private static bool m_DidLose = false;

    public static bool f_DidLose()
    {
        return m_DidLose;
    }

    private float m_CheckTimer = 0.25f;

    [SerializeField]
    private TextMeshPro m_LoseText;

    // Update is called once per frame
    void Update()
    {
        if (!scr_LoseCondition.f_DidLose())
        {
            m_CheckTimer -= Time.deltaTime;
            if (m_CheckTimer < 0.0f)
            {
                m_CheckTimer = 0.25f;
                GameObject[] allKitties = GameObject.FindGameObjectsWithTag("Kitty");
                if (allKitties.Length >= 60)
                {
                    m_DidLose = true;
                }
            }
        }
        else
        {
            m_LoseText.text = "You Lost\nTry Again?";
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(1);
                m_LoseText.text = "";
                m_DidLose = false;
            }
        }
    }
}
