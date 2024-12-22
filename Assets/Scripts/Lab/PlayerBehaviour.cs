using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance;
    private Animator _animator;
    private bool _isExcited = false;
   

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        
        }

        _animator = gameObject.GetComponent<Animator>();
    }


    public void Excited()
    {
        
        if(_animator != null && !_isExcited)
        {
            _animator.SetTrigger("Excited");
            
            Debug.Log("Happy");
            Debug.Log("Animator State: " + _animator.GetCurrentAnimatorStateInfo(0).IsName("Excited"));
          
        }
    }

   


    public void Irritated()
    {
        if(_animator != null)
        {
            _animator.SetTrigger("irritated");
        }
    }
}
