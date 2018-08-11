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

    }

    // Update is called once per frame
    void Update()
    {
        float random = Random.Range(0.0f, 1.0f);
        if(random <= 0.01f)
        {
            SpawnKitty();
        }
    }

    private void SpawnKitty()
    {
        int numTraits = Random.Range(1, 3);

        GameObject newKitty = GameObject.Instantiate(m_BaseKitty, transform.position, Quaternion.identity);
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
