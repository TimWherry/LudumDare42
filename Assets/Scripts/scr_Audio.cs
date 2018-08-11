using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Audio : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_CatSell;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void f_PlayCatSell()
    {
        m_CatSell.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position;
    }
}
