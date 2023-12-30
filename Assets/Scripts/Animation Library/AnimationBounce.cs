using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
public class AnimationBounce : MonoBehaviour
{
    public Transform bounceObject;
    [SerializeField] private float bounceAmount;
    [SerializeField] private float bounceDuration;

    void Start()
    {
        //Bounce(bounceObject);
      
    }

    #region By using DG tween Library ..
    //void Bounce(Transform obj)
    //{
    //    if (obj != null)
    //    {

    //        #region  heartBeat Animation...
    //        //obj.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f)
    //        //     .SetEase(Ease.OutQuad)
    //        //     .SetLoops(-1, LoopType.Yoyo)
    //        //     .SetDelay(Random.Range(0f, 1f));

    //        #endregion
    //        Vector3 originalPosition = obj.position;

    //        obj.DOMoveY(originalPosition.y + bounceAmount, bounceDuration)
    //            .SetEase(Ease.InBounce)

    //            .SetLoops(-1, LoopType.Yoyo)
    //            .SetDelay(Random.Range(0f, 1f));
    //    }
    //}

    #endregion

   

}
