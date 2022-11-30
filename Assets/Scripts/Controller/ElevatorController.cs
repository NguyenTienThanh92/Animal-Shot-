using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Transform endPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("cham1");
            DOVirtual.DelayedCall(1f, delegate
            {
                if (Vector3.Distance(transform.position, other.transform.position) <= 0.2f)
                {
                    Debug.Log("cham2");
                    StartCoroutine(MoveUp(other.gameObject));
                }
            });
        }
    }

    private IEnumerator MoveUp(GameObject obj)
    {
        float time = 0;
        var objEndPoint = endPoint.position - new Vector3(0, 0.75f, 0);

        while (time < duration)
        {
            Debug.Log("Coroutine");
            transform.position = Vector3.Lerp(transform.position, endPoint.position, time / duration);
            obj.transform.position = Vector3.Lerp(obj.transform.position, objEndPoint, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = endPoint.position;
        obj.transform.position = objEndPoint;
    }
}
