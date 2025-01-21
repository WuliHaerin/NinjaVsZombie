using UnityEngine;
using System.Collections;

public class UnsufficentCoinsMenu : MonoBehaviour
{

	public GameObject PlayerSelectionMenu, UnsufficentMenu,PlayerGroup;//for inapp,unsufficent menu screens
	void Start()
	{

	}
	void Update()
	{

	}


	//for button control
	public void OnButtonClick(string ButtonName)
	{
		switch (ButtonName)
		{
			//for ok button
			case "Ok":
				AdManager.ShowVideoAd("192if3b93qo6991ed0",
			(bol) => {
				if (bol)
				{
					TotalCoins.Static.AddCoins(500);
					TotalCoins.Static.UpdateCoins();
					UnsufficentMenu.SetActive(false);//for unsufficent menu disables
					PlayerSelectionMenu.SetActive(true);
					PlayerGroup.SetActive(true);
					SoundController.Static.PlayClickSound();//for click sound
					MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.playerSelectionMenu;//for moving inapp menu state

					AdManager.clickid = "";
					AdManager.getClickid();
					AdManager.apiSend("game_addiction", AdManager.clickid);
					AdManager.apiSend("lt_roi", AdManager.clickid);


				}
				else
				{
					StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
				}
			},
			(it, str) => {
				Debug.LogError("Error->" + str);
				//AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
			});
				break;
			case "NO":
				UnsufficentMenu.SetActive(false);//for unsufficent menu disables
				PlayerSelectionMenu.SetActive(true);
				PlayerGroup.SetActive(true);
				SoundController.Static.PlayClickSound();//for click sound
				MainMenuScreens.currentScreen = MainMenuScreens.MenuScreens.playerSelectionMenu;//for moving inapp menu state
				break;
		}
	}
}
