namespace IntusProject.Client.StateService
{
    public class StateContainerService
    {
        /// <summary>
        /// The State property with initial value
        /// </summary>
        public Dictionary <string, object> Value { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// The event that will be raised for state changed
        /// </summary>
        public event Action OnStateChange;

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

        /// <summary>
        /// The state change event notification
        /// </summary>
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
