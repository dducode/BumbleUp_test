using System;
using System.Collections;
using UnityEngine;

namespace BumbleUp.Extensions {

    public static class CanvasExtensions {

        public static void Show (this Canvas canvas) {
            canvas.enabled = true;
        }


        public static void Hide (this Canvas canvas) {
            canvas.enabled = false;
        }


        public static void Show (this Canvas canvas, CanvasGroup group, MonoBehaviour owner, Action onComplete = null) {
            owner.StartCoroutine(ShowCanvas(canvas, group, onComplete));
        }


        public static void Hide (this Canvas canvas, CanvasGroup group, MonoBehaviour owner, Action onComplete = null) {
            owner.StartCoroutine(HideCanvas(canvas, group, onComplete));
        }


        private static IEnumerator ShowCanvas (Behaviour canvas, CanvasGroup group, Action onComplete) {
            canvas.enabled = true;
            group.alpha = 0;

            while (group.alpha < 1) {
                group.alpha += Time.deltaTime * 10;
                yield return new WaitForEndOfFrame();
            }
            
            onComplete?.Invoke();
        }


        private static IEnumerator HideCanvas (Behaviour canvas, CanvasGroup group, Action onComplete) {
            while (group.alpha > 0) {
                group.alpha -= Time.deltaTime * 10;
                yield return new WaitForEndOfFrame();
            }

            canvas.enabled = false;
            onComplete?.Invoke();
        }

    }

}