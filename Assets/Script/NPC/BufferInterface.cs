/// <summary>
/// Buffer interface.cs
/// 
/// Title: Hack & Slash RPG - A Unity3D Game Engine Tutorial | BurgZerg Arcade. [Online].;
/// Author: Laliberte P. 
/// Date: 2013 October 24. 
/// Available from: http://www.burgzergarcade.com/hack-slash-rpg-unity3d-game-engine-tutorial
/// </summary>
public interface BufferInterface : SpellInerface{
	int buffVal{get;set;}
	float buffTimer{get;set;}
	float buffTimerRemaining{get;}


}