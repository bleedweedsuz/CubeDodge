using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
public class PlayservicesManager : MonoBehaviour {

	// Use this for initialization
	public static bool isLoggedIn;
	public static bool started;
	public static PlayservicesManager Instance { get; private set; }

	void Start () {
		if(!started){
			started = true;
		Instance = this;
		startPlayService ();
		//
		//		((PlayGamesLocalUser)Social.localUser).GetStats((rc, stats) =>
		//			{
		//				// -1 means cached stats, 0 is succeess
		//				// see  CommonStatusCodes for all values.
		//				if (rc <= 0 && stats.HasDaysSinceLastPlayed()) {
		//					Debug.Log("It has been " + stats.DaysSinceLastPlayed + " days");
		//				}
		//			});

		// post score 12345 to leaderboard ID "Cfji293fjsie_QA")
		//		Social.ReportScore(ScoreManager.highscore, "Cfji293fjsie_QA", (bool success) => {
		//			// handle success or failure
		//		});
		}

	}
	public void startPlayService(){
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
		signIn ();
	}
	public void signIn(){
		Social.localUser.Authenticate((bool success) => {
			if (success)
			{
				PlayerPrefs.SetInt("signin",1);
				isLoggedIn = true;

			}
			else{
				isLoggedIn = false;
			}

		});
	}
	#region Achievements
	public static void UnlockAchievements(string id){
		Social.ReportProgress (id, 100, success => {
		});



	}
	public static void IncrementAchievements(string id, int stepsToIncrement){
		PlayGamesPlatform.Instance.IncrementAchievement (id, stepsToIncrement, success => {
		});
	}

	public static void showAchievementsUI(){
		Social.ShowAchievementsUI ();
	}
	#endregion /Achievements

	#region LeaderBoards
	public static void addScoreToLeaderBoard(string leaderBoardId, long score){
		Social.ReportScore (score, leaderBoardId, success => {
			if(success){
				//succes to submit score
			}
		});

	}
	public static void addCoinsToLeaderBoard(string leaderBoardId, long coins){
		Social.ReportScore (coins, leaderBoardId, success => {
			if(success){
				//succes to submit score
			}
		});
	}
	public static void addTotalPlayedToLeaderBoard(string leaderBoardId, long totalPlayed){
		Social.ReportScore (totalPlayed, leaderBoardId, success => {
			if(success){
				//succes to submit score
			}
		});
	}
	public static void showLeaderBoardUI(){
		Social.ShowLeaderboardUI ();

	}
	#endregion /LeaderBoards


}
