namespace IntusProject.Client.StateService
{
    public class StateContainerService
    {
        /// <summary>
        /// The State property with initial value
        /// </summary>
        public Dictionary <string, object> Value { get; set; } = new Dictionary<string, object>();
        public Dictionary <string, bool> State { get; set; } = new Dictionary<string, bool>();
        /// <summary>
        /// The event that will be raised for state changed
        /// </summary>
        public event Action OnStateChange;

        /// <summary>
        /// The property to know if state changed or not
        /// </summary>
        public bool StateChanged { get; set; } = false;

        /// <summary>
        /// The method that will be accessed by the sender component 
        /// to update the state
        /// </summary>
        public void SetValue(string pageName, object stateData)
        {
            if (Value.ContainsKey(pageName))
                Value[pageName] = stateData;
            else
                Value.Add(pageName, stateData);
            NotifyStateChanged();
        }

        /// <summary>
        /// The method that will be accessed by the sender component 
        /// to Fetch the state
        /// </summary>
        public object GetValue(string pageName)
        {
            object data = null;
            if (Value.ContainsKey(pageName))
                data = Value[pageName];
            NotifyStateChanged();
            return data;
        }
        public bool GetPageState(string pageName)
        {
            bool data = false;
            if (State.ContainsKey(pageName))
                data = State[pageName];
            NotifyStateChanged();
            return data;
        }
        public void SetPageState(string pageName, bool state)
        {
            if (State.ContainsKey(pageName))
                State[pageName] = state;
            else
                State.Add(pageName, state);
            NotifyStateChanged();
        }
        /// <summary>
        /// The state change event notification
        /// </summary>
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
