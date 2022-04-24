using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class StartScreen : MonoBehaviour
    {
        [Title("Parameters")] [SerializeField] private float titleFadeDuration = 1.5f;
        [SerializeField] private float pressFadeDuration = 1.25f;
        [SerializeField] private float fadeOutDuration = 0.75f;
        [SerializeField] private float pulseDuration = 0.65f;
        [SerializeField] private float pulseScaleValue = 1.1f;

        [Header("References")] [SerializeField]
        private TextMeshProUGUI titleText;

        [SerializeField] private TextMeshProUGUI pressText;
        [SerializeField] private GameObject pressButton;
        [SerializeField] private CameraFollower cameraFollower;
        [SerializeField] private GameObject startPanel;


        private void Awake()
        {
            ResetValues(0);
            FadeOut();
        }

        private void ResetValues(float duration, Action onFadeFinish = null)
        {
            titleText.DOFade(0, duration).OnComplete((() => { onFadeFinish?.Invoke(); }));
            pressText.DOFade(0, duration);
        }

        public void FadeOut()
        {
            titleText.DOFade(1f, titleFadeDuration).OnComplete(() =>
            {
                pressText.DOFade(1f, pressFadeDuration).OnComplete(() =>
                {
                    StartPulsing();
                    pressButton.SetActive(true);
                });
            });
        }

        public void StartPulsing()
        {
            pressText.transform.DOScale(new Vector3(pulseScaleValue, pulseScaleValue, 0), pulseDuration)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void OnPressClicked()
        {
            ResetValues(fadeOutDuration, () =>
            {
                startPanel.gameObject.SetActive(false);
                cameraFollower.GameStart();
            });
        }
    }
}