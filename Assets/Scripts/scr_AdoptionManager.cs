using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scr_AdoptionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Traits;
    [SerializeField]
    private GameObject[] m_DisplayTraits;

    private eKittyTrait[] m_KittyTraits;

    [SerializeField]
    private GameObject m_KittySelected;

    [SerializeField]
    private int m_Cash = 0;

    [SerializeField]
    TextMeshPro cashMesh;

    private scr_Audio m_Audio;

    public void f_SetNumberOfTraits(int num)
    {
        m_KittyTraits = new eKittyTrait[num];
    }

    public void f_SetTrait(int index, eKittyTrait trait, GameObject display)
    {
        m_KittyTraits[index] = trait;
        m_Traits[index].gameObject.SetActive(true);
        display.transform.parent = m_Traits[index].transform;
        display.transform.localPosition = new Vector3(0.0f, 0.0f, -0.01f);
    }

    // Use this for initialization
    void Start()
    {
        m_Audio = GameObject.FindObjectOfType<scr_Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scr_LoseCondition.f_DidLose())
        {
            cashMesh.text = "$" + m_Cash;
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D[] colliders = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));

                GameObject selectedKitty = f_FindValidCat(colliders);
                if (selectedKitty != null)
                {
                    f_ClearTraits();
                    m_KittySelected = selectedKitty;
                    f_SelectCat(selectedKitty);
                }

                if (colliders.Length > 0)
                {
                    Collider2D adopterCollider = null;
                    for (int i = 0; i < colliders.Length; ++i)
                    {
                        if (colliders[i].tag.Equals("Adopter"))
                        {
                            adopterCollider = colliders[i];
                        }
                    }
                    if (adopterCollider != null)
                    {
                        if (m_KittySelected != null)
                        {
                            f_AttemptAdoption(adopterCollider.GetComponent<scr_Adopter>());
                        }
                    }
                    else
                    {
                        if (selectedKitty == null)
                        {
                            m_KittySelected = selectedKitty;
                            f_ClearTraits();
                        }
                    }
                }
                else
                {
                    if (selectedKitty == null)
                    {
                        m_KittySelected = selectedKitty;
                        f_ClearTraits();
                    }
                }
            }
        }
    }

    private void f_AttemptAdoption(scr_Adopter script)
    {
        if (script.f_AreTraitsValid(m_KittySelected.GetComponent<scr_KittyMover>().f_GetTraits()))
        {
            m_Cash += 100;
            Destroy(script.gameObject);
            Destroy(m_KittySelected);
            f_ClearTraits();
            m_Audio.f_PlayCatSell();
        }
    }

    private GameObject f_FindValidCat(Collider2D[] colliders)
    {
        GameObject selectedKitty = null;
        for (int i = 0; i < colliders.Length; ++i)
        {
            if (colliders[i].tag.Equals("Kitty"))
            {
                if (selectedKitty == null)
                {
                    selectedKitty = colliders[i].gameObject;
                }
                else
                {
                    if (selectedKitty.transform.position.z < colliders[i].transform.position.z)
                    {
                        selectedKitty = colliders[i].gameObject;
                    }
                }
            }
        }
        return selectedKitty;
    }

    private void f_SelectCat(GameObject selectedKitty)
    {
        scr_KittyMover script = selectedKitty.GetComponent<scr_KittyMover>();
        f_SetNumberOfTraits(script.f_GetNumberOfTraits());
        for (int i = 0; i < m_KittyTraits.Length; ++i)
        {
            f_SetTrait(i, script.f_GetTrait(i), GameObject.Instantiate(m_DisplayTraits[(int)script.f_GetTrait(i)],Vector3.zero,Quaternion.identity));
        }
    }

    private void f_ClearTraits()
    {
        for (int i = 0; i < m_Traits.Length; ++i)
        {
            if (m_Traits[i].transform.GetChildCount() > 0)
            {
                Destroy(m_Traits[i].transform.GetChild(0).gameObject);
            }
            m_Traits[i].gameObject.SetActive(false);
        }
        m_KittyTraits = new eKittyTrait[0];
    }
}
