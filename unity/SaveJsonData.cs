using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveJsonData
{
	private static SaveJsonData saveJsonData = new SaveJsonData();
	public CharacterClass characterClass;
	SaveJsonData() {
        characterClass = new CharacterClass();
        characterClass.Cap = new IdexData();
        characterClass.Eyebrows = new IdexData();
        characterClass.Eyes = new IdexData();
        characterClass.Feet = new IdexData();
        characterClass.Full_Torso = new IdexData();
        characterClass.Glasses = new IdexData();
        characterClass.Hair = new IdexData();
        characterClass.Hands = new IdexData();
        characterClass.Legs = new IdexData();
        characterClass.Skin = new IdexData();
        characterClass.Torso = new IdexData();
        characterClass.Torso_Prop = new IdexData();
        characterClass.faceData = new FaceData();
    }

	public static SaveJsonData GetSaveJsonData()
	{
		return saveJsonData;
	}
    public CharacterClass GetCharacter()
    {
        return characterClass;
    }


    [SerializeField]
    public void ChanceCharacterJson(string itemName, string MeshIndex, string MatIndex, string RGBA)
    {
        if (itemName == "CAP")
        {
            characterClass.Cap.MeshIndex = MeshIndex;
            characterClass.Cap.MatIndex = MatIndex;
            characterClass.Cap.RGBA = RGBA;
        }

        if (itemName == "EYE")
        {
            characterClass.Eyes.MeshIndex = MeshIndex;
            characterClass.Eyes.MatIndex = MatIndex;
            characterClass.Eyes.RGBA = RGBA;
        }
        if (itemName == "FEE")
        {
            characterClass.Feet.MeshIndex = MeshIndex;
            characterClass.Feet.MatIndex = MatIndex;
            characterClass.Feet.RGBA = RGBA;
        }
        if (itemName == "FTOR")
        {
            characterClass.Full_Torso.MeshIndex = MeshIndex;
            characterClass.Full_Torso.MatIndex = MatIndex;
            characterClass.Full_Torso.RGBA = RGBA;
        }

        if (itemName == "Glasses")
        {
            characterClass.Glasses.MeshIndex = MeshIndex;
            characterClass.Glasses.MatIndex = MatIndex;
            characterClass.Glasses.RGBA = RGBA;
        }

        if (itemName == "Eyebrows")
        {
            characterClass.Eyebrows.MeshIndex = MeshIndex;
            characterClass.Eyebrows.MatIndex = MatIndex;
            characterClass.Eyebrows.RGBA = RGBA;
        }

        if (itemName == "HAI")
        {
            characterClass.Hair.MeshIndex = MeshIndex;
            characterClass.Hair.MatIndex = MatIndex;
            characterClass.Hair.RGBA = RGBA;
        }
        if (itemName == "HAN")
        {
            characterClass.Hands.MeshIndex = MeshIndex;
            characterClass.Hands.MatIndex = MatIndex;
            characterClass.Hands.RGBA = RGBA;
        }
        if (itemName == "TOR")
        {
            characterClass.Hands.MeshIndex = MeshIndex;
            characterClass.Hands.MatIndex = MatIndex;
            characterClass.Hands.RGBA = RGBA;
        }
        if (itemName == "LEG")
        {
            characterClass.Legs.MeshIndex = MeshIndex;
            characterClass.Legs.MatIndex = MatIndex;
            characterClass.Legs.RGBA = RGBA;
        }
        if (itemName == "SKIN")
        {
            characterClass.Skin.MeshIndex = MeshIndex;
            characterClass.Skin.MatIndex = MatIndex;
            characterClass.Skin.RGBA = RGBA;
        }
        if (itemName == "TOR")
        {
            characterClass.Torso.MeshIndex = MeshIndex;
            characterClass.Torso.MatIndex = MatIndex;
            characterClass.Torso.RGBA = RGBA;
        }
        if (itemName == "TORP")
        {
            characterClass.Torso_Prop.MeshIndex = MeshIndex;
            characterClass.Torso_Prop.MatIndex = MatIndex;
            characterClass.Torso_Prop.RGBA = RGBA;
        }
    }

    [SerializeField]
    public void ChangeFaceValue(string faceValue,int ind)
	{
        characterClass.faceData.A[ind] = faceValue;
    }

    
}
    