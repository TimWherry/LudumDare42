using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_KittyMover : MonoBehaviour
{
    [SerializeField]
    private GameObject m_KittyDecoration;
    [SerializeField]
    private GameObject[] m_Traits;

    [SerializeField]
    private GameObject[] m_Decorations;

    private eKittyColors m_Color;

    private eKittyTrait[] m_KittyTraits;

    // Use this for initialization
    void Start()
    {
        f_SetRandomLook();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void f_SetNumberOfTraits(int num)
    {
        m_KittyTraits = new eKittyTrait[num];
    }

    public void f_SetTrait(int index, eKittyTrait trait, GameObject display)
    {
        m_KittyTraits[index] = trait;
        m_Traits[index].transform.GetChild(0).gameObject.SetActive(true);
        display.transform.parent = m_Traits[index].transform;
        display.transform.localPosition = new Vector3(0.0f, 0.0f, -0.01f);
    }

    private void f_SetRandomLook()
    {
        f_SetRandomColor();
        f_SetRandomDecoration();
    }

    private void f_SetRandomColor()
    {
        m_Color = KittyEnums.GetRandomColor();
        GetComponent<SpriteRenderer>().color = KittyEnums.GetColor(m_Color);
    }

    private void f_SetRandomDecoration()
    {
        int index = Random.Range(-1, m_Decorations.Length);
        if (index == -1)
            return;
        GameObject newDeco = GameObject.Instantiate(m_Decorations[index], m_KittyDecoration.transform.position, Quaternion.identity);
        newDeco.transform.parent = m_KittyDecoration.transform;
        newDeco.transform.localPosition = new Vector3(0.0f, 0.0f, -0.001f);
        if (index == 1)
        {
            newDeco.transform.localPosition = new Vector3(0.05f, 0.1f, -0.001f);
        }
    }

    [SerializeField]
    private float m_MaxTimeToWalk = 1.0f;
    private float m_WalkTimer = 0.0f;
    [SerializeField]
    private float m_Speed = 5.0f;
    private Vector2 m_WalkDirection;

    private Rigidbody2D rigidbody;

    // Update is called once per frame
    void Update()
    {
        m_WalkTimer -= Time.deltaTime;
        if(m_WalkTimer <= 0.0f)
        {
            f_RollWalker();
        }
        rigidbody.velocity = m_WalkDirection * m_Speed;
    }

    private void f_RollWalker()
    {
        m_WalkDirection = Random.insideUnitCircle;
        m_WalkDirection.Normalize();
        m_WalkTimer = m_MaxTimeToWalk;
    }
}
