using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ComboText : MonoBehaviour
{
    Vector3 Target;
    [SerializeField] private CanvasGroup canvasg;
    void Start()
    {
        Destroy(gameObject, 3.1f);
        Target = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        canvasg.DOFade(0, 3);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, 1 * Time.deltaTime);
        
    }
}
