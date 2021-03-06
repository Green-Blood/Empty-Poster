using System;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Sounds
{
    public class Sounds : MonoBehaviour
    {
        [SerializeField] private AudioSource[] audioSources;
        [SerializeField] private AudioSource impactSound;
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private float endGameFadeDuration = 4f;
        [SerializeField] private MMFeedbacks mmFeedbacks;
        private StateMachine _stateMachine;
        private List<AudioSource> _initialSources;

        public void Init(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _initialSources = new List<AudioSource>();
            foreach (var audio in audioSources)
            {
                _initialSources.Add(audio);
            }

            _stateMachine.OnStateChanged += OnStateChanged;
        }

        private void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Intro:
                    for (var index = 0; index < audioSources.Length; index++)
                    {
                        var audioSource = audioSources[index];
                        if (index == 0)
                        {
                            audioSource.DOFade(0.04f, fadeDuration);
                            audioSource.gameObject.SetActive(true);
                        }
                        else
                        {
                            audioSource.DOFade(0.05f, fadeDuration);
                            audioSource.gameObject.SetActive(false);
                            impactSound.gameObject.SetActive(false);
                        }
                    }

                    audioSources[0].gameObject.SetActive(true);
                    break;
                case GameState.Transition:

                    break;
                case GameState.Chase:
                    audioSources[1].gameObject.SetActive(true);
                    break;
                case GameState.End:
                    impactSound.gameObject.SetActive(true);
                    foreach (var audioSource in audioSources)
                    {
                        audioSource.DOFade(0, fadeDuration);
                    }
                    mmFeedbacks.PlayFeedbacks();


                    break;
                case GameState.Finish:

                    foreach (var audioSource in audioSources)
                    {
                        audioSource.DOFade(0, endGameFadeDuration);
                    }
                    audioSources[2].gameObject.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public void PlaySirens()
        {
            audioSources[1].gameObject.SetActive(false);
            audioSources[3].gameObject.SetActive(true);
        }
    }
}