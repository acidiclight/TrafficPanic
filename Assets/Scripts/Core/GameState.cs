using System;
using System.Collections.Generic;
using Traffic;
using UnityEditor.Connect;
using UnityEngine;

namespace Core
{
    public class GameState
    {
        private readonly List<Car> carsInLevel = new List<Car>();
        private readonly List<int> carsToRemove = new List<int>();
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
            for (var i = carsToRemove.Count - 1; i >= 0; i--)
            {
                var car = carsToRemove[i];
                this.carsInLevel.RemoveAt(car);
                this.carsToRemove.RemoveAt(i);
            }
            
            if (this.currentState == CurrentGameState.Playing)
            {
                for (var i = 0; i < carsInLevel.Count; i++)
                {
                    var car = carsInLevel[i];

                    if (car == null)
                    {
                        carsToRemove.Add(i);
                    }
                    
                    if (car.IsCrashed)
                    {
                        this.CurrentState = CurrentGameState.GameOver;
                        return;
                    }
                }
            }
        }

        public void Nuke()
        {
            // Destroy all cars.
            for (var i = carsInLevel.Count - 1; i >= 0; i--)
            {
                var car = carsInLevel[i];

                // Destroy the car if it isn't already destroyed.
                if (car != null)
                    UnityEngine.Object.Destroy(car.gameObject);
                
                carsInLevel.RemoveAt(i);
            }
            
            // Reset the score, but not the high score.
            this.currentScore = 0;
            this.ScoreUpdated?.Invoke(this.currentScore, true);

            // Reset the game state.
            this.currentState = CurrentGameState.MainMenu;
        }
    }
}