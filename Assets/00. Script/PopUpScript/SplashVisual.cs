using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class SplashVisual : MonoBehaviour
{
    [SerializeField] private RectTransform _backgroundImg;
    [SerializeField] private RectTransform[] characterFolder;
    [SerializeField] private Image _logoImg;
    [SerializeField] private RectTransform _bigLogoText;
    [SerializeField] private RectTransform _smallLogoText;
    [SerializeField] private TMP_Text _touchText;
    [SerializeField] private Button LoginPanel;
    private void Awake()
    {
        //SoundManager.Instance.PlayBGM("SplashBGM");
        StartCoroutine(SplashStart());
    }

    IEnumerator SplashStart()
    {
        _backgroundImg.DOAnchorPosY(0f, 1f); //background Img Slide
        _logoImg.DOFade(1f, 1f); //logo Fade In
        yield return YieldInstructionCache.WaitForSeconds(1f);

        //Character Appear
        characterFolder[0].DOAnchorPosY(0f, 0.5f);
        yield return YieldInstructionCache.WaitForSeconds(0.4f);
        characterFolder[1].DOAnchorPosY(0f, 0.5f);
        yield return YieldInstructionCache.WaitForSeconds(0.4f);
        characterFolder[2].DOAnchorPosY(0f, 0.5f);
        yield return YieldInstructionCache.WaitForSeconds(0.4f);

        //logoText Appear
        _bigLogoText.gameObject.SetActive(true);
        _bigLogoText.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
        yield return YieldInstructionCache.WaitForSeconds(0.4f);
        _smallLogoText.gameObject.SetActive(true);
        _smallLogoText.DOScale(new Vector3(3f, 3f, 3f), 0.5f);
        _touchText.DOFade(1f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        LoginPanel.onClick.AddListener(() => PlayfabManager.Instance.Login());
    }
}
