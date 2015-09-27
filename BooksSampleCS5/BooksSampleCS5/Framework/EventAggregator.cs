using System;

namespace BooksSample.Framework
{
    public class EventAggregator<TEvent>
         where TEvent : EventArgs
    {
        private static EventAggregator<TEvent> s_eventAggregator;

        // TODO: 04 - expression bodied member: property
        public static EventAggregator<TEvent> Instance
        {
            get
            {
                return s_eventAggregator ?? (s_eventAggregator = new EventAggregator<TEvent>());
            }
        }

        private EventAggregator()
        {
        }

        public event Action<object, TEvent> Event;

        // TODO: 08 - null conditional operator
        public void Publish(object source, TEvent ev)
        {
            var handler = Event;
            if (handler != null)
            {
                handler(source, ev);
            }
        }
    }
}
