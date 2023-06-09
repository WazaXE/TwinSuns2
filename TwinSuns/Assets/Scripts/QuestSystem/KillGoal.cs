using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{

    public int EnemyID { get; set; }

    public KillGoal(Quest quest, int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.EnemyID = enemyID;
        this.Description = description;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Initialize()
    {
        base.Initialize();
        AIDamageable.OnEnemyDeath += EnemyDied;
    }

    private void OnDestroy()
    {
        AIDamageable.OnEnemyDeath -= EnemyDied;
    }

    private void EnemyDied(int enemy)
    {
        if (enemy == this.EnemyID)
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
