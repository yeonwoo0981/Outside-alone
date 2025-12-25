using System;
using UnityEngine;

namespace Member.SYW._01_Scripts.Manager
{
    public class LobbyManager : MonoBehaviour
    {
        private void Start()
        {
            SoundManager.Instance.Play(BGMSoundType.LOBBYBGM, 1f);
        }
    }
}