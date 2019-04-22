using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelRandomization : MonoBehaviour
{
    public GameObject[] firstSection;
    public GameObject[] secondSection;
    public GameObject[] thridSection;
    public GameObject[] fourSection;
    public GameObject[] fifthSection;

    public GameObject[][] arrayOfSection;

    void Start() {
        arrayOfSection = new GameObject[][] { firstSection, secondSection, thridSection, fourSection, fifthSection };

        foreach (GameObject[] section in arrayOfSection) {
            Randomize(section);
        }
    }

    void Randomize(GameObject[] array) {
        int index = Random.Range(0, array.Length);
        GameObject obj = array[index];
        obj.SetActive(true);
    }
}
