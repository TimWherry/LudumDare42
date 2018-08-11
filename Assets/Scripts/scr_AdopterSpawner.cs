using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AdopterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_BaseAdopter;

    [SerializeField]
    private GameObject[] m_KittyTraitImages;

    [SerializeField]
    private GameObject[] m_Adopters = new GameObject[6];

    [SerializeField]
    private float xStep = 5.0f;
    [SerializeField]
    private float yStep = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!scr_LoseCondition.f_DidLose())
        {
            float random = Random.Range(0.0f, 1.0f);
            if (random <= 0.01f)
            {
                AttemptToSpawnAdopter();
            }
        }
    }

    private void AttemptToSpawnAdopter()
    {
        int x = 0;
        int y = 0;
        for(int i = 0; i < m_Adopters.Length; ++i)
        {
            if(m_Adopters[i] == null)
            {
                m_Adopters[i] = SpawnAdopter(x, y);
                break;
            }
            x++;
            if(x > 1)
            {
                y++;
                x = 0;
            }
        }
    }

    private GameObject SpawnAdopter(int x, int y)
    {
        int numTraits = Random.Range(1, 3);
        GameObject newAdopter = GameObject.Instantiate(m_BaseAdopter, new Vector3(transform.position.x + x * xStep, transform.position.y + y * -yStep, 0.0f), Quaternion.identity);

        scr_Adopter script = newAdopter.GetComponent<scr_Adopter>();
        script.f_SetNumberOfTraits(numTraits);
        eKittyTrait firstTrait = eKittyTrait.None;
        for (int i = 0; i < numTraits; ++i)
        {
            firstTrait = KittyEnums.GetRandomTrait(firstTrait);
            if (firstTrait != eKittyTrait.None && firstTrait != eKittyTrait.Max)
            {
                script.f_SetTrait(i, firstTrait, GameObject.Instantiate(m_KittyTraitImages[(int)firstTrait], Vector3.zero, Quaternion.identity));
            }
        }
        return newAdopter;
    }
}
