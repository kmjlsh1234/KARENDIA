using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter_Manager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int aniNum;
    int randNum;

    private void Awake()
    {
        StartCoroutine(CharacterActivate());
    }
    
    IEnumerator CharacterActivate()
    {
        randNum = Random.Range(0, aniNum);
        yield return YieldInstructionCache.WaitForSeconds(10f);
        anim.SetTrigger(randNum + "_trigger");
        StartCoroutine(CharacterActivate());
    }
}
