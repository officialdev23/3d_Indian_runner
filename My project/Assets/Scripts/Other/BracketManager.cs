using UnityEngine;
using UnityEngine.EventSystems;

public class BracketManager : MonoBehaviour
{
	static BracketManager instance;

	public static int LaunchCount
    {
		get => PlayerPrefs.GetInt("LaunchJFCount",0);
		set => PlayerPrefs.SetInt("LaunchJFCount",value);
    }

	public static BracketManager Instance
	{
		get
		{
			if (instance == null)
				instance = GameObject.FindObjectOfType(typeof(BracketManager)) as BracketManager;

			return instance;
		}
	}

	public static bool IsTV()
    {
		var deviceModel = SystemInfo.deviceModel.ToLower();

		if (deviceModel.Contains("aft") || deviceModel.Contains("aeohy")|| Application.isEditor)
			return true;
		else
			return false;
	}

	void Awake()
	{
		Application.targetFrameRate = 60;
		gameObject.name = this.GetType().Name;
		DontDestroyOnLoad(gameObject);
		//	InitializeAds();
	}
	public void SetSelectedGameObject(GameObject go)
    {
		EventSystem.current.SetSelectedGameObject(go);
    }
}
