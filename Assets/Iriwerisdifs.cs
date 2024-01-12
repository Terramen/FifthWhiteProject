using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iriwerisdifs : MonoBehaviour
{
    private void Awake() {
        StartCoroutine(HrertJrwersdf());
    }
    IEnumerator HrertJrwersdf()
    {
        yield return new WaitForSeconds(0.9f);

        gameObject.SetActive(false);
    }
}
