using System;
using System.Collections.Generic;
using TowerDefense.Agents.Data;
using Core.Extensions;
using TowerDefense.Nodes;
using UnityEngine;

namespace TowerDefense.Level
{
	/// <summary>
	/// WaveManager - handles wave initialisation and completion
	/// </summary>
	public class WaveManager : MonoBehaviour
	{
		/// <summary>
		/// Current wave being used
		/// </summary>
		protected int m_CurrentIndex;

        public List<AgentConfiguration> agentConfigurations;

        public List<Node> startingNodes;

        public int waveTime;
        public int waveEnemies;

        /// <summary>
        /// Whether the WaveManager starts waves on Awake - defaulted to null since the LevelManager should call this function
        /// </summary>
        public bool startWavesOnAwake;

		/// <summary>
		/// The waves to run in order
		/// </summary>
		[Tooltip("Specify this list in order")]
		public List<Wave> waves = new List<Wave>();

        Wave currentWave;

        public int waveNumber
		{
			get { return m_CurrentIndex; }
		}

        public int totalWaves = 5;

		public float waveProgress
		{
			get
			{
				if (currentWave == null)
				{
					return 0;
				}
				return currentWave.progress;
			}
		}

		/// <summary>
		/// Called when a wave begins
		/// </summary>
		public event Action waveChanged;

		/// <summary>
		/// Called when all waves are finished
		/// </summary>
		public event Action spawningCompleted;

		/// <summary>
		/// Starts the waves
		/// </summary>
		public virtual void StartWaves()
		{
			if (waveNumber <= totalWaves+1)
			{
				InitCurrentWave();
			}
			else
			{
				Debug.LogWarning("[LEVEL] No Waves on wave manager. Calling spawningCompleted");
				SafelyCallSpawningCompleted();
			}
		}

		/// <summary>
		/// Inits the first wave
		/// </summary>
		protected virtual void Awake()
		{
			if (startWavesOnAwake)
			{
				StartWaves();
			}
		}

		/// <summary>
		/// Sets up the next wave
		/// </summary>
		protected virtual void NextWave()
		{
			currentWave.waveCompleted -= NextWave;
			if (waveNumber < totalWaves)
			{
				InitCurrentWave();
			}
			else
			{
				SafelyCallSpawningCompleted();
			}
		}

		/// <summary>
		/// Initialize the current wave
		/// </summary>
		protected virtual void InitCurrentWave()
		{
            TimedWave wave = (TimedWave)waves[0];
            wave.timeToNextWave = waveTime;
            wave.spawnInstructions = new List<SpawnInstruction>();
            AddSpawns(wave.spawnInstructions);
            wave.m_CurrentIndex = 0;

            currentWave = wave;
            wave.Init();
            m_CurrentIndex++;

            if (waveChanged != null)
			{
				waveChanged();
			}
		}

        protected virtual void AddSpawns(List<SpawnInstruction> list)
        {
            for (int i = 0; i < waveEnemies; i++)
            {
                float delay = 3f - i * 0.1f;
                if(delay < 0.3f)
                {
                    delay = 0.3f;
                }
                list.Add(CreateSpawn(delay));
            }
        }

        protected virtual SpawnInstruction CreateSpawn(float delay)
        {
            SpawnInstruction si = new SpawnInstruction();

            si.delayToSpawn = delay;
            si.agentConfiguration = agentConfigurations[(int)UnityEngine.Random.Range(0, agentConfigurations.Count)];
            si.startingNode = startingNodes[(int)UnityEngine.Random.Range(0, startingNodes.Count)];

            return si;
        }

        /// <summary>
        /// Calls spawningCompleted event
        /// </summary>
        protected virtual void SafelyCallSpawningCompleted()
		{
			if (spawningCompleted != null)
			{
				spawningCompleted();
			}
		}
	}
}