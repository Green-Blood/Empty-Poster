using System.Collections;
using DG.Tweening;
using Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class EndScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI weekText;
        [SerializeField] private Image gamePanel;

        [SerializeField] private float panelFadeDuration = 1.75f;
        [SerializeField] private float panelFadeValue = 0.8f;
        [SerializeField] private float textFadeDuration = 1.25f;
        [SerializeField] private float textFadeDelay = 0.9f;
        [SerializeField] private float firstDelay = 0.5f;
        private StateMachine _stateMachine;
        private CameraFollower _cameraFollower;

        public void Init(StateMachine stateMachine, CameraFollower cameraFollower)
        {
            _stateMachine = stateMachine;
            _cameraFollower = cameraFollower;
            _stateMachine.OnStateChanged += OnStateChanged;
            ResetValues();
        }

        private void ResetValues()
        {
            gamePanel.DOFade(0f, 0f);
            weekText.DOFade(0f, 0f);
        }

        private void OnStateChanged(GameState gameState)
        {
            if (gameState == GameState.End)
            {
                gamePanel.gameObject.SetActive(true);
                StartCoroutine(StarAnimationsWithDelay());
            }
        }

        private IEnumerator StarAnimationsWithDelay()
        {
            yield return new WaitForSeconds(firstDelay);
            _cameraFollower.GameFinish();
            StartAnimations();
        }

        private void StartAnimations()
        {
            gamePanel.DOFade(panelFadeValue, panelFadeDuration);
            weekText.DOFade(1f, textFadeDuration).SetDelay(textFadeDelay).OnComplete(() =>
            {
                StartCoroutine(RestartGameWithDelay());
            });
        }

        private void StartGameBeginAnimations()
        {
            gamePanel.DOFade(0f, panelFadeDuration);
            weekText.DOFade(0f, textFadeDuration).SetDelay(textFadeDelay).OnComplete(() =>
            {
                gamePanel.gameObject.SetActive(false);
            });
        }

        private IEnumerator RestartGameWithDelay()
        {
            _stateMachine.BeginState();
            yield return new WaitForSeconds(firstDelay);
            StartGameBeginAnimations();
            _cameraFollower.GameStart();
        }
    }
}