using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this all exist within the namespace
namespace MJ
{
    public class Behaviour : MonoBehaviour
    {
       /// <summary>
       /// Gets a random colour from all possible colour with an alpha of 1
       /// </summary>
       /// <returns>A random colour</returns>
        public Color GetRandomColour()
        {
            return new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
        }

        /// <summary>
        /// Scales our gameo bject to 0
        /// </summary>
        /// <param name="_go">The game object we want to scale</param>
        public void ScaleToZero(GameObject _go)
        {
            _go.transform.localScale = Vector3.zero;
        }

        /// <summary>
        /// Gets a random float between two number
        /// </summary>
        /// <param name="_min">The min</param>
        /// <param name="_max">The max</param>
        /// <returns></returns>
        public float GetRandomFloat(float _min, float _max)
        {
            return UnityEngine.Random.Range(_min, _max);
        }

        /// <summary>
        /// Gets a random int between two number
        /// </summary>
        /// <param name="_min">The min</param>
        /// <param name="_max">The max</param>
        /// <returns></returns>
        public int GetRandomInt(int _min, int _max)
        {
            return UnityEngine.Random.Range(_min, _max);
        }

        #region Coroutine Helpers

        /// <summary>
        /// Executes the Action block as a Coroutine on the next frame.
        /// </summary>
        /// <param name="func">The Action block</param>
        protected void ExecuteNextFrame(Action func)
        {
            StartCoroutine(ExecuteAfterFramesCoroutine(1, func));
        }
        /// <summary>
        /// Executes the Action block as a Coroutine after X frames.
        /// </summary>
        /// <param name="func">The Action block</param>
        protected void ExecuteAfterFrames(int frames, Action func)
        {
            StartCoroutine(ExecuteAfterFramesCoroutine(frames, func));
        }
        private IEnumerator ExecuteAfterFramesCoroutine(int frames, Action func)
        {
            for (int f = 0; f < frames; f++)
                yield return new WaitForEndOfFrame();
            func();
        }
        /// <summary>
        /// Executes the Action block as a Coroutine after X seconds
        /// </summary>
        /// <param name="seconds">Seconds.</param>
        protected void ExecuteAfterSeconds(float seconds, Action func)
        {
            if (seconds <= 0f)
                func();
            else
                StartCoroutine(ExecuteAfterSecondsCoroutine(seconds, func));
        }
        private IEnumerator ExecuteAfterSecondsCoroutine(float seconds, Action func)
        {
            yield return new WaitForSeconds(seconds);
            func();
        }
        /// <summary>
        /// Executes the Action block as a Coroutine whern a condition is met
        /// </summary>
        /// <param name="condition">The Condition block</param>
        /// <param name="func">The Action block</param>
        protected void ExecuteWhenTrue(Func<bool> condition, Action func)
        {
            StartCoroutine(ExecuteWhenTrueCoroutine(condition, func));
        }
        private IEnumerator ExecuteWhenTrueCoroutine(Func<bool> condition, Action func)
        {
            while (condition() == false)
                yield return new WaitForEndOfFrame();
            func();
        }

        #endregion
    }
}
