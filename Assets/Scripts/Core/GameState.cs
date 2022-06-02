using System;
using System.Collections.Generic;
using Traffic;
using UnityEngine;

namespace Core
{
    public class GameState
    {
        private readonly List<Car> carsInLevel = new List<Car>();
        private CurrentGameState currentState;
        private long currentScore;
        private long highScore;

        public CurrentGameState CurrentState
        {
            get => currentState;
            set
            {
                if (this.currentState != value)
                {
                    this.currentState = value;
                    Debug.Log($"Current game state is now {value.ToString()}");
                    CurrentStateChanged?.Invoke(value);
                }
            }
        }

        public long Score => currentScore;
        public long HighScore => highScore;

        public event Action<CurrentGameState> CurrentStateChanged;
        public event Action<long, bool> ScoreUpdated;
        public event Action<long> HighScoreUpdated;

        public GameState()
        {
            this.currentScore = 0;
            this.highScore = 0;
            this.CurrentState = CurrentGameState.MainMenu;
        }
        
        public void AddPoints(long pointsToAdd)
        {
            if (pointsToAdd == 0)
                return;
            
            var isRemovingPoints = pointsToAdd < 0;
            var newScore = currentScore + pointsToAdd;
            var beatHighScore = newScore > highScore;

            this.currentScore = newScore;
            this.ScoreUpdated?.Invoke(this.currentScore, isRemovingPoints);
            
            if (beatHighScore)
            {
                Debug.Log("High score has been beaten");
                highScore = currentScore;
                HighScoreUpdated?.Invoke(this.highScore);
            }

            Debug.Log((isRemovingPoints
                ? "Removing "
                : "Adding ") + $"{pointsToAdd} to the score. Score is now {currentScore}");
        }

        public void ReportNewCar(Car car)
        {
            if (car is null) return;
            if (carsInLevel.Contains(car)) return;
            
            this.carsInLevel.Add(car);
        }

        internal void Update()
        {
            if (this.currentState == CurrentGameState.Playing)
            {
                for (var i = 0; i < carsInLevel.Count; i++)
                {
                    var car = carsInLevel[i];

                    if (car.IsCrashed)
                    {
                        this.CurrentState = CurrentGameState.GameOver;
                        return;
                    }
                }
            }
        }
    }
}