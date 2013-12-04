using UnityEngine;
using System.Collections;
/// <summary>
/// Day night.
/// this is attached to the directional light to make it rotate between the daylight and the night
/// 
/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
/// Author: Laliberte P. 
/// Date: 2013 October 24. 
/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
/// </summary>
public class DayNight : MonoBehaviour {
	
	public enum TimeOfDay{
		start,
		sunrise,
		sunset
	}

	public Transform Sun;
	public float dayCycle = 1, dayCycleInHours;
	
	public float sunrise,sunset,Modskybox;
	
	private const float seconds = 1;
	private const float minute = 60 * seconds;
	private const float hour = 60 * minute;
	private const float day = 24 * hour;
	
	
	private float _rotationOfSun, dps = 360/day;
	private float _rotate,_timeOfDay;
	
	private TimeOfDay _time;
	
	// Use this for initialization
	void Start () {
		_time = TimeOfDay.start;
		dayCycleInHours = dayCycle*minute*48;
		
		RenderSettings.skybox.SetFloat("_Blend",0);
		_timeOfDay = 0;
		_rotationOfSun = dps *day/(dayCycleInHours*-1);
		
		sunrise*= dayCycleInHours;
		sunset*= dayCycleInHours;
	}
	
	// Update is called once per frame
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		Sun.Rotate(new Vector3(_rotationOfSun,0,0) *Time.deltaTime);
		_timeOfDay += Time.deltaTime;
		if(_timeOfDay > dayCycleInHours){
			_timeOfDay -= dayCycleInHours;
			
		}
		
		if(_timeOfDay>sunrise && _timeOfDay<sunset && RenderSettings.skybox.GetFloat("_Blend")<1){
			_time = DayNight.TimeOfDay.sunrise;
			SkyBox();
		}else if(_timeOfDay>sunset
			&& RenderSettings.skybox.GetFloat("_Blend")>0){
			
			_time = DayNight.TimeOfDay.sunset;
			SkyBox();
		}else{
			_time = DayNight.TimeOfDay.start;
		}
		
		
	}
	private void SkyBox(){
		float time=0;
		
		switch(_time){
		case TimeOfDay.sunrise:
			time = (_timeOfDay-sunrise) / dayCycleInHours*Modskybox;
			break;
		case TimeOfDay.sunset:
			
			time = (_timeOfDay-sunset) / dayCycleInHours*Modskybox;
			time = 1-time;
			break;
		}
		RenderSettings.skybox.SetFloat("_Blend",time);
	}
}