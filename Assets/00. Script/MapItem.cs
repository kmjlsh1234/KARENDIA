using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapItem : MonoBehaviour
{
    public int num;
    // Start is called before the first frame update
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(MoveScene()));
    }

    IEnumerator MoveScene()
    {
        SoundManager.Instance.PlaySound("Half_Dragon_Play_Btn_Click");
        yield return YieldInstructionCache.WaitForSeconds(2f);
        SceneManager.LoadScene("DragonMain");
    }
}
