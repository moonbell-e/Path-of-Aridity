namespace Battle.Controller
{
    public delegate void SendBattleData(BattleData battleData);

    public interface IBattleEvent
    {
        public event SendBattleData BattleEventStarted;
    }
}