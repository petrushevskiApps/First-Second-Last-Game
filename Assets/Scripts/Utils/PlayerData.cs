using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    private const bool DEFAULT_STATE = true;
    private const float DEFAULT_SLIDER = 0.5f;
    private const float DEFAULT_VOLUME = 1f;

    private const string SETTINGS_GENDER_KEY = "GenderSettings";
    private const string SETTINGS_VFX_KEY = "vfxKey";
    private const string SETTINGS_BFADER_KEY = "bfaderKey";
    private const string SETTINGS_DFADER_KEY = "dfaderKey";
    private const string SETTINGS_BACKGROUND_KEY = "backgroundKey";
    private const string SETTINGS_VQUESTIONS_KEY = "vquestionsKey";

    private const string SETTINGS_BGMUSIC_KEY = "bgMusicVolumeKey";
    private const string SETTINGS_SFX_KEY = "sfxVolumeKey";

    private const string SETTINGS_AQUESTIONS_STATE_KEY = "audioStateKey";
    private const string SETTINGS_AQUESTIONS_KEY = "aQuestionVolumeKey";

    private const string SETTINGS_HELP_STATE = "helpModeKey";
    private const string SETTINGS_SPEED_MODE_KEY = "speedModeKey";
    

    private void Awake()
    {
        base.Awake();
    }

    #region BasicSettings
    public void SaveGender(int gender)
    {
        PlayerPrefs.SetInt(SETTINGS_GENDER_KEY, gender);
    }
    public int GetGender()
    {
        if (PlayerPrefs.HasKey(SETTINGS_GENDER_KEY))
        {
            return PlayerPrefs.GetInt(SETTINGS_GENDER_KEY) == 1 ? 1 : 2;
        }
        return 1;
    }
    #endregion

    #region GraphicsSettings
    public void SaveVFX(bool isOn)
    {
        PlayerPrefs.SetInt(SETTINGS_VFX_KEY, isOn ? 1 : 0);
    }
    public bool GetVFX()
    {
        if (PlayerPrefs.HasKey(SETTINGS_VFX_KEY))
        {
            return PlayerPrefs.GetInt(SETTINGS_VFX_KEY) == 1 ? true : false;
        }
        return DEFAULT_STATE;
    }

    public void SaveBackgroundFader(float value)
    {
        PlayerPrefs.SetFloat(SETTINGS_BFADER_KEY, value);
    }
    public float GetBackgroundFader()
    {
        if (PlayerPrefs.HasKey(SETTINGS_BFADER_KEY))
        {
            return PlayerPrefs.GetFloat(SETTINGS_BFADER_KEY);
        }
        return DEFAULT_SLIDER;
    }

    public void SaveDecorationFader(float value)
    {
        PlayerPrefs.SetFloat(SETTINGS_DFADER_KEY, value);
    }
    public float GetDecorationFader()
    {
        if (PlayerPrefs.HasKey(SETTINGS_DFADER_KEY))
        {
            return PlayerPrefs.GetFloat(SETTINGS_DFADER_KEY);
        }
        return DEFAULT_SLIDER;
    }

    public void SaveTextQuestionsState(bool isOn)
    {
        PlayerPrefs.SetInt(SETTINGS_VQUESTIONS_KEY, isOn ? 1 : 0);
    }
    public bool GetVisualQuestions()
    {
        if (PlayerPrefs.HasKey(SETTINGS_VQUESTIONS_KEY))
        {
            return PlayerPrefs.GetInt(SETTINGS_VQUESTIONS_KEY) == 1 ? true : false;
        }
        return DEFAULT_STATE;
    }

    public void SaveBackground(bool isOn)
    {
        PlayerPrefs.SetInt(SETTINGS_BACKGROUND_KEY, isOn ? 1 : 0);
    }
    public bool GetBackground()
    {
        if (PlayerPrefs.HasKey(SETTINGS_BACKGROUND_KEY))
        {
            return PlayerPrefs.GetInt(SETTINGS_BACKGROUND_KEY) == 1 ? true : false;
        }
        return DEFAULT_STATE;
    }
    #endregion

    #region AudioSettings
    public void SaveBgMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(SETTINGS_BGMUSIC_KEY, value);
    }
    public float GetBgMusicVolume()
    {
        if (PlayerPrefs.HasKey(SETTINGS_BGMUSIC_KEY))
        {
            return PlayerPrefs.GetFloat(SETTINGS_BGMUSIC_KEY);
        }
        return DEFAULT_VOLUME;
    }

    public void SaveAudioQuestionsVolume(float value)
    {
        PlayerPrefs.SetFloat(SETTINGS_AQUESTIONS_KEY, value);
    }
    public float GetAudioQuestionsVolume()
    {
        if (PlayerPrefs.HasKey(SETTINGS_AQUESTIONS_KEY))
        {
            return PlayerPrefs.GetFloat(SETTINGS_AQUESTIONS_KEY);
        }
        return DEFAULT_VOLUME;
    }

    public void SaveSFXVolume(float value)
    {
        PlayerPrefs.SetFloat(SETTINGS_SFX_KEY, value);
    }
    public float GetSFXVolume()
    {
        if (PlayerPrefs.HasKey(SETTINGS_SFX_KEY))
        {
            return PlayerPrefs.GetFloat(SETTINGS_SFX_KEY);
        }
        return DEFAULT_VOLUME;
    }


    #endregion

    #region Gameplay Settings
    public void SaveAudioQuestionsState(bool state)
    {
        PlayerPrefs.SetInt(SETTINGS_AQUESTIONS_STATE_KEY, state ? 1 : 0);
    }
    public bool GetAudioQuestionsState()
    {
        if (PlayerPrefs.HasKey(SETTINGS_AQUESTIONS_STATE_KEY))
        {
            return PlayerPrefs.GetInt(SETTINGS_AQUESTIONS_STATE_KEY) == 1 ? true : false;
        }
        return DEFAULT_STATE;
    }

    public void SaveHelpModeState(bool state)
    {
        PlayerPrefs.SetInt(SETTINGS_HELP_STATE, state ? 1 : 0);
    }
    public bool GetHelpModeState()
    {
        if (PlayerPrefs.HasKey(SETTINGS_HELP_STATE))
        {
            return PlayerPrefs.GetInt(SETTINGS_HELP_STATE) == 1 ? true : false;
        }
        return DEFAULT_STATE;
    }

    public void SaveSpeedMode(int value)
    {
        PlayerPrefs.SetInt(SETTINGS_SPEED_MODE_KEY, value);
    }
    public int GetSpeedMode()
    {
        if (PlayerPrefs.HasKey(SETTINGS_SPEED_MODE_KEY))
        {
            int value = PlayerPrefs.GetInt(SETTINGS_SPEED_MODE_KEY);
            return value >= 0 && value < 3 ? value : 0;
        }
        return 0;
    }
    #endregion
}
