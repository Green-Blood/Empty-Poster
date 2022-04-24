using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class FinishScreen : MonoBehaviour
    {
        [SerializeField] private Image gamePanel;
        [SerializeField] private float panelFadeDuration = 1.75f;
        [SerializeField] private float panelFadeValue = 1f;
        [SerializeField] private float firstDelay = 6f;
        [SerializeField] private float restartDelay = 4f;
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
        }

        private void OnStateChanged(GameState gameState)
        {
            if (gameState == GameState.Finish)
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
            gamePanel.DOFade(panelFadeValue, panelFadeDuration).OnComplete(() =>
            {
                StartCoroutine(RestartGameWithDelay());
            });

        }
        private IEnumerator RestartGameWithDelay()
        {
            yield return new WaitForSeconds(restartDelay);
            SceneManager.LoadScene(0);
        }
    }
}