using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Adopter : MonoBehaviour
{
    [SerializeField]
    private GameObject m_NoseHolder;
    [SerializeField]
    private GameObject m_MouthHolder;
    [SerializeField]
    private GameObject m_HairHolder;


    [SerializeField]
    private GameObject[] m_Mouths;
    [SerializeField]
    private GameObject[] m_Noses;
    [SerializeField]
    private GameObject[] m_Hairs;


    [SerializeField]
    private GameObject[] m_Traits;

    private eKittyTrait[] m_KittyTraits;

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

    public bool f_AreTraitsValid(eKittyTrait[] traits)
    {
        bool firstValid = false;
        bool secondValid = false;
        for (int i = 0; i < traits.Length; ++i)
        {
            for(int j = 0; j < m_KittyTraits.Length; ++j)
            {
                if(m_KittyTraits[j].Equals(traits[i]))
                {
                    if(!firstValid)
                    {
                        firstValid = true;
                    }
                    else
                    {
                        secondValid = true;
                    }
                }
            }
        }

        if(traits.Length == 1 || m_KittyTraits.Length == 1)
        {
            return firstValid;
        }
        return firstValid && secondValid;
    }

    // Use this for initialization
    void Start()
    {
        RandomizeAdopter();
    }

    private void RandomizeAdopter()
    {
        RandomizeMouth();
        RandomizeNose();
        RandomizeHair();
    }

    private void RandomizeMouth()
    {
        GameObject newMouth = GameObject.Instantiate(m_Mouths[Random.Range(0, m_Mouths.Length)], Vector3.zero, Quaternion.identity);
        newMouth.transform.parent = m_MouthHolder.transform;
        newMouth.transform.localPosition = Vector3.zero;
    }

    private void RandomizeNose()
    {
        GameObject newNose = GameObject.Instantiate(m_Noses[Random.Range(0, m_Noses.Length)], Vector3.zero, Quaternion.identity);
        newNose.transform.parent = m_NoseHolder.transform;
        newNose.transform.localPosition = Vector3.zero;
    }

    private void RandomizeHair()
    {
        GameObject newHair = GameObject.Instantiate(m_Hairs[Random.Range(0, m_Hairs.Length)], Vector3.zero, Quaternion.identity);
        newHair.transform.parent = m_HairHolder.transform;
        newHair.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
