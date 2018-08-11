using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_KittySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_BaseKitty;

    [SerializeField]
    private GameObject[] m_KittyTraitImages;

    // Use this for initialization
    void Start()
    {
        SpawnKitty();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scr_LoseCondition.f_DidLose())
        {
            float random = Random.Range(0.0f, 1.0f);
            if (random <= 0.015f)
            {
                SpawnKitty();
            }
        }
    }

    private void SpawnKitty()
    {
        int numTraits = Random.Range(1, 3);

        GameObject[] kitties = GameObject.FindGameObjectsWithTag("Kitty");
        Vector3 position = Vector3.zero;
        if(kitties.Length > 0)
        {
            position = kitties[Random.Range(0, kitties.Length)].transform.position;
        }

        GameObject newKitty = GameObject.Instantiate(m_BaseKitty, position, Quaternion.identity);
        scr_KittyMover script = newKitty.GetComponent<scr_KittyMover>();
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
    }
}
