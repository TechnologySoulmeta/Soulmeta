using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MTakePhoto : MonoBehaviour
{
    public int FileCounter = 0;
    [SerializeField] private Camera Cam;
    [SerializeField] private MeshRenderer background;
    [SerializeField] private Material[] allBackground;
    [SerializeField] private AnimationClip blinkAnimationClip;
    [SerializeField] private GameObject _head;


    [SerializeField] private GameObject LoadingReference;
    [SerializeField] private Sprite finishIcon;
    [SerializeField] private Sprite loadingIcon;
    [SerializeField] private Animator animatorReference;

    [SerializeField] private Transform characterReference;
    [SerializeField] private Transform baseReference;

    private string recordAnimationName;

    public void CamCapture(string tokeID, TextMeshProUGUI message, GameObject a, GameObject b, String recordName)
    {
        recordAnimationName = recordName;
        int randomBackgroundIndex = UnityEngine.Random.Range(0, allBackground.Length);
        if(allBackground.Length != 0)
        {
            background.material = allBackground[randomBackgroundIndex];
        }

        Animation animationRef = _head.GetComponent<Animation>();
        animationRef.Stop();
        animationRef.Play(blinkAnimationClip.name);
        characterReference.localEulerAngles = new Vector3(0f, 138.629f, 0f);
        baseReference.localEulerAngles = new Vector3(0f, -41.567f, 0f);

        StartCoroutine(TakeNFTPhoto(tokeID, message, a, b));

    }


    public class tempJson
    {
        public string img_data;
        public string token_id;
        public tempJson(string data, string id)
        {
            img_data = data;
            token_id = id;
        }
    }


    IEnumerator TakeNFTPhoto(string tokeID, TextMeshProUGUI message, GameObject a, GameObject b)
    {

        yield return new WaitForSeconds(0.15f);

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);

        //File.WriteAllBytes(Application.dataPath + "/Avatar/" + FileCounter + ".png", Bytes);
        Debug.Log(Application.dataPath);
        FileCounter++;

        tempJson _data = new tempJson(Convert.ToBase64String(Bytes), tokeID);
        Debug.Log(String.Join("", Bytes));

        byte[] postData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(_data));

        //File.WriteAllBytes(Application.dataPath + "/Avatar/" + FileCounter + "123.txt", postData);

        UnityWebRequest request = new UnityWebRequest("/api/3dnft/upload_img", "POST");
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string result = request.downloadHandler.text;
            message.text = "Your 3D NFT has been minted!";
            LoadingReference.GetComponent<Animator>().enabled = false;
            LoadingReference.GetComponent<Image>().sprite = finishIcon;
            LoadingReference.GetComponent<RectTransform>().localEulerAngles = Vector3.zero;
            yield return new WaitForSeconds(1);
            a.SetActive(false);
            b.SetActive(false);
            LoadingReference.GetComponent<Animator>().enabled = true;
            LoadingReference.GetComponent<Image>().sprite = loadingIcon;
            Debug.Log(result);
        }
        else
        {
            Debug.Log(request.error);
            Debug.Log(request.downloadHandler.text);
        }
        animatorReference.SetTrigger(recordAnimationName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            CamCapture2();
    }

    public void CamCapture2()
    {
        int randomBackgroundIndex = UnityEngine.Random.Range(0, allBackground.Length);
        if(allBackground.Length != 0)
        {
            background.material = allBackground[randomBackgroundIndex];
        }

        Animation animationRef = _head.GetComponent<Animation>();
        animationRef.Stop();
        animationRef.Play(blinkAnimationClip.name);
        characterReference.localEulerAngles = new Vector3(0f, 138.629f, 0f);
        baseReference.localEulerAngles = new Vector3(0f, -41.567f, 0f);

        StartCoroutine(TakeNFTPhoto2());

    }

    IEnumerator TakeNFTPhoto2()
    {

        yield return new WaitForSeconds(0.15f);

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);
        SaveJsonData saveJsonData = SaveJsonData.GetSaveJsonData();
        //File.WriteAllBytes(Application.dataPath + "/Avatar/" + FileCounter + ".png", Bytes);
        Debug.Log(saveJsonData.GetCharacter().ToString());

        File.WriteAllText(Application.dataPath + "/Avatar/" + "0.json", JsonUtility.ToJson(saveJsonData.GetCharacter()));

    }

}
