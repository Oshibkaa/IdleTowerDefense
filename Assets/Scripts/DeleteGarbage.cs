using System.Collections;
using UnityEngine;

public class DeleteGarbage : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private float _timer;

    private void Start()
    {
        StartCoroutine(DleteObject());
    }

    IEnumerator DleteObject()
    {
        yield return new WaitForSeconds(_timer);
        Destroy(gameObject);
    }
}
