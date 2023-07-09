using System;

namespace CodeBase.Events
{
    public class EventBus
    {
        private EventBus()
        {
        }

        private static EventBus _instance;

        public static EventBus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventBus();

                return _instance;
            }
        }

        //Enemy
        public Action EnemyHealthChanged;
        public Action EnemyDied;

        //Player
        public Action PlayerHealthChanged;
    }
}