using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{

    private CharacterClass characterClass;
    private void Awake()
    {
        SaveJsonData saveJsonData = SaveJsonData.GetSaveJsonData();
        characterClass = saveJsonData.GetCharacter();
    }
    public void JsonShow()
    {
        string json = JsonUtility.ToJson(characterClass);
        print(json);
    }

}
