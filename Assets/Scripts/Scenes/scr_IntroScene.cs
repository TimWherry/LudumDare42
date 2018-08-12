using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_IntroScene : MonoBehaviour
{
    private bool m_IsNameScreen = true;
    private float m_NameScreenTimer = 0.75f;
    private bool m_IsTitleScreen = false;
    private float m_TitleScreenTimer = 1.25f;
    private bool m_IsBackgroundInfo = false;

    [SerializeField]
    private GameObject m_NameText;
    [SerializeField]
    private GameObject m_GameText;
    [SerializeField]
    private GameObject m_BackgroundInfo;
    [SerializeField]
    private GameObject m_InstructionText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsNameScreen)
        {
            m_NameScreenTimer -= Time.deltaTime;
            if(m_NameScreenTimer < 0.0f)
            {
                m_NameText.SetActive(false);
                m_IsNameScreen = false;
                m_IsTitleScreen = true;
                m_GameText.SetActive(true);
            }
        }
        else if(m_IsTitleScreen)
        {
            m_TitleScreenTimer -= Time.deltaTime;
            if(m_TitleScreenTimer < 0.0f)
            {
                m_GameText.SetActive(false);
                m_IsTitleScreen = false;
                m_IsBackgroundInfo = true;
                m_BackgroundInfo.SetActive(true);
            }
        }
        else if(m_IsBackgroundInfo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_IsBackgroundInfo = false;
                m_BackgroundInfo.SetActive(false);
                m_InstructionText.SetActive(true);
            }
        }
        else if(!m_IsNameScreen && !m_IsTitleScreen && !m_IsBackgroundInfo)
        {
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
