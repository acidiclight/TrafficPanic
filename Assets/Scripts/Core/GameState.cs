using System;
using UnityEngine;

namespace Core
{
    public class GameState
    {
        private CurrentGameState currentState;
        private long currentScore;
        private long highScore;

        public CurrentGameState CurrentState
        {
            get => currentState;
            private set
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

    }
}