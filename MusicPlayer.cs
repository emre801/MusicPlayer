using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTouch.AVFoundation;
using MonoTouch.Foundation;
using MonoTouch.AudioToolbox;

namespace BlankGame
{
		public class MusicPlayer
		{
			
		Dictionary<string, AVAudioPlayer> sounds = new Dictionary<string, AVAudioPlayer>();
			ArrayList songs = new ArrayList();
			Random r;
			AVAudioPlayer audioPlayer=null;

				public MusicPlayer()
				{
					this.r = new Random();
				}
				public void addNewSound(String name)
				{
					var mediafile=NSUrl.FromFilename(@"Content/"+ name+".wav");
					sounds.Add(name,AVAudioPlayer.FromUrl(mediafile));
				}
				public void playSound(String name)
				{
					AVAudioPlayer sound = sounds[name];
					sound.Play();
				}

				public void playMusic()
				{
					if(audioPlayer==null || !audioPlayer.Playing)
					{	
						int index = r.Next() % songs.Count;
						this.audioPlayer = (AVAudioPlayer)songs [index];	
						audioPlayer.Play();
					}
				}
				
				public void pauseUnpauseMusic()
				{
					if(audioPlayer == null)
						return;

					if(audioPlayer.Playing)
						audioPlayer.Pause();
					else
						audioPlayer.Play();
				}

				public void addNewSong(String name)
				{
					var mediafile=NSUrl.FromFilename(@"Content/Music/"+ name+".mp3");
					songs.Add(AVAudioPlayer.FromUrl(mediafile));
				}


		}
}

